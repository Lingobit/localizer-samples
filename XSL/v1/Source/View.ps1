# Windows PowerShell or PowerShell 7; no browser XSLT support is required.
param([string]$Culture = 'de', [switch]$NoOpen)
$ErrorActionPreference = 'Stop'
$transform = [System.Xml.Xsl.XslCompiledTransform]::new()
$transform.Load((Join-Path $PSScriptRoot "${Culture}/export.xsl"))
$result = Join-Path $PSScriptRoot "${Culture}/index.html"
$transform.Transform((Join-Path $PSScriptRoot "${Culture}/export.xml"), $result)
if (!$NoOpen) { Start-Process $result }
