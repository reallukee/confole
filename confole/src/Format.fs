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
        | Bold      | NoBold
        | Faint     | NoFaint
        | Italic    | NoItalic
        | Underline | NoUnderline
        | Blinking  | NoBlinking
        | Reverse   | NoReverse
        | Hidden    | NoHidden
        | Strikeout | NoStrikeout
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Formats = Format List

    let init () : Formats =
        []

    let bold formats = Bold :: formats
    let noBold formats = NoBold :: formats

    let faint formats = Faint :: formats
    let noFaint formats = NoFaint :: formats

    let italic formats = Italic :: formats
    let noItalic formats = NoItalic :: formats

    let underline formats = Underline :: formats
    let noUnderline formats = NoUnderline :: formats

    let blinking formats = Blinking :: formats
    let noBlinking formats = NoBlinking :: formats

    let reverse formats = Reverse :: formats
    let noReverse formats = NoReverse :: formats

    let hidden formats = Hidden :: formats
    let noHidden formats = NoHidden :: formats

    let strikeout formats = Strikeout :: formats
    let noStrikeout formats = NoStrikeout :: formats

    let foregroundColor color formats =
        ForegroundColor color :: formats

    let backgroundColor color formats =
        BackgroundColor color :: formats

    let apply text format =
        match format with
        | Bold        -> printf "\x1b[1m%s" text
        | NoBold      -> printf "\x1b[22m%s" text
        | Faint       -> printf "\x1b[2m%s" text
        | NoFaint     -> printf "\x1b[22%s" text
        | Italic      -> printf "\x1b[3m%s" text
        | NoItalic    -> printf "\x1b[23m%s" text
        | Underline   -> printf "\x1b[4m%s" text
        | NoUnderline -> printf "\x1b[24m%s" text
        | Blinking    -> printf "\x1b[5m%s" text
        | NoBlinking  -> printf "\x1b[25%s" text
        | Reverse     -> printf "\x1b[7m%s" text
        | NoReverse   -> printf "\x1b[27m%s" text
        | Hidden      -> printf "\x1b[8m%s" text
        | NoHidden    -> printf "\x1b[28m%s" text
        | Strikeout   -> printf "\x1b[9m%s" text
        | NoStrikeout -> printf "\x1b[29m%s" text
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

    let applyAll text formats =
        formats
        |> List.rev
        |> List.iter (fun item ->
            apply "" item
        )

        printf "%s\x1b[0m" text

    let reset text =
        [
            NoBold
            NoFaint
            NoItalic
            NoUnderline
            NoBlinking
            NoReverse
            NoHidden
            NoStrikeout
            ForegroundColor (RGB (255, 255, 255))
            BackgroundColor (RGB (0, 0, 0))
        ]
        |> applyAll text
