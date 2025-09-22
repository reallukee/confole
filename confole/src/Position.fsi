(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Position.fsi

    Title       : POSITION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Position.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

module Position =
    open Common

    type Cell = {
        col : int
        row : int
    }

    type Position =
        | ColRow of int * int
        | Cell   of Cell
