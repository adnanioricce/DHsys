#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.DotNet.NuGet
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.String
nuget Fake.Core.Process
nuget Fake.IO.Zip
nuget Fake.Api.GitHub
nuget Fake.DotNet.AssemblyInfoFile
nuget Fake.Tools.Git
//"
open Fake
open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open Fake.Api
open System
open System.IO
let buildDir = __SOURCE_DIRECTORY__ + "/build"
let apiDir = buildDir + "/Api"
let toolsDir = buildDir + "/Tools"
let librariesPackagesPath = buildDir + "/Libraries"
let getEnvVar name =
  match Environment.environVar name with
    | s when (not (System.String.IsNullOrWhiteSpace s)) -> s
    | s when (not (System.String.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable(name,EnvironmentVariableTarget.User)))) 
      -> Environment.GetEnvironmentVariable(name,EnvironmentVariableTarget.User)    
    | _ -> failwith (sprintf "set the %s environment var to create a github release" name)

Target.initEnvironment ()

Target.create "CleanSolution" (fun _ ->      
  Trace.log "--- Cleaning Solution ---"  
  !! "src/**/bin"
  ++ "src/**/obj"
  ++ (__SOURCE_DIRECTORY__ + ".fake")  
  |> Shell.cleanDirs  
)
Target.create "CleanBuild" (fun _ ->
  Trace.log "--- Clean Previous Builds ---"
  !! "build/"
  |> Shell.cleanDirs
)
Target.create "PackLibraries" (fun _ ->
  Trace.log "--- Pack Library Projects ---"
  !! "src/Libraries/**/*.csproj"
  |> Seq.iter (DotNet.pack id))

Target.create "PublishWebApi" (fun _ ->
  Trace.log "--- Publishing Web Api ---"
  !! "src/Presentation/**/*.*proj"
  |> Seq.iter (DotNet.publish id))

Target.create "UploadNugetPacks" (fun _ ->
  
  let setNugetPushParams (defaults:NuGet.NuGetPushParams) =
    {
      defaults with
        ApiKey = Some (getEnvVar "DHSYS_NUGET_KEY")
        Source = Some "https://api.nuget.org/v3/index.json"
    }
  let setParams (defaults:DotNet.NuGetPushOptions) =
    {
      defaults with
        PushParams = setNugetPushParams defaults.PushParams
    }
  Trace.log "--- Uploading Packages ---"
  let packagesPaths = Directory.GetFiles(librariesPackagesPath)
  packagesPaths |> Seq.iter (DotNet.nugetPush setParams)
)
Target.create "ZipAllBinaries" (fun _ -> 
  Trace.log "--- Zipping All Binaries ---"
  let apiAssemblyName = System.Reflection.Assembly.LoadFrom(apiDir + "/Api.dll").GetName()  
  let apiZipFileName = sprintf "build/%s-%s.zip" apiAssemblyName.Name (apiAssemblyName.Version.ToString())
  // let helperZipFileName = sprintf "build/%s-%s.zip" "Helper" (apiAssemblyName.Version.ToString())  
  Zip.createZip apiDir apiZipFileName "" (int Compression.CompressionLevel.Optimal) true (Directory.GetFiles(apiDir))
  // Zip.createZip toolsDir helperZipFileName "" (int Compression.CompressionLevel.Optimal) true (Directory.GetFiles(toolsDir + "/Helper"))
  )
Target.create "UploadToGithub" (fun _ ->
  Trace.log "--- Uploading Published Projects To GitHub ---"
  let token = getEnvVar "GITHUB_TOKEN"
  let owner = "adnanioricce"
  let repoName = "DHsys"  
  let filesToUpload = Directory.GetFiles(buildDir,"*",SearchOption.AllDirectories)
                      |> Seq.where (fun f -> f.EndsWith(".zip") || f.EndsWith(".nupkg"))                      
  filesToUpload |> Seq.iter (fun f -> Trace.log (sprintf "file:%s" f))
  GitHub.createClientWithToken token
    |> GitHub.draftNewRelease owner repoName "DHsys" false [""]
    |> GitHub.uploadFiles (filesToUpload)
    |> GitHub.publishDraft
    |> Async.RunSynchronously
  ()
)
//TODO: Write code to generate build number of development and master builds
  

Target.create "All" ignore

"CleanSolution"
  ==> "CleanBuild"
  ==> "PackLibraries"
  ==> "PublishHelperTool"
  ==> "PublishWebApi"
  ==> "UploadNugetPacks"
  ==> "ZipAllBinaries"
  ==> "UploadToGithub"
  ==> "All"

Target.runOrDefault "All"
