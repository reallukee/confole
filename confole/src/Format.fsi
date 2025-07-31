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
        | Bold            of bool
        | Faint           of bool
        | Italic          of bool
        | Underline       of bool
        | Blinking        of bool
        | Reverse         of bool
        | Hidden          of bool
        | Strikeout       of bool
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format list

    val init :
        unit ->
        Formats

    val restore : Formats -> Formats

    val bold      : bool -> Formats -> Formats
    val faint     : bool -> Formats -> Formats
    val italic    : bool -> Formats -> Formats
    val underline : bool -> Formats -> Formats
    val blinking  : bool -> Formats -> Formats
    val reverse   : bool -> Formats -> Formats
    val hidden    : bool -> Formats -> Formats
    val strikeout : bool -> Formats -> Formats

    val foregroundColor : color : Color -> Formats -> Formats
    val backgroundColor : color : Color -> Formats -> Formats

    val clear : Formats -> Formats

    val apply    : bool -> string -> Format -> unit
    val applyAll : bool -> string -> Formats -> unit
    val reset    : string -> unit

    val configure : bool -> string -> (Formats -> Formats) -> unit

    type Builder =
        new :
            unit ->
            Builder

        member Yield :
            (Formats -> Formats) -> (Formats -> Formats)

        member Combine :
            (Formats -> Formats) * (Formats -> Formats) ->
            (Formats -> Formats)

        member Delay :
            (unit -> (Formats -> Formats)) ->
            (Formats -> Formats)

        member Run :
            (Formats -> Formats) ->
            Formats

    val builder : Builder
