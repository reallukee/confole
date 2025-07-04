(*
    F# Script

    dotnet fsi rules2.fsx
*)

// Necessary for F# Interactive
#r @"../confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let rules =
    Rule.init ()
    |> Rule.hideCursorBlinking
    |> Rule.hideCursor

Rule.applyAll rules

printfn "Hello, World!"

Rule.reset ()
