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
        | Bold      | NoBold
        | Faint     | NoFaint
        | Italic    | NoItalic
        | Underline | NoUnderline
        | Blinking  | NoBlinking
        | Reverse   | NoReverse
        | Hidden    | NoHidden
        | Strikeout | NoStrikeout
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format List

    val init :
        unit ->
        Formats

    val bold : formats : Formats -> Formats
    val noBold : formats : Formats -> Formats

    val faint : formats : Formats -> Formats
    val noFaint : formats : Formats -> Formats

    val italic : formats : Formats -> Formats
    val noItalic : formats : Formats -> Formats

    val underline : formats : Formats -> Formats
    val noUnderline : formats : Formats -> Formats

    val blinking : formats : Formats -> Formats
    val noBlinking : formats : Formats -> Formats

    val reverse : formats : Formats -> Formats
    val noReverse : formats : Formats -> Formats

    val hidden : formats : Formats -> Formats
    val noHidden : formats : Formats -> Formats

    val strikeout : formats : Formats -> Formats
    val noStrikeout : formats : Formats -> Formats

    val foregroundColor : color : Color -> formats : Formats -> Formats
    val backgroundColor : color : Color -> formats : Formats -> Formats

    val apply :
        text   : string ->
        format : Format ->
        unit

    val applyAll :
        text    : string ->
        formats : Formats ->
        unit

    val reset :
        text : string ->
        unit
