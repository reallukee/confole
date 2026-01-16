(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Color.fsi

    Title       : COLOR
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Color.
                  Il modulo Color si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

[<AbstractClass>]
type Color =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFColor : color : Color -> Color.Color

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPColor : color : Color.Color -> Color



and XTermColor =

    inherit Color

    new : unit       -> XTermColor
    new : id   : int -> XTermColor

    member Id : int with get, set

    static member fromRGB : red : int    * green : int    * blue : int    -> XTermColor
    static member fromHEX : red : string * green : string * blue : string -> XTermColor
    static member fromId  : id  : int                                     -> XTermColor

    static member fromRGBColor : rgbColor : RGBColor -> XTermColor
    static member fromHEXColor : hexColor : HEXColor -> XTermColor

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFXTerm      : xTermColor : XTermColor -> Color.XTerm
    static member internal toFXTermColor : xTermColor : XTermColor -> Color.XTermColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPXTermColor : xTerm      : Color.XTerm      -> XTermColor
    static member internal toOOPXTermColor : xTermColor : Color.XTermColor -> XTermColor

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string



and RGBColor =

    inherit Color

    new : unit                                  -> RGBColor
    new : red  : int * green : int * blue : int -> RGBColor

    member Red   : int with get, set
    member Green : int with get, set
    member Blue  : int with get, set

    static member fromRGB : red : int    * green : int    * blue : int    -> RGBColor
    static member fromHEX : red : string * green : string * blue : string -> RGBColor
    static member fromId  : id  : int                                     -> RGBColor

    static member fromHEXColor   : hexColor   : HEXColor   -> RGBColor
    static member fromXTermColor : xTermColor : XTermColor -> RGBColor

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toRGB      : rgbColor : RGBColor -> Color.RGB
    static member internal toRGBColor : rgbColor : RGBColor -> Color.RGBColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPRGBColor : rgb      : Color.RGB      -> RGBColor
    static member internal toOOPRGBColor : rgbColor : Color.RGBColor -> RGBColor

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string



and HEXColor =

    inherit Color

    new : unit                                           -> HEXColor
    new : red  : string * green : string * blue : string -> HEXColor

    member Red   : string with get, set
    member Green : string with get, set
    member Blue  : string with get, set

    static member fromHEX : red : string * green : string * blue : string -> HEXColor
    static member fromRGB : red : int    * green : int    * blue : int    -> HEXColor
    static member fromId  : id  : int                                     -> HEXColor

    static member fromRGBColor   : rgbColor   : RGBColor   -> HEXColor
    static member fromXTermColor : xTermColor : XTermColor -> HEXColor

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toHEX      : hexColor : HEXColor -> Color.HEX
    static member internal toHEXColor : hexColor : HEXColor -> Color.HEXColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPHEXColor : hex      : Color.HEX      -> HEXColor
    static member internal toOOPHEXColor : hexColor : Color.HEXColor -> HEXColor

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
