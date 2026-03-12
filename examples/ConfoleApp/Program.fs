// Program.fs ** ConfoleApp Example
//   Confole: https://github.com/reallukee/confole/

namespace Reallukee.Confole.Examples

open System

open Reallukee.Confole

module Program =

    [<EntryPoint>]
    let main args =
        Rule.doTitle "ConfoleApp"

        Format.init ()
        |> Format.italic          (Some true)
        |> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
        |> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))
        |> Format.applyAllNewLine "Hello, World from ConfoleApp!"

        do Console.ReadKey(true)
        |> ignore

        Format.reset ""

        0
