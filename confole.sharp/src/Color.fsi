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
                  Questo modulo wrappa anche i moduli Colors
                  e ColorConversion.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

[<AbstractClass>]
type Color =

    internal new : unit -> Color

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFColor : color : Color -> Color.Color

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPColor : color : Color.Color -> Color



and XTermColor =

    inherit Color

    new : unit       -> XTermColor
    new : id   : int -> XTermColor

    member Id : int with get, set

    static member FromRGB : red : int    * green : int    * blue : int    -> XTermColor
    static member FromHEX : red : string * green : string * blue : string -> XTermColor
    static member FromId  : id  : int                                     -> XTermColor

    static member FromRGBColor : rgbColor : RGBColor -> XTermColor
    static member FromHEXColor : hexColor : HEXColor -> XTermColor

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFXTerm      : xTermColor : XTermColor -> Color.XTerm
    static member internal ToFXTermColor : xTermColor : XTermColor -> Color.XTermColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPXTermColor : xTerm      : Color.XTerm      -> XTermColor
    static member internal ToOOPXTermColor : xTermColor : Color.XTermColor -> XTermColor



and RGBColor =

    inherit Color

    new : unit                                  -> RGBColor
    new : red  : int * green : int * blue : int -> RGBColor

    member Red   : int with get, set
    member Green : int with get, set
    member Blue  : int with get, set

    static member FromRGB : red : int    * green : int    * blue : int    -> RGBColor
    static member FromHEX : red : string * green : string * blue : string -> RGBColor
    static member FromId  : id  : int                                     -> RGBColor

    static member FromHEXColor   : hexColor   : HEXColor   -> RGBColor
    static member FromXTermColor : xTermColor : XTermColor -> RGBColor

    static member Get    : color : string                              -> RGBColor
    static member TryGet : color : string * outColor : byref<RGBColor> -> bool
    static member Exists : color : string                              -> bool

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToRGB      : rgbColor : RGBColor -> Color.RGB
    static member internal ToRGBColor : rgbColor : RGBColor -> Color.RGBColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPRGBColor : rgb      : Color.RGB      -> RGBColor
    static member internal ToOOPRGBColor : rgbColor : Color.RGBColor -> RGBColor



and HEXColor =

    inherit Color

    new : unit                                           -> HEXColor
    new : red  : string * green : string * blue : string -> HEXColor

    member Red   : string with get, set
    member Green : string with get, set
    member Blue  : string with get, set

    static member FromHEX : red : string * green : string * blue : string -> HEXColor
    static member FromRGB : red : int    * green : int    * blue : int    -> HEXColor
    static member FromId  : id  : int                                     -> HEXColor

    static member FromRGBColor   : rgbColor   : RGBColor   -> HEXColor
    static member FromXTermColor : xTermColor : XTermColor -> HEXColor

    static member Get    : color : string                              -> HEXColor
    static member TryGet : color : string * outColor : byref<HEXColor> -> bool
    static member Exists : color : string                              -> bool

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToHEX      : hexColor : HEXColor -> Color.HEX
    static member internal ToHEXColor : hexColor : HEXColor -> Color.HEXColor

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPHEXColor : hex      : Color.HEX      -> HEXColor
    static member internal ToOOPHEXColor : hexColor : Color.HEXColor -> HEXColor
