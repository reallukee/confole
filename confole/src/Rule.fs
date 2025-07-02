namespace Reallukee.Confole

open Color

module Rule =
    type Rule =
        | ShowCursor
        | HideCursor
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Rules = Rule List

    let initRules =
        []

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
        | ShowCursor -> printf "\x1b[?25h"
        | HideCursor -> printf "\x1b[?25l"
        | ForegroundColor color ->
            match color with
            | RGB (red, green, blue) ->
                printf "\x1b[38;2;%d;%d;%dm" red green blue
            | RGBColor (color) ->
                printf "\x1b[38;2;%d;%d;%dm" color.red color.green color.blue
            | _ -> printf ""
        | BackgroundColor color ->
            match color with
            | RGB (red, green, blue) ->
                printf "\x1b[48;2;%d;%d;%dm" red green blue
            | RGBColor (color) ->
                printf "\x1b[48;2;%d;%d;%dm" color.red color.green color.blue
            | _ -> printf ""

    let applyRules rules =
        rules
        |> List.iter (fun item ->
            applyRule item
        )
