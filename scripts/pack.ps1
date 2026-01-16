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

    [switch] $Experimental
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

    $dotnetArgs = @(
        "--no-restore",
        "--configuration",
        $Configuration
    )

    if ($Experimental.IsPresent) {
        $dotnetArgs += @(
            "/p:DefineConstants=EXPERIMENTAL"
        )
    }

    & dotnet build $_ @dotnetArgs

    & dotnet pack $_ --configuration ${Configuration}
}

Pop-Location
