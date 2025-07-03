(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Format.fsi

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color

module Format =
    type Format =
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format List

    val initFormat :
        unit ->
        Formats

    val foregroundColor :
        color   : Color ->
        formats : Formats ->
        Formats

    val backgroundColor :
        color   : Color ->
        formats : Formats ->
        Formats

    val applyFormat :
        text   : string ->
        format : Format ->
        unit

    val applyFormats :
        text    : string ->
        formats : Formats ->
        unit

    val resetFormats :
        text : string ->
        unit
