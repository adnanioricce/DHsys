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

let releaseDir = "../release/"

let zipFilename = "releases/DHsys.zip"
Target.initEnvironment ()
let targetCreateZip param = 
    Trace.log "--- Starting to zip release builds ---"
    Trace.log "--- getting files ... ---"    
    let files = System.IO.Directory.GetFiles(releaseDir, "*.msi | *.nupkg", System.IO.SearchOption.AllDirectories)
    Trace.log "--- Done ---"
    Trace.log "--- Starting to Zip files ... ---"
    Zip.createZip releaseDir zipFilename "" 1 false files
    Trace.log "--- Done ---"    
let rec copyFiles (source: DirectoryInfo) (target: DirectoryInfo) =
    source.GetDirectories()
    |> Seq.iter (fun dir -> copyFiles dir (target.CreateSubdirectory dir.Name))
    source.GetFiles()
    |> Seq.iter (fun file -> file.CopyTo(target.FullName @@ file.Name, true) |> ignore)

Target.create "PackLibraryProjects" (fun _ ->
  let buildDir = "../build/Libraries"
  let releaseDir = "../release/Libraries/"
  Trace.log "--- Building Msi Installer ---"
  !! "src/Libraries/*.csproj"
  -- "src/*Windows*.csproj" //For now the windows projects are just for the legacy application, don't want to publish them
  |> Seq.iter (DotNet.pack id)
  |> copyFiles (directoryInfo buildDir) (directoryInfo releaseDir)
)
Target.create "BuildMsiInstaller" (fun _ -> 
  Trace.log "--- Building Msi Installer ---"
  (CreateProcess.fromRawCommand "build_desktop_installer.cmd" []) 
  |> Proc.run
  |> ignore
)
Target.create "InstallMsi" (fun _ -> 
  Trace.log "--- Installing Msi Installer ---"
  (CreateProcess.fromRawCommand "msiexec /i ""Desktop-Installer.msi"" /norestart /L*V ""package.log"" ")
  |> Proc.run 
  |> ignore
)
//TODO: Check if all files were installed
Target.create "ZipBuilds" targetCreateZip
Target.create "All" ignore

"PackLibraryProjects"  
  ==> "BuildMsiInstaller"  
  ==> "ZipBuilds"
  ==> "All"

Target.runOrDefault "All"
