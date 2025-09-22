(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Format.fsi

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



type RestoreFormat =
    interface IFormat

    new : unit -> RestoreFormat

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type BoldFormat =
    interface IFormat

    new : flag : bool -> BoldFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type FaintFormat =
    interface IFormat

    new : flag : bool -> FaintFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type ItalicFormat =
    interface IFormat

    new : flag : bool -> ItalicFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type UnderlineFormat =
    interface IFormat

    new : flag : bool -> UnderlineFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type BlinkingFormat =
    interface IFormat

    new : flag : bool -> BlinkingFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type ReverseFormat =
    interface IFormat

    new : flag : bool -> ReverseFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type HiddenFormat =
    interface IFormat

    new : flag : bool -> HiddenFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type StrikeoutFormat =
    interface IFormat

    new : flag : bool -> StrikeoutFormat

    member Flag : bool with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type RestoreForegroundColorFormat =
    interface IFormat

    new : unit -> RestoreForegroundColorFormat

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type RestoreBackgroundColorFormat =
    interface IFormat

    new : unit -> RestoreBackgroundColorFormat

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type ForegroundColorFormat =
    interface IFormat

    new : color : Color -> ForegroundColorFormat

    member Color : Color

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type BackgroundColorFormat =
    interface IFormat

    new : color : Color -> BackgroundColorFormat

    member Color : Color

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type Formats =
    new : unit -> Formats

    member NewLine : bool     with get, set
    member Formats : IFormats with get

    new : formats : IFormats * newLine : bool -> Formats
    new : newLine : bool                      -> Formats

    member Item : int -> IFormat with get

    member AddFormat  : format  : IFormat  -> Formats
    member AddFormats : formats : IFormats -> Formats

    member AddRestoreFormat : unit -> Formats

    member AddBoldFormat      : flag : bool -> Formats
    member AddFaintFormat     : flag : bool -> Formats
    member AddItalicFormat    : flag : bool -> Formats
    member AddUnderlineFormat : flag : bool -> Formats
    member AddBlinkingFormat  : flag : bool -> Formats
    member AddReverseFormat   : flag : bool -> Formats
    member AddHiddenFormat    : flag : bool -> Formats
    member AddStrikeoutFormat : flag : bool -> Formats

    member AddRestoreForegroundColorFormat : unit -> Formats
    member AddRestoreBackgroundColorFormat : unit -> Formats

    member AddForegroundColorFormat : color : Color -> Formats
    member AddBackgroundColorFormat : color : Color -> Formats

    member Clear : unit -> Formats
    member View  : unit -> unit

    member Apply : format : IFormat * newLine : bool * text : string -> unit
    member Apply : format : IFormat * text : string                  -> unit

    member ApplyAll : newLine : bool * text : string -> unit
    member ApplyAll : text : string                  -> unit

    member Reset : text : string -> unit

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string
