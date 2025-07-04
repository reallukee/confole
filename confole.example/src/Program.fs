namespace Reallukee.Confole.Example

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main _ =
        Rule.init ()
        |> Rule.hideCursorBlinking
        |> Rule.hideCursor
        |> Rule.applyAll

        printfn "Hello, World!"

        do Console.ReadKey(false)
        |> ignore

        Rule.reset ()

        0
