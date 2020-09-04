#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.String
nuget Fake.Core.Process
nuget Fake.AppVeyor //"
#load ".fake/build.fsx/intellisense.fsx"
open Fake
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.FileSystemOperators
open Fake.IO.Globbing.Operators
open Fake.Core.TargetOperators
open System
open System.IO
let buildDir = "../build/"
let packagesDir = buildDir + "Packages"
let testDir = "./tests/"
let sourceDir = "./src/"
let buildDockerImage param =
  // System.Console.WriteLine(param.ToString())
  (CreateProcess.fromRawCommand "./build_docker_images.cmd" [])  
  |> Proc.run
  |> ignore
  
Target.initEnvironment ()

Target.create "CleanApp" (fun _ ->
  Trace.log "--- Cleaning App ---"
  !! "../src/**/bin"
  ++ "../src/**/obj"
  |> Shell.cleanDirs 
)
Target.create "CleanTest" (fun _ -> 
  Trace.log "--- Cleaning Tests ---"
  !! "../tests/**/bin"
  ++ "../tests/**/obj"
  |> Shell.cleanDirs
)
Target.create "CleanBuild" (fun _ -> 
  !! "../build/**/"
  |> Shell.cleanDirs
) 
Target.create "BuildLibraries" (fun _ ->  
  Trace.log "--- Building Libraries  ---"
  !! "../src/Libraries/**/*.*proj"  
  -- "../src/**/*Windows*.*proj"
  |> Seq.iter (DotNet.build id)  
)
Target.create "BuildApps" (fun _ -> 
  Trace.log "--- Building Applications ---"
  !! "../src/Presentation/**/*.csproj"
  |> (DotNet.build id)
)
Target.create "BuildTest" (fun _ ->
  Trace.log "--- Starting Tests building ---"
  !! "../src/tests/**/*.csproj"
  // |> Seq.filter String.startsWith "Web.csproj"
  // |> Trace.logItems "BuildTest-Output: "
  |> Seq.iter (DotNet.build id)
)

Target.create "RunUnitTests" (fun _ ->
  Trace.log "--- Executing Unit Tests ---"
  !! "../tests/UnitTests/**/*.csproj"
  |> Seq.iter (DotNet.test id)
)
Target.create "RunIntegrationTests" (fun _ ->
  Trace.log "--- Executing Integration Tests ---"
  !! "../tests/IntegrationTests/**/*.csproj"
  |> Seq.iter (Dotnet.test id)
)
Trace.log "--- Building Docker Image ---"
Target.create "BuildDockerImage" (fun _ ->  
  !! "../src/**/Dockerfile" 
  |> buildDockerImage
)
// Trace.log
Target.create "PublishSolution" (fun _ ->
  Trace.log "--- Publishing Applications ---"
  !! "../src/**/Api.csproj"
  !! "../src/**/Desktop.csproj"
  |> Seq.iter (DotNet.publish id)
)
Target.create "PackLibraries" (fun _ ->
  Trace.log "--- Packaging Libraries ---" 
  !! "../src/Libraries/**/*.csproj"
  |> Seq.iter (DotNet.pack id)
)
Target.create "CopyPackages" (fun _ -> 
  Trace.log "--- Copying Libraries Packages ---"
  || "../src/Libraries/**/*.nupkg"
  |> Copy packagesDir
)
Target.create "All" ignore

"CleanApp"
  ==> "CleanTest"
  ==> "CleanBuild"
  ==> "BuildLibraries"
  ==> "BuildApps"
  ==> "BuildTest"
  ==> "RunUnitTests"
  ==> "RunIntegrationTests"  
  ==> "BuildDockerImage"
  ==> "PublishSolution"
  ==> "PackLibraries"
  ==> "CopyPackages"
  ==> "All"
  // ==> "BuildApp"
  // ==> "BuildTest"
  // ==> "TestSolution"
  // ==> "PublishSolution"  
  // ==> "All"

Target.runOrDefault "All"
