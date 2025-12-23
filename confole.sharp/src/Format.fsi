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
                  Il modulo Format si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



[<AbstractClass>]
type FormatEmpty =
    interface IFormat

    new : format : Format.Format -> FormatEmpty

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type RestoreFormat =
    inherit FormatEmpty

    new : unit -> RestoreFormat

type RestoreForegroundColorFormat =
    inherit FormatEmpty

    new : unit -> RestoreForegroundColorFormat

type RestoreBackgroundColorFormat =
    inherit FormatEmpty

    new : unit -> RestoreBackgroundColorFormat



[<AbstractClass>]
type FormatFlag =
    interface IFormat

    new : format : (bool -> Format.Format) * flag : bool -> FormatFlag

    member Flag : bool with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type BoldFormat =
    inherit FormatFlag

    new : flag : bool -> BoldFormat

type FaintFormat =
    inherit FormatFlag

    new : flag : bool -> FaintFormat

type ItalicFormat =
    inherit FormatFlag

    new : flag : bool -> ItalicFormat

type UnderlineFormat =
    inherit FormatFlag

    new : flag : bool -> UnderlineFormat

type BlinkingFormat =
    inherit FormatFlag

    new : flag : bool -> BlinkingFormat

type ReverseFormat =
    inherit FormatFlag

    new : flag : bool -> ReverseFormat

type HiddenFormat =
    inherit FormatFlag

    new : flag : bool -> HiddenFormat

type StrikeoutFormat =
    inherit FormatFlag

    new : flag : bool -> StrikeoutFormat



[<AbstractClass>]
type FormatColor =
    interface IFormat

    new : format : (Color.Color -> Format.Format) * color : Sharp.Color -> FormatColor

    member Color : Sharp.Color with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type ForegroundColorFormat =
    inherit FormatColor

    new : color : Sharp.Color -> ForegroundColorFormat

type BackgroundColorFormat =
    inherit FormatColor

    new : color : Sharp.Color -> BackgroundColorFormat



type Formats =
    new : unit -> Formats

    member NewLine : bool     with get, set
    member Formats : IFormats with get

    new : formats : IFormats * newLine : bool -> Formats
    new : newLine : bool                      -> Formats

    member Item : int -> IFormat with get

    member AddFormat  : format  : IFormat  -> Formats
    member AddFormats : formats : IFormats -> Formats

    member AddRestore                : unit          -> Formats
    member AddRestoreForegroundColor : unit          -> Formats
    member AddRestoreBackgroundColor : unit          -> Formats
    member AddBold                   : flag  : bool  -> Formats
    member AddFaint                  : flag  : bool  -> Formats
    member AddItalic                 : flag  : bool  -> Formats
    member AddUnderline              : flag  : bool  -> Formats
    member AddBlinking               : flag  : bool  -> Formats
    member AddReverse                : flag  : bool  -> Formats
    member AddHidden                 : flag  : bool  -> Formats
    member AddStrikeout              : flag  : bool  -> Formats
    member AddForegroundColor        : color : Color -> Formats
    member AddBackgroundColor        : color : Color -> Formats

    member Clear : unit -> Formats
    member View  : unit -> unit

    member Apply    : format : IFormat * text    : string * newLine : bool -> unit
    member Apply    : format : IFormat * text    : string                  -> unit
    member ApplyAll : text   : string  * newLine : bool                    -> unit
    member ApplyAll : text   : string                                      -> unit

    member Reset : text : string -> unit

    static member DoRestore                : text : string                 -> unit
    static member DoRestoreForegroundColor : text : string                 -> unit
    static member DoRestoreBackgroundColor : text : string                 -> unit
    static member DoBold                   : text : string * flag  : bool  -> unit
    static member DoFaint                  : text : string * flag  : bool  -> unit
    static member DoItalic                 : text : string * flag  : bool  -> unit
    static member DoUnderline              : text : string * flag  : bool  -> unit
    static member DoBlinking               : text : string * flag  : bool  -> unit
    static member DoReverse                : text : string * flag  : bool  -> unit
    static member DoHidden                 : text : string * flag  : bool  -> unit
    static member DoStrikeout              : text : string * flag  : bool  -> unit
    static member DoForegroundColor        : text : string * color : Color -> unit
    static member DoBackgroundColor        : text : string * color : Color -> unit

    static member DoReset : text : string -> unit

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
