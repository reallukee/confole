namespace Reallukee.Confole

open System

open Rule
open Color

module Program =
    [<EntryPoint>]
    let main _ =
        initRules
        |> hideCursor
        |> foregroundColor (RGB (255, 0, 0))
        |> applyRules

        printfn "Hello, World!"

        Console.ReadKey() |> ignore

        0
