param([string]$Culture = 'de', [string]$SmokePath)
$ErrorActionPreference = 'Stop'
if ($Culture -notmatch '^[a-z]{2}(-[A-Za-z]{2})?$') { throw 'Invalid culture' }
$app = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../App'))
$ts = Join-Path $PSScriptRoot "Export_${Culture}.ts"
if (!(Test-Path $ts)) { throw "Use Create Localized Files first: $ts" }
& (Join-Path $app 'lrelease.exe') $ts -qm (Join-Path $app "Export_${Culture}.qm")
if ($LASTEXITCODE) { throw 'Qt lrelease failed' }
$arguments = "--culture $Culture"
if ($SmokePath) { $arguments += ' --smoke "' + $SmokePath + '"' }
$process = [Diagnostics.Process]::Start((Join-Path $app 'QtExport.exe'), $arguments)
if ($SmokePath) {
    if (!$process.WaitForExit(30000)) { $process.Kill(); throw 'Qt smoke timed out' }
    if ($process.ExitCode) { throw "Qt application failed: $($process.ExitCode)" }
}
$process.Dispose()
