(*
    F# Script

    Type "dotnet fsi rule.manuale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

let rules = [
    Rule.Title                    "Confole"
    Rule.ShowCursorBlinking
    Rule.ShowCursor
    Rule.DisableDesignateMode
    Rule.DisableAlternativeBuffer
    Rule.CursorShape              (Some Rule.Shape.User)
    Rule.DefaultForegroundColor   (Some (Color.RGB (255, 255, 255)))
    Rule.DefaultBackgroundColor   (Some (Color.RGB (0, 0, 0)))
    Rule.DefaultCursorColor       (Some (Color.RGB (255, 255, 255)))
]

printf "%s" (Rule.renders rules)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

printf "%s" (Rule.renderReset ())
