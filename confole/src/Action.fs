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
        | EraseDisplay of Erase
        | EraseLine    of Erase

    type Actions = Action list

    let init () : Actions = []

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
        | EraseDisplay erase ->
            let erase =
                match erase with
                | FromCurrentToEnd   -> 0
                | FromBeginToCurrent -> 1
                | FromBeginToEnd     -> 2

            printf "%s%dJ" CSI erase
        | EraseLine erase ->
            let erase =
                match erase with
                | FromCurrentToEnd   -> 0
                | FromBeginToCurrent -> 1
                | FromBeginToEnd     -> 2

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
