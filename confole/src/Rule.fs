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
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Rules = Rule List

    let initRules () : Rules =
        []

    let showCursorBlinking rules =
        ShowCursorBlinking :: rules

    let hideCursorBlinking rules =
        HideCursorBlinking :: rules

    let showCursor rules =
        ShowCursor :: rules

    let hideCursor rules =
        HideCursor :: rules

    let foregroundColor color rules =
        ForegroundColor color :: rules

    let backgroundColor color rules =
        BackgroundColor color :: rules

    let applyRule rule =
        match rule with
        | ShowCursorBlinking -> printf "\x1b[?12h"
        | HideCursorBlinking -> printf "\x1b[?12l"
        | ShowCursor -> printf "\x1b[?25h"
        | HideCursor -> printf "\x1b[?25l"
        | ForegroundColor color ->
            match color with
            | XTerm (color) ->
                printf "\x1b[38;5;%dm" color
            | XTermColor (color) ->
                printf "\x1b[38;5;%dm" color.id
            | RGB (red, green, blue) ->
                printf "\x1b[38;2;%d;%d;%dm" red green blue
            | RGBColor (color) ->
                printf "\x1b[38;2;%d;%d;%dm" color.red color.green color.blue
            | HEX (red, green, blue) ->
                let red, green, blue = hexToRGB red green blue

                printf "\x1b[38;2;%d;%d;%dm" red green blue
            | HEXColor (color) ->
                let color = hexColorToRGBColor color

                printf "\x1b[38;2;%d;%d;%dm" color.red color.green color.blue
        | BackgroundColor color ->
            match color with
            | XTerm (color) ->
                printf "\x1b[48;5;%dm" color
            | XTermColor (color) ->
                printf "\x1b[48;5;%dm" color.id
            | RGB (red, green, blue) ->
                printf "\x1b[48;2;%d;%d;%dm" red green blue
            | RGBColor (color) ->
                printf "\x1b[48;2;%d;%d;%dm" color.red color.green color.blue
            | HEX (red, green, blue) ->
                let red, green, blue = hexToRGB red green blue

                printf "\x1b[48;2;%d;%d;%dm" red green blue
            | HEXColor (color) ->
                let color = hexColorToRGBColor color

                printf "\x1b[48;2;%d;%d;%dm" color.red color.green color.blue

    let applyRules rules =
        rules
        |> List.iter (fun item ->
            applyRule item
        )

    let resetRules () =
        [
            ShowCursorBlinking
            ShowCursor
            ForegroundColor (RGB (255, 255, 255))
            BackgroundColor (RGB (0, 0, 0))
        ]
        |> applyRules
