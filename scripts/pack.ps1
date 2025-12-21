param(
    [ValidateSet(
        "Confole",
        "Confole.Sharp",
        "Confole.Templates",
        "All"
    )]
    [string] $Target = "All",

    [ValidateSet(
        "Debug",
        "Release"
    )]
    [string] $Configuration = "Release",

    [string] $Output
)

try {
    (& dotnet --version) | Out-Null
}
catch {
    Write-Error -Message ".NET SDK not found!"

    exit 1
}

Push-Location

$Root = Split-Path -Parent (Get-Location)

if (-not (Test-Path -Path $Root -PathType Container)) {
    Write-Error -Message "Can't enter repository root directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $Root

switch ($Target) {
    "Confole"           { $Projects = @("./confole") }
    "Confole.Sharp"     { $Projects = @("./confole.sharp") }
    "Confole.Templates" { $Projects = @("./confole.templates")}
    "All"               { $Projects = @("./confole.slnx") }
    default             { exit 1 }
}

$Projects | ForEach-Object {
    & dotnet restore $_ --ignore-failed-sources

    & dotnet build $_ --no-restore --configuration ${Configuration}

    if ($null -ne $Output -and "" -ne $Output) {
        & dotnet pack $_ --no-build --configuration ${Configuration} --output ${Output}
    } else {
        & dotnet pack $_ --no-build --configuration ${Configuration}
    }
}

Pop-Location
