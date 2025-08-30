(*
    F# Script

    Type "dotnet fsi cursor.delayedpipeline.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Position.ColRow (4, 2))

Cursor.applyAll false cursors

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
