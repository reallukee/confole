(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
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
        | Up           of n        : int option
        | Down         of n        : int option
        | Next         of n        : int option
        | Previous     of n        : int option
        | NextLine     of n        : int option
        | PreviousLine of n        : int option
        | Move         of position : Position option

    type Cursors = Cursor list



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



    let init () : Cursors = []

    let initPreset (cursors : Cursors) =
        cursors

    let clear (cursors : Cursors) : Cursors = []

    let view (cursors : Cursors) =
        cursors
        |> List.rev
        |> List.iter (fun cursor ->
            printfn "%A" cursor
        )



    let apply cursor =
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
                match defaultArg position (ColRow (0, 0)) with
                | ColRow (col, row) -> col + 1, row + 1
                | Cell cell -> cell.col + 1, cell.row + 1
                | _ -> failwith "Unsupported position format!"

            printf "%s%d;%dH" CSI row col

        | _ -> failwith "Not yet implemented!"

    let applyNewLine cursor =
        apply cursor

        printfn ""

    let applyAll cursors =
        cursors
        |> List.rev
        |> List.iter (fun cursor ->
            apply cursor
        )

    let applyAllNewLine cursors =
        applyAll cursors

        printfn ""



    let reset () =
        [
            Move (Some (ColRow (0, 0)))
        ]
        |> applyAll



    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""



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



    let doReverse () = apply Reverse
    let doSave    () = apply Save
    let doRestore () = apply Restore

    let doUp       n = apply (Up n)
    let doDown     n = apply (Down n)
    let doNext     n = apply (Next n)
    let doPrevious n = apply (Previous n)

    let doNextLine     n = apply (NextLine n)
    let doPreviousLine n = apply (PreviousLine n)

    let doMove position = apply (Move position)
