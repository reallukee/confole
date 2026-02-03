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
type Color internal () =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFColor (color : Color) =
        match color with
        // XTerm
        | :? XTermColor as xTermColor -> Color.XTerm xTermColor.Id
        // RGB
        | :? RGBColor   as rgbColor   -> Color.RGB   (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
        // HEX
        | :? HEXColor   as hexColor   -> Color.HEX   (hexColor.Red, hexColor.Green, hexColor.Blue)
        | color -> failwithf "%A: Unsupported color format!" color

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPColor (color : Color.Color) : Color =
        match color with
        | Color.XTerm      xTerm      -> XTermColor.ToOOPXTermColor xTerm
        | Color.XTermColor xTermColor -> XTermColor.ToOOPXTermColor xTermColor
        | Color.RGB        rgb        -> RGBColor.ToOOPRGBColor     rgb
        | Color.RGBColor   rgbColor   -> RGBColor.ToOOPRGBColor     rgbColor
        | Color.HEX        hex        -> HEXColor.ToOOPHEXColor     hex
        | Color.HEXColor   hexColor   -> HEXColor.ToOOPHEXColor     hexColor
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



    static member FromId id =
        new XTermColor (id)

    static member FromRGB (red, green, blue) =
        let id = ColorConversion.rgbToXTerm (red, green, blue)

        new XTermColor (id)

    static member FromHEX (red, green, blue) =
        let id = ColorConversion.hexToXTerm (red, green, blue)

        new XTermColor (id)



    static member FromRGBColor (rgbColor : RGBColor) =
        let id = ColorConversion.rgbToXTerm (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

        new XTermColor (id)

    static member FromHEXColor (hexColor : HEXColor) =
        let id = ColorConversion.hexToXTerm (hexColor.Red, hexColor.Green, hexColor.Blue)

        new XTermColor (id)



    override this.Equals obj =
        match obj with
        | :? XTermColor as other ->
            this.Id = other.Id
        | _ -> false

    override this.GetHashCode () =
        hash this.Id

    override this.ToString () =
        $"XTermColor({this.Id})"



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFXTerm (xTermColor : XTermColor) =
        xTermColor.Id

    static member internal ToFXTermColor (xTermColor : XTermColor) =
        Color.xTermToXTermColor xTermColor.Id

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPXTermColor (xTerm : Color.XTerm) =
        let id = xTerm

        new XTermColor (id)

    static member internal ToOOPXTermColor (xTermColor : Color.XTermColor) =
        new XTermColor (xTermColor.id)



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



    static member FromRGB (red, green, blue) =
        new RGBColor (red, green, blue)

    static member FromHEX (red, green, blue) =
        let red, green, blue = ColorConversion.hexToRGB (red, green, blue)

        new RGBColor (red, green, blue)

    static member FromId id =
        let red, green, blue = ColorConversion.xTermToRGB id

        new RGBColor (red, green, blue)



    static member FromHEXColor (hexColor : HEXColor) =
        let red, green, blue = ColorConversion.hexToRGB (hexColor.Red, hexColor.Green, hexColor.Blue)

        new RGBColor (red, green, blue)

    static member FromXTermColor (xTermColor : XTermColor) =
        let red, green, blue = ColorConversion.xTermToRGB xTermColor.Id

        new RGBColor (red, green, blue)



    static member Get color =
        let color = Colors.RGB.get color Colors.RGB.Format.RGB

        let red, green, blue =
            match color with
            | Color.Color.RGB (red, green, blue) -> red, green, blue
            | _ -> failwith "It can't happen :)"

        RGBColor.FromRGB (red, green, blue)

    static member TryGet (color, outColor : byref<RGBColor>) =
        let color = Colors.RGB.tryGet color Colors.RGB.Format.RGB

        match color with
        | Some color ->
            let red, green, blue =
                match color with
                | Color.Color.RGB (red, green, blue) -> red, green, blue
                | _ -> failwith "It can't happen :)"

            outColor <- RGBColor.FromRGB (red, green, blue)

            true

        | None -> false

    static member Exists color =
        Colors.RGB.exists color



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



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToRGB (rgbColor : RGBColor) =
        rgbColor.Red, rgbColor.Green, rgbColor.Blue

    static member internal ToRGBColor (rgbColor : RGBColor) =
        Color.rgbToRGBColor (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPRGBColor (rgb : Color.RGB) =
        let red, green, blue = rgb

        new RGBColor (red, green, blue)

    static member internal ToOOPRGBColor (rgbColor : Color.RGBColor) =
        new RGBColor (rgbColor.red, rgbColor.green, rgbColor.blue)



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



    static member FromHEX (red, green, blue) =
        new HEXColor (red, green, blue)

    static member FromRGB (red, green, blue) =
        let red, green, blue = ColorConversion.rgbToHEX (red, green, blue)

        new HEXColor (red, green, blue)

    static member FromId id =
        let red, green, blue = ColorConversion.xTermToHEX id

        new HEXColor (red, green, blue)



    static member FromRGBColor (rgbColor : RGBColor) =
        let red, green, blue = ColorConversion.rgbToHEX (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

        new HEXColor (red, green, blue)

    static member FromXTermColor (xTermColor : XTermColor) =
        let red, green, blue = ColorConversion.xTermToHEX xTermColor.Id

        new HEXColor (red, green, blue)



    static member Get color =
        let color = Colors.HEX.get color Colors.HEX.Format.HEX

        let red, green, blue =
            match color with
            | Color.Color.HEX (red, green, blue) -> red, green, blue
            | _ -> failwith "It can't happen :)"

        HEXColor.FromHEX (red, green, blue)

    static member TryGet (color, outColor : byref<HEXColor>) =
        let color = Colors.HEX.tryGet color Colors.HEX.Format.HEX

        match color with
        | Some color ->
            let red, green, blue =
                match color with
                | Color.Color.HEX (red, green, blue) -> red, green, blue
                | _ -> failwith "It can't happen :)"

            outColor <- HEXColor.FromHEX (red, green, blue)

            true

        | None -> false

    static member Exists color =
        Colors.HEX.exists color



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



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToHEX (hexColor : HEXColor) =
        hexColor.Red, hexColor.Green, hexColor.Blue

    static member internal ToHEXColor (hexColor : HEXColor) =
        Color.hexToHEXColor (hexColor.Red, hexColor.Green, hexColor.Blue)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPHEXColor (hex : Color.HEX) =
        let red, green, blue = hex

        new HEXColor (red, green, blue)

    static member internal ToOOPHEXColor (hexColor : Color.HEXColor) =
        new HEXColor (hexColor.red, hexColor.green, hexColor.blue)
