#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.String
nuget Fake.Core.Process //"
// #load ".fake/buildpackages.fsx/intellisense.fsx"
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

Target.create "CleanSolution" (fun _ ->
  Trace.log "--- Cleaning Solution ---"
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
Target.create "BuildLibraries" (fun _ ->  
  Trace.log "--- Building Libraries  ---"
  !! "src/Libraries/**/*.*proj"  
  -- "src/**/*Windows*.*proj"
  |> Seq.iter (DotNet.build id)
)

Target.create "RunUnitTests" (fun _ ->
  Trace.log "--- Executing Unit Tests ---"
  !! "tests/UnitTests/**/*.csproj"
  -- "tests/UnitTests/Desktop.Tests/Desktop.Tests.csproj"
  |> Seq.iter (DotNet.test id)
)
Target.create "All" ignore

"CleanSolution"
  ==> "CleanTest"
  ==> "CleanBuild"
  ==> "BuildLibraries"  
  ==> "RunUnitTests"  
  ==> "All"  

Target.runOrDefault "All"
