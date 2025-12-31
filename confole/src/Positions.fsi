(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Positions.fsi

    Title       : POSITIONS
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Positions.
                  Fornisce una lista di Positions out-of-the-box
                  accessibili tramite etichetta.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Positions =

    open Position

    module ColRow =

        type Format =
            | ColRow
            | Cell

        val tryGet : position : string -> format : Format -> Position option
        val get    : position : string -> format : Format -> Position
        val exists : position : string                    -> bool

    module XY =

        type Format =
            | XY
            | Coord

        val tryGet : position : string -> format : Format -> Position option
        val get    : position : string -> format : Format -> Position
        val exists : position : string                    -> bool
