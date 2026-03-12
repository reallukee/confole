(*
    F# Script

    Type "dotnet fsi action.funzionale.fsx" to run!

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

// Variante 1 -- Pipeline
Action.init ()
|> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
|> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
|> Action.applyAll

// Variante 2 -- Pipeline ritardata
let actions =
    Action.init ()
    |> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    |> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)

Action.applyAll actions

// Variante 3 -- Pipeline + DSL
Action.configure (fun actions ->
    actions
    |> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    |> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
)

Action.reset ()
