try {
    (& dotnet --version) | Out-Null
}
catch {
    exit 1
}

Push-Location

$root = (Split-Path -Parent (Get-Location))

if (-not (Test-Path -Path $root -PathType Container)) {
    exit 1
}

Set-Location -Path $root

$projects = @(
    "confole",
    "confole.sharp"
)

$projects | ForEach-Object {
    & dotnet restore $PSItem

    & dotnet build $PSItem --no-restore --configuration Release

    & dotnet pack $PSItem --no-build --configuration Release
}

Pop-Location
