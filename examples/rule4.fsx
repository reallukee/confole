(*
    F# Script

    dotnet fsi rule4.fsx
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

Rule.builder {
    Rule.title                    "Confole"
    Rule.showCursorBlinking
    Rule.showCursor
    Rule.disableDesignateMode
    Rule.disableAlternativeBuffer
    Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    Rule.defaultCursorColor       (Color.RGB (255, 255, 255))
}
|> Rule.applyAll false

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

Rule.reset ()
