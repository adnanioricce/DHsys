namespace Seeder

module Seed =
    open System
    open System.IO
    open DAL.DbContexts
    open Core.Entities.Catalog
    open Deedle
    open FSharp.Data
    open System.Globalization   
    let private downloadDataFiles outputDir =
        let sourceUrl (i:int) = sprintf "https://raw.github.com/adnanioricce/DHsysSeed/Produtos/%i.csv" i
        let download (index:int) =
            async {
                let outputPath f = sprintf "%s/%i" outputDir f
                let! request = Http.AsyncRequestStream(sourceUrl index)
                use outputFile = new FileStream(outputPath index,FileMode.Create)
                return request.ResponseStream.CopyToAsync(outputFile)
            }
        let fileCount = Directory.GetFiles(outputDir) |> Seq.length
        [0..fileCount] |> Seq.map (download)
                       |> Async.Parallel
                       |> Async.RunSynchronously        
    let private readCsvFile file = Frame.ReadCsv(file,separators=";") 
    
    let prepareData =
        let mapProdutoCsvHeaders csv =
            let headers = ["RegistryCode";
                            "Name";
                            "RiskClass";
                            "CommercialName";
                            "OwnerOfRegistry";
                            "ManufacturerName";
                            "ManufacturerCountry";
                            "MedicalProductModel";
                            "RegistryPublicationDate";
                            "RegistryValidity";
                            "DateOfRegistryUpdate"]
            csv |> Frame.indexColsWith headers
        let readPrecosCsv csv =
            let targetColumns = ["APRESENTAÇÃO";
                            "REGISTRO";
                            "PF 0%";
                            "PF 12%";
                            "PF 17%";
                            "PF 17% ALC";
                            "PF 17,5%";
                            "PF 17,5% ALC";
                            "PF 18%";
                            "PF 18% ALC";
                            "PF 20%";
                            "PMC 0%";
                            "PMC 12%";
                            "PMC 17%";
                            "PMC 17% ALC";
                            "PMC 17,5%";
                            "PMC 17,5% ALC";
                            "PMC 18%";
                            "PMC 18% ALC";
                            "PMC 20%";
                            "CAP";
                            "CONFAZ 87";
                            "ICMS 0%";]            
            csv |> Frame.sliceCols (targetColumns)                
        let productMap (row:ObjectSeries<string>) =
            let product = Product()
            // row.Print()
            product.RegistryCode <- string (row.Item "RegistryCode")
            product.Name <- string (row.Item "Name")
            product.RiskClass <- match string (row.Item "RiskClass") with
                                  | "I" -> RiskClass.I
                                  | "II" -> RiskClass.II
                                  | "III" -> RiskClass.III
                                  | "IV" -> RiskClass.IV
            product.CommercialName <- string (row.Item "CommercialName")
            product.OwnerOfRegistry <- string (row.Item "OwnerOfRegistry")
            product.ManufacturerName <- string (row.Item "ManufacturerName")
            product.ManufacturerCountry <- string (row.Item "ManufacturerCountry")
            product.MedicalProductModel <- string (row.Item "MedicalProductModel")
            product.RegistryPublicationDate <- DateTime.ParseExact (string (row.Item "RegistryPublicationDate"),"dd/MM/yyyy",CultureInfo("pt-BR",true),DateTimeStyles.AssumeLocal)
            product.RegistryValidity <- string (row.Item "RegistryValidity")
            product.DateOfRegistryUpdate <- DateTimeOffset.ParseExact(string (row.Item "DateOfRegistryUpdate"),"MM/dd/yyyy HH:mm:ss",CultureInfo("pt-BR",true),DateTimeStyles.AssumeLocal)
            product.UseRestriction <- "Unknown Restriction"
            product
        let productCsv = (Directory.GetFiles "Csvs/Produtos") |> Seq.map (fun f -> mapProdutoCsvHeaders (readCsvFile f) |> Frame.mapRowValues productMap)
                                                              |> Seq.map (fun f -> f.Values)
                                                              |> Seq.concat
        productCsv
    let importCsvToDatabase options =
        let connStr = snd (options |> Seq.find (fun opt -> (fst opt) = "--connectionString"))
        let outputDir = "Data/ProductSeed"
        let saveToCsv (productRecords:Product seq) =
            let productFrame = Frame.ofRecords productRecords
            productFrame.SaveCsv("Data/ProductSeed/product_seed.csv")
        
        let productSeedJob (chunk:Product seq) = async {
            let factory = DHsysContextFactory()
            let context = factory.CreateContext(connStr)
            for c in chunk do
                context.Add(c)
            printfn "saving %i data" (chunk |> Seq.length)
            let result = context.SaveChanges()
            printfn "%i entries saved" result
            return result
        }
        let importProductData (records:Product seq) =
            let chunkSize = int (round ((float (Seq.length(records))) * 0.25))
            records |> Seq.chunkBySize chunkSize
                    |> Seq.map productSeedJob
                    |> Async.Parallel
                    |> Async.RunSynchronously
                    // |> ignore
        // downloadDataFiles |> ignore
        let productRecords = prepareData        
        if not (Directory.Exists(outputDir)) then
            let targetDir = Directory.CreateDirectory(outputDir)
            saveToCsv productRecords
            importProductData productRecords
        else
            saveToCsv productRecords 
            importProductData productRecords
    