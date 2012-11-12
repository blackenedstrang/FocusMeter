$msbuildExe = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe"
$zipExe = "..\..\tools\7za.exe"
$publishDir = ".\publish\"
$packageFile = $publishDir+'ClickOncePackage.zip'

# Cleanup
rd "$publishDir" -recurse -force -ErrorAction SilentlyContinue | out-null
mkdir "$publishDir" -ErrorAction SilentlyContinue | out-null

# Publish
$version = 19
& $msbuildExe /target:publish /p:Configuration=Release /p:PublishDir="$publishDir" /property:ApplicationRevision=$version
if ($lastexitcode -ne 0) { throw }

# Zip
& $zipExe a -r -tzip "$packageFile" "$publishDir*" | Out-Null
if ($lastexitcode -ne 0) { throw }

# Create release on CodePlex
# https://www.codeplex.com/Services/ReleaseService.asmx
$service = New-WebServiceProxy -Uri "https://www.codeplex.com/Services/ReleaseService.asmx" -Namespace CodePlex
$service.Timeout = 300000; #increase default timeout at least in 3 times
$releaseName="Release $version"
Write-Host -ForegroundColor Green "$releaseName"
$releaseDate = Get-Date
$packageFile = [System.IO.File]::ReadAllBytes("$packageFile")
[xml]$xmlContent = Get-Content '.\CodePlex.xml'
$settings = $xmlContent.settings
$username = $settings.username
$password = $settings.password
$releaseID = $service.CreateClickOnceRelease("FocusMeter",$releaseName,$releaseName,$releaseDate,"Stable","true","",
 $packageFile,$username,$password)
if ($lastexitcode -ne 0) { throw }
Write-Host -ForegroundColor Green "`n$releaseName release created with release ID: $releaseID"

