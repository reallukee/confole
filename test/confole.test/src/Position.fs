(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Position.fs

    Title       : POSITION
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Position.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Position

type Position () =

    [<Fact>]
    [<Trait("Category", "Position")>]
    member _.``rowColToCell funziona?`` () =
        let row = 0
        let col = 0

        let cell = rowColToCell (row, col)

        cell.row
        |> should equal row

        cell.col
        |> should equal col

    [<Fact>]
    [<Trait("Category", "Position")>]
    member _.``xYToCoord funziona?`` () =
        let x = 0
        let y = 0

        let coord = xYToCoord (x, y)

        coord.x
        |> should equal x

        coord.y
        |> should equal y



    [<Fact>]
    [<Trait("Category", "Position")>]
    member _.``cellTorowCol funziona?`` () =
        let cell = {
            row = 0
            col = 0
        }

        let row, col = cellToRowCol cell

        row
        |> should equal cell.row

        col
        |> should equal cell.col

    [<Fact>]
    [<Trait("Category", "Position")>]
    member _.``coordToXY funziona?`` () =
        let coord = {
            x = 0
            y = 0
        }

        let x, y = coordToXY coord

        x
        |> should equal coord.x

        y
        |> should equal coord.y
