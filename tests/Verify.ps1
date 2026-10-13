$ErrorActionPreference = 'Stop'
$projectRoot = Split-Path $PSScriptRoot -Parent
$compiler = Join-Path $env:WINDIR 'Microsoft.NET\Framework64\v4.0.30319\csc.exe'
$assembly = Join-Path $projectRoot 'CSLab06\bin\Release\CSLab06.exe'
if (!(Test-Path -LiteralPath $assembly)) { throw 'Build Release in Visual Studio before running tests.' }
$testDir = Join-Path $projectRoot 'TestResults'
New-Item -ItemType Directory -Path $testDir -Force | Out-Null
$testExe = Join-Path $testDir 'Verify.exe'
& $compiler /nologo /target:exe /out:$testExe /reference:$assembly /reference:System.Windows.Forms.dll /reference:System.Drawing.dll (Join-Path $PSScriptRoot 'Verify.cs')
if ($LASTEXITCODE -ne 0) { throw 'Test compilation failed.' }
Copy-Item -LiteralPath $assembly -Destination (Join-Path $testDir 'CSLab06.exe') -Force
Push-Location $projectRoot
try {
    & $testExe | Tee-Object -FilePath (Join-Path $testDir 'results.txt')
    if ($LASTEXITCODE -ne 0) { throw 'Regression tests failed.' }
} finally { Pop-Location }
