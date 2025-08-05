(*
    F# Script

    dotnet fsi action3.fsx
*)

// Necessary for F# Interactive
// dotnet build confole --configuration Release

// #r @"../confole/bin/Release/netstandard2.0/confole.dll"

// Necessary for F# Interactive
// dotnet build confole --configuration Release
// dotnet pack confole --configuration Release

#r @"nuget: Reallukee.Confole, 1.0.0"

open System

open Reallukee.Confole

printfn "Hello, World!"

do Console.ReadKey(true)
|> ignore

Action.configure false (fun actions ->
    actions
    |> Action.eraseDisplay Action.Erase.FromBeginToEnd
    |> Action.eraseLine    Action.Erase.FromBeginToEnd
)

Action.reset ()
