(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Format.fsi

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



type FormatRestore =
    interface IFormat

    new : unit -> FormatRestore

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type FormatBold =
    interface IFormat

    new : bool -> FormatBold

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatFaint =
    interface IFormat

    new : bool -> FormatFaint

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatItalic =
    interface IFormat

    new : bool -> FormatItalic

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatUnderline =
    interface IFormat

    new : bool -> FormatUnderline

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatBlinking =
    interface IFormat

    new : bool -> FormatBlinking

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatReverse =
    interface IFormat

    new : bool -> FormatReverse

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatHidden =
    interface IFormat

    new : bool -> FormatHidden

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatStrikeout =
    interface IFormat

    new : bool -> FormatStrikeout

    member Flag : bool with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type FormatRestoreForegroundColor =
    interface IFormat

    new : unit -> FormatRestoreForegroundColor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatRestoreBackgroundColor =
    interface IFormat

    new : unit -> FormatRestoreBackgroundColor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type FormatForegroundColor =
    interface IFormat

    new : Color -> FormatForegroundColor

    member Color : Color

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type FormatBackgroundColor =
    interface IFormat

    new : Color -> FormatBackgroundColor

    member Color : Color

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type Formats =
    new : unit -> Formats

    member NewLine : bool     with get, set
    member Formats : IFormats with get

    new : IFormats * bool -> Formats
    new : bool -> Formats

    member Item : int -> IFormat with get

    member AddFormat  : IFormat  -> Formats
    member AddFormats : IFormats -> Formats

    member AddRestoreFormat : unit -> Formats

    member AddBoldFormat      : bool -> Formats
    member AddFaintFormat     : bool -> Formats
    member AddItalicFormat    : bool -> Formats
    member AddUnderlineFormat : bool -> Formats
    member AddBlinkingFormat  : bool -> Formats
    member AddReverseFormat   : bool -> Formats
    member AddHiddenFormat    : bool -> Formats
    member AddStrikeoutFormat : bool -> Formats

    member AddRestoreForegroundColorFormat : unit -> Formats
    member AddRestoreBackgroundColorFormat : unit -> Formats

    member AddForegroundColorFormat : Color -> Formats
    member AddBackgroundColorFormat : Color -> Formats

    member Clear : unit -> Formats

    member View : unit -> unit

    member Apply : IFormat * bool * string -> unit
    member Apply : IFormat * string        -> unit

    member ApplyAll : bool * string -> unit
    member ApplyAll : string        -> unit

    member Reset : string -> unit

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
