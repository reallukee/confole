(*
    F# Script

    dotnet fsi format.fsx
*)

// Necessary for F# Interactive
#r @"../confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

Format.reset ""
