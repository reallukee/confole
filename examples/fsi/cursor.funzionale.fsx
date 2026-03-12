(*
    F# Script

    Type "dotnet fsi cursor.funzionale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

// Variante 1 -- Pipeline
Cursor.init ()
|> Cursor.move (Some (Position.RowCol (2, 4)))
|> Cursor.applyAll

// Variante 2 -- Pipeline ritardata
let cursors =
    Cursor.init ()
    |> Cursor.move (Some (Position.RowCol (2, 4)))

Cursor.applyAll cursors

// Variante 3 -- Pipeline + DSL
Cursor.configure (fun cursors ->
    cursors
    |> Cursor.move (Some (Position.RowCol (2, 4)))
)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
