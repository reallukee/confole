(*
    F# Script

    Type "dotnet fsi action.imperativo.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Action.doEraseDisplay (Some Action.Erase.FromBeginToEnd)
Action.doEraseLine    (Some Action.Erase.FromBeginToEnd)

Action.doReset ()
