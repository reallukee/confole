(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Color.fsi

    Title       : COLOR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Color.
                  Funzioni helper per fare wrapping e unwrapping
                  di Color e tipi satellite.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Color =

    type XTermColor = {
        id : int
    }

    type XTerm = int

    type RGBColor = {
        red   : int
        green : int
        blue  : int
    }

    type RGB = int * int * int

    type HEXColor = {
        red   : string
        green : string
        blue  : string
    }

    type HEX = string * string * string

    type Color =
        | XTerm      of id    : XTerm
        | XTermColor of color : XTermColor
        | RGB        of rgb   : RGB
        | RGBColor   of color : RGBColor
        | HEX        of hex   : HEX
        | HEXColor   of color : HEXColor

    val xTermToXTermColor : id  : XTerm -> XTermColor
    val rgbToRGBColor     : rgb : RGB   -> RGBColor
    val hexToHEXColor     : hex : HEX   -> HEXColor

    val xTermColorToXTerm : xTermColor : XTermColor -> XTerm
    val rgbColorToRGB     : rgbColor   : RGBColor   -> RGB
    val hexColorToHEX     : hexColor   : HEXColor   -> HEX
