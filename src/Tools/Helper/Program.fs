// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
open Seeder.Seed
open Seeder.Helpers

[<EntryPoint>]
let main argv =
    let operations = [operation "migrate";operation "add_migration";operation "remove_migration";operation "seed";]    
    let helpMessage = @"operations:            
            seed - run seed script on given npgsql connection string
                parameters:
                    --connectionString -> connection string of the database to seed. OBS: tables must be already defined on database
        "
    let printHelpMessage = printfn "%s" helpMessage

    let userOperation = if Seq.isEmpty argv then 
                           printHelpMessage 
                           "" 
                        else 
                            argv |> Seq.head
    match userOperation with
    | "migrate" -> ()
    | "seed" -> 
            if argv.[1].StartsWith("--") then
                importCsvToDatabase ([argv.[1],argv.[2]])
                ()
            importCsvToDatabase (["--connectionString",argv.[1]])
    | _ -> ()
    0 // return an integer exit code