try {
    (& dotnet --version) | Out-Null
}
catch {
    exit 1
}

Push-Location

$root = Join-Path -Path (Split-Path -Parent (Get-Location)) -ChildPath "examples"

if (-not (Test-Path -Path $root -PathType Container)) {
    exit 1
}

Set-Location -Path $root

dotnet nuget locals all --clear

$env:CI = "true"

Get-ChildItem -Filter *.fsx | ForEach-Object {
    & dotnet fsi $PSItem.FullName
}

Pop-Location
