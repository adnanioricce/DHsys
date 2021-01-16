// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.IO
open Core.Entities
open Infrastructure.Helpers
open DAL.DbContexts
open Seeder.Seed
open Seeder.Helpers

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
    importCsvToDatabase [("--connectionString","User ID=postgres;Password=postgres;Host=localhost;Port=2424;Database=dhsysdb_dev;Pooling=true;")]
    let userOperation = if Seq.isEmpty argv then "" else argv |> Seq.head
    match userOperation with
    | "migrate" -> ()
    | "seed" -> ()
    | _ -> ()
    0 // return an integer exit code