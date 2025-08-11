(*
    F# Script

    Type "dotnet fsi format.array.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

[
    Format.Italic          true
    Format.ForegroundColor (Color.RGB (255, 0, 0))
    Format.BackgroundColor (Color.RGB (0, 0, 255))
]
|> Format.applyAll true "Hello, World!"

do Console.ReadKey(true)
|> ignore

Format.reset ""
