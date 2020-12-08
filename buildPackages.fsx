#r "paket:
nuget Fake.DotNet.Cli
nuget Fake.DotNet.NuGet
nuget Fake.IO.FileSystem
nuget Fake.Core.Target
nuget Fake.Core.String
nuget Fake.Core.Process //"
// #load ".fake/buildpackages.fsx/intellisense.fsx"
open Fake
open Fake.Core
open Fake.DotNet
open Fake.DotNet.NuGet
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
  !! "build/Libraries/"
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
Target.create "PackLibraries" (fun _ ->
  Trace.log "--- Packaging Lib Projects ---"
  !! "src/Libraries/**/*.csproj"
  -- "src/Libraries/**/*.Windows.csproj"
  |> Seq.iter (DotNet.pack id)
)
Target.create "UploadPackages" (fun _ ->
  let setNugetPushParams (defaults:NuGet.NuGetPushParams) =
        { defaults with
            // DisableBuffering = true
            ApiKey = Some (Environment.environVarOrDefault "dhsys-nuget-key" "")
            Source = Some "https://api.nuget.org/v3/index.json"
         }   
  let setParams (defaults:DotNet.NuGetPushOptions) =
        { defaults with
            PushParams = setNugetPushParams defaults.PushParams
         }
  Trace.log "--- Uploading Packages ---"
  let packagesPath = Directory.GetFiles ("build\\Libraries")
  packagesPath |> Seq.iter (fun path -> DotNet.nugetPush setParams path)
        
  )
  

Target.create "All" ignore

"CleanSolution"
  ==> "CleanTest"
  ==> "CleanBuild"
  ==> "BuildLibraries"  
  ==> "RunUnitTests"
  ==> "PackLibraries"
  ==> "UploadPackages"
  ==> "All"  

Target.runOrDefault "All"
