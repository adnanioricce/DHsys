[xml]$manifestFile = Get-Content src/Presentation/Desktop/AppxManifest.xml
$manifestFile.Package.Applications.Application.Executable = "Desktop.msix"
echo $manifestFile.Package.Applications.Application.Executable
$manifestFile.Save("./temp.xml")
#foreach($node in $manifestFile.Applications.FirstChild){
#	Write-Host $node.Attributes
#}