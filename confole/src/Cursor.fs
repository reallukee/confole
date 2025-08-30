(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

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
    let private SP   = "\u0020"

    type Cursor =
        | Reverse
        | Save
        | Restore
        | Up           of int option
        | Down         of int option
        | Next         of int option
        | Previous     of int option
        | NextLine     of int option
        | PreviousLine of int option
        | Move         of Position

    type Cursors = Cursor list

    let init () : Cursors = []

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

    let clear (cursors : Cursors) : Cursors = []

    let view (cursors : Cursors) =
        cursors
        |> List.rev
        |> List.iter (fun cursor ->
            printfn "%A" cursor
        )

    let apply newLine cursor =
        match cursor with
        | Reverse -> printf "%sM" ESC
        | Save    -> printf "%s7" ESC
        | Restore -> printf "%s8" ESC

        | Up       n -> printf "%sA%d" CSI (defaultArg n 1)
        | Down     n -> printf "%sB%d" CSI (defaultArg n 1)
        | Next     n -> printf "%sC%d" CSI (defaultArg n 1)
        | Previous n -> printf "%sD%d" CSI (defaultArg n 1)

        | NextLine     n -> printf "%sE%d" CSI (defaultArg n 1)
        | PreviousLine n -> printf "%sF%d" CSI (defaultArg n 1)

        | Move position ->
            let col, row =
                match position with
                | ColRow (col, row) -> col + 1, row + 1
                | Cell cell -> cell.col + 1, cell.row + 1
                | _ -> failwith "Unsupported position format!"

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
        member _.Yield cursorFunction : Cursors -> Cursors =
            cursorFunction

        member _.Combine (cursor : Cursors -> Cursors, cursorFunction) : Cursors -> Cursors =
            cursor >> cursorFunction

        member _.Delay ``function`` : Cursors -> Cursors =
            ``function`` ()

        member _.Run cursorsFunction : Cursors =
            cursorsFunction (init ())

    let builder = Builder ()
