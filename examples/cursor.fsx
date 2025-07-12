(*
    F# Script

    dotnet fsi cursor2.fsx
*)

// Necessary for F# Interactive
// #r @"../confole/bin/Release/netstandard2.0/confole.dll"
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release
#r @"nuget: Reallukee.Confole, 1.0.0"

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Position.ColRow (4, 2))

Cursor.applyAll false cursors

printfn "Hello, World!"

Cursor.reset ()
