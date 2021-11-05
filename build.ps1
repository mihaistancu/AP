﻿$OutputPath = "$PSScriptRoot\artifacts"

function Clean-Output {
	Remove-Item $OutputPath -Recurse
}

function Build-Solution {
	msbuild AP.sln /p:Configuration=Debug /p:OutputPath=$OutputPath
}

function Build-Portal {
	Set-Location AP.Portal

	ng build --output-path $OutputPath\portal

	Set-Location $PSScriptRoot
}

Clean-Output
Build-Solution
Build-Portal