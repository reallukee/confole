(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Color.fsi

    Title       : COLOR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Color.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

module Color =
    open Common

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

    val rgbToHEX : rgb : int * int * int -> string * string * string
    val hexToRGB : hex : string * string * string -> int * int * int

    val rgbColorToHEXColor : rgbColor : RGBColor -> HEXColor
    val hexColorToRGBColor : hexColor : HEXColor -> RGBColor

    val colorToRGB : color : Color -> int * int * int
    val colorToHEX : color : Color -> string * string * string

    module RGB =
        val Acqua   : RGBColor
        val Black   : RGBColor
        val Blue    : RGBColor
        val Fuchsia : RGBColor
        val Gray    : RGBColor
        val Green   : RGBColor
        val Lime    : RGBColor
        val Maroon  : RGBColor
        val Navy    : RGBColor
        val Olive   : RGBColor
        val Purple  : RGBColor
        val Red     : RGBColor
        val Silver  : RGBColor
        val Teal    : RGBColor
        val White   : RGBColor
        val Yellow  : RGBColor

    module HEX =
        val Acqua   : HEXColor
        val Acqua   : HEXColor
        val Black   : HEXColor
        val Blue    : HEXColor
        val Fuchsia : HEXColor
        val Gray    : HEXColor
        val Green   : HEXColor
        val Lime    : HEXColor
        val Maroon  : HEXColor
        val Navy    : HEXColor
        val Olive   : HEXColor
        val Purple  : HEXColor
        val Red     : HEXColor
        val Silver  : HEXColor
        val Teal    : HEXColor
        val White   : HEXColor
        val Yellow  : HEXColor
