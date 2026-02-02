(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fs

    Title       : RULE
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Rule.

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

open Reallukee.Confole.Rule

[<Class>]
type Rule () =

    [<Fact>]
    [<Trait("Category", "Rule")>]
    member _.``render funziona?`` () =
        let testCases = [
            Title "Confole", "\u001B]0;Confole\u0007"

            ShowCursorBlinking, "\u001B[?12h"
            HideCursorBlinking, "\u001B[?12l"

            ShowCursor, "\u001B[?25h"
            HideCursor, "\u001B[?25l"

            EnableDesignateMode,  "\u001B(0"
            DisableDesignateMode, "\u001B(B"

            EnableAlternativeBuffer,  "\u001B[?1049h"
            DisableAlternativeBuffer, "\u001B[?1049l"

            CursorShape (Some Shape.User), "\u001B[0\u0020q"
            CursorShape None,              "\u001B[0\u0020q"

            DefaultForegroundColor (Some (Color.RGB (255,  255,  255 ))), "\u001B]10;rgb:FF/FF/FF\u001B\\"
            DefaultForegroundColor (Some (Color.HEX ("FF", "FF", "FF"))), "\u001B]10;rgb:FF/FF/FF\u001B\\"
            // DefaultForegroundColor (Some (Color.XTerm 128)),              "\u001B]10;rgb:FF/FF/FF\u001B\\"
            DefaultForegroundColor None,                                  "\u001B]10;rgb:FF/FF/FF\u001B\\"
            DefaultBackgroundColor (Some (Color.RGB (0,    0,    0   ))), "\u001B]11;rgb:00/00/00\u001B\\"
            DefaultBackgroundColor (Some (Color.HEX ("00", "00", "00"))), "\u001B]11;rgb:00/00/00\u001B\\"
            // DefaultBackgroundColor (Some (Color.XTerm 128)),              "\u001B]11;rgb:00/00/00\u001B\\"
            DefaultBackgroundColor None,                                  "\u001B]11;rgb:00/00/00\u001B\\"
            DefaultCursorColor (Some (Color.RGB (255,  255,  255 ))),     "\u001B]12;rgb:FF/FF/FF\u001B\\"
            DefaultCursorColor (Some (Color.HEX ("FF", "FF", "FF"))),     "\u001B]12;rgb:FF/FF/FF\u001B\\"
            // DefaultCursorColor (Some (Color.XTerm 128)),                  "\u001B]12;rgb:FF/FF/FF\u001B\\"
            DefaultCursorColor None,                                      "\u001B]12;rgb:FF/FF/FF\u001B\\"
        ]

        testCases
        |> List.iter (fun (Rule, expected) ->
            render Rule
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Rule")>]
    member _.``renders funziona?`` () =
        let testCase =
            init()
            |> showCursor
            |> hideCursor

        let expected = "\u001B[?25h\u001B[?25l"

        renders testCase
        |> should equal expected

    [<Fact>]
    [<Trait("Category", "Rule")>]
    member _.``trunk funziona?`` () =
        let testCase =
            init()
            |> defaultForegroundColor None
            |> defaultForegroundColor (Some (Color.RGB (255,  255,  255 )))
            |> defaultForegroundColor (Some (Color.HEX ("FF", "FF", "FF")))
            // |> defaultForegroundColor (Some (Color.XTerm 128))
            |> defaultBackgroundColor None
            |> defaultBackgroundColor (Some (Color.RGB (0,    0,    0   )))
            |> defaultBackgroundColor (Some (Color.HEX ("00", "00", "00")))
            // |> defaultBackgroundColor (Some (Color.XTerm 128))
            |> defaultCursorColor     None
            |> defaultCursorColor     (Some (Color.RGB (255,  255,  255 )))
            |> defaultCursorColor     (Some (Color.HEX ("FF", "FF", "FF")))
            // |> defaultCursorColor     (Some (Color.XTerm 128))

        let expected = [
            DefaultForegroundColor (Some (Color.HEX ("FF", "FF", "FF")))
            DefaultBackgroundColor (Some (Color.HEX ("00", "00", "00")))
            DefaultCursorColor     (Some (Color.HEX ("FF", "FF", "FF")))
        ]

        trunk testCase
        |> should equal expected
