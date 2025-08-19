try {
    (& dotnet --version) | Out-Null
}
catch {
    exit 1
}

& dotnet nuget locals all --clear
