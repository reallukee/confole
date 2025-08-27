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
        | XTerm      of int
        | XTermColor of XTermColor
        | RGB        of int * int * int
        | RGBColor   of RGBColor
        | HEX        of string * string * string
        | HEXColor   of HEXColor

    let rgbToHEX rgb =
        let red, green, blue = rgb

        let red   = sprintf "%x" red
        let green = sprintf "%x" green
        let blue  = sprintf "%x" blue

        red, green, blue

    let hexToRGB hex =
        let red, green, blue = hex

        let hex (hex : string) =
            hex
            |> Seq.rev
            |> Seq.mapi (fun index item ->
                let value =
                    match item with
                    | c when c >= '0' && c <= '9' -> int c - int '0'
                    | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 10
                    | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 10
                    | _ -> failwith "Invalid char"

                value * pown 16 index
            )
            |> Seq.sum

        let red   = hex red
        let green = hex green
        let blue  = hex blue

        red, green, blue

    let rgbColorToHEXColor (rgbColor : RGBColor) : HEXColor =
        let red   = sprintf "%x" rgbColor.red
        let green = sprintf "%x" rgbColor.green
        let blue  = sprintf "%x" rgbColor.blue

        {
            red   = red
            green = green
            blue  = blue
        }

    let hexColorToRGBColor (hexColor : HEXColor) : RGBColor =
        let hex (hex : string) =
            hex
            |> Seq.rev
            |> Seq.mapi (fun index item ->
                let value =
                    match item with
                    | c when c >= '0' && c <= '9' -> int c - int '0'
                    | c when c >= 'A' && c <= 'Z' -> int c - int 'A' + 10
                    | c when c >= 'a' && c <= 'z' -> int c - int 'a' + 10
                    | _ -> failwith "Invalid char"

                value * pown 16 index
            )
            |> Seq.sum

        let red   = hex hexColor.red
        let green = hex hexColor.green
        let blue  = hex hexColor.blue

        {
            red   = red
            green = green
            blue  = blue
        }

    let colorToRGB color =
        match color with
        | RGB (red, green, blue) -> red, green, blue
        | RGBColor color -> color.red, color.green, color.blue

        | HEX (red, green, blue) -> hexToRGB (red, green, blue)
        | HEXColor color ->
            hexColorToRGBColor color
            |> fun color -> color.red, color.green, color.blue

        | _ -> failwith "Unsupported color format!"

    let colorToHEX color =
        match color with
        | RGB (red, green, blue) -> rgbToHEX (red, green, blue)
        | RGBColor color ->
            rgbColorToHEXColor color
            |> fun color -> color.red, color.green, color.blue

        | HEX (red, green, blue) -> red, green, blue
        | HEXColor color -> color.red, color.green, color.blue

        | _ -> failwith "Unsupported color format!"
