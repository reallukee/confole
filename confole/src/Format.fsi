(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Format.fsi

    Title       : FORMAT
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Format.
                  Il modulo Format si occupa di sequenze VTS
                  relative alla formattazione del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Format =
    open Common

    type Format =
        | Restore
        | Bold                   of bool
        | Faint                  of bool
        | Italic                 of bool
        | Underline              of bool
        | Blinking               of bool
        | Reverse                of bool
        | Hidden                 of bool
        | Strikeout              of bool
        | RestoreForegroundColor
        | RestoreBackgroundColor
        | ForegroundColor        of Color
        | BackgroundColor        of Color

    type Formats = Format list

    val restore : formats : Formats -> Formats

    val bold      : flag : bool -> formats : Formats -> Formats
    val faint     : flag : bool -> formats : Formats -> Formats
    val italic    : flag : bool -> formats : Formats -> Formats
    val underline : flag : bool -> formats : Formats -> Formats
    val blinking  : flag : bool -> formats : Formats -> Formats
    val reverse   : flag : bool -> formats : Formats -> Formats
    val hidden    : flag : bool -> formats : Formats -> Formats
    val strikeout : flag : bool -> formats : Formats -> Formats

    val restoreForegroundColor : formats : Formats -> Formats
    val restoreBackgroundColor : formats : Formats -> Formats

    val foregroundColor : color : Color -> formats : Formats -> Formats
    val backgroundColor : color : Color -> formats : Formats -> Formats

    val init  : unit              -> Formats
    val clear : formats : Formats -> Formats
    val view  : formats : Formats -> unit

    val apply        : text : string -> format : Format -> unit
    val applyNewLine : text : string -> format : Format -> unit

    val applyAll        : text : string -> formats : Formats -> unit
    val applyAllNewLine : text : string -> formats : Formats -> unit

    val reset : text : string -> unit

    val configure        : text : string -> config : (Formats -> Formats) -> unit
    val configureNewLine : text : string -> config : (Formats -> Formats) -> unit

    type Builder =
        new : unit -> Builder

        member Yield :
            formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Combine :
            format : (Formats -> Formats) * formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Delay :
            ``function`` : (unit -> (Formats -> Formats)) ->
            (Formats -> Formats)

        member Run :
            formatsFunction : (Formats -> Formats) ->
            Formats

    val builder : Builder

    val doRestore : text : string -> unit

    val doBold      : text : string -> flag : bool -> unit
    val doFaint     : text : string -> flag : bool -> unit
    val doItalic    : text : string -> flag : bool -> unit
    val doUnderline : text : string -> flag : bool -> unit
    val doBlinking  : text : string -> flag : bool -> unit
    val doReverse   : text : string -> flag : bool -> unit
    val doHidden    : text : string -> flag : bool -> unit
    val doStrikeout : text : string -> flag : bool -> unit

    val doRestoreForegroundColor : text : string -> unit
    val doRestoreBackgroundColor : text : string -> unit

    val doForegroundColor : text : string -> color : Color -> unit
    val doBackgroundColor : text : string -> color : Color -> unit
