(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : PositionConversion.fs

    Title       : POSITION CONVERSION
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo PositionConversion.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Position
open Reallukee.Confole.PositionConversion

type PositionConversion () =

    [<Fact>]
    [<Trait("Category", "PositionConversion")>]
    member _.``rowColToXY funziona?`` () =
        let rowCol = 4, 2

        let xY = 2, 4

        rowColToXY rowCol
        |> should equal xY

    [<Fact>]
    [<Trait("Category", "PositionConversion")>]
    member _.``xYToRowCol funziona?`` () =
        let xY = 2, 4

        let rowCol = 4, 2

        xYToRowCol xY
        |> should equal rowCol

    [<Fact>]
    [<Trait("Category", "PositionConversion")>]
    member _.``cellToCoord funziona?`` () =
        let cell : Cell = {
            row = 4
            col = 2
        }

        let coord : Coord = {
            x = 2
            y = 4
        }

        cellToCoord cell
        |> should equal coord

    [<Fact>]
    [<Trait("Category", "PositionConversion")>]
    member _.``coordToCell funziona?`` () =
        let coord : Coord = {
            x = 2
            y = 4
        }

        let cell : Cell = {
            row = 4
            col = 2
        }

        coordToCell coord
        |> should equal cell
