(*
    F# Script

    Type "dotnet fsi cursor.manuale.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

let cursors = [
    Cursor.Move (Some (Position.RowCol (2, 4)))
]

printf "%s" (Cursor.renders cursors)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

printf "%s" (Cursor.renderReset ())
