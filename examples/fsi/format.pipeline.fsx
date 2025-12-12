(*
    F# Script

    Type "dotnet fsi format.pipeline.fsx" to run!

    Necessary for F# Interactive:

        dotnet build confole --configuration Release
        dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.1.0"

open System

open Reallukee.Confole

Format.init ()
|> Format.italic          true
|> Format.foregroundColor (Color.RGB (255, 0, 0))
|> Format.backgroundColor (Color.RGB (0, 0, 255))
|> Format.applyAllNewLine "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Format.reset ""
