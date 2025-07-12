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
open Position

module Rule =
    type Rule =
        | Title                  of string
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | DefaultForegroundColor of Color
        | DefaultBackgroundColor of Color
        | DefaultCursorColor     of Color

    type Rules = Rule List

    let init () : Rules =
        []

    let title value rules = Title value :: rules

    let showCursorBlinking rules = ShowCursorBlinking :: rules
    let hideCursorBlinking rules = HideCursorBlinking :: rules

    let showCursor rules = ShowCursor :: rules
    let hideCursor rules = HideCursor :: rules

    let defaultForegroundColor color rules = DefaultForegroundColor color :: rules
    let defaultBackgroundColor color rules = DefaultBackgroundColor color :: rules
    let defaultCursorColor color rules = DefaultCursorColor color :: rules

    let apply newLine rule =
        match rule with
        | Title value -> printf "\x1b]0;%s\x07" value

        | ShowCursorBlinking -> printf "\x1b[?12h"
        | HideCursorBlinking -> printf "\x1b[?12l"

        | ShowCursor -> printf "\x1b[?25h"
        | HideCursor -> printf "\x1b[?25l"

        | DefaultForegroundColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "\x1b]10;rgb:%s/%s/%s\x1b\\" red green blue
        | DefaultBackgroundColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "\x1b]11;rgb:%s/%s/%s\x1b\\" red green blue
        | DefaultCursorColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "\x1b]12;rgb:%s/%s/%s\x1b\\" red green blue

        | _ -> failwith "Not yet implemented!"

        if newLine then
            printfn ""

    let applyAll newLine rules =
        rules
        |> List.rev
        |> List.iter (fun item ->
            apply false item
        )

        if newLine then
            printfn ""

    let reset () =
        [
            ShowCursorBlinking

            ShowCursor

            DefaultForegroundColor (RGB (255, 255, 255))
            DefaultBackgroundColor (RGB (0, 0, 0))
            DefaultCursorColor     (RGB (255, 255, 255))
        ]
        |> applyAll false
