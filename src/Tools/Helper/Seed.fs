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
    open System.Collections.Generic
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
    [<Literal>]
    let sampleCsvPath = __SOURCE_DIRECTORY__ + "/Csvs/Produtos/32_produto_saude_modelo.csv"    
    type ProdutoCsv = CsvProvider<sampleCsvPath,IgnoreErrors=true,HasHeaders=true,Separators=";">
    let private downloadDataFiles outputDir =
        let sourceUrl (i:int) = sprintf "https://raw.github.com/adnanioricce/DHsysSeed/Produtos/%i.csv" i
        let download (index:int) =
            async {
                let outputPath f = sprintf "%s/%i" outputDir f
                let! request = Http.AsyncRequestStream(sourceUrl index)
                let outputFilePath = outputPath index
                let outputFile = File.CreateText(outputFilePath)
                let strReader = new StreamReader(request.ResponseStream,Encoding.GetEncoding("iso-8859-1"))
                let str = strReader.ReadToEnd()
                outputFile.Write(str)
                outputFile.Flush()
                outputFile.Close()
            }
        let fileCount = Directory.GetFiles(outputDir) |> Seq.length
        [0..fileCount] |> Seq.map (download)
                       |> Async.Parallel
                       |> Async.RunSynchronously

    let importCsvToDatabase options =        
        let connStr = snd (options |> Seq.find (fun opt -> (fst opt) = "--connectionString"))
        
        let mapProdutoCsvHeaders csv = csv |> Frame.indexColsWith headers        
        let productMap (row:ProdutoCsv.Row) =
            let product = Product()          
            product.RegistryCode <- string (row.NUMERO_REGISTRO_CADASTRO)
            product.Name <- (row.NOME_TECNICO)
            product.RiskClass <- match string (row.CLASSE_RISCO) with
                                  | "I" -> RiskClass.I
                                  | "II" -> RiskClass.II
                                  | "III" -> RiskClass.III
                                  | "IV" -> RiskClass.IV
            product.CommercialName <- (row.NOME_COMERCIAL)
            product.OwnerOfRegistry <- (row.DETENTOR_REGISTRO_CADASTRO)
            product.ManufacturerName <- (row.NOME_FABRICANTE)
            product.ManufacturerCountry <- (row.NOME_PAIS_FABRIC)
            product.MedicalProductModel <- (row.DS_MODELO_PRODUTO_MEDICO)
            product.RegistryPublicationDate <- row.DT_PUB_REGISTRO_CADASTRO
            product.RegistryValidity <- string row.VALIDADE_REGISTRO_CADASTRO
            product.DateOfRegistryUpdate <- DateTimeOffset(row.DT_ATUALIZACAO_DADO)
            product.UseRestriction <- "Unknown Restriction"
            product
        let readLine line headers = async {
                try
                    let content = String.concat "" [line;headers]                                        
                    let csvLine = Frame.ReadCsv(new MemoryStream(Encoding.UTF8.GetBytes(content)),hasHeaders=true,separators=";").FillMissing(Direction.Forward)
                    // csvLine.Print()
                    printfn "%i" (csvLine.RowCount)
                    // csvLine.Rows.Print()
                    let products = csvLine |> Frame.mapValues productMap
                    // productFrame.Print()                   
                    let factory = DHsysContextFactory()
                    let context = factory.CreateContext(connStr)
                    let result = Seq.sumBy (fun p -> 
                                                printfn "%O" p
                                                let entry = context.Add p                                                                                                
                                                context.SaveChanges()) (products.Rows.Values)
                    // let! result =  context.SaveChangesAsync() |> Async.AwaitTask
                    printfn "%i entries saved" result
                    ()
                with
                    | :? IndexOutOfRangeException as ex -> printfn "index out of range exception on line: \n%s" line; ()
            }
        let productSeedJob (chunk:Product seq) connString = async {
            printfn "importing %i entries to database" (Seq.length chunk)
            let factory = DHsysContextFactory()
            let context = factory.CreateContext(connString)
            context.AddRange(chunk)
            printfn "saving %i data" (chunk |> Seq.length)
            let result = context.SaveChanges()
            printfn "%i entries saved" result
            return result
        }
        let importProductData (records:Product seq) connString =
            let chunkSize = int (round ((float (Seq.length(records))) * 0.25))
            printfn "starting new import jobs for %i records" (Seq.length records)
            records |> Seq.chunkBySize chunkSize
                    |> Seq.map (fun p -> productSeedJob p connString)
                    |> Async.Parallel                    
                    |> Async.RunSynchronously
                    |> ignore
        
        let importJob file = async {            
                printfn "reading %s " file
                let! csv = ProdutoCsv.AsyncLoad file
                printfn "%s load" file
                let mappedRows = csv.Rows |> Seq.map productMap
            try
                printfn "%s mapped" file
                
                let result = mappedRows |> Seq.map (fun r -> async {
                                                    let context = (DHsysContextFactory()).CreateContext(connStr)
                                                    context.Add(r)
                                                    return context.SaveChanges()
                                                })
                                       |> Async.Parallel
                                       |> Async.RunSynchronously
                                       |> Seq.sum
                
                printfn "%i entries inserted" result
                return result
            with
                | :? Exception as ex -> printfn "Exception:%O \n" ex; return -1                       
            }
        let stopwatch = Diagnostics.Stopwatch()
        stopwatch.Start()        
        printfn "preparing data..."
        let jobs = Directory.GetFiles("Csvs/Produtos") |> Seq.map (importJob)
        printfn "jobs defined, started to import"
        jobs |> Async.Parallel
             |> Async.RunSynchronously
             |> ignore
        stopwatch.Stop()
        printfn "elapsed time to seed %O" stopwatch.Elapsed