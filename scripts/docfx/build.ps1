try {
    (& dotnet --version) | Out-Null
}
catch {
    Write-Error -Message ".NET SDK not found!"

    exit 1
}

(& dotnet tool update -g docfx) | Out-Null

Push-Location

$Root = Join-Path -Path (Split-Path -Parent (Split-Path -Parent (Get-Location))) -ChildPath "docfx"

if (-not (Test-Path -Path $Root -PathType Container)) {
    Write-Error -Message "Can't enter repository docfx directory!"

    Pop-Location

    exit 1
}

Set-Location -Path $Root

& docfx build docfx.json

Pop-Location
