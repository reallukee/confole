(*
    F# Script

    Type "dotnet fsi rule.funzionale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

// Variante 1 -- Pipeline
Rule.init ()
|> Rule.title                    "Confole"
|> Rule.showCursorBlinking
|> Rule.showCursor
|> Rule.disableDesignateMode
|> Rule.disableAlternativeBuffer
|> Rule.cursorShape              (Some Rule.Shape.User)
|> Rule.defaultForegroundColor   (Some (Color.RGB (255, 255, 255)))
|> Rule.defaultBackgroundColor   (Some (Color.RGB (0, 0, 0)))
|> Rule.defaultCursorColor       (Some (Color.RGB (255, 255, 255)))
|> Rule.applyAll

// Variante 2 -- Pipeline ritardata
let rules =
    Rule.init ()
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Some (Color.RGB (255, 255, 255)))
    |> Rule.defaultBackgroundColor   (Some (Color.RGB (0, 0, 0)))
    |> Rule.defaultCursorColor       (Some (Color.RGB (255, 255, 255)))

Rule.applyAll rules

// Variante 3 -- Pipeline + DSL
Rule.configure (fun rules ->
    rules
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Some (Color.RGB (255, 255, 255)))
    |> Rule.defaultBackgroundColor   (Some (Color.RGB (0, 0, 0)))
    |> Rule.defaultCursorColor       (Some (Color.RGB (255, 255, 255)))
)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
