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
open Position

module Format =
    let private ESC = "\u001B"
    let private CSI = "\u001B["
    let private OSC = "\u001B]"

    let private BELL = "\u0007"
    let private SP   = "\u0020"

    type Format =
        | Restore
        | Bold                   of bool
        | Faint                  of bool
        | Italic                 of bool
        | Underline              of bool
        | Blinking               of bool
        | Reverse                of bool
        | Hidden                 of bool
        | Strikeout              of bool
        | RestoreForegroundColor
        | RestoreBackgroundColor
        | ForegroundColor        of Color
        | BackgroundColor        of Color

    type Formats = Format list

    let init () : Formats = []

    let restore formats = Restore :: formats

    let bold      flag formats = Bold      flag :: formats
    let faint     flag formats = Faint     flag :: formats
    let italic    flag formats = Italic    flag :: formats
    let underline flag formats = Underline flag :: formats
    let blinking  flag formats = Blinking  flag :: formats
    let reverse   flag formats = Reverse   flag :: formats
    let hidden    flag formats = Hidden    flag :: formats
    let strikeout flag formats = Strikeout flag :: formats

    let restoreForegroundColor formats = RestoreForegroundColor :: formats
    let restoreBackgroundColor formats = RestoreBackgroundColor :: formats

    let foregroundColor color formats = ForegroundColor color :: formats
    let backgroundColor color formats = BackgroundColor color :: formats

    let clear (formats : Formats) : Formats = []

    let view (formats : Formats) =
        formats
        |> List.rev
        |> List.iter (fun format ->
            printfn "%A" format
        )

    let apply newLine text format =
        match format with
        | Restore -> printf "%s0m%s" CSI text

        | Bold      flag -> printf "%s%dm%s" CSI (if flag then 1 else 22) text
        | Faint     flag -> printf "%s%dm%s" CSI (if flag then 2 else 22) text
        | Italic    flag -> printf "%s%dm%s" CSI (if flag then 3 else 23) text
        | Underline flag -> printf "%s%dm%s" CSI (if flag then 4 else 24) text
        | Blinking  flag -> printf "%s%dm%s" CSI (if flag then 5 else 25) text
        | Reverse   flag -> printf "%s%dm%s" CSI (if flag then 7 else 27) text
        | Hidden    flag -> printf "%s%dm%s" CSI (if flag then 8 else 28) text
        | Strikeout flag -> printf "%s%dm%s" CSI (if flag then 9 else 29) text

        | RestoreForegroundColor -> printf "%s39m%s" CSI text
        | RestoreBackgroundColor -> printf "%s49m%s" CSI text

        | ForegroundColor color ->
            match color with
            | XTerm id ->
                printf "%s38;5;%dm%s" CSI id text
            | XTermColor color ->
                printf "%s38;5;%dm%s" CSI color.id text
            | _ ->
                colorToRGB color
                |> fun (red, green, blue) ->
                    printf "%s38;2;%d;%d;%dm%s" CSI red green blue text
        | BackgroundColor color ->
            match color with
            | XTerm id ->
                printf "%s48;5;%dm%s" CSI id text
            | XTermColor color ->
                printf "%s48;5;%dm%s" CSI color.id text
            | _ ->
                colorToRGB color
                |> fun (red, green, blue) ->
                    printf "%s48;2;%d;%d;%dm%s" CSI red green blue text

        | _ -> failwith "Not yet implemented!"

        if newLine then
            printfn ""

    let applyAll newLine text formats =
        formats
        |> List.rev
        |> List.iter (fun item ->
            apply false "" item
        )

        printf "%s%s0m" text CSI

        if newLine then
            printfn ""

    let reset text =
        [
            Restore

            Bold      false
            Faint     false
            Italic    false
            Underline false
            Blinking  false
            Reverse   false
            Hidden    false
            Strikeout false

            ForegroundColor (RGB (255, 255, 255))
            BackgroundColor (RGB (0, 0, 0))
        ]
        |> applyAll false text

    let configure newLine text config =
        init ()
        |> config
        |> applyAll newLine text

    type Builder () =
        member _.Yield formatF : Formats -> Formats =
            formatF

        member _.Combine (acc : Formats -> Formats, formatF) : Formats -> Formats =
            acc >> formatF

        member _.Delay f : Formats -> Formats =
            f ()

        member _.Run formatsF : Formats =
            formatsF (init ())

    let builder = Builder ()
