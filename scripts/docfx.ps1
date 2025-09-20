try {
    (& dotnet --version) | Out-Null
}
catch {
    Write-Error -Message ".NET SDK not found!"

    exit 1
}

(& dotnet tool update -g docfx) | Out-Null

Push-Location

$root = Join-Path -Path (Split-Path -Parent (Get-Location)) -ChildPath "docfx"

if (-not (Test-Path -Path $root -PathType Container)) {
    Write-Error -Message "Can't enter repository docfx directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $root

& docfx build docfx.json

docfx docfx.json --serve

Pop-Location
