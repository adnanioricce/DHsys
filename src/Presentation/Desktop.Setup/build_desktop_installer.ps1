$tools = '..\..\..\tools\wix\3.11';
# $majorVersionNumber = 1
# $midVersionNumber = 1
# $minorVersionNumber = 0
$configuration = "Release"
$platform = "x86"
$framework = "netcoreapp3.1"
$releasePath = "..\Desktop\bin\{0}\{1}\win-{2}" -f $configuration, $framework, $platform
$installerFilePath = "bin\{0}\{1}\Desktop-{2}-{3}.msi" -f $configuration, $culture, $configuration, $platform
# $buildNumber = "{0}.{1}.{2}.0" -f  $majorVersionNumber, $midVersionNumber, $minorVersionNumber
Remove-Item -Path $releasePath -Recurse -Force
dotnet publish ..\Desktop\Desktop.csproj -c $configuration -r win-$platform 
$releaseBinsPath = "{0}\publish\Desktop.dll" -f $releasePath
$buildNumber = 
 & $tools\heat.exe dir $releasePath\publish -cg PublishedComponents -dr INSTALLFOLDER -scom -sreg -srd  -gg -sfrag -out ComponentsGenerated.wxs
 & $tools\candle.exe -dBuildVersion="1.2.0.0" -dBasePath="..\Desktop\bin\Release\netcoreapp3.1\win-x86\publish" -dPlatform=x86 -dProjectDir="..\Desktop" -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -out obj\$configuration\ *.wxs
 & $tools\light.exe  -b $releasePath\publish -wixprojectfile Desktop.Setup.wixproj  -ext $tools\WixUtilExtension.dll -ext $tools\WixUIExtension.dll -loc Common.wxl obj\$configuration\ComponentsGenerated.wixobj obj\$configuration\Components.wixobj obj\$configuration\Directories.wixobj obj\$configuration\Product.wixobj -o bin\$configuration\Desktop-Installer.msi