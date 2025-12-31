(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Color.fs

    Title       : COLOR
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Color.
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



    let xTermToXTermColor id =
        let id = id

        {
            id = id
        }

    let rgbToRGBColor rgb : RGBColor =
        let red, green, blue = rgb

        {
            red   = red
            green = green
            blue  = blue
        }

    let hexToHEXColor hex : HEXColor =
        let red, green, blue = hex

        {
            red   = red
            green = green
            blue  = blue
        }

    let xTermColorToXTerm xTermColor =
        xTermColor.id

    let rgbColorToRGB (rgbColor : RGBColor) =
        rgbColor.red, rgbColor.green, rgbColor.blue

    let hexColorToHEX (hexColor : HEXColor) =
        hexColor.red, hexColor.green, hexColor.blue
