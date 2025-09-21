(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Action.fs

    Title       : ACTION
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Action.
                  Il modulo Action si occupa di sequenze VTS
                  relative al viewport del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Action =
    open Common

    type Erase =
        | FromCurrentToEnd
        | FromBeginToCurrent
        | FromBeginToEnd

    type Action =
        | InsertCharacter of int
        | DeleteCharacter of int
        | InsertLine      of int
        | DeleteLine      of int
        | EraseDisplay    of Erase option
        | EraseLine       of Erase option

    type Actions = Action list



    let insertCharacter n actions = InsertCharacter n :: actions
    let deleteCharacter n actions = DeleteCharacter n :: actions

    let insertLine n actions = InsertLine n :: actions
    let deleteLine n actions = DeleteLine n :: actions

    let eraseDisplay erase actions = EraseDisplay erase :: actions
    let eraseLine    erase actions = EraseLine    erase :: actions



    let init () : Actions = []

    let clear (actions : Actions) : Actions = []

    let view (actions : Actions) =
        actions
        |> List.rev
        |> List.iter (fun action ->
            printfn "%A" action
        )



    let apply action =
        match action with
        | InsertCharacter n -> printf "%s%d@" CSI n
        | DeleteCharacter n -> printf "%s%dP" CSI n

        | InsertLine n -> printf "%s%dL" CSI n
        | DeleteLine n -> printf "%s%dM" CSI n

        | EraseDisplay erase ->
            let erase =
                match erase with
                | Some FromCurrentToEnd   -> 0
                | Some FromBeginToCurrent -> 1
                | Some FromBeginToEnd     -> 2
                | None                    -> 2

            printf "%s%dJ" CSI erase
        | EraseLine erase ->
            let erase =
                match erase with
                | Some FromCurrentToEnd   -> 0
                | Some FromBeginToCurrent -> 1
                | Some FromBeginToEnd     -> 2
                | None                    -> 2

            printf "%s%dK" CSI erase

        | _ -> failwith "Not yet implemented!"

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
        []
        |> applyAll



    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""



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
    let doEraseLine    erase = apply (EraseLine erase)
