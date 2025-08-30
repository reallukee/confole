(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Color.fs

    Title       : COLOR
    Description : Color

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

[<AbstractClass>]
type Color() = class end

and XTermColor() =
    inherit Color()

    let mutable id_ = 0

    new(id) as this =
        XTermColor() then

        this.Id <- id

    member this.Id
        with get() =
            id_

        and set(id) =
            id_ <- id

    static member fromId(id) =
        new XTermColor(id)

    override this.Equals(obj) =
        match obj with
        | :? XTermColor as other ->
            this.Id = other.Id
        | _ -> false

    override this.GetHashCode() =
        hash(this.Id)

    override this.ToString() =
        $"XTermColor({this.Id})"

and RGBColor() =
    inherit Color()

    let mutable red_   = 0
    let mutable green_ = 0
    let mutable blue_  = 0

    new(red, green, blue) as this =
        RGBColor() then

        this.Red   <- red
        this.Green <- green
        this.Blue  <- blue

    member this.Red
        with get() =
            red_

        and set(red) =
            red_ <- red

    member this.Green
        with get() =
            green_

        and set(green) =
            green_ <- green

    member this.Blue
        with get() =
            blue_

        and set(blue) =
            blue_ <- blue

    static member fromRGB(red, green, blue) =
        new RGBColor(red, green, blue)

    static member fromHEX(red, green, blue) =
        let red, green, blue = Reallukee.Confole.Color.hexToRGB (red, green, blue)

        new RGBColor(red, green, blue)

    static member fromHEXColor(hexColor : HEXColor) =
        let red, green, blue = Reallukee.Confole.Color.hexToRGB (hexColor.Red, hexColor.Green, hexColor.Blue)

        new RGBColor(red, green, blue)

    override this.Equals(obj) =
        match obj with
        | :? RGBColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode() =
        hash(this.Red, this.Green, this.Blue)

    override this.ToString() =
        $"RGBColor({this.Red}, {this.Green}, {this.Blue})"

and HEXColor() =
    inherit Color()

    let mutable red_   = "0"
    let mutable green_ = "0"
    let mutable blue_  = "0"

    new(red, green, blue) as this =
        HEXColor() then

        this.Red   <- red
        this.Green <- green
        this.Blue  <- blue

    member this.Red
        with get() =
            red_

        and set(red) =
            red_ <- red

    member this.Green
        with get() =
            green_

        and set(green) =
            green_ <- green

    member this.Blue
        with get() =
            blue_

        and set(blue) =
            blue_ <- blue

    static member fromHEX(red, green, blue) =
        new HEXColor(red, green, blue)

    static member fromRGB(red, green, blue) =
        let red, green, blue = Reallukee.Confole.Color.rgbToHEX (red, green, blue)

        new HEXColor(red, green, blue)

    static member fromHEXColor(rgbColor : RGBColor) =
        let red, green, blue = Reallukee.Confole.Color.rgbToHEX (rgbColor.Red, rgbColor.Green, rgbColor.Blue)

        new HEXColor(red, green, blue)

    override this.Equals(obj) =
        match obj with
        | :? HEXColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode() =
        hash(this.Red, this.Green, this.Blue)

    override this.ToString() =
        $"HEXColor({this.Red:X2}, {this.Green:X2}, {this.Blue:X2})"
