(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Format.fs

    Title       : FORMAT
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Format.
                  Il modulo Format si occupa di sequenze VTS
                  relative alla formattazione del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Format =
    open Common

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



    let init () : Formats = []

    let clear (formats : Formats) : Formats = []

    let view (formats : Formats) =
        formats
        |> List.rev
        |> List.iter (fun format ->
            printfn "%A" format
        )



    let apply text format =
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

    let applyNewLine text format =
        apply text format

        printfn ""

    let applyAll text formats =
        formats
        |> List.rev
        |> List.iter (fun item ->
            apply "" item
        )

        printf "%s" text

    let applyAllNewLine text formats =
        applyAll text formats

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
        |> applyAll text



    let configure text config =
        init ()
        |> config
        |> applyAll text

    let configureNewLine text config =
        configure text config

        printfn ""



    type Builder () =
        member _.Yield formatFunction : Formats -> Formats =
            formatFunction

        member _.Combine (format : Formats -> Formats, formatFunction) : Formats -> Formats =
            format >> formatFunction

        member _.Delay ``function`` : Formats -> Formats =
            ``function``  ()

        member _.Run formatsFunction : Formats =
            formatsFunction (init ())

    let builder = Builder ()



    let doRestore text = apply text Restore

    let doBold      text flag = apply text (Bold flag)
    let doFaint     text flag = apply text (Faint flag)
    let doItalic    text flag = apply text (Italic flag)
    let doUnderline text flag = apply text (Underline flag)
    let doBlinking  text flag = apply text (Blinking flag)
    let doReverse   text flag = apply text (Reverse flag)
    let doHidden    text flag = apply text (Hidden flag)
    let doStrikeout text flag = apply text (Strikeout flag)

    let doRestoreForegroundColor text = apply text RestoreForegroundColor
    let doRestoreBackgroundColor text = apply text RestoreForegroundColor

    let doForegroundColor text color = apply text (ForegroundColor color)
    let doBackgroundColor text color = apply text (BackgroundColor color)
