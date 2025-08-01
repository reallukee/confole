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
    let private ESC = "\u001B"
    let private CSI = "\u001B["
    let private OSC = "\u001B]"

    let private BELL = "\u0007"

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

    type Cursors = Cursor list

    let init () : Cursors =
        []

    let reverse cursors = Reverse :: cursors
    let save    cursors = Save    :: cursors
    let restore cursors = Restore :: cursors

    let up       n cursors = Up       n :: cursors
    let down     n cursors = Down     n :: cursors
    let next     n cursors = Next     n :: cursors
    let previous n cursors = Previous n :: cursors

    let nextLine     n cursors = NextLine     n :: cursors
    let previousLine n cursors = PreviousLine n :: cursors

    let move position cursors = Move position :: cursors

    let clear (cursors : Cursors) : Cursors =
        []

    let apply newLine cursor =
        match cursor with
        | Reverse -> printf "%sM" ESC
        | Save    -> printf "%s7" ESC
        | Restore -> printf "%s8" ESC

        | Up       n -> printf "%sA%d" CSI n
        | Down     n -> printf "%sB%d" CSI n
        | Next     n -> printf "%sC%d" CSI n
        | Previous n -> printf "%sD%d" CSI n

        | NextLine     n -> printf "%sE%d" CSI n
        | PreviousLine n -> printf "%sF%d" CSI n

        | Move position ->
            let col, row =
                match position with
                | ColRow (col, row) -> col + 1, row + 1
                | Cell cell -> cell.col + 1, cell.row + 1
                | _ -> failwith "Unsupported position format"

            printf "%s%d;%dH" CSI row col

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
        [
            Move (ColRow (0, 0))
        ]
        |> applyAll false

    let configure newLine config =
        init ()
        |> config
        |> applyAll newLine

    type Builder () =
        member _.Yield cursorF : Cursors -> Cursors =
            cursorF

        member _.Combine (acc : Cursors -> Cursors, cursorF) : Cursors -> Cursors =
            acc >> cursorF

        member _.Delay f : Cursors -> Cursors =
            f ()

        member _.Run cursorsF : Cursors =
            cursorsF (init ())

    let builder = Builder ()
