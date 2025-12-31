(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : PositionConversion.fsi

    Title       : POSITION CONVERSION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo PositionConversion.
                  Questo modulo parla da solo! Dai si
                  capisce cosa fa!!!
                  MIAO! MIAO! MIAO!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module PositionConversion =

    open System

    open Position

    val colRowToXY : colRow : ColRow -> XY
    val xYToColRow : xY     : XY     -> ColRow

    val cellToCoord : cell  : Cell  -> Coord
    val coordToCell : coord : Coord -> Cell
