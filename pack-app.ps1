$app_path = "./src/Presentation/Desktop/"
C:\'Program Files (x86)'\'Windows Kits'\10\bin\10.0.17763.0\x86\makeappx pack /v /h SHA256 /d $app_path /p DHsys.msix
C:\'Program Files (x86)'\'Windows Kits'\10\bin\10.0.17763.0\x86\signtool sign /fd SHA256 /a /f $(DHsysPackCert) /p $(packSignPassword) $(Build.ArtifactStagingDirectory)/DHsys.msix