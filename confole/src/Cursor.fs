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

                  Il modulo Cursor permette di ottenere gli
                  stessi risultati con 4 approcci diversi:

                  * Manuale
                  * Funzionale
                  * Imperativo
                  * DSL

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open ColorConversion
open Position
open PositionConversion

// Cur
module Cursor =

    type Cursor =
        | Reverse                                    // RVS
        | Save                                       // SV
        | Restore                                    // RST
        | Up           of n        : int option      // U
        | Down         of n        : int option      // D
        | Next         of n        : int option      // NX
        | Previous     of n        : int option      // PV
        | NextLine     of n        : int option      // NXL
        | PreviousLine of n        : int option      // PVL
        | Move         of position : Position option // MV

    let RVS          = Reverse
    let SV           = Save
    let RST          = Restore
    let U   n        = Up           n
    let D   n        = Down         n
    let NX  n        = Next         n
    let PV  n        = Previous     n
    let NXL n        = NextLine     n
    let PVL n        = PreviousLine n
    let MV  position = Move         position

    type Cursors = Cursor list

    let defaultCursors = [
        Move None
    ]



    let getCursor cursor =
        match cursor with
        | Reverse -> sprintf "%sM" ESC
        | Save    -> sprintf "%s7" ESC
        | Restore -> sprintf "%s8" ESC

        | Up       n -> sprintf "%sA%d" CSI (defaultArg n 1)
        | Down     n -> sprintf "%sB%d" CSI (defaultArg n 1)
        | Next     n -> sprintf "%sC%d" CSI (defaultArg n 1)
        | Previous n -> sprintf "%sD%d" CSI (defaultArg n 1)

        | NextLine     n -> sprintf "%sE%d" CSI (defaultArg n 1)
        | PreviousLine n -> sprintf "%sF%d" CSI (defaultArg n 1)

        | Move position ->
            let position = defaultArg position (RowCol (0, 0))

            let row, col =
                match position with
                | RowCol (row, col) -> row + 1, col + 1
                | Cell cell -> cell.row + 1, cell.col + 1
                | XY (x, y) -> y + 1, x + 1
                | Coord coord -> coord.y + 1, coord.x + 1
                | position -> failwithf "%A: Unsupported position format!" position

            sprintf "%s%d;%dH" CSI row col

        | cursor -> failwithf "%A: Not yet implemented!" cursor

    let getCursors cursors =
        cursors
        |> List.rev
        |> List.map (fun cursor ->
            getCursor cursor
        )
        |> String.concat ""

    let getReverse () = getCursor Reverse
    let getSave    () = getCursor Save
    let getRestore () = getCursor Restore

    let getUp       n = getCursor (Up       n)
    let getDown     n = getCursor (Down     n)
    let getNext     n = getCursor (Next     n)
    let getPrevious n = getCursor (Previous n)

    let getNextLine     n = getCursor (NextLine     n)
    let getPreviousLine n = getCursor (PreviousLine n)

    let getMove position = getCursor (Move position)

    let getReset () = getCursors defaultCursors

    let getRVS = getReverse
    let getSV  = getSave
    let getRST = getRestore

    let getU  = getUp
    let getD  = getDown
    let getNX = getNext
    let getPV = getPrevious

    let getNXL = getNextLine
    let getPVL = getPreviousLine

    let getMV = getMove



    let init () : Cursors = []

    let initp (cursors : Cursors) = cursors

    let clear (cursors : Cursors) : Cursors = []

    let view (cursors : Cursors) =
        cursors
        |> List.rev
        |> List.iter (fun cursor ->
            printfn "%A" cursor
        )

        cursors

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

    let apply cursor =
        printf "%s" (getCursor cursor)

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
        defaultCursors
        |> applyAll

    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""

    let rvs = reverse
    let sv  = save
    let rst = restore

    let u  = up
    let d  = down
    let nx = next
    let pv = previous

    let nxl = nextLine
    let pvl = previousLine

    let mv = move



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

    let doUp       n = apply (Up       n)
    let doDown     n = apply (Down     n)
    let doNext     n = apply (Next     n)
    let doPrevious n = apply (Previous n)

    let doNextLine     n = apply (NextLine     n)
    let doPreviousLine n = apply (PreviousLine n)

    let doMove position = apply (Move position)

    let doReset () = reset ()

    let doRVS = doReverse
    let doSV  = doSave
    let doRST = doRestore

    let doU  = doUp
    let doD  = doDown
    let doNX = doNext
    let doPV = doPrevious

    let doNXL = doNextLine
    let doPVL = doPreviousLine

    let doMV = doMove
