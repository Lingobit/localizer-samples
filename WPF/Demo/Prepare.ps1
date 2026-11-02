#requires -Version 5.1
[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$Target,
    [Parameter(Mandatory)][string]$Workspace,
    [string]$V1Project
)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$familyRoot=[IO.Path]::GetFullPath((Join-Path $PSScriptRoot '..'))
$manifest=Get-Content -LiteralPath (Join-Path $familyRoot 'sample.json') -Raw -Encoding utf8|ConvertFrom-Json
$variants=@($manifest.variants|Where-Object target -eq $Target)
if($variants.Count -ne 1){throw 'Select a target listed in the family README.'}
$variant=$variants[0]
if(!$V1Project){$V1Project=Join-Path $familyRoot "$Target\v1\Sample.loc"}
$V1Project=(Resolve-Path -LiteralPath $V1Project).Path
$originalRoot=Split-Path -Parent $V1Project
$Workspace=[IO.Path]::GetFullPath($Workspace)
foreach($root in @($familyRoot,$originalRoot)){
    $boundary=$root.TrimEnd([char]92)+'\'
    if($Workspace.Equals($root,[StringComparison]::OrdinalIgnoreCase) -or $Workspace.StartsWith($boundary,[StringComparison]::OrdinalIgnoreCase) -or $root.StartsWith($Workspace.TrimEnd([char]92)+'\',[StringComparison]::OrdinalIgnoreCase)){
        throw 'Choose an independent workspace outside the sample and your v1 folder.'
    }
}
if((Test-Path -LiteralPath $Workspace) -and @(Get-ChildItem -LiteralPath $Workspace -Force).Count){throw 'Workspace must be new or empty; translation work is never overwritten.'}
$originalInput=Join-Path $originalRoot ('App\'+$variant.input)
if(!(Test-Path -LiteralPath $originalInput)){throw 'The v1 project must have its matching App folder beside it.'}
$originalVersion=[Diagnostics.FileVersionInfo]::GetVersionInfo($originalInput)
if($originalVersion.ProductMajorPart -ne 1 -or $originalVersion.ProductMinorPart -ne 0){throw 'The source project must still use the v1 application.'}
if($manifest.family -ne 'MFC'){
    $options=(Get-Content -LiteralPath (Join-Path $originalRoot ('App\'+$variant.application+'.runtimeconfig.json')) -Raw|ConvertFrom-Json).runtimeOptions
    $frameworks=if($options.PSObject.Properties['frameworks']){@($options.frameworks)}else{@($options.framework)}
    if(!($frameworks|Where-Object {$_.name -eq 'Microsoft.WindowsDesktop.App' -and $_.version.StartsWith($Target.Substring(3)+'.')})){throw 'The v1 runtime target does not match Target.'}
}
$v2=Join-Path $familyRoot "$Target\v2"
$v2Version=[Diagnostics.FileVersionInfo]::GetVersionInfo((Join-Path $v2 ('App'+[IO.Path]::DirectorySeparatorChar+$variant.input)))
$expectedMajor=if($manifest.family -eq 'MFC'){1}else{2}
$expectedMinor=if($manifest.family -eq 'MFC'){1}else{0}
if($v2Version.ProductMajorPart -ne $expectedMajor -or $v2Version.ProductMinorPart -ne $expectedMinor){throw 'The sample does not contain a matching v2 application.'}
[IO.Directory]::CreateDirectory($Workspace)|Out-Null
foreach($folder in 'Source','App'){
    $source=[IO.Path]::GetFullPath((Join-Path $v2 $folder)).TrimEnd([char]92)+'\'
    foreach($file in Get-ChildItem -LiteralPath $source -Recurse -File){
        $relative=$file.FullName.Substring($source.Length)
        if($relative -match 'MfcAppDEU\.dll$'){continue}
        if($relative.Replace([char]92,[char]47) -match '(^|/)(bin|obj|de|de-DE|Localized)(/|$)'){continue}
        $destination=Join-Path $Workspace ($folder+'\'+$relative)
        [IO.Directory]::CreateDirectory((Split-Path -Parent $destination))|Out-Null
        Copy-Item -LiteralPath $file.FullName -Destination $destination
    }
}
Copy-Item -LiteralPath $V1Project -Destination (Join-Path $Workspace 'Sample.loc')
@{family=$manifest.family;target=$Target;state='v2-before-scan';sourceProjectSHA256=(Get-FileHash -LiteralPath $V1Project).Hash}|ConvertTo-Json|Set-Content -LiteralPath (Join-Path $Workspace 'workflow.json') -Encoding utf8
Write-Host "Open $Workspace\Sample.loc. Run Scan for Changes, review New/Updated/Fuzzy and Removed in Output, then translate and Create Localized. Your v1 project is unchanged."
