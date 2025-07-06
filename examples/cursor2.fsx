(*
    F# Script

    dotnet fsi cursor.fsx
*)

// Necessary for F# Interactive
#r @"../confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

Cursor.init ()
|> Cursor.move (Position.ColRow (4, 2))
|> Cursor.applyAll false

printfn "Hello, World!"

Cursor.reset ()
