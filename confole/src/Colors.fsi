(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Colors.fsi

    Title       : COLORS
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Colors.
                  Fornisce una lista di Colors out-of-the-box
                  accessibili tramite etichetta.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Colors =

    open Color

    module RGB =

        type Format =
            | RGB
            | RGBColor

        val tryGet : color : string -> format : Format -> Color option
        val get    : color : string -> format : Format -> Color
        val exists : color : string                    -> bool

    module HEX =

        type Format =
            | HEX
            | HEXColor

        val tryGet : color : string -> format : Format -> Color option
        val get    : color : string -> format : Format -> Color
        val exists : color : string                    -> bool
