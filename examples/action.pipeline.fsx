(*
    F# Script

    Type "dotnet fsi action.pipeline.fsx" to run!

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

let actions =
    Action.init ()
    |> Action.eraseDisplay Action.Erase.FromBeginToEnd
    |> Action.eraseLine    Action.Erase.FromBeginToEnd

Action.applyAll false actions

Action.reset ()
