// Program.fs ** ChangeOutputColor Example
//   Confole: https://github.com/reallukee/confole/

namespace Reallukee.Confole.Examples

open System

open Reallukee.Confole

module Program =

    let red () =
        printfn "Red"

        for i = 0 to 15 do
            Format.doForegroundColor ""    (Some (Color.RGB (i * 17, 0, 0)))
            Format.doBackgroundColor "   " (Some (Color.RGB (i * 17, 0, 0)))

        Format.doReset ""

        printfn ""

    let green () =
        printfn "Green"

        for i = 0 to 15 do
            Format.doForegroundColor ""    (Some (Color.RGB (0, i * 17, 0)))
            Format.doBackgroundColor "   " (Some (Color.RGB (0, i * 17, 0)))

        Format.doReset ""

        printfn ""

    let blue () =
        printfn "Blue"

        for i = 0 to 15 do
            Format.doForegroundColor ""    (Some (Color.RGB (0, 0, i * 17)))
            Format.doBackgroundColor "   " (Some (Color.RGB (0, 0, i * 17)))

        Format.doReset ""

        printfn ""

    [<EntryPoint>]
    let main _ =
        red   ()
        green ()
        blue  ()

        do Console.ReadKey()
        |> ignore

        0
