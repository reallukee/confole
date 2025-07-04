(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Rule.fs

    Title       : RULE
    Description : Rule

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color

module Rule =
    type Rule =
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor

    type Rules = Rule List

    let init () : Rules =
        []

    let showCursorBlinking rules = ShowCursorBlinking :: rules
    let hideCursorBlinking rules = HideCursorBlinking :: rules

    let showCursor rules = ShowCursor :: rules
    let hideCursor rules = HideCursor :: rules

    let apply rule =
        match rule with
        | ShowCursorBlinking -> printf "\x1b[?12h"
        | HideCursorBlinking -> printf "\x1b[?12l"
        | ShowCursor -> printf "\x1b[?25h"
        | HideCursor -> printf "\x1b[?25l"

    let applyAll rules =
        rules
        |> List.rev
        |> List.iter (fun item ->
            apply item
        )

    let reset () =
        [
            ShowCursorBlinking
            ShowCursor
        ]
        |> applyAll
