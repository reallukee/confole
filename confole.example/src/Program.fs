namespace Reallukee.Confole.Example

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main _ =
        Rule.init ()
        |> Rule.hideCursorBlinking
        |> Rule.hideCursor
        |> Rule.defaultForegroundColor (Color.RGB (255, 255, 255))
        |> Rule.defaultBackgroundColor (Color.RGB (0, 0, 0))
        |> Rule.defaultCursorColor     (Color.RGB (255, 255, 255))
        |> Rule.applyAll false

        printfn "Hello, World!"

        do Console.ReadKey(false)
        |> ignore

        Rule.reset ()

        0
