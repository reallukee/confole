(*
    F# Script

    Type "dotnet fsi cursor.configure.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

Cursor.configure false (fun cursors ->
    cursors
    |> Cursor.move (Position.ColRow (4, 2))
)

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
