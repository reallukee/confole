(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Color.fs

    Title       : COLOR
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Color.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

module Color =
    open Common

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
                    | _ -> failwith "Inletid char"

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
                    | _ -> failwith "Inletid char"

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

    module RGB =
        let Acqua   : RGBColor = { red =   0; green = 255; blue = 255 }
        let Black   : RGBColor = { red =   0; green =   0; blue =   0 }
        let Blue    : RGBColor = { red =   0; green =   0; blue = 255 }
        let Fuchsia : RGBColor = { red = 255; green =   0; blue = 255 }
        let Gray    : RGBColor = { red = 128; green = 128; blue = 128 }
        let Green   : RGBColor = { red =   0; green = 128; blue =   0 }
        let Lime    : RGBColor = { red =   0; green = 255; blue =   0 }
        let Maroon  : RGBColor = { red = 128; green =   0; blue =   0 }
        let Navy    : RGBColor = { red =   0; green =   0; blue = 128 }
        let Olive   : RGBColor = { red = 128; green = 128; blue =   0 }
        let Purple  : RGBColor = { red = 128; green =   0; blue = 128 }
        let Red     : RGBColor = { red = 255; green =   0; blue =   0 }
        let Silver  : RGBColor = { red = 192; green = 192; blue = 192 }
        let Teal    : RGBColor = { red =   0; green = 128; blue = 128 }
        let White   : RGBColor = { red = 255; green = 255; blue = 255 }
        let Yellow  : RGBColor = { red = 255; green = 255; blue =   0 }

    module HEX =
        let Acqua   : HEXColor = { red = "00"; green = "FF"; blue = "FF" }
        let Black   : HEXColor = { red = "00"; green = "00"; blue = "00" }
        let Blue    : HEXColor = { red = "00"; green = "00"; blue = "FF" }
        let Fuchsia : HEXColor = { red = "FF"; green = "00"; blue = "FF" }
        let Gray    : HEXColor = { red = "80"; green = "80"; blue = "80" }
        let Green   : HEXColor = { red = "00"; green = "80"; blue = "00" }
        let Lime    : HEXColor = { red = "00"; green = "FF"; blue = "00" }
        let Maroon  : HEXColor = { red = "80"; green = "00"; blue = "00" }
        let Navy    : HEXColor = { red = "00"; green = "00"; blue = "80" }
        let Olive   : HEXColor = { red = "80"; green = "80"; blue = "00" }
        let Purple  : HEXColor = { red = "80"; green = "00"; blue = "80" }
        let Red     : HEXColor = { red = "FF"; green = "00"; blue = "00" }
        let Silver  : HEXColor = { red = "C0"; green = "C0"; blue = "C0" }
        let Teal    : HEXColor = { red = "00"; green = "80"; blue = "80" }
        let White   : HEXColor = { red = "FF"; green = "FF"; blue = "FF" }
        let Yellow  : HEXColor = { red = "FF"; green = "FF"; blue = "00" }
