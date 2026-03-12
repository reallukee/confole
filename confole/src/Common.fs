(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Common.fs

    Title       : COMMON
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Common.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

[<AutoOpen>]
module internal Common =

    let ESC = "\u001B"
    let CSI = "\u001B["
    let OSC = "\u001B]"

    let Bell = "\u0007"
    let SP   = "\u0020"
    let ST   = "\u001B\\"
