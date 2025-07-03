namespace Reallukee.Confole.Example

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main _ =
        Rule.initRules ()
        |> Rule.hideCursor
        |> Rule.applyRules

        Format.initFormat ()
        |> Format.foregroundColor (Color.HEX ("10", "AA", "FF"))
        |> Format.backgroundColor (Color.HEX ("DD", "00", "CC"))
        |> Format.applyFormats "Hello, World!"

        do Console.ReadKey(false)
        |> ignore

        0
