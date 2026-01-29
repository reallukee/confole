// Program.fs ** Confole.Dev
//   Confole: https://github.com/reallukee/confole/

namespace Reallukee.Confole

open System

module Program =

    [<EntryPoint>]
    let main args =
        Rule.doTitle "Confole"

        let formats =
            Format.init ()
            |> Format.italic          (Some true)
            |> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
            |> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))

        Format.applyAllNewLine "Hello, World!" formats

        do Console.ReadKey(true)
        |> ignore

        Format.reset ""

        // Alias

        (*
        let fmt =
            Format.init ()
            |> Fmt.itc (Some true)
            |> Fmt.fgc (Some (Color.RGB (255, 0, 0)))
            |> Fmt.bgc (Some (Color.RGB (0, 0, 255)))

        Fmt.applyallnl "Hello, World!" fmt
        *)

        0
