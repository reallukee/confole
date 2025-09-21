(*
    F# Script

    Type "dotnet fsi action.builder.fsx" to run!

    Necessary for F# Interactive

    dotnet build confole --configuration Release
    dotnet pack confole --configuration Release
*)

#r @"../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.1.0"

open System

open Reallukee.Confole

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Action.builder {
    Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
}
|> Action.applyAll

Action.reset ()
