(*
    F# Script

    Type "dotnet fsi rule.dsl.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

Rule.Builder () {
    Rule.title                    "Confole"
    Rule.showCursorBlinking
    Rule.showCursor
    Rule.disableDesignateMode
    Rule.disableAlternativeBuffer
    Rule.cursorShape              (Some Rule.Shape.User)
    Rule.defaultForegroundColor   (Some (Color.RGB (255, 255, 255)))
    Rule.defaultBackgroundColor   (Some (Color.RGB (0, 0, 0)))
    Rule.defaultCursorColor       (Some (Color.RGB (255, 255, 255)))
}
|> Rule.applyAll

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
