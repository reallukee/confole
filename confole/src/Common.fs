(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Common.fs

    Title       : COMMON
    Description : Common

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

module Common =
    let ESC = "\u001B"
    let CSI = "\u001B["
    let OSC = "\u001B]"

    let BELL = "\u0007"
    let SP   = "\u0020"
