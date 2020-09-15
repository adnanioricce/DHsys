#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.String
nuget Fake.Core.Process //"
// #load "./CI_CD/.fake/buildapi.fsx/intellisense.fsx"
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
let testDir = "./tests/"
let sourceDir = "./src/"
//Change
Target.initEnvironment ()

Target.create "CleanApp" (fun _ ->
  Trace.log "--- Cleaning App ---"
  !! "src/**/bin"
  ++ "src/**/obj"
  |> Shell.cleanDirs 
)
Target.create "CleanTest" (fun _ -> 
  Trace.log "--- Cleaning Tests ---"
  !! "tests/**/bin"
  ++ "tests/**/obj"
  |> Shell.cleanDirs
)
Target.create "CleanBuild" (fun _ -> 
  !! "build/**/"
  |> Shell.cleanDirs
) 
Target.create "BuildApps" (fun _ -> 
  Trace.log "--- Building Applications ---"
  !! "src/**/Api.csproj"
  |> Seq.iter (DotNet.build id)
)
Target.create "RunUnitTests" (fun _ ->
  Trace.log "--- Executing Unit Tests ---"
  !! "tests/UnitTests/**/*.csproj"
  -- "tests/UnitTests/**/*Desktop*.csproj"
  -- "tests/UnitTests/**/*Windows*.csproj"
  |> Seq.iter (DotNet.test id)
)
Target.create "PublishApi" (fun _ ->
  Trace.log "--- Publishing Api ---"
  !! "src/**/Api.csproj"  
  |> Seq.iter (DotNet.publish id)
)

Target.create "All" ignore

"CleanApp"
  ==> "CleanTest"
  ==> "CleanBuild"  
  ==> "BuildApps"  
  ==> "RunUnitTests"  
  ==> "PublishApi"  
  ==> "All"  

Target.runOrDefault "All"
