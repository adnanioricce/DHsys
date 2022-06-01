//TODO:
module Auth =
    let baseEndpoint = ""
    let register post log model =
        // send model to api
        (post (sprintf "%s/%s" baseEndpoint "") model)
        |> Result.bind (fun u -> )
    let authenticate post log model =        
        (post (sprintf "%s/%s" baseEndpoint "auth")  model)
        |> Result.mapError (fun e -> log "failed to authenticate user")
        |> Result.bind (fun u -> log "user was authenticated with success! ")
        