@echo off
powershell.exe -NoProfile -ExecutionPolicy unrestricted -Command "& { .\create_release.ps1 %*; if ($lastexitcode -ne 0) {write-host "ERROR: $lastexitcode" -fore RED; exit $lastexitcode} }" 
pause