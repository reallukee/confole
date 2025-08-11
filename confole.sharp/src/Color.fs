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

    let mutable id = 0

    new(id) as this =
        XTermColor() then

        this.Id <- id

    member this.Id
        with get() =
            id

        and set(value) =
            id <- value

    override this.Equals(obj) =
        match obj with
        | :? XTermColor as other ->
            this.Id = other.Id
        | _ -> false

    override this.GetHashCode() =
        hash(id)

    override this.ToString() =
        $"{this.Id}"

type RGBColor() =
    inherit Color()

    let mutable red   = 0
    let mutable green = 0
    let mutable blue  = 0

    new(red, green, blue) as this =
        RGBColor() then

        this.Red   <- red
        this.Green <- green
        this.Blue  <- blue

    member this.Red
        with get() =
            red

        and set(value) =
            red <- value

    member this.Green
        with get() =
            green

        and set(value) =
            green <- value

    member this.Blue
        with get() =
            blue

        and set(value) =
            blue <- value

    override this.Equals(obj) =
        match obj with
        | :? RGBColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode() =
        hash(red, green, blue)

    override this.ToString() =
        $"RGB({this.Red}, {this.Green}, {this.Blue})"

type HEXColor() =
    inherit Color()

    let mutable red   = "0"
    let mutable green = "0"
    let mutable blue  = "0"

    new(red, green, blue) as this =
        HEXColor() then

        this.Red   <- red
        this.Green <- green
        this.Blue  <- blue

    member this.Red
        with get() =
            red

        and set(value) =
            red <- value

    member this.Green
        with get() =
            green

        and set(value) =
            green <- value

    member this.Blue
        with get() =
            blue

        and set(value) =
            blue <- value

    override this.Equals(obj) =
        match obj with
        | :? HEXColor as other ->
            this.Red   = other.Red   &&
            this.Green = other.Green &&
            this.Blue  = other.Blue
        | _ -> false

    override this.GetHashCode() =
        hash(red, green, blue)

    override this.ToString() =
        $"#{this.Red:X2}{this.Green:X2}{this.Blue:X2}"
