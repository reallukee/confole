(*
    F# Script

    Type "dotnet fsi rule.array.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

[
    Rule.Title                    "Confole"
    Rule.ShowCursorBlinking
    Rule.ShowCursor
    Rule.DisableDesignateMode
    Rule.DisableAlternativeBuffer
    Rule.CursorShape              Rule.Shape.User
    Rule.DefaultForegroundColor   (Color.RGB (255, 255, 255))
    Rule.DefaultBackgroundColor   (Color.RGB (0, 0, 0))
    Rule.DefaultCursorColor       (Color.RGB (255, 255, 255))
]
|> Rule.applyAll false

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

Rule.reset ()
