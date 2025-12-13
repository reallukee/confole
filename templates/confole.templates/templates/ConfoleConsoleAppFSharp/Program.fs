// Program.fs ** ConfoleConsoleApp
//   Confole: https://github.com/reallukee/confole

namespace ConfoleConsoleApp

open System

open Reallukee.Confole

module Program =
    [<EntryPoint>]
    let main args =
        #if (mode == "functional")
        let formats =
            Format.init ()
            |> Format.italic          true
            |> Format.foregroundColor (Color.RGB (255, 0, 0))
            |> Format.backgroundColor (Color.RGB (0, 0, 255))

        Format.applyAllNewLine "Hello, World from ConfoleConsoleApp!" formats

        Format.reset ""
        #endif
        #if (mode == "imperative")
        Format.doForegroundColor "" (Color.RGB (255, 0, 0))
        Format.doBackgroundColor "" (Color.RGB (0, 0, 255))
        Format.doBold "Hello, World! from ConfoleConsoleApp!" true

        printfn ""

        Format.reset ""
        #endif

        printf "More at: "

        #if (mode == "functional")
        let formats =
            Format.init ()
            |> Format.underline true

        Format.applyAllNewLine "https://github.com/reallukee/confole" formats

        do Console.ReadKey(true)
        |> ignore

        Format.reset ""

        #endif
        #if (mode == "imperative")
        Format.doUnderline "https://github.com/reallukee/confole" true

        printfn ""

        do Console.ReadKey(true)
        |> ignore

        Format.reset ""
        #endif

        0
