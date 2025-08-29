try {
    (& dotnet --version) | Out-Null
}
catch {
    Write-Error -Message ".NET SDK not found!"

    exit 1
}

Push-Location

$root = Join-Path -Path (Split-Path -Parent (Get-Location)) -ChildPath "examples"

if (-not (Test-Path -Path $root -PathType Container)) {
    Write-Error -Message "Can't enter repository examples directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $root

& dotnet nuget locals all --clear

$env:CI = "true"

Get-ChildItem -Filter *.fsx | ForEach-Object {
    & dotnet fsi $_.FullName
}

Pop-Location
