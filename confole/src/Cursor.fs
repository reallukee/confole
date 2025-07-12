(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Cursor

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Cursor =
    type Cursor =
        | Reverse
        | Save
        | Restore
        | Up           of int
        | Down         of int
        | Next         of int
        | Previous     of int
        | NextLine     of int
        | PreviousLine of int
        | Move         of Position

    type Cursors = Cursor List

    let init () : Cursors =
        []

    let reverse cursors = Reverse :: cursors
    let save cursors = Save :: cursors
    let restore cursors = Restore :: cursors

    let up n cursors = Up n :: cursors
    let down n cursors = Down n :: cursors
    let next n cursors = Next n :: cursors
    let previous n cursors = Previous n :: cursors

    let nextLine n cursors = NextLine n :: cursors
    let previousLine n cursors = PreviousLine n :: cursors

    let move position cursors = Move position :: cursors

    let apply newLine cursor =
        match cursor with
        | Reverse -> printf "\x1bM"
        | Save    -> printf "\x1b7"
        | Restore -> printf "\x1b8"

        | Up       n -> printf "\x1b[A%d" n
        | Down     n -> printf "\x1b[B%d" n
        | Next     n -> printf "\x1b[C%d" n
        | Previous n -> printf "\x1b[D%d" n

        | NextLine     n -> printf "\x1b[E%d" n
        | PreviousLine n -> printf "\x1b[F%d" n

        | Move position ->
            let col, row =
                match position with
                | ColRow (col, row) -> col + 1, row + 1
                | Cell cell -> cell.col + 1, cell.row + 1
                | _ -> failwith "Unsupported position format"

            printf "\x1b[%d;%dH" row col

        | _ -> failwith "Not yet implemented!"

        if newLine then
            printfn ""

    let applyAll newLine cursors =
        cursors
        |> List.rev
        |> List.iter (fun cursor ->
            apply false cursor
        )

        if newLine then
            printfn ""

    let reset () =
        []
        |> applyAll false
