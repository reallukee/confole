namespace Reallukee.Confole

module Color =
    type RGBColor = {
        red : int
        green : int
        blue : int
    }

    type HEXColor = {
        red : string
        green : string
        blue : string
    }

    type Color =
        | RGB of int * int * int
        | HEX of string * string * string
        | RGBColor of RGBColor
        | HEXColor of HEXColor
