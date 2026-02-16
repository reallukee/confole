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

open Microsoft.FSharp.Reflection

open Color
open ColorConversion
open Position
open PositionConversion

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

    type Cursors = Cursor list

    let defaultCursors = [
        Move None
    ]



    (*
        NOTA IMPLEMENTATIVA
        ===================

        Per motivi prestazionali, la lista di Cursor viene
        composta in ordine inverso. Prima di eseguire
        qualsiasi operazione di valutazione o consumo, la
        lista viene quindi riordinata correttamente.

        Per questo motivo è FORTEMENTE sconsigliato creare la
        lista manualmente senza usufruire delle funzioni
        appositamente fornite.

        Il core del modulo è DE FACTO "render" (la funzione
        definita qui sotto :O). Render ottiene un Cursor e
        lo converte in stringa.
    *)

    // Modalità manuale
    let render cursor =
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
            let position = defaultArg position (Position.RowCol (1, 1))

            let row, col =
                match position with
                | RowCol (row, col) -> row     ,    col
                | Cell   cell       -> cell.row,    cell.col
                | XY     (x, y)     -> y       + 1, x        + 1
                | Coord  coord      -> coord.y + 1, coord.x  + 1
                | position -> failwithf "%A: Unsupported position format!" position

            sprintf "%s%d;%dH" CSI row col

        | cursor -> failwithf "%A: Not yet implemented!" cursor

    let renders cursors =
        cursors
        |> List.rev
        |> List.map (fun cursor ->
            render cursor
        )
        |> String.concat ""

    let renderReverse () = render Reverse
    let renderSave    () = render Save
    let renderRestore () = render Restore

    let renderUp       n = render (Up       n)
    let renderDown     n = render (Down     n)
    let renderNext     n = render (Next     n)
    let renderPrevious n = render (Previous n)

    let renderNextLine     n = render (NextLine     n)
    let renderPreviousLine n = render (PreviousLine n)

    let renderMove position = render (Move position)

    let renderReset () = renders defaultCursors



    // Modalità funzionale
    let init () : Cursors = []

    let initWith (cursors : Cursors) = cursors

    let trunk (cursors : Cursors) =
        cursors
        |> List.distinctBy (fun item ->
            let caseInfo, _ = FSharpValue.GetUnionFields(item, typeof<Cursor>)

            caseInfo.Tag
        )
        |> List.rev

    let clear (cursors : Cursors) : Cursors = []

    let view (cursors : Cursors) =
        cursors
        |> List.rev
        |> List.iteri (fun index cursor ->
            printfn "%010d : %A" index cursor
        )

        cursors

    let preview cursors =
        cursors
        |> trunk
        |> view

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
        printf "%s" (render cursor)

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



    // Modalità DSL
    type Builder () =

        member _.Yield cursorFunction : Cursors -> Cursors =
            cursorFunction

        member _.Combine (cursor : Cursors -> Cursors, cursorFunction) : Cursors -> Cursors =
            cursor >> cursorFunction

        member _.Delay ``function`` : Cursors -> Cursors =
            ``function`` ()

        member _.Run cursorsFunction : Cursors =
            cursorsFunction (init ())



    // Modalità imperativa
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
