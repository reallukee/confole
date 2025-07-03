(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Format.fs

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color

module Format =
    type Format =
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format List

    let initFormat () : Formats =
        []

    let foregroundColor color formats =
        ForegroundColor color :: formats

    let backgroundColor color formats =
        BackgroundColor color :: formats

    let applyFormat text format =
        match format with
        | ForegroundColor color ->
            match color with
            | XTerm (color) ->
                printf "\x1b[38;5;%dm%s" color text
            | XTermColor (color) ->
                printf "\x1b[38;5;%dm%s" color.id text
            | RGB (red, green, blue) ->
                printf "\x1b[38;2;%d;%d;%dm%s" red green blue text
            | RGBColor (color) ->
                printf "\x1b[38;2;%d;%d;%dm%s" color.red color.green color.blue text
            | HEX (red, green, blue) ->
                let red, green, blue = hexToRGB red green blue

                printf "\x1b[38;2;%d;%d;%dm%s" red green blue text
            | HEXColor (color) ->
                let color = hexColorToRGBColor color

                printf "\x1b[38;2;%d;%d;%dm%s" color.red color.green color.blue text
        | BackgroundColor color ->
            match color with
            | XTerm (color) ->
                printf "\x1b[48;5;%dm%s" color text
            | XTermColor (color) ->
                printf "\x1b[48;5;%dm%s" color.id text
            | RGB (red, green, blue) ->
                printf "\x1b[48;2;%d;%d;%dm%s" red green blue text
            | RGBColor (color) ->
                printf "\x1b[48;2;%d;%d;%dm%s" color.red color.green color.blue text
            | HEX (red, green, blue) ->
                let red, green, blue = hexToRGB red green blue

                printf "\x1b[48;2;%d;%d;%dm%s" red green blue text
            | HEXColor (color) ->
                let color = hexColorToRGBColor color

                printf "\x1b[48;2;%d;%d;%dm%s" color.red color.green color.blue text

    let applyFormats text formats =
        formats
        |> List.iter (fun item ->
            applyFormat "" item
        )

        printf "%s\x1b[0m" text

    let resetFormats text =
        [
            ForegroundColor (RGB (255, 255, 255))
            BackgroundColor (RGB (0, 0, 0))
        ]
        |> applyFormats text
