(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Color.fs

    Title       : COLOR
    Description : Color

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

module Color =
    type XTermColor = {
        id : int
    }

    type RGBColor = {
        red   : int
        green : int
        blue  : int
    }

    type HEXColor = {
        red   : string
        green : string
        blue  : string
    }

    type Color =
        | XTerm of int
        | XTermColor of XTermColor
        | RGB of int * int * int
        | HEX of string * string * string
        | RGBColor of RGBColor
        | HEXColor of HEXColor

    let rgbToHEX (red : int) (green : int) (blue : int) : string * string * string =
        let red   = sprintf "%x" red
        let green = sprintf "%x" green
        let blue  = sprintf "%x" blue

        red, green, blue

    let hexToRGB (red : string) (green : string) (blue : string) : int * int * int =
        let hex hex =
            hex
            |> Seq.rev
            |> Seq.mapi (fun index item ->
                let value =
                    match item with
                    | c when c >= '0' && c <= '9' -> int c - int '0'
                    | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 10
                    | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 10
                    | _ -> failwith ""

                value * pown 16 index
            )
            |> Seq.sum

        let red   = hex red
        let green = hex green
        let blue  = hex blue

        red, green, blue

    let rgbColorToHEXColor (color : RGBColor) : HEXColor =
        let red   = sprintf "%x" color.red
        let green = sprintf "%x" color.green
        let blue  = sprintf "%x" color.blue

        {
            red   = red
            green = green
            blue  = blue
        }

    let hexColorToRGBColor (color : HEXColor) : RGBColor =
        let hex hex =
            hex
            |> Seq.rev
            |> Seq.mapi (fun index item ->
                let value =
                    match item with
                    | c when c >= '0' && c <= '9' -> int c - int '0'
                    | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 10
                    | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 10
                    | _ -> failwith ""

                value * pown 16 index
            )
            |> Seq.sum

        let red   = hex color.red
        let green = hex color.green
        let blue  = hex color.blue

        {
            red   = red
            green = green
            blue  = blue
        }
