(*
    F# Script

    Type "dotnet fsi format.imperativo.fsx" to run!

    To run in F# Interactive:

        dotnet build confole --configuration Release
*)

#r @"../../bin/confole/Release/netstandard2.0/confole.dll"

open System

open Reallukee.Confole

Format.doItalic          "" (Some true)
Format.doForegroundColor "" (Some (Color.RGB (255, 0, 0)))
Format.doBackgroundColor "" (Some (Color.RGB (0, 0, 255)))

printfn "Hello, World!"

// For GitHub actions!
if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Format.doReset ""
