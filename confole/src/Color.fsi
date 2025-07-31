(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Color.fsi

    Title       : COLOR
    Description : Color

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

module Color =
    type XTermColor = {
        id : int
    }

    type RGBColor = {
        red   : int
        green : int
        blue  : int
    }

    type HEXColor = {
        red   : string
        green : string
        blue  : string
    }

    type Color =
        | XTerm      of int
        | XTermColor of XTermColor
        | RGB        of int * int * int
        | RGBColor   of RGBColor
        | HEX        of string * string * string
        | HEXColor   of HEXColor

    val rgbToHEX : int -> int -> int -> string * string * string
    val hexToRGB : string -> string -> string -> int * int * int

    val rgbColorToHEXColor : RGBColor -> HEXColor
    val hexColorToRGBColor : HEXColor -> RGBColor

    val colorRGB : Color -> int * int * int
    val colorHEX : Color -> string * string * string
