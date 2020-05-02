# $kvSecretBytes = [System.Convert]::FromBase64String($(DHsysPackCert))
# $certCollection = New-Object System.Security.Cryptography.X509Certificates.X509Certificate2Collection
# $certCollection.Import($kvSecretBytes, $null, [System.Security.Cryptography.X509Certificates.X509KeyStorageFlags]::Exportable) 
$app_path = "./src/Presentation/Desktop/"
# $pfx_path = "C:\Users\adnan\DevCerts\DHsys.pfx"
"C:\Program Files (x86)\Windows Kits\10\bin\10.0.17763.0\x86\makeappx" pack /v /h SHA256 /d $app_path /p DHsys.msix
"C:\Program Files (x86)\Windows Kits\10\bin\10.0.17763.0\x86\signtool" sign /fd SHA256 /a /f $(DHsysPackCert) /p $(packSignPassword) $(Build.ArtifactStagingDirectory)/DHsys.msix