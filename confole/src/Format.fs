(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fs

    Title       : FORMAT
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Format.
                  Il modulo Format si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Il modulo Format permette di ottenere gli
                  stessi risultati con 4 approcci diversi:

                  * Manuale
                  * Funzionale
                  * Imperativo
                  * DSL

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.4.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Format =

    type Format =
        | Restore                                        // RST
        | RestoreForegroundColor                         // RFGC
        | RestoreBackgroundColor                         // RBGC
        | Bold                   of flag  : bool option  // BLD
        | Faint                  of flag  : bool option  // FNT
        | Italic                 of flag  : bool option  // ITC
        | Underline              of flag  : bool option  // UND
        | Blinking               of flag  : bool option  // BKG
        | Reverse                of flag  : bool option  // RVS
        | Hidden                 of flag  : bool option  // HDN
        | Strikeout              of flag  : bool option  // SKT
        | ForegroundColor        of color : Color option // FGC
        | BackgroundColor        of color : Color option // BGC

    let RST        = Restore
    let RFGC       = RestoreForegroundColor
    let RBGC       = RestoreBackgroundColor
    let BLD  flag  = Bold                   flag
    let FNT  flag  = Faint                  flag
    let ITC  flag  = Italic                 flag
    let UND  flag  = Underline              flag
    let BKG  flag  = Blinking               flag
    let RVS  flag  = Reverse                flag
    let HDN  flag  = Hidden                 flag
    let SKT  flag  = Strikeout              flag
    let FGC  color = ForegroundColor        color
    let BGC  color = BackgroundColor        color

    type Formats = Format list

    let private defaultFormats = [
        Restore
    ]



    let getFormat text format =
        match format with
        | Restore -> sprintf "%s0m%s" CSI text

        | RestoreForegroundColor -> sprintf "%s39m%s" CSI text
        | RestoreBackgroundColor -> sprintf "%s49m%s" CSI text

        | Bold      flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 1 else 22) text
        | Faint     flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 2 else 22) text
        | Italic    flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 3 else 23) text
        | Underline flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 4 else 24) text
        | Blinking  flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 5 else 25) text
        | Reverse   flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 7 else 27) text
        | Hidden    flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 8 else 28) text
        | Strikeout flag -> sprintf "%s%dm%s" CSI (if (defaultArg flag false) then 9 else 29) text

        | ForegroundColor color ->
            let color = defaultArg color (Color.RGB (255, 255, 255))

            match color with
            | XTerm id ->
                sprintf "%s38;5;%dm%s" CSI id text
            | XTermColor color ->
                sprintf "%s38;5;%dm%s" CSI color.id text
            | _ ->
                let red, green, blue =
                    match color with
                    | RGB (red, green, blue) -> red, green, blue
                    | RGBColor color -> color.red, color.green, color.blue

                    | HEX (red, green, blue) -> hexToRGB (red, green, blue)
                    | HEXColor color ->
                        hexColorToRGBColor color
                        |> fun color -> color.red, color.green, color.blue

                    | color -> failwithf "%A: Unsupported color format!" color

                sprintf "%s38;2;%d;%d;%dm%s" CSI red green blue text
        | BackgroundColor color ->
            let color = defaultArg color (Color.RGB (0, 0, 0))

            match color with
            | XTerm id ->
                sprintf "%s48;5;%dm%s" CSI id text
            | XTermColor color ->
                sprintf "%s48;5;%dm%s" CSI color.id text
            | _ ->
                let red, green, blue =
                    match color with
                    | RGB (red, green, blue) -> red, green, blue
                    | RGBColor color -> color.red, color.green, color.blue

                    | HEX (red, green, blue) -> hexToRGB (red, green, blue)
                    | HEXColor color ->
                        hexColorToRGBColor color
                        |> fun color -> color.red, color.green, color.blue

                    | color -> failwithf "%A: Unsupported color format!" color

                sprintf "%s48;2;%d;%d;%dm%s" CSI red green blue text

        | format -> failwithf "%A: Not yet implemented!" format

    let getFormats text formats =
        sprintf "%s%s" (
            formats
            |> List.map (fun format ->
                getFormat "" format
            )
            |> String.concat ""
        ) text

    let getRestore text = getFormat text Restore

    let getRestoreForegroundColor text = getFormat text RestoreForegroundColor
    let getRestoreBackgroundColor text = getFormat text RestoreBackgroundColor

    let getBold      text flag = getFormat text (Bold      flag)
    let getFaint     text flag = getFormat text (Faint     flag)
    let getItalic    text flag = getFormat text (Italic    flag)
    let getUnderline text flag = getFormat text (Underline flag)
    let getBlinking  text flag = getFormat text (Blinking  flag)
    let getReverse   text flag = getFormat text (Reverse   flag)
    let getHidden    text flag = getFormat text (Hidden    flag)
    let getStrikeout text flag = getFormat text (Strikeout flag)

    let getForegroundColor text color = getFormat text (ForegroundColor color)
    let getBackgroundColor text color = getFormat text (BackgroundColor color)

    let getReset text = getFormats text defaultFormats

    let getRST = getRestore

    let getRFGC = getRestoreForegroundColor
    let getRBGC = getRestoreBackgroundColor

    let getBLD = getBold
    let getFNT = getFaint
    let getITC = getItalic
    let getUND = getUnderline
    let getBKG = getBlinking
    let getRVS = getReverse
    let getHDN = getHidden
    let getSKT = getStrikeout

    let getFGC = getForegroundColor
    let getBGC = getBackgroundColor



    let init () : Formats = []

    let initPreset (formats : Formats) = formats

    let clear (formats : Formats) : Formats = []

    let view (formats : Formats) =
        formats
        |> List.rev
        |> List.iter (fun format ->
            printfn "%A" format
        )

    let restore formats = Restore :: formats

    let restoreForegroundColor formats = RestoreForegroundColor :: formats
    let restoreBackgroundColor formats = RestoreBackgroundColor :: formats

    let bold      flag formats = Bold      flag :: formats
    let faint     flag formats = Faint     flag :: formats
    let italic    flag formats = Italic    flag :: formats
    let underline flag formats = Underline flag :: formats
    let blinking  flag formats = Blinking  flag :: formats
    let reverse   flag formats = Reverse   flag :: formats
    let hidden    flag formats = Hidden    flag :: formats
    let strikeout flag formats = Strikeout flag :: formats

    let foregroundColor color formats = ForegroundColor color :: formats
    let backgroundColor color formats = BackgroundColor color :: formats

    let apply text format =
        printf "%s" (getFormat text format)

    let applyNewLine text format =
        apply text format

        printfn ""

    let applyAll text formats =
        formats
        |> List.rev
        |> List.iter (fun format ->
            apply "" format
        )

        printf "%s" text

    let applyAllNewLine text formats =
        applyAll text formats

        printfn ""

    let reset text =
        defaultFormats
        |> applyAll text

    let configure text config =
        init ()
        |> config
        |> applyAll text

    let configureNewLine text config =
        configure text config

        printfn ""

    let rst = restore

    let rfgc = restoreForegroundColor
    let rbgc = restoreBackgroundColor

    let bld = bold
    let fnt = faint
    let itc = italic
    let und = underline
    let bkg = blinking
    let rvs = reverse
    let hdn = hidden
    let skt = strikeout

    let fgc = foregroundColor
    let bgc = backgroundColor



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

    let doRestoreForegroundColor text = apply text RestoreForegroundColor
    let doRestoreBackgroundColor text = apply text RestoreForegroundColor

    let doBold      text flag = apply text (Bold      flag)
    let doFaint     text flag = apply text (Faint     flag)
    let doItalic    text flag = apply text (Italic    flag)
    let doUnderline text flag = apply text (Underline flag)
    let doBlinking  text flag = apply text (Blinking  flag)
    let doReverse   text flag = apply text (Reverse   flag)
    let doHidden    text flag = apply text (Hidden    flag)
    let doStrikeout text flag = apply text (Strikeout flag)

    let doForegroundColor text color = apply text (ForegroundColor color)
    let doBackgroundColor text color = apply text (BackgroundColor color)

    let doReset text = reset text

    let doRST = doRestore

    let doRFGC = doRestoreForegroundColor
    let doRBGC = doRestoreBackgroundColor

    let doBLD = doBold
    let doFNT = doFaint
    let doITC = doItalic
    let doUND = doUnderline
    let doBKG = doBlinking
    let doRVS = doReverse
    let doHDN = doHidden
    let doSKT = doStrikeout

    let doFGC = doForegroundColor
    let doBGC = doBackgroundColor
