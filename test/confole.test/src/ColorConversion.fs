(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : ColorConversion.fs

    Title       : COLOR CONVERSION
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo ColorConversion.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Color
open Reallukee.Confole.ColorConversion

type ColorConversion () =

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``hexToRGB funziona?`` () =
        let hex = "FF", "FA", "86"

        let rgb = 255, 250, 134

        hexToRGB hex
        |> should equal rgb

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``rgbToHEX funziona?`` () =
        let rgb = 255, 250, 134

        let hex = "FF", "FA", "86"

        rgbToHEX rgb
        |> should equal hex

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``hexColorToRGBColor funziona?`` () =
        let hexColor : HEXColor = {
            red   = "FF"
            green = "FA"
            blue  = "86"
        }

        let rgbColor : RGBColor = {
            red   = 255
            green = 250
            blue  = 134
        }

        hexColorToRGBColor hexColor
        |> should equal rgbColor

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``rgbColorToHEXColor funziona?`` () =
        let rgbColor : RGBColor = {
            red   = 255
            green = 250
            blue  = 134
        }

        let hexColor : HEXColor = {
            red   = "FF"
            green = "FA"
            blue  = "86"
        }

        rgbColorToHEXColor rgbColor
        |> should equal hexColor



    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``xTermToRGB funziona?`` () =
        let rgb = Array.concat [
            [|
                let levels = [|
                    0; 95; 135; 175; 215; 255
                |]

                for red in levels do
                    for green in levels do
                        for blue in levels do
                            yield red, green, blue
            |]
            [|
                for i in 0 .. 23 ->
                    let value = 8 + i * 10

                    value, value, value
            |]
        ]

        [|
            for i in 16 .. 255 -> i
        |]
        |> Array.iter (fun xTerm ->
            let rgb =
                match Array.tryItem (xTerm - 16) rgb with
                | Some color -> color
                | None -> failwith "Can't be None!"

            xTermToRGB xTerm
            |> should equal rgb
        )

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``xTermToHEX funziona?`` () =
        let hex = Array.concat [
            [|
                let levels = [|
                    0; 95; 135; 175; 215; 255
                |]

                for red in levels do
                    for green in levels do
                        for blue in levels do
                            yield rgbToHEX(red, green, blue)
            |]
            [|
                for i in 0 .. 23 ->
                    let value = 8 + i * 10

                    rgbToHEX(value, value, value)
            |]
        ]

        [|
            for i in 16 .. 255 -> i
        |]
        |> Array.iter (fun xTerm ->
            let hex =
                match Array.tryItem (xTerm - 16) hex with
                | Some color -> color
                | None -> failwith "Can't be None!"

            xTermToHEX xTerm
            |> should equal hex
        )



    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``rgbToXTerm funziona?`` () =
        Array.concat [
            [|
                let levels = [|
                    0; 95; 135; 175; 215; 255
                |]

                for red in levels do
                    for green in levels do
                        for blue in levels do
                            yield red, green, blue
            |]
            [|
                for i in 0 .. 23 ->
                    let value = 8 + i * 10

                    value, value, value
            |]
        ]
        |> Array.iteri (fun index rgb ->
            rgbToXTerm rgb
            |> should equal (index + 16)
        )

    [<Fact>]
    [<Trait("Category", "ColorConversion")>]
    member _.``hexToXTerm funziona?`` () =
        Array.concat [
            [|
                let levels = [|
                    0; 95; 135; 175; 215; 255
                |]

                for red in levels do
                    for green in levels do
                        for blue in levels do
                            yield rgbToHEX(red, green, blue)
            |]
            [|
                for i in 0 .. 23 ->
                    let value = 8 + i * 10

                    rgbToHEX(value, value, value)
            |]
        ]
        |> Array.iteri (fun index hex ->
            hexToXTerm hex
            |> should equal (index + 16)
        )
