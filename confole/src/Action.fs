(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Action.fs

    Title       : ACTION
    Description : Action

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Action =
    let private ESC = "\u001B"
    let private CSI = "\u001B["
    let private OSC = "\u001B]"

    let private BELL = "\u0007"
    let private SP   = "\u0020"

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

    let init () : Actions = []

    let insertCharacter n actions = InsertCharacter n :: actions
    let deleteCharacter n actions = DeleteCharacter n :: actions

    let insertLine n actions = InsertLine n :: actions
    let deleteLine n actions = DeleteLine n :: actions

    let eraseDisplay erase actions = EraseDisplay erase :: actions
    let eraseLine    erase actions = EraseLine    erase :: actions

    let clear (actions : Actions) : Actions = []

    let view (actions : Actions) =
        actions
        |> List.rev
        |> List.iter (fun action ->
            printfn "%A" action
        )

    let apply newLine action =
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

        if newLine then
            printfn ""

    let applyAll newLine actions =
        actions
        |> List.rev
        |> List.iter (fun action ->
            apply false action
        )

        if newLine then
            printfn ""

    let reset () =
        []
        |> applyAll false

    let configure newLine config =
        init ()
        |> config
        |> applyAll newLine

    type Builder () =
        member _.Yield actionF : Actions -> Actions =
            actionF

        member _.Combine (acc : Actions -> Actions, actionF) : Actions -> Actions =
            acc >> actionF

        member _.Delay f : Actions -> Actions =
            f ()

        member _.Run actionsF : Actions =
            actionsF (init ())

    let builder = Builder ()
