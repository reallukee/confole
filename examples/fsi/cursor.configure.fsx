(*
    F# Script

    Type "dotnet fsi cursor.configure.fsx" to run!

    To run in F# Interactive:

    * dotnet build confole --configuration Release
    * dotnet pack confole --configuration Release
*)

#r @"../../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.2.0"

open System

open Reallukee.Confole

Cursor.configure (fun cursors ->
    cursors
    |> Cursor.move (Some (Position.ColRow (4, 2)))
)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
