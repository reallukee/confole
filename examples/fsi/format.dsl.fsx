(*
    F# Script

    Type "dotnet fsi format.dsl.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

Format.builder {
    Format.italic          (Some true)
    Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
    Format.backgroundColor (Some (Color.RGB (0, 0, 255)))
}
|> Format.applyAllNewLine "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Format.reset ""
