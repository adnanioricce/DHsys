
#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.IO.Zip 
nuget Fake.Api.GitHub
//"
#load ".fake/deployDesktop.fsx/intellisense.fsx"
open Fake.Api
open Fake.Core
open Fake.DotNet
open Fake.IO
// open Fake.IO.Zip
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators

let releaseDir = "../release/"
let zipFilename = "releases/DHsys.zip"

Target.initEnvironment ()
let targetCreateZip param = 
    Trace.log "--- Starting to zip release builds ---"
    Trace.log "--- getting files ... ---"    
    let files = System.IO.Directory.GetFiles(releaseDir, "*.msi", System.IO.SearchOption.AllDirectories)
    Trace.log "--- Done ---"
    Trace.log "--- Starting to Zip files ... ---"
    Zip.createZip releaseDir zipFilename "" 1 false files
    Trace.log "--- Done ---"    
    
Target.create "BuildMsiInstaller" (fun _ -> 
  Trace.log "--- Building Msi Installer ---"
  (CreateProcess.fromRawCommand "build_desktop_installer.cmd" []) 
  |> Proc.run
  |> ignore
)
Target.create "InstallMsi" (fun _ -> 
  Trace.log "--- Installing Msi Installer ---"
  (CreateProcess.fromRawCommand "deployDesktop.fsx" [])
  |> Proc.run 
  |> ignore
)
//TODO: Check if all files were installed
Target.create "ZipBuild" targetCreateZip
Target.create "GithubRelease" (fun _ ->
  let token =
    match Environment.environVarOrDefault "github_token" "" with
      | s when not (System.String.IsNullOrWhiteSpace s) -> s
      | _ -> failwith "please set the github_token environment variable to a github personal access token with repo access"
  let files =
    !! "../release/Desktop/*.zip"
  GitHub.createClientWithToken token
  |> GitHub.draftNewRelease "adnanioricce" "DHsys" "POS" true []
  |> GitHub.uploadFiles files
  |> GitHub.publishDraft
  |> Async.RunSynchronously
)


Target.create "All" ignore

"BuildMsiInstaller"
  ==> "ZipBuild"
  ==> "GithubRelease"
  ==> "All"

Target.runOrDefault "All"
