(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fs

    Title       : FORMAT
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Format.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Test

open Xunit
open FsUnit.Xunit

open Reallukee.Confole.Color
open Reallukee.Confole.Position

open Reallukee.Confole.Format

[<Class>]
type Format () =

    [<Fact>]
    [<Trait("Category", "Format")>]
    member _.``render funziona?`` () =
        let testCases = [
            Restore, "\u001B[0m"

            RestoreForegroundColor, "\u001B[39m"
            RestoreBackgroundColor, "\u001B[49m"

            Bold      (Some true),  "\u001B[1m"
            Bold      (Some false), "\u001B[22m"
            Bold      None,         "\u001B[22m"
            Faint     (Some true),  "\u001B[2m"
            Faint     (Some false), "\u001B[22m"
            Faint     None,         "\u001B[22m"
            Italic    (Some true),  "\u001B[3m"
            Italic    (Some false), "\u001B[23m"
            Italic    None,         "\u001B[23m"
            Underline (Some true),  "\u001B[4m"
            Underline (Some false), "\u001B[24m"
            Underline None,         "\u001B[24m"
            Blinking  (Some true),  "\u001B[5m"
            Blinking  (Some false), "\u001B[25m"
            Blinking  None,         "\u001B[25m"
            Reverse   (Some true),  "\u001B[7m"
            Reverse   (Some false), "\u001B[27m"
            Reverse   None,         "\u001B[27m"
            Hidden    (Some true),  "\u001B[8m"
            Hidden    (Some false), "\u001B[28m"
            Hidden    None,         "\u001B[28m"
            Strikeout (Some true),  "\u001B[9m"
            Strikeout (Some false), "\u001B[29m"
            Strikeout None,         "\u001B[29m"

            ForegroundColor (Some (Color.RGB (255,  255,  255 ))), "\u001B[38;2;255;255;255m"
            ForegroundColor (Some (Color.HEX ("FF", "FF", "FF"))), "\u001B[38;2;255;255;255m"
            ForegroundColor (Some (Color.XTerm 128)),              "\u001B[38;5;128m"
            ForegroundColor None,                                  "\u001B[38;2;255;255;255m"
            BackgroundColor (Some (Color.RGB (0,     0,   0   ))), "\u001B[48;2;0;0;0m"
            BackgroundColor (Some (Color.HEX ("00", "00", "00"))), "\u001B[48;2;0;0;0m"
            BackgroundColor (Some (Color.XTerm 128)),              "\u001B[48;5;128m"
            BackgroundColor None,                                  "\u001B[48;2;0;0;0m"
        ]

        testCases
        |> List.iter (fun (format, expected) ->
            render "" format
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Format")>]
    member _.``renders funziona?`` () =
        let testCase =
            init()
            |> foregroundColor None
            |> backgroundColor None

        let expected = "\u001B[38;2;255;255;255m\u001B[48;2;0;0;0m"

        renders "" testCase
        |> should equal expected

    [<Fact>]
    [<Trait("Category", "Format")>]
    member _.``trunk funziona?`` () =
        let testCase =
            init()
            |> foregroundColor None
            |> foregroundColor (Some (Color.RGB (128, 128, 128)))
            |> foregroundColor (Some (Color.RGB (255, 255, 255)))
            |> backgroundColor None
            |> backgroundColor (Some (Color.RGB (128, 128, 128)))
            |> backgroundColor (Some (Color.RGB (0,   0,   0  )))

        let expected = [
            ForegroundColor (Some (Color.RGB (255, 255, 255)))
            BackgroundColor (Some (Color.RGB (0,   0,   0  )))
        ]

        trunk testCase
        |> should equal expected
