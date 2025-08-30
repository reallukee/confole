(*
    F# Script

    Type "dotnet fsi format.delayedpipeline.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Format.reset ""
