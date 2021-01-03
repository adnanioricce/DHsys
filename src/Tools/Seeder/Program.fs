// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open Core.Entities
open Infrastructure.Helpers
open DAL.DbContexts
open Seeder.SeedWithAnvisa
type Operation = {
    Name: string
    Options: string seq
    Action: string seq -> int
}
let operation name options action = { Name = name;Options = options;Action = action}
type DataSource = {
    Path:string
    Type:string
}
let dataSource (source:string) = 
    let isHttp = source.[0..5] = "http"        
    let fileType = source.[source.LastIndexOf(".")..]
    match fileType.ToLower() with
    | ".json" -> { Path = source;Type = fileType}
    | "/"
    | _ -> failwith "the given source file is of a type not supported"
let createContext connectionString = 
    let factory = DHsysContextFactory()
    factory.CreateContext connectionString
let seed (options:string seq) =
    let definedOptions = [("-s","--source");("-d","--directory");("-u","--url");("-c","--connectionString")]
    let userOptions = options |> Seq.filter (fun option -> definedOptions |> Seq.exists (fun opt -> (fst opt) = option || (snd opt) = option))
    let dataFiles = (userOptions |> Seq.filter (fun opt -> opt = "--source" || opt = "-s")) |> Seq.map dataSource
    let connectionString = userOptions |> Seq.find (fun opt -> opt = "--connectionString" || opt = "-c")
    let chunkFile fileData =
        let chunkJob (id:int) (chunk:BaseEntity seq) (connStr:string) =
            async {
                printfn "seed task %i with %i elements starting" id (chunk |> Seq.length)
                let context = createContext connStr
                context.AddRange(chunk)
                return context.SaveChanges()
            }        
        fileData |> Seq.mapi (fun i chunk -> chunkJob i chunk connectionString) 
                 |> Seq.chunkBySize 8
                 |> Seq.toList
    let seedChunk chunkJob =
        chunkJob |> List.map (fun job -> job |> Async.Parallel
                                             |> Async.RunSynchronously)
            
    let chunkJobs = Seq.map ((fun d -> DataReaders.GetDataChunked d.Path) >> chunkFile) dataFiles
    let result = 
        chunkJobs |> Seq.map (fun _chunkJob -> 
            let half = ((_chunkJob |> Seq.length) / 2);
            let first = _chunkJob.[0..half]        
            let second = _chunkJob.[half..]
            [first;second] |> Seq.map seedChunk)
    0
    // dataFiles |> Seq.map

[<EntryPoint>]
let main argv =
    let operations = [operation "migrate";operation "add_migration";operation "remove_migration";operation "seed";]    
    let helpMessage = @"operations:
            migrate - run remaining database migrations for given npgsql connection string
            add_migration - Add a new migration for the Desktop and Api Projects
                parameters:                    
                    --migrationName -> the name of the migration
            remove_migration - removes a migration from the Desktop and Api projects 
            seed - run seed script on given npgsql connection string
        "        
    printfn "%s" helpMessage
    let userOperation = argv |> Seq.head 
    match userOperation with
    | "migrate" -> ""
    | _ -> ""
    0 // return an integer exit code