(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Position.fsi

    Title       : POSITION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Position.
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

    val rowColToCell : rowCol : RowCol -> Cell
    val xYToCoord    : xY     : XY     -> Coord

    val cellToRowCol : cell  : Cell  -> RowCol
    val coordToXY    : coord : Coord -> XY
