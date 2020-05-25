#All this don't work






function Format-String ($template) 
{
   
  # Set all unbound variables (@args) in the local context
    while (($key, $val, $args) = $args) { Set-Variable $key $val }
    $ExecutionContext.InvokeCommand.ExpandString($template)
}
$tools = '..\..\..\tools\wix\3.11';
$majorVersionNumber = 1
$midVersionNumber = 1
$minorVersionNumber = 0
# $settings = @{
$configuration = "Release"
$platform = "x86"
$framework = "netcoreapp3.1"
$culture = "en-us"
# }
# -dBuildVersion=$buildNumber  -d"DevEnvDir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\" -dSolutionDir=$solutionDir -dSolutionExt=.sln -dSolutionFileName=DHsys.sln -dSolutionName=DHsys -dSolutionPath=$solutionDir\DHsys.sln -dConfiguration=$configuration -dOutDir=bin\$configuration\ -dPlatform=$platform -dProjectDir=.\ -dProjectExt=.wixproj -dProjectFileName=Desktop.Setup.wixproj -dProjectName=Desktop.Setup -dProjectPath=Desktop.Setup.wixproj -dTargetDir=bin\$configuration\ -dTargetExt=.msi -dTargetFileName=Desktop-$configuration-$platform-.msi -dTargetName=Desktop-$configuration-$platform- -dTargetPath=bin\$configuration\Desktop-$configuration-$platform-.msi -dDesktop.Configuration=$configuration -d("Desktop.FullConfiguration=" + $configuration + "|" + $platform) -dDesktop.Platform=$platform -dDesktop.ProjectDir=..\Desktop\ -dDesktop.ProjectExt=.csproj -dDesktop.ProjectFileName=Desktop.csproj -dDesktop.ProjectName=Desktop -dDesktop.ProjectPath=..\Desktop\Desktop.csproj -dDesktop.TargetDir=..\Desktop\bin\$configuration\$framework\ -dDesktop.TargetExt=.dll -dDesktop.TargetFileName=Desktop.dll -dDesktop.TargetName=Desktop -dDesktop.TargetPath=..\Desktop\bin\$configuration\$framework\Desktop.dll -out obj\$configuration\ -arch $platform
$releasePath = "..\Desktop\bin\{0}\{1}\win-{2}\publish" -f $configuration, $framework, $platform
$installerFilePath = "bin\{0}\{1}\Desktop-{2}-{3}.msi" -f $configuration, $culture, $configuration, $platform
$buildNumber = "{0}.{1}.{2}.0" -f  $majorVersionNumber, $midVersionNumber, $minorVersionNumber
Remove-Item -Path $releasePath -Recurse -Force
dotnet publish ..\Desktop\Desktop.csproj -c Release -r win-x86 
$solutionDir = "..\..\..\"
# -contentsfile obj\$configuration\Desktop.Setup.wixproj.BindContentsFileListen-us.txt -outputsfile obj\$configuration\Desktop.Setup.wixproj.BindOutputsFileListen-us.txt -builtoutputsfile obj\$configuration\Desktop.Setup.wixproj.BindBuiltOutputsFileListen-us.txt
# -pdbout ($installerFilePath + 'pdb') -cultures:$culture
& $tools\heat.exe dir $releasePath\publish -cg ProductComponents -dr INSTALLFOLDER -scom -sreg -srd  -gg -sfrag -out ComponentsGenerated.wxs
& $tools\candle.exe  -ext "..\..\..\tools\wix\3.11\WixUtilExtension.dll" -ext "..\..\..\tools\wix\3.11\WixUIExtension.dll" ComponentsGenerated.wxs Components.wxs Directories.wxs Product.wxs
& $tools\Light.exe -out $installerFilePath  -ext "..\..\..\tools\wix\3.11\WixUtilExtension.dll" -ext "..\..\..\tools\wix\3.11\WixUIExtension.dll" -loc Common.wxl  -wixprojectfile Desktop.Setup.wixproj obj\$configuration\ComponentsGenerated.wixobj obj\$configuration\Components.wixobj obj\$configuration\Directories.wixobj obj\$configuration\Product.wixobj