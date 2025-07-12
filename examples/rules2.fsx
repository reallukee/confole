(*
    F# Script

    dotnet fsi rules2.fsx
*)

// Necessary for F# Interactive
// #r @"../confole/bin/Release/netstandard2.0/confole.dll"
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release
#r @"nuget: Reallukee.Confole, 1.0.0"

open Reallukee.Confole

let rules =
    Rule.init ()
    |> Rule.title                  "Confole"
    |> Rule.hideCursorBlinking
    |> Rule.hideCursor
    |> Rule.defaultForegroundColor (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor     (Color.RGB (255, 255, 255))

Rule.applyAll false rules

printfn "Hello, World!"

Rule.reset ()
