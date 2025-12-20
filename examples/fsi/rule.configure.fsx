(*
    F# Script

    Type "dotnet fsi rule.configure.fsx" to run!

    To run in F# Interactive:

    * dotnet build confole --configuration Release
    * dotnet pack confole --configuration Release
*)

#r @"../../confole/bin/Release/netstandard2.0/confole.dll"

// #r @"nuget: Reallukee.Confole, 1.2.0"

open System

open Reallukee.Confole

Rule.configure (fun rules ->
    rules
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))
)

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
