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
open Position

module Format =
    type Format =
        | Restore
        | Bold      of bool
        | Faint     of bool
        | Italic    of bool
        | Underline of bool
        | Blinking  of bool
        | Reverse   of bool
        | Hidden    of bool
        | Strikeout of bool
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format List

    val init :
        unit ->
        Formats

    val restore : formats : Formats -> Formats

    val bold : bool -> formats : Formats -> Formats
    val faint : bool -> formats : Formats -> Formats
    val italic : bool -> formats : Formats -> Formats
    val underline : bool -> formats : Formats -> Formats
    val blinking : bool -> formats : Formats -> Formats
    val reverse : bool -> formats : Formats -> Formats
    val hidden : bool -> formats : Formats -> Formats
    val strikeout : bool -> formats : Formats -> Formats

    val foregroundColor : color : Color -> formats : Formats -> Formats
    val backgroundColor : color : Color -> formats : Formats -> Formats

    val apply :
        newLine : bool ->
        text   : string ->
        format : Format ->
        unit

    val applyAll :
        newLine : bool ->
        text    : string ->
        formats : Formats ->
        unit

    val reset :
        text : string ->
        unit
