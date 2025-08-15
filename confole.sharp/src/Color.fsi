(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Color.fsi

    Title       : COLOR
    Description : Color

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

[<AbstractClass>]
type Color = class end

and XTermColor =
    inherit Color

    new : unit -> XTermColor
    new : int -> XTermColor

    member Id : int with get, set

    static member fromId : int -> XTermColor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

and RGBColor =
    inherit Color

    new : unit -> RGBColor
    new : int * int * int -> RGBColor

    member Red   : int with get, set
    member Green : int with get, set
    member Blue  : int with get, set

    static member fromRGB : int * int * int -> RGBColor
    static member fromHEX : string * string * string -> RGBColor

    static member fromHEXColor : HEXColor -> RGBColor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

and HEXColor =
    inherit Color

    new : unit -> HEXColor
    new : string * string * string -> HEXColor

    member Red   : string with get, set
    member Green : string with get, set
    member Blue  : string with get, set

    static member fromHEX : string * string * string -> HEXColor
    static member fromRGB : int * int * int -> HEXColor

    static member fromHEXColor : RGBColor -> HEXColor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
