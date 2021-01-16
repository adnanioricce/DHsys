namespace Seeder

module Seed =
    open System
    open System.IO
    open System.Text
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
    
    // let importProductData files =        
        
        
    let importCsvToDatabase options =        
        let readLine line headers =
            try
                let content = String.concat "" [headers;line]
                let csvLine = Frame.ReadCsv(new MemoryStream(Encoding.UTF8.GetBytes(content)),separators=";")                
                Some (csvLine.FillMissing(Direction.Forward))
            with
                | :? System.IndexOutOfRangeException as ex -> printfn "index out of range exception on line: \n%s" line; None
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
        let productMap (row:ObjectSeries<string>) =
            let product = Product()            
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
        let productSeedJob (chunk:Product seq) connString = async {
            printfn "importing %i entries to database" (Seq.length chunk)
            let factory = DHsysContextFactory()
            let context = factory.CreateContext(connString)
            for c in chunk do
                context.Add(c)
            printfn "saving %i data" (chunk |> Seq.length)
            let result = context.SaveChanges()
            printfn "%i entries saved" result
            return result
        }
        let importProductData (records:Product seq) connString =
            let chunkSize = int (round ((float (Seq.length(records))) * 0.25))
            records |> Seq.chunkBySize chunkSize
                    |> Seq.map (fun p -> productSeedJob p connString)
                    |> Async.Parallel
                    |> Async.Ignore
                    |> Async.RunSynchronously
                    |> ignore
        
        let importJob file connString = async {
            let! lines = (File.ReadAllLinesAsync file) |> Async.AwaitTask
            printfn "lines of %s loaded, starting to read line by line" file
            let headers = lines |> Seq.head
            let data = lines.[1..] |> Seq.map (readLine headers) 
                                   |> Seq.filter (fun f -> f.IsSome)
                                   |> Seq.map (fun f -> f.Value)
                                   |> Seq.reduce (Frame.merge)
            
            printfn "lines of file %s loaded,filtering all invalid rows" file
            return data 
                        |> Frame.mapRowValues (fun f -> productMap f)
                        |> (fun f -> importProductData f.Values connString)
            }
        let stopwatch = new Diagnostics.Stopwatch()
        stopwatch.Start()
        let connStr = snd (options |> Seq.find (fun opt -> (fst opt) = "--connectionString"))        
        printfn "preparing data..."
        let jobs = Directory.GetFiles("Csvs/Produtos") |> Seq.map (fun f -> importJob f connStr)
        printfn "jobs defined, started to import"
        jobs |> Async.Parallel
             |> Async.Ignore
             |> Async.RunSynchronously
             |> ignore             
        stopwatch.Stop()
        printfn "elapsed time to seed %O" stopwatch.Elapsed