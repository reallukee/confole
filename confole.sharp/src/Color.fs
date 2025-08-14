(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

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

type XTermColor() =
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

    override this.Equals(obj) =
        match obj with
        | :? XTermColor as other ->
            this.Id = other.Id
        | _ -> false

    override this.GetHashCode() =
        hash(this.Id)

    override this.ToString() =
        $"XTermColor({this.Id})"

type RGBColor() =
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

type HEXColor() =
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
