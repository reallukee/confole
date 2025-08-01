(*
    F# Script

    dotnet fsi rule5.fsx
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

[
    Rule.Title                    "Confole"
    Rule.ShowCursorBlinking
    Rule.ShowCursor
    Rule.DisableDesignateMode
    Rule.DisableAlternativeBuffer
    Rule.DefaultForegroundColor   (Color.RGB (255, 255, 255))
    Rule.DefaultBackgroundColor   (Color.RGB (0, 0, 0))
    Rule.DefaultCursorColor       (Color.RGB (255, 255, 255))
]
|> Rule.applyAll false

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

Rule.reset ()
