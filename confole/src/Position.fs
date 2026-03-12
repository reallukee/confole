(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Position.fs

    Title       : POSITION
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Position.
                  Funzioni helper per fare wrapping e unwrapping
                  di Position e tipi satellite.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Position =

    type Cell = {
        row : int
        col : int
    }

    type RowCol = int * int

    type Coord = {
        x : int
        y : int
    }

    type XY = int * int

    type Position =
        | RowCol of rowCol : RowCol
        | Cell   of cell   : Cell
        | XY     of xY     : XY
        | Coord  of coord  : Coord



    let rowColToCell rowCol : Cell =
        let row, col = rowCol

        {
            row = row
            col = col
        }

    let xYToCoord xY : Coord =
        let x, y = xY

        {
            x = x
            y = y
        }

    let cellToRowCol (cell : Cell) =
        cell.row, cell.col

    let coordToXY (coord : Coord) =
        coord.x, coord.y
