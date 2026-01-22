(*
    F# Script

    Type "dotnet fsi format.funzionale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

// Variante 1 -- Pipeline
Format.init ()
|> Format.italic          (Some true)
|> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
|> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))
|> Format.applyAllNewLine "Hello, World!"

// Variante 2 -- Pipeline ritardata
let formats =
    Format.init ()
    |> Format.italic          (Some true)
    |> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
    |> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))

Format.applyAllNewLine "Hello, World!" formats

// Variante 3 -- Pipeline + DSL
Format.configureNewLine "Hello, World!" (fun formats ->
    formats
    |> Format.italic          (Some true)
    |> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
    |> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))
)

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Format.reset ""
