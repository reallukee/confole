(*
    F# Script

    Type "dotnet fsi rule.delayedpipeline.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.1.0"

open System

open Reallukee.Confole

let rules =
    Rule.init ()
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))

Rule.applyAll rules

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
