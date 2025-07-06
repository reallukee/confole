(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Position.fs

    Title       : POSITION
    Description : Position

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

module Position =
    type Cell = {
        col : int
        row : int
    }

    type Position =
        | ColRow of int * int
        | Cell of Cell
