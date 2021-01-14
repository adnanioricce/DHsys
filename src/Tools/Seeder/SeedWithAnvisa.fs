namespace Seeder

module SeedWithAnvisa =
    open System
    open System.IO
    open DAL.DbContexts
    open Core.Entities.Catalog
    open Deedle
    open FSharp.Data
    open System.Threading.Tasks
    let readCsvFile file = Frame.ReadCsv file    
    let importCsvToDatabase options =
        let connStr = options |> Seq.find (fun opt -> opt = "--connectionString")
        let outputDir = options |> Seq.find (fun opt -> opt = "--output-dir")
        let downloadDataFiles outputDir =
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
            
        let importProductData (conn:string) (csvFile:string) =
            let templateMap (row:ObjectSeries<string>) =                
                let template = ProductTemplate()
                template.RegistryCode <- string (row.Item "NUMERO_REGISTRO_CADASTRO")
                template.Name <- string (row.Item "NOME_TECNICO")
                template.RiskClass <- match string (row.Item "CLASSE_RISCO") with
                                      | "I" -> RiskClass.I
                                      | "II" -> RiskClass.II
                                      | "III" -> RiskClass.III
                                      | "IV" -> RiskClass.IV
                template.CommercialName <- string (row.Item "NOME_COMMERCIAL")
                template.OwnerOfRegistry <- string (row.Item "DETENTOR_REGISTRO_CADASTRO")
                template.ManufacturerName <- string (row.Item "NOME_FABRICANTE")
                template.ManufacturerCountry <- string (row.Item "NOME_PAIS_FABRIC")
                template.MedicalProductModel <- string (row.Item "DS_MODELO_PRODUTO_MEDICO")
                template.RegistryPublicationDate <- DateTime.Parse (string (row.Item "DT_PUB_REGISTRO_CADASTRO"))
                template.RegistryValidity <- string (row.Item "VALIDADE_REGISTRO_CADASTRO")
                template.DateOfRegistryUpdate <- DateTimeOffset.Parse(string (row.Item "DT_ATUALIZACAO_DADO"))
                template            
            async {
                let csv = readCsvFile csvFile
                let mappedValues = csv.Rows |> Series.mapValues templateMap
                let products = mappedValues |> Series.mapValues (fun k -> k.CreateProduct())
                let factory = DHsysContextFactory()
                let context = factory.CreateContext(conn)
                context.AddRange(mappedValues.Values)
                let templateSaveResult = context.SaveChanges
                context.AddRange(products)
                let productSaveResult = context.SaveChanges()
                return (templateSaveResult , productSaveResult)
            }
        let importProductData (dir:string) (connStr:string) =
            downloadDataFiles dir |> ignore
            let files = Directory.GetFiles(dir)
            let jobs = files |> Seq.map (fun f -> importProductData connStr f)
            jobs |> Async.Parallel
                 |> Async.RunSynchronously

        if not (Directory.Exists(outputDir)) then
            let targetDir = Directory.CreateDirectory("ProductSeed")            
            importProductData targetDir.Name connStr
        else importProductData outputDir connStr
    