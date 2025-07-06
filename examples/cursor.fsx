(*
    F# Script

    dotnet fsi cursor2.fsx
*)

// Necessary for F# Interactive
#r @"../confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Position.ColRow (4, 2))

Cursor.applyAll false cursors

printfn "Hello, World!"

Cursor.reset ()
