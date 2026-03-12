(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fsi

    Title       : FORMAT
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Format.
                  Il modulo Format si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Il modulo Format si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

                  Riscrittura v4!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open System
open System.Collections
open System.Collections.Generic

open Reallukee.Confole

[<Class>]
type Formats =

    (*
        Wrapper OOP modulo Format: v4

        Cosa manca?

        * render    : Perchè? Richiederebbe il wrapping della DU.
        * trunk     : Non lo so...
        * apply     : Perchè? Richiederebbe il wrapping della DU.
        * configure : Perchè? Richiederebbe il wrapping della DU.
        * Builder   : I DSL in C# non esistono.

        Detto questo buon uso!

        MIAO a tutti!
    *)

    internal new : unit -> Formats

    static member NewLine     : bool                with get,          set
    member        FormatsList : List<Format.Format> with internal get, internal set

    // Modalità manuale
    member Renders : text : string -> string

    static member RenderRestore : text : string -> string

    static member RenderRestoreForegroundColor : text : string -> string
    static member RenderRestoreBackgroundColor : text : string -> string

    static member RenderBold      : text : string               -> string
    static member RenderBold      : text : string * flag : bool -> string
    static member RenderFaint     : text : string               -> string
    static member RenderFaint     : text : string * flag : bool -> string
    static member RenderItalic    : text : string               -> string
    static member RenderItalic    : text : string * flag : bool -> string
    static member RenderUnderline : text : string               -> string
    static member RenderUnderline : text : string * flag : bool -> string
    static member RenderBlinking  : text : string               -> string
    static member RenderBlinking  : text : string * flag : bool -> string
    static member RenderReverse   : text : string               -> string
    static member RenderReverse   : text : string * flag : bool -> string
    static member RenderHidden    : text : string               -> string
    static member RenderHidden    : text : string * flag : bool -> string
    static member RenderStrikeout : text : string               -> string
    static member RenderStrikeout : text : string * flag : bool -> string

    static member RenderForegroundColor : text : string                 -> string
    static member RenderForegroundColor : text : string * color : Color -> string
    static member RenderBackgroundColor : text : string                 -> string
    static member RenderBackgroundColor : text : string * color : Color -> string

    static member RenderReset : text : string -> string

    // Modalità "funzionale"
    static member Init     : unit              -> Formats
    static member InitWith : formats : Formats -> Formats

    member Clear   : unit -> Formats

    member View    : unit -> Formats
    member Preview : unit -> Formats

    member Restore : unit -> Formats

    member RestoreForegroundColor : unit -> Formats
    member RestoreBackgroundColor : unit -> Formats

    member Bold      : unit        -> Formats
    member Bold      : flag : bool -> Formats
    member Faint     : unit        -> Formats
    member Faint     : flag : bool -> Formats
    member Italic    : unit        -> Formats
    member Italic    : flag : bool -> Formats
    member Underline : unit        -> Formats
    member Underline : flag : bool -> Formats
    member Blinking  : unit        -> Formats
    member Blinking  : flag : bool -> Formats
    member Reverse   : unit        -> Formats
    member Reverse   : flag : bool -> Formats
    member Hidden    : unit        -> Formats
    member Hidden    : flag : bool -> Formats
    member Strikeout : unit        -> Formats
    member Strikeout : flag : bool -> Formats

    member ForegroundColor : unit          -> Formats
    member ForegroundColor : color : Color -> Formats
    member BackgroundColor : unit          -> Formats
    member BackgroundColor : color : Color -> Formats

    member ApplyAll : text : string                  -> unit
    member ApplyAll : text : string * newLine : bool -> unit

    static member Reset : text : string -> unit

    // Modalità imperativa
    static member DoRestore : text : string -> unit

    static member DoRestoreForegroundColor : text : string -> unit
    static member DoRestoreBackgroundColor : text : string -> unit

    static member DoBold      : text : string               -> unit
    static member DoBold      : text : string * flag : bool -> unit
    static member DoFaint     : text : string               -> unit
    static member DoFaint     : text : string * flag : bool -> unit
    static member DoItalic    : text : string               -> unit
    static member DoItalic    : text : string * flag : bool -> unit
    static member DoUnderline : text : string               -> unit
    static member DoUnderline : text : string * flag : bool -> unit
    static member DoBlinking  : text : string               -> unit
    static member DoBlinking  : text : string * flag : bool -> unit
    static member DoReverse   : text : string               -> unit
    static member DoReverse   : text : string * flag : bool -> unit
    static member DoHidden    : text : string               -> unit
    static member DoHidden    : text : string * flag : bool -> unit
    static member DoStrikeout : text : string               -> unit
    static member DoStrikeout : text : string * flag : bool -> unit

    static member DoForegroundColor : text : string                 -> unit
    static member DoForegroundColor : text : string * color : Color -> unit
    static member DoBackgroundColor : text : string                 -> unit
    static member DoBackgroundColor : text : string * color : Color -> unit

    static member DoReset : text : string -> unit
