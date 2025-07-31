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

type XTermColor =
    inherit Color

    new : unit -> XTermColor
    new : int -> XTermColor

    member Id : int with get, set

    override Equals : obj -> bool
    override GetHashCode : unit -> int
    override ToString : unit -> string

type RGBColor =
    inherit Color

    new : unit -> RGBColor
    new : int * int * int -> RGBColor

    member Red   : int with get, set
    member Green : int with get, set
    member Blue  : int with get, set

    override Equals : obj -> bool
    override GetHashCode : unit -> int
    override ToString : unit -> string

type HEXColor =
    inherit Color

    new : unit -> HEXColor
    new : string * string * string -> HEXColor

    member Red   : string with get, set
    member Green : string with get, set
    member Blue  : string with get, set

    override Equals : obj -> bool
    override GetHashCode : unit -> int
    override ToString : unit -> string
