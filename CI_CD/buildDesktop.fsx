#r "paket:
nuget Fake.IO.FileSystem
nuget Fake.DotNet.Cli
nuget Fake.Core.Target
nuget Fake.Core.Process
nuget Fake.Core.String //
"
#load ".fake/builddesktop.fsx/intellisense.fsx"
open Fake
open Fake.Core
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.Core.TargetOperators
let buildDir = "../build/"

Target.create "CleanApp" (fun _ ->
  Trace.log "--- Cleaning App ---"
  !! "../src/**/bin"
  ++ "../src/**/obj"
  ++ "../build"
  |> Shell.cleanDirs 
)
Target.create "CleanTest" (fun _ -> 
  Trace.log "--- Cleaning Tests ---"
  !! "../tests/**/bin"
  ++ "../tests/**/obj"
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
  !! "../src/**/Api.csproj"
  |> Seq.iter (DotNet.build id)
)
Target.create "BuildTest" (fun _ ->
  Trace.log "--- Starting Tests building ---"
  !! "../src/tests/**/*.csproj"
  -- "../src/tests/**/*Desktop*.csproj"  
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
  -- "../tests/**/*Api*.csproj"
  |> Seq.iter (DotNet.test id)
)
Target.create "PublishDesktopApp" (fun _ ->
  Trace.log "--- Publishing Desktop App ---"
  !! "../src/**/Desktop.csproj"  
  |> Seq.iter (DotNet.publish id)
)

Target.create "All" ignore

"CleanApp"
  ==> "CleanTest"  
  ==> "BuildLibraries"
  ==> "BuildApps"
  ==> "BuildTest"
  ==> "RunUnitTests"
  ==> "RunIntegrationTests"    
  ==> "PublishDesktopApp"    
  ==> "All"  

Target.runOrDefault "All"