Push-Location

$Root = Split-Path -Parent (Get-Location)

if (-not (Test-Path -Path $Root -PathType Container)) {
    Write-Error -Message "Can't enter repository root directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $Root

$Targets = @(
    ".vs",
    ".idea",
    "bin",
    "obj",
    "_site",
    "api"
)

$Exclusions = @(
    ".git"
) | ForEach-Object {
    Join-Path -Path $Root -ChildPath $_
}

Get-ChildItem -Path $Root -Directory -Recurse -Force | Where-Object {
    if ($Exclusions -contains $_.Parent.FullName) {
        return $false
    }

    $Targets -contains $_.Name
} | ForEach-Object {
    try {
        Remove-Item -Path $_.FullName -Recurse -Force | Out-Null
    }
    catch {
        Write-Error -Message "Can't remove $(_.FullName)!"

        exit 1
    }
}

Pop-Location
