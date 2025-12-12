Push-Location

$root = Split-Path -Parent (Get-Location)

if (-not (Test-Path -Path $root -PathType Container)) {
    Write-Error -Message "Can't enter repository root directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $root

$targets = @(
    ".vs",
    ".idea",
    "bin",
    "obj",
    "_site",
    "api"
)

$exclusions = @(
    ".git"
) | ForEach-Object {
    Join-Path -Path $root -ChildPath $_
}

Get-ChildItem -Path $root -Directory -Recurse -Force | Where-Object {
    if ($exclusions -contains $_.Parent.FullName) {
        return $false
    }

    $targets -contains $_.Name
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
