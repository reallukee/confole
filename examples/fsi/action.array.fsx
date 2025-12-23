(*
    F# Script

    Type "dotnet fsi action.array.fsx" to run!

    To run in F# Interactive:

    * dotnet build confole --configuration Release
    * dotnet pack confole --configuration Release
*)

#r @"../../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.2.0"

open System

open Reallukee.Confole

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

[
    Action.EraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.EraseLine    (Some Action.Erase.FromBeginToEnd)
]
|> Action.applyAll

Action.reset ()
