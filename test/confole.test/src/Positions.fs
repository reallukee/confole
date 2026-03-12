(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Positions.fs

    Title       : POSITIONS
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Positions.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Position
open Reallukee.Confole.Positions

[<Class>]
type Positions () =

    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``rowCol tryGet funziona?`` () =
        let testCases = [
            "Home", RowCol.Format.RowCol, Some (Position.RowCol (1, 1))
            "Hame", RowCol.Format.RowCol, None
        ]

        testCases
        |> List.iter (fun (color, format, expected) ->
            RowCol.tryGet color format
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``xY tryGet funziona?`` () =
        let testCases = [
            "Home", XY.Format.XY, Some (Position.XY (0, 0))
            "Hame", XY.Format.XY, None
        ]

        testCases
        |> List.iter (fun (color, format, expected) ->
            XY.tryGet color format
            |> should equal expected
        )



    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``rowCol get funziona?`` () =
        RowCol.get "Home" RowCol.Format.RowCol
        |> should equal (Position.RowCol (1, 1))

    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``xY get funziona?`` () =
        XY.get "Home" XY.Format.XY
        |> should equal (Position.XY (0, 0))



    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``rowCol get lancia l'eccezione?`` () =
        let ex =
            Assert.Throws<System.Exception>(fun () ->
                RowCol.get "Hame" RowCol.Format.RowCol
                |> ignore
            )

        ex.Message
        |> should equal "Hame: Not found!"

    [<Fact>]
    [<Trait("Category", "Positions")>]
    member _.``xY get lancia l'eccezione?`` () =
        let ex =
            Assert.Throws<System.Exception>(fun () ->
                XY.get "Hame" XY.Format.XY
                |> ignore
            )

        ex.Message
        |> should equal "Hame: Not found!"
