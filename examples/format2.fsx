(*
    F# Script

    dotnet fsi format2.fsx
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

Format.init ()
|> Format.italic true
|> Format.foregroundColor (Color.RGB (255, 0, 0))
|> Format.backgroundColor (Color.RGB (0, 0, 255))
|> Format.applyAll true "Hello, World!"

do Console.ReadKey(true)
|> ignore

Format.reset ""
