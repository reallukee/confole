(*
    F# Script

    dotnet fsi formats3.fsx
*)

// Necessary for F# Interactive
// dotnet build confole --configuration Release

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

// Necessary for F# Interactive
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

Format.configure true "Hello, World!" (fun formats ->
    formats
    |> Format.italic true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))
)

do Console.ReadKey(false)
|> ignore

Format.reset ""
