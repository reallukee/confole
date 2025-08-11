(*
    F# Script

    Type "dotnet fsi action.array.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

[
    Action.EraseDisplay Action.Erase.FromBeginToEnd
    Action.EraseLine    Action.Erase.FromBeginToEnd
]
|> Action.applyAll false

Action.reset ()
