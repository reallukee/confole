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
        | XTerm of int
        | XTermColor of XTermColor
        | RGB of int * int * int
        | HEX of string * string * string
        | RGBColor of RGBColor
        | HEXColor of HEXColor

    val rgbToHEX :
        red   : int ->
        green : int ->
        blue  : int ->
        string * string * string

    val hexToRGB :
        red   : string ->
        green : string ->
        blue  : string ->
        int * int * int

    val rgbColorToHEXColor :
        color : RGBColor ->
        HEXColor

    val hexColorToRGBColor :
        color : HEXColor ->
        RGBColor
