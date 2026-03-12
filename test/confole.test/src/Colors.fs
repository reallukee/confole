(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Colors.fs

    Title       : COLORS
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Colors.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Color
open Reallukee.Confole.Colors

[<Class>]
type Colors () =

    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``rgb tryGet funziona?`` () =
        let testCases = [
            "Red", RGB.Format.RGB, Some (Color.RGB (255, 0, 0))
            "Rad", RGB.Format.RGB, None
        ]

        testCases
        |> List.iter (fun (color, format, expected) ->
            RGB.tryGet color format
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``hex tryGet funziona?`` () =
        let testCases = [
            "Red", HEX.Format.HEX, Some (Color.HEX ("FF", "00", "00"))
            "Rad", HEX.Format.HEX, None
        ]

        testCases
        |> List.iter (fun (color, format, expected) ->
            HEX.tryGet color format
            |> should equal expected
        )



    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``rgb get funziona?`` () =
        RGB.get "Red" RGB.Format.RGB
        |> should equal (Color.RGB (255, 0, 0))

    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``hex get funziona?`` () =
        HEX.get "Red" HEX.Format.HEX
        |> should equal (Color.HEX ("FF", "00", "00"))



    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``rgb get lancia l'eccezione?`` () =
        let ex =
            Assert.Throws<System.Exception>(fun () ->
                RGB.get "Rad" RGB.Format.RGB
                |> ignore
            )

        ex.Message
        |> should equal "Rad: Not found!"

    [<Fact>]
    [<Trait("Category", "Colors")>]
    member _.``hex get lancia l'eccezione?`` () =
        let ex =
            Assert.Throws<System.Exception>(fun () ->
                HEX.get "Rad" HEX.Format.HEX
                |> ignore
            )

        ex.Message
        |> should equal "Rad: Not found!"
