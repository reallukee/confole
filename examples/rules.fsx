(*
    F# Script

    dotnet fsi rules.fsx
*)

// Necessary for F# Interactive
#r @"../confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

Rule.init ()
|> Rule.hideCursorBlinking
|> Rule.hideCursor
|> Rule.applyAll

printfn "Hello, World!"

Rule.reset ()
