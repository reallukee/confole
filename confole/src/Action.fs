(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Action.fs

    Title       : ACTION
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Action.
                  Il modulo Action si occupa di sequenze VTS
                  relative al viewport del terminale.

                  Il modulo Action permette di ottenere gli
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

module Action =

    type Erase =
        | FromCurrentToEnd
        | FromBeginToCurrent
        | FromBeginToEnd

    type Action =
        | InsertCharacter of n    : int option   // IC
        | DeleteCharacter of n    : int option   // DC
        | InsertLine      of n    : int option   // IL
        | DeleteLine      of n    : int option   // DL
        | EraseDisplay    of mode : Erase option // ED
        | EraseLine       of mode : Erase option // EL

    let IC n     = InsertCharacter n
    let DC n     = DeleteCharacter n
    let IL n     = InsertLine      n
    let DL n     = DeleteLine      n
    let ED erase = EraseDisplay    erase
    let EL erase = EraseLine       erase

    type Actions = Action list

    let private defaultActions : Actions = []



    let getAction action =
        match action with
        | InsertCharacter n -> sprintf "%s%d@" CSI (Option.defaultValue 1 n)
        | DeleteCharacter n -> sprintf "%s%dP" CSI (Option.defaultValue 1 n)

        | InsertLine n -> sprintf "%s%dL" CSI (Option.defaultValue 1 n)
        | DeleteLine n -> sprintf "%s%dM" CSI (Option.defaultValue 1 n)

        | EraseDisplay erase ->
            let erase =
                match erase with
                | Some FromCurrentToEnd   -> 0
                | Some FromBeginToCurrent -> 1
                | Some FromBeginToEnd     -> 2
                | None                    -> 2

            sprintf "%s%dJ" CSI erase
        | EraseLine erase ->
            let erase =
                match erase with
                | Some FromCurrentToEnd   -> 0
                | Some FromBeginToCurrent -> 1
                | Some FromBeginToEnd     -> 2
                | None                    -> 2

            sprintf "%s%dK" CSI erase

        | action -> failwithf "%A: Not yet implemented!" action

    let getActions actions =
        actions
        |> List.map (fun action ->
            getAction action
        )
        |> String.concat ""

    let getInsertCharacter n = getAction (InsertCharacter n)
    let getDeleteCharacter n = getAction (DeleteCharacter n)

    let getInsertLine n = getAction (InsertLine n)
    let getDeleteLine n = getAction (DeleteLine n)

    let getEraseDisplay erase = getAction (EraseDisplay erase)
    let getEraseLine    erase = getAction (EraseLine    erase)

    let getReset () = getActions defaultActions

    let getIC = getInsertCharacter
    let getDC = getDeleteCharacter

    let getIL  = getInsertLine
    let getDL  = getDeleteLine

    let getED  = getEraseDisplay
    let getEL  = getEraseLine



    let init () : Actions = []

    let initPreset (actions : Actions) = actions

    let clear (actions : Actions) : Actions = []

    let view (actions : Actions) =
        actions
        |> List.rev
        |> List.iter (fun action ->
            printfn "%A" action
        )

    let insertCharacter n actions = InsertCharacter n :: actions
    let deleteCharacter n actions = DeleteCharacter n :: actions

    let insertLine n actions = InsertLine n :: actions
    let deleteLine n actions = DeleteLine n :: actions

    let eraseDisplay erase actions = EraseDisplay erase :: actions
    let eraseLine    erase actions = EraseLine    erase :: actions

    let apply action =
        printf "%s" (getAction action)

    let applyNewLine action =
        apply action

        printfn ""

    let applyAll actions =
        actions
        |> List.rev
        |> List.iter (fun action ->
            apply action
        )

    let applyAllNewLine actions =
        applyAll actions

        printfn ""

    let reset () =
        defaultActions
        |> applyAll

    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""

    let ic = insertCharacter
    let dc = deleteCharacter

    let il = insertLine
    let dl = deleteLine

    let ed = eraseDisplay
    let el = eraseLine



    type Builder () =
        member _.Yield actionFunction : Actions -> Actions =
            actionFunction

        member _.Combine (action : Actions -> Actions, actionFunction) : Actions -> Actions =
            action >> actionFunction

        member _.Delay ``function`` : Actions -> Actions =
            ``function`` ()

        member _.Run actionsFunction : Actions =
            actionsFunction (init ())

    let builder = Builder ()



    let doInsertCharacter n = apply (InsertCharacter n)
    let doDeleteCharacter n = apply (DeleteCharacter n)

    let doInsertLine n = apply (InsertLine n)
    let doDeleteLine n = apply (DeleteLine n)

    let doEraseDisplay erase = apply (EraseDisplay erase)
    let doEraseLine    erase = apply (EraseLine    erase)

    let doReset () = reset ()

    let doIC = doInsertCharacter
    let doDC = doDeleteCharacter

    let doIL = doInsertLine
    let doDL = doDeleteLine

    let doED = doEraseDisplay
    let doEL = doEraseLine
