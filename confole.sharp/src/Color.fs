(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Color.fs

    Title       : COLOR
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Color.
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
type Color () =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFColor (color : Color) =
        match color with
        // XTerm
        | :? XTermColor as xTermColor -> Color.XTerm (xTermColor.Id)
        // RGB
        | :? RGBColor   as rgbColor   -> Color.RGB   (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
        // HEX
        | :? HEXColor   as hexColor   -> Color.HEX   (hexColor.Red, hexColor.Green, hexColor.Blue)
        | color -> failwithf "%A: Unsupported color format!" color

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPColor (color : Color.Color) : Color =
        match color with
        | Color.XTerm      xTerm      -> XTermColor.toOOPXTermColor (xTerm)
        | Color.XTermColor xTermColor -> XTermColor.toOOPXTermColor (xTermColor)
        | Color.RGB        rgb        -> RGBColor.toOOPRGBColor     (rgb)
        | Color.RGBColor   rgbColor   -> RGBColor.toOOPRGBColor     (rgbColor)
        | Color.HEX        hex        -> HEXColor.toOOPHEXColor     (hex)
        | Color.HEXColor   hexColor   -> HEXColor.toOOPHEXColor     (hexColor)
        | color -> failwithf "%A: Unsupported color format!" color



and XTermColor () =

    inherit Color ()

    let mutable id = 0



    new id as this =
        XTermColor () then
            this.Id <- id



    member this.Id
        with get () =
            id

        and set value =
            id <- value



    static member fromId id =
        new XTermColor (id)

    static member fromRGB (red, green, blue) =
        let id = ColorConversion.rgbToXTerm (red, green, blue)

        new XTermColor (id)

    static member fromHEX (red, green, blue) =
        let id = ColorConversion.hexToXTerm (red, green, blue)

        new XTermColor (id)



    static member fromRGBColor (rgbColor : RGBColor) =
        let id = ColorConversion.rgbToXTerm (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

        new XTermColor (id)

    static member fromHEXColor (hexColor : HEXColor) =
        let id = ColorConversion.hexToXTerm (hexColor.Red, hexColor.Green, hexColor.Blue)

        new XTermColor (id)



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFXTerm (xTermColor : XTermColor) =
        xTermColor.Id

    static member internal toFXTermColor (xTermColor : XTermColor) =
        Color.xTermToXTermColor xTermColor.Id

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPXTermColor (xTerm : Color.XTerm) =
        let id = xTerm

        new XTermColor (id)

    static member internal toOOPXTermColor (xTermColor : Color.XTermColor) =
        new XTermColor (xTermColor.id)



    override this.Equals obj =
        match obj with
        | :? XTermColor as other ->
            this.Id = other.Id
        | _ -> false

    override this.GetHashCode () =
        hash this.Id

    override this.ToString () =
        $"XTermColor({this.Id})"



and RGBColor () =

    inherit Color ()

    let mutable red   = 0
    let mutable green = 0
    let mutable blue  = 0



    new (red, green, blue) as this =
        RGBColor () then
            this.Red   <- red
            this.Green <- green
            this.Blue  <- blue



    member this.Red
        with get () =
            red

        and set value =
            red <- value

    member this.Green
        with get () =
            green

        and set value =
            green <- value

    member this.Blue
        with get () =
            blue

        and set value =
            blue <- value



    static member fromRGB (red, green, blue) =
        new RGBColor (red, green, blue)

    static member fromHEX (red, green, blue) =
        let red, green, blue = ColorConversion.hexToRGB (red, green, blue)

        new RGBColor (red, green, blue)

    static member fromId id =
        let red, green, blue = ColorConversion.xTermToRGB id

        new RGBColor (red, green, blue)



    static member fromHEXColor (hexColor : HEXColor) =
        let red, green, blue = ColorConversion.hexToRGB (hexColor.Red, hexColor.Green, hexColor.Blue)

        new RGBColor (red, green, blue)

    static member fromXTermColor (xTermColor : XTermColor) =
        let red, green, blue = ColorConversion.xTermToRGB xTermColor.Id

        new RGBColor (red, green, blue)



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toRGB (rgbColor : RGBColor) =
        rgbColor.Red, rgbColor.Green, rgbColor.Blue

    static member internal toRGBColor (rgbColor : RGBColor) =
        Color.rgbToRGBColor (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPRGBColor (rgb : Color.RGB) =
        let red, green, blue = rgb

        new RGBColor (red, green, blue)

    static member internal toOOPRGBColor (rgbColor : Color.RGBColor) =
        new RGBColor (rgbColor.red, rgbColor.green, rgbColor.blue)



    override this.Equals obj =
        match obj with
        | :? RGBColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode () =
        hash (this.Red, this.Green, this.Blue)

    override this.ToString () =
        $"RGBColor({this.Red}, {this.Green}, {this.Blue})"



and HEXColor () =

    inherit Color ()

    let mutable red   = "00"
    let mutable green = "00"
    let mutable blue  = "00"



    new (red, green, blue) as this =
        HEXColor () then
            this.Red   <- red
            this.Green <- green
            this.Blue  <- blue



    member this.Red
        with get () =
            red

        and set value =
            red <- value

    member this.Green
        with get () =
            green

        and set value =
            green <- value

    member this.Blue
        with get () =
            blue

        and set value =
            blue <- value



    static member fromHEX (red, green, blue) =
        new HEXColor (red, green, blue)

    static member fromRGB (red, green, blue) =
        let red, green, blue = ColorConversion.rgbToHEX (red, green, blue)

        new HEXColor (red, green, blue)

    static member fromId id =
        let red, green, blue = ColorConversion.xTermToHEX id

        new HEXColor (red, green, blue)



    static member fromRGBColor (rgbColor : RGBColor) =
        let red, green, blue = ColorConversion.rgbToHEX (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

        new HEXColor (red, green, blue)

    static member fromXTermColor (xTermColor : XTermColor) =
        let red, green, blue = ColorConversion.xTermToHEX xTermColor.Id

        new HEXColor (red, green, blue)



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toHEX (hexColor : HEXColor) =
        hexColor.Red, hexColor.Green, hexColor.Blue

    static member internal toHEXColor (hexColor : HEXColor) =
        Color.hexToHEXColor (hexColor.Red, hexColor.Green, hexColor.Blue)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPHEXColor (hex : Color.HEX) =
        let red, green, blue = hex

        new HEXColor (red, green, blue)

    static member internal toOOPHEXColor (hexColor : Color.HEXColor) =
        new HEXColor (hexColor.red, hexColor.green, hexColor.blue)



    override this.Equals obj =
        match obj with
        | :? HEXColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode () =
        hash (this.Red, this.Green, this.Blue)

    override this.ToString () =
        $"HEXColor({this.Red:X2}, {this.Green:X2}, {this.Blue:X2})"
