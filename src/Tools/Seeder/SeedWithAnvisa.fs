namespace Seeder

module SeedWithAnvisa
    open System.IO
    open DAL.DbContexts
    open Core.Entities.Catalog
    let readCsvFile file = CsvFile.Load file
    let productMap row =
        {
            RegistryCode = row.["NUMERO_REGISTRO_CADASTRO"] // RegistryCode
            Name = row.["NOME_TECNICO"] // Name
            Classification = row.["CLASSE_RISCO"] // Classification
            CommercialName = row.["NOME_COMERCIAL"] // CommercialName
            OwnerOfRegistry = row.["DETENTOR_REGISTRO_CADASTRO"] // OwnerOfRegistry
            ManufacturerName = row.["NOME_FABRICANTE"] // ManufacturerName
            ManufacturerCountry = row.["NOME_PAIS_FABRIC"] // ManufacturerCountry
            MedicalProductModel = row.["DS_MODELO_PRODUTO_MEDICO"] // MedicalProductModel
            RegistryPublicationDate = row.["DT_PUB_REGISTRO_CADASTRO"] // RegistryPublicationDate
            RegistryValidity = row.["VALIDADE_REGISTRO_CADASTRO"] // RegistryValidity
            DateOfUpdate = row.["DT_ATUALIZACAO_DADO"] // DateOfUpdate
        }
    let importCsvToDatabase options =
        let connStr = options |> Seq.find (fun opt -> opt == "--connectionString")
        let outputDir = options |> Seq.find (fun opt -> opt == "--output-dir")
        let downloadDataFiles outputDir =
            let sourceUrl i = sprintf "https://raw.github.com/adnanioricce/DHsysSeed/Produtos/%i.csv" i
            let download index =
                async {
                    let outputPath f = sprintf "%s/%s" outputDir f
                    let! request = Http.AsyncRequestStream(sourceUrl index)
                    use outputFile = FileStream(outputPath index,FileMode.Create)
                    do! request.ResponseStream.CopyToAsync(outputFile)
                }
            let fileCount= Directory.GetFiles(outputDir) |> Seq.length
            [0..fileCount] |> Seq.map download
                           |> Async.RunSynchronously
            
        let importCsv (conn:string) (csvFile:string) =
            async {
                let csv = readCsvFile csvFile
                let products = csv |> Seq.map productMap
                let factory = DHsysContextFactory()
                let context = factory.CreateContext()
                context.AddRange(products)
                return context.SaveChanges()
            }
        let importDirectory (dir:string) =
            downloadDataFiles dir
            let files = Directory.GetFiles(dir)
            let jobs = files |> Seq.map (fun f -> importCsv connStr f)
            jobs |> Async.Parallel
                 |> Async.RunSynchronously
        if !Directory.Exists(outputDir) then
            Directory.CreateDirectory("ProductSeed")
            return importDirectory "ProductSeed"
        else importDirectory outputDir
    