(*
    F# Script

    Type "dotnet fsi action.dsl.fsx" to run!

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

Action.Builder () {
    Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
}
|> Action.applyAll

Action.reset ()
