param(
    [ValidateSet(
        "Confole",
        "Confole.Sharp",
        "All"
    )]
    $Target = "All",

    [ValidateSet(
        "Debug",
        "Release"
    )]
    $Configuration = "Release",

    $Output = "bin"
)

try {
    (& dotnet --version) | Out-Null
}
catch {
    Write-Error -Message ".NET SDK not found!"

    exit 1
}

Push-Location

$root = Split-Path -Parent (Get-Location)

if (-not (Test-Path -Path $root -PathType Container)) {
    Write-Error -Message "Can't enter repository root directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $root

switch ($Target) {
    "Confole"       { $projects = @("confole") }
    "Confole.Sharp" { $projects = @("confole.sharp") }
    "All"           { $projects = @("confole", "confole.sharp") }
    default         { exit 1 }
}

$projects | ForEach-Object {
    & dotnet restore $_ --ignore-failed-sources

    & dotnet build $_ --no-restore --configuration ${Configuration} --output ${Output}
}

Pop-Location
