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
type Color = class end



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

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
