Param(
    [switch] $SkipBuild
)

if (!$SkipBuild)
{
    & $PSScriptRoot\build.ps1
}

Start-Process "http://localhost:9090"

& $PSScriptRoot\artifacts\AP.Host.exe
