#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.IO.Zip 
nuget Fake.IO.
//"
#load ".fake/build.fsx/intellisense.fsx"
open Fake.Core
open Fake.DotNet
open Fake.IO
// open Fake.IO.Zip
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let buildDir = "../builds/"
let zipFilename = "releases/eShop.zip"
// let vault = Vault.fromFakeEnvironmentOrNone()
Target.initEnvironment ()
// let getSecrets 
let targetTryToLoginDocker param = 
    Trace.log "--- Try to login in docker ---"
    (CreateProcess.fromRawCommand "docker" ["login"])
    |> Proc.run
    |> ignore
let targetCreateZip param = 
    Trace.log "--- Starting to zip release builds ---"
    Trace.log "--- getting files ... ---"    
    let files = System.IO.Directory.GetFiles(buildDir, "*.*", System.IO.SearchOption.AllDirectories)
    Trace.log "--- Done ---"
    Trace.log "--- Starting to Zip files ... ---"
    Zip.createZip buildDir zipFilename "" 1 false files
    Trace.log "--- Done ---"
    
let targetPushDockerImages param =
    Trace.log "--- Pushing docker images to Docker hub ---"
    (CreateProcess.fromRawCommand "./push_docker_images.cmd" [])
    |> Proc.run
    |> ignore
Target.create "ZipBuilds" targetCreateZip
Target.create "DockerLogin" targetTryToLoginDocker
Target.create "PushDockerImages" targetPushDockerImages
Target.create "All" ignore

"ZipBuilds"
  ==> "DockerLogin"
  ==> "PushDockerImages"
  ==> "All"

Target.runOrDefault "All"
