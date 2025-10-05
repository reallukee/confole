(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Common.fsi

    Title       : COMMON
    Description : Common

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

module Common =
    val ESC : string
    val CSI : string
    val OSC : string

    val Bell : string
    val SP   : string
