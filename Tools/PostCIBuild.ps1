$bf = $Env:APPVEYOR_BUILD_FOLDER

function CodeSign
{
	param($file)
	&'C:\Program Files (x86)\Microsoft SDKs\ClickOnce\SignTool\signtool.exe' sign /f "$bf/Tools/tgstation13.org.pfx" /p "$env:snk_passphrase" /t http://timestamp.verisign.com/scripts/timstamp.dll "$file"
}

#Sign the output files
if (Test-Path env:snk_passphrase)
{
	CodeSign "$bf/DMLang.Tests/bin/Release/DMLang.Tests.dll"
	CodeSign "$bf/DMLang.Server/bin/Release/DMLang.Server.exe"
	$env:snk_passphrase = ""
}

$version = [System.Diagnostics.FileVersionInfo]::GetVersionInfo("$bf/DMLang.Server/bin/Release/DMLang.Server.exe").FileVersion
