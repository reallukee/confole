(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Cursor.

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

open Reallukee.Confole.Cursor

[<Class>]
type Cursor () =

    [<Fact>]
    [<Trait("Category", "Cursor")>]
    member _.``render funziona?`` () =
        let testCases = [
            Reverse, "\u001BM"
            Save,    "\u001B7"
            Restore, "\u001B8"

            Up       (Some 3), "\u001B[A3"
            Up       (Some 1), "\u001B[A1"
            Up       None,     "\u001B[A1"
            Down     (Some 3), "\u001B[B3"
            Down     (Some 1), "\u001B[B1"
            Down     None,     "\u001B[B1"
            Next     (Some 3), "\u001B[C3"
            Next     (Some 1), "\u001B[C1"
            Next     None,     "\u001B[C1"
            Previous (Some 3), "\u001B[D3"
            Previous (Some 1), "\u001B[D1"
            Previous None,     "\u001B[D1"

            NextLine     (Some 3), "\u001B[E3"
            NextLine     (Some 1), "\u001B[E1"
            NextLine     None,     "\u001B[E1"
            PreviousLine (Some 3), "\u001B[F3"
            PreviousLine (Some 1), "\u001B[F1"
            PreviousLine None,     "\u001B[F1"

            Move (Some (Position.RowCol (2, 4))), "\u001B[2;4H"
            Move (Some (Position.RowCol (1, 1))), "\u001B[1;1H"
            Move None,                            "\u001B[1;1H"
            Move (Some (Position.XY     (3, 1))), "\u001B[2;4H"
            Move (Some (Position.XY     (0, 0))), "\u001B[1;1H"
            Move None,                            "\u001B[1;1H"
        ]

        testCases
        |> List.iter (fun (cursor, expected) ->
            render cursor
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Cursor")>]
    member _.``renders funziona?`` () =
        let testCase =
            init()
            |> up       None
            |> down     None
            |> next     None
            |> previous None

        let expected = "\u001B[A1\u001B[B1\u001B[C1\u001B[D1"

        renders testCase
        |> should equal expected

    [<Fact>]
    [<Trait("Category", "Cursor")>]
    member _.``trunk funziona?`` () =
        let testCase =
            init()
            |> up       None
            |> up       (Some 1)
            |> up       (Some 3)
            |> down     None
            |> down     (Some 1)
            |> down     (Some 3)
            |> next     None
            |> next     (Some 1)
            |> next     (Some 3)
            |> previous None
            |> previous (Some 1)
            |> previous (Some 3)

        let expected = [
            Up       (Some 3)
            Down     (Some 3)
            Next     (Some 3)
            Previous (Some 3)
        ]

        trunk testCase
        |> should equal expected
