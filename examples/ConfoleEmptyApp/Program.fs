// Program.fs ** ConfoleEmptyApp Example
//   Confole: https://github.com/reallukee/confole/

namespace Reallukee.Confole.Examples

open System

open Reallukee.Confole

module Program =

    [<EntryPoint>]
    let main args =
        printfn "Hello, World from ConfoleEmptyApp!"

        do Console.ReadKey(true)
        |> ignore

        0
