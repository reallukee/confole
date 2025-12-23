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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
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
        | XTerm      of code  : int
        | XTermColor of color : XTermColor
        | RGB        of red   : int        * green : int    * blue : int
        | RGBColor   of color : RGBColor
        | HEX        of red   : string     * green : string * blue : string
        | HEXColor   of color : HEXColor

    val rgbToHEX : rgb : int    * int    * int    -> string * string * string
    val hexToRGB : hex : string * string * string -> int    * int    * int

    val rgbColorToHEXColor : rgbColor : RGBColor -> HEXColor
    val hexColorToRGBColor : hexColor : HEXColor -> RGBColor

    val colorToRGB : color : Color -> int    * int    * int
    val colorToHEX : color : Color -> string * string * string
