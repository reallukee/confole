(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : ColorConversion.fsi

    Title       : COLOR CONVERSION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo ColorConversion.
                  Questo modulo parla da solo! Dai si
                  capisce cosa fa!!!
                  MIAO! MIAO! MIAO!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module ColorConversion =

    open System

    open Color

    val hexToRGB : hex : HEX -> RGB
    val rgbToHEX : rgb : RGB -> HEX

    val hexColorToRGBColor : hexColor : HEXColor -> RGBColor
    val rgbColorToHEXColor : rgbColor : RGBColor -> HEXColor



    val xTermToRGB : id : XTerm -> RGB
    val xTermToHEX : id : XTerm -> HEX

    val xTermColorToRGBColor : xTermColor : XTermColor -> RGBColor
    val xTermColorToHEXColor : xTermColor : XTermColor -> HEXColor

    val rgbToXTerm : rgb : RGB -> XTerm
    val hexToXTerm : hex : HEX -> XTerm

    val rgbColorToXTermColor : rgbColor : RGBColor -> XTermColor
    val hexColorToXTermColor : hexColor : HEXColor -> XTermColor
