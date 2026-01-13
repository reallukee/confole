(*
    F# Script

    Type "dotnet fsi cursor.dsl.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

Cursor.builder {
    Cursor.move (Some (Position.RowCol (2, 4)))
}
|> Cursor.applyAll

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
