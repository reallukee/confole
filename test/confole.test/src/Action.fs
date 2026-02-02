(*
    ------------
    Confole Test
    ------------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Action.fs

    Title       : ACTION
    Description : Contiene le funzioni di test delle funzionalità
                  pubbliche del modulo Action.

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

open Reallukee.Confole.Action

[<Class>]
type Action () =

    [<Fact>]
    [<Trait("Category", "Action")>]
    member _.``render funziona?`` () =
        let testCases = [
            InsertCharacter (Some 1), "\u001B[1@"
            InsertCharacter (Some 3), "\u001B[3@"
            InsertCharacter None,     "\u001B[1@"
            DeleteCharacter (Some 1), "\u001B[1P"
            DeleteCharacter (Some 3), "\u001B[3P"
            DeleteCharacter None,     "\u001B[1P"

            InsertLine (Some 1), "\u001B[1L"
            InsertLine (Some 3), "\u001B[3L"
            InsertLine None,     "\u001B[1L"
            DeleteLine (Some 1), "\u001B[1M"
            DeleteLine (Some 3), "\u001B[3M"
            DeleteLine None,     "\u001B[1M"

            EraseDisplay (Some Erase.FromCurrentToEnd), "\u001B[0J"
            EraseDisplay None,                          "\u001B[2J"
            EraseLine    (Some Erase.FromCurrentToEnd), "\u001B[0K"
            EraseLine    None,                          "\u001B[2K"
        ]

        testCases
        |> List.iter (fun (action, expected) ->
            render action
            |> should equal expected
        )

    [<Fact>]
    [<Trait("Category", "Action")>]
    member _.``renders funziona?`` () =
        let testCase =
            init()
            |> insertCharacter None
            |> deleteCharacter None
            |> insertLine      None
            |> deleteLine      None

        let expected = "\u001B[1@\u001B[1P\u001B[1L\u001B[1M"

        renders testCase
        |> should equal expected

    [<Fact>]
    [<Trait("Category", "Action")>]
    member _.``trunk funziona?`` () =
        let testCase =
            init()
            |> insertCharacter None
            |> insertCharacter (Some 1)
            |> insertCharacter (Some 3)
            |> deleteCharacter None
            |> deleteCharacter (Some 1)
            |> deleteCharacter (Some 3)

        let expected = [
            InsertCharacter (Some 3)
            DeleteCharacter (Some 3)
        ]

        trunk testCase
        |> should equal expected
