namespace Reallukee.Confole

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main _ =
        let rules =
            Rule.init ()
            |> Rule.title                    "Confole"
            |> Rule.showCursorBlinking
            |> Rule.showCursor
            |> Rule.disableDesignateMode
            |> Rule.disableAlternativeBuffer
            |> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
            |> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
            |> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))

        Rule.applyAll false rules

        printfn "Hello, World!"

        do Console.ReadKey(false)
        |> ignore

        Rule.reset ()

        0
