(*
    F# Script

    dotnet fsi action4.fsx
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

Action.builder {
    Action.eraseDisplay Action.Erase.FromBeginToEnd
    Action.eraseLine    Action.Erase.FromBeginToEnd
}
|> Action.applyAll false

Action.reset ()
