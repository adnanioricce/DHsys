namespace Seeder

module Helpers =
    open DAL.DbContexts
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