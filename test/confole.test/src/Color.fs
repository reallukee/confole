(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Color.fs

    Title       : COLOR
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Color.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Color

module Color =

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``xTermToXTermColor funziona?`` () =
        let id = 120

        let xTermColor = xTermToXTermColor id

        xTermColor.id
        |> should equal id

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``rgbToRGBColor funziona?`` () =
        let red   = 255
        let green = 255
        let blue  = 255

        let rgb = red, green, blue

        let rgbColor = rgbToRGBColor rgb

        rgbColor.red
        |> should equal red

        rgbColor.green
        |> should equal green

        rgbColor.blue
        |> should equal blue

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``hexToHEXColor funziona?`` () =
        let red   = "FF"
        let green = "FF"
        let blue  = "FF"

        let hex = "FF", "FF", "FF"

        let hexColor = hexToHEXColor hex

        hexColor.red
        |> should equal red

        hexColor.green
        |> should equal green

        hexColor.blue
        |> should equal blue

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``xTermColorToXTerm funziona?`` () =
        let xTermColor = {
            id = 120
        }

        let xTerm = xTermColorToXTerm xTermColor

        xTerm
        |> should equal xTermColor.id

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``rgbColorToRGB funziona?`` () =
        let rgbColor : RGBColor = {
            red   = 255
            green = 255
            blue  = 255
        }

        let red, green, blue = rgbColorToRGB rgbColor

        red
        |> should equal rgbColor.red

        green
        |> should equal rgbColor.green

        blue
        |> should equal rgbColor.blue

    [<Fact>]
    [<Trait("Category", "Color")>]
    let ``hexColorToHEX funziona?`` () =
        let hexColor : HEXColor = {
            red   = "FF"
            green = "FF"
            blue  = "FF"
        }

        let red, green, blue = hexColorToHEX hexColor

        red
        |> should equal hexColor.red

        green
        |> should equal hexColor.green

        blue
        |> should equal hexColor.blue
