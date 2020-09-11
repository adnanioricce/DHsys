$tools = '..\..\..\tools\wix\3.11';

$configuration = "Release"
$platform = "x86"
$framework = "netcoreapp3.1"
$releasePath = "..\..\..\release\Desktop"
$installerFilePath = "Desktop-{0}-{1}.msi" -f $configuration, $platform
$buildPath = "..\..\..\build\Desktop\bin"
dotnet publish ..\Desktop\Desktop.csproj -c $configuration -r win-$platform 
$releaseBinsPath = "..\..\..\build\Desktop\Desktop.dll" -f $releasePath
$buildNumber = 
 & $tools\heat.exe dir $buildPath -cg PublishedComponents -dr INSTALLFOLDER -scom -sreg -srd  -gg -sfrag -out ComponentsGenerated.wxs
 & $tools\candle.exe -dBuildVersion="1.2.0.0" -dBasePath="..\..\..\build\Desktop\" -dPlatform=x86 -dProjectDir="..\Desktop" -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -out obj\$configuration\ *.wxs
 & $tools\light.exe  -b $buildPath -wixprojectfile Desktop.Setup.wixproj  -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -loc Common.wxl obj\$configuration\ComponentsGenerated.wixobj obj\$configuration\Components.wixobj obj\$configuration\Directories.wixobj obj\$configuration\Product.wixobj -o $releasePath\Desktop-Installer.msi