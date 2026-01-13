(*
    F# Script

    Type "dotnet fsi action.manuale.fsx" to run!

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

let actions = [
    Action.EraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.EraseLine    (Some Action.Erase.FromBeginToEnd)
]

printf "%s" (Action.renders actions)

printf "%s" (Action.renderReset ())
