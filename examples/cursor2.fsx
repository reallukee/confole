(*
    F# Script

    dotnet fsi cursor.fsx
*)

// Necessary for F# Interactive
// #r @"../confole/bin/Release/netstandard2.0/confole.dll"
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release
#r @"nuget: Reallukee.Confole, 1.0.0"

open Reallukee.Confole

Cursor.init ()
|> Cursor.move (Position.ColRow (4, 2))
|> Cursor.applyAll false

printfn "Hello, World!"

Cursor.reset ()
