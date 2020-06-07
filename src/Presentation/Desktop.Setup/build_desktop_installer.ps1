# #All this don't work
# function Format-String ($template) 
# {
   
  # # Set all unbound variables (@args) in the local context
    # while (($key, $val, $args) = $args) { Set-Variable $key $val }
    # $ExecutionContext.InvokeCommand.ExpandString($template)
# }
$tools = '..\..\..\tools\wix\3.11';
# $majorVersionNumber = 1
# $midVersionNumber = 1
# $minorVersionNumber = 0
# # $settings = @{
$configuration = "Release"
$platform = "x86"
$framework = "netcoreapp3.1"
# $culture = "en-us"
# # }
# # -dBuildVersion=$buildNumber  -d"DevEnvDir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\" -dSolutionDir=$solutionDir -dSolutionExt=.sln -dSolutionFileName=DHsys.sln -dSolutionName=DHsys -dSolutionPath=$solutionDir\DHsys.sln -dConfiguration=$configuration -dOutDir=bin\$configuration\ -dPlatform=$platform -dProjectDir=.\ -dProjectExt=.wixproj -dProjectFileName=Desktop.Setup.wixproj -dProjectName=Desktop.Setup -dProjectPath=Desktop.Setup.wixproj -dTargetDir=bin\$configuration\ -dTargetExt=.msi -dTargetFileName=Desktop-$configuration-$platform-.msi -dTargetName=Desktop-$configuration-$platform- -dTargetPath=bin\$configuration\Desktop-$configuration-$platform-.msi -dDesktop.Configuration=$configuration -d("Desktop.FullConfiguration=" + $configuration + "|" + $platform) -dDesktop.Platform=$platform -dDesktop.ProjectDir=..\Desktop\ -dDesktop.ProjectExt=.csproj -dDesktop.ProjectFileName=Desktop.csproj -dDesktop.ProjectName=Desktop -dDesktop.ProjectPath=..\Desktop\Desktop.csproj -dDesktop.TargetDir=..\Desktop\bin\$configuration\$framework\ -dDesktop.TargetExt=.dll -dDesktop.TargetFileName=Desktop.dll -dDesktop.TargetName=Desktop -dDesktop.TargetPath=..\Desktop\bin\$configuration\$framework\Desktop.dll -out obj\$configuration\ -arch $platform
$releasePath = "..\Desktop\bin\{0}\{1}\win-{2}" -f $configuration, $framework, $platform
$installerFilePath = "bin\{0}\{1}\Desktop-{2}-{3}.msi" -f $configuration, $culture, $configuration, $platform
# $buildNumber = "{0}.{1}.{2}.0" -f  $majorVersionNumber, $midVersionNumber, $minorVersionNumber
Remove-Item -Path $releasePath -Recurse -Force
dotnet publish ..\Desktop\Desktop.csproj -c $configuration -r win-$platform 
# $solutionDir = "..\..\..\"
# # -contentsfile obj\$configuration\Desktop.Setup.wixproj.BindContentsFileListen-us.txt -outputsfile obj\$configuration\Desktop.Setup.wixproj.BindOutputsFileListen-us.txt -builtoutputsfile obj\$configuration\Desktop.Setup.wixproj.BindBuiltOutputsFileListen-us.txt
# # -pdbout ($installerFilePath + 'pdb') -cultures:$culture
# & $tools\heat.exe dir $releasePath\publish -cg ProductComponents -dr INSTALLFOLDER -scom -sreg -srd  -gg -sfrag -out ComponentsGenerated.wxs
# & $tools\candle.exe  -ext "..\..\..\tools\wix\3.11\WixUtilExtension.dll" -ext "..\..\..\tools\wix\3.11\WixUIExtension.dll" ComponentsGenerated.wxs Components.wxs Directories.wxs Product.wxs
# & $tools\Light.exe -out $installerFilePath  -ext "..\..\..\tools\wix\3.11\WixUtilExtension.dll" -ext "..\..\..\tools\wix\3.11\WixUIExtension.dll" -loc Common.wxl  -wixprojectfile Desktop.Setup.wixproj obj\$configuration\ComponentsGenerated.wixobj obj\$configuration\Components.wixobj obj\$configuration\Directories.wixobj obj\$configuration\Product.wixobj
 & $tools\heat.exe dir $releasePath\publish -cg PublishedComponents -dr INSTALLFOLDER -scom -sreg -srd  -gg -sfrag -out ComponentsGenerated.wxs
 # -dBasePath=..\Desktop\bin\Debug\netcoreapp3.1\win-x86\publish -d"DevEnvDir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\\" -dSolutionDir=D:\GitRepo\Desktop\DHsys\ -dSolutionExt=.sln -dSolutionFileName=DHsys.sln -dSolutionName=DHsys -dSolutionPath=D:\GitRepo\Desktop\DHsys\DHsys.sln -dConfiguration=Debug -dOutDir=bin\Debug\ -dPlatform=x86 -dProjectDir=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop.Setup\ -dProjectExt=.wixproj -dProjectFileName=Desktop.Setup.wixproj -dProjectName=Desktop.Setup -dProjectPath=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop.Setup\Desktop.Setup.wixproj -dTargetDir=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop.Setup\bin\Debug\ -dTargetExt=.msi -dTargetFileName=Desktop-Debug-x86.msi -dTargetName=Desktop-Debug-x86 -dTargetPath=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop.Setup\bin\Debug\Desktop-Debug-x86.msi -dDesktop.Configuration=Debug -d"Desktop.FullConfiguration=Debug|AnyCPU" -dDesktop.Platform=AnyCPU -dDesktop.ProjectDir=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop\ -dDesktop.ProjectExt=.csproj -dDesktop.ProjectFileName=Desktop.csproj -dDesktop.ProjectName=Desktop -dDesktop.ProjectPath=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop\Desktop.csproj -dDesktop.TargetDir=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop\bin\Debug\netcoreapp3.1\ -dDesktop.TargetExt=.dll -dDesktop.TargetFileName=Desktop.dll -dDesktop.TargetName=Desktop -dDesktop.TargetPath=D:\GitRepo\Desktop\DHsys\src\Presentation\Desktop\bin\Debug\netcoreapp3.1\Desktop.dll -out obj\Debug\ -arch x86 -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\\WixUtilExtension.dll" -ext "C:\Program Files (x86)\WiX Toolset v3.11\bin\\WixUIExtension.dll" ComponentsGenerated.wxs Components.wxs Directories.wxs Product.wxs
 # -d"DevEnvDir=C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\\"
 #
 & $tools\candle.exe -dBuildVersion="1.2.0.0" -dBasePath="..\Desktop\bin\Release\netcoreapp3.1\win-x86\publish" -dPlatform=x86 -dProjectDir="..\Desktop" -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -out obj\$configuration\ *.wxs
 & $tools\light.exe  -b $releasePath\publish -wixprojectfile Desktop.Setup.wixproj  -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -loc Common.wxl obj\$configuration\ComponentsGenerated.wixobj obj\$configuration\Components.wixobj obj\$configuration\Directories.wixobj obj\$configuration\Product.wixobj -o bin\$configuration\Desktop-Installer.msi