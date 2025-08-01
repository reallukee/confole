(*
    F# Script

    dotnet fsi cursor3.fsx
*)

// Necessary for F# Interactive
// dotnet build confole --configuration Release

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

// Necessary for F# Interactive
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

Cursor.configure false (fun cursors ->
    cursors
    |> Cursor.move (Position.ColRow (4, 2))
)

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

Cursor.reset ()
