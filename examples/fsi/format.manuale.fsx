(*
    F# Script

    Type "dotnet fsi format.manuale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

let formats = [
    Format.Italic          (Some true)
    Format.ForegroundColor (Some (Color.RGB (255, 0, 0)))
    Format.BackgroundColor (Some (Color.RGB (0, 0, 255)))
]

printf "%s" (Format.renders "" formats)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

printf "%s" (Format.renderReset "")
