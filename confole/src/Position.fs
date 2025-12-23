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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole

module Position =
    type Cell = {
        col : int
        row : int
    }

    type Position =
        | ColRow of col  : int  * row : int
        | Cell   of cell : Cell
