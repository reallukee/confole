(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fsi

    Title       : FORMAT
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Format.
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
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

open Microsoft.FSharp.Reflection

open Color
open ColorConversion
open Position
open PositionConversion

module Format =

    (*
        Le VTS presenti in questo modulo sono state tratte dalla
        guida di Microsoft sull'uso dell'API della console.

        Puoi consultare la documentazione sopra citata qui:

        https://learn.microsoft.com/windows/console/console-virtual-terminal-sequences

        NOTA BENE: L'implementazione sottostante si prende delle
                   "libertà creative" per adattarsi alle scelte
                   progettuali di Confole. Questo si traduce, tra
                   le altre cose, in naming e valori di default
                   personalizzati!

        NOTE BENE: Purtroppo a causa della mia infinita svogliatezza
                   non ho ancora scritto la documentazione in-code.
                   Punto quindi sul fatto che l'API sia così costruita
                   bene da parlare da sé!

                   Buon divertimento \(._.)/ <333!
    *)

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

    type Formats = Format list

    val defaultFormats : Formats



    // Modalità manuale
    val render  : text : string -> format  : Format  -> string
    val renders : text : string -> formats : Formats -> string

    val renderRestore : text : string -> string

    val renderRestoreForegroundColor : text : string -> string
    val renderRestoreBackgroundColor : text : string -> string

    val renderBold      : text : string -> flag : bool option -> string
    val renderFaint     : text : string -> flag : bool option -> string
    val renderItalic    : text : string -> flag : bool option -> string
    val renderUnderline : text : string -> flag : bool option -> string
    val renderBlinking  : text : string -> flag : bool option -> string
    val renderReverse   : text : string -> flag : bool option -> string
    val renderHidden    : text : string -> flag : bool option -> string
    val renderStrikeout : text : string -> flag : bool option -> string

    val renderForegroundColor : text : string -> color : Color option -> string
    val renderBackgroundColor : text : string -> color : Color option -> string

    val renderReset : text : string -> string



    // Modalità funzionale
    val init     : unit              -> Formats
    val initWith : formats : Formats -> Formats

    val trunk : formats : Formats -> Formats
    val clear : formats : Formats -> Formats

    val view    : formats : Formats -> Formats
    val preview : formats : Formats -> Formats

    val restore : formats : Formats -> Formats

    val restoreForegroundColor : formats : Formats -> Formats
    val restoreBackgroundColor : formats : Formats -> Formats

    val bold      : flag : bool option -> formats : Formats -> Formats
    val faint     : flag : bool option -> formats : Formats -> Formats
    val italic    : flag : bool option -> formats : Formats -> Formats
    val underline : flag : bool option -> formats : Formats -> Formats
    val blinking  : flag : bool option -> formats : Formats -> Formats
    val reverse   : flag : bool option -> formats : Formats -> Formats
    val hidden    : flag : bool option -> formats : Formats -> Formats
    val strikeout : flag : bool option -> formats : Formats -> Formats

    val foregroundColor : color : Color option -> formats : Formats -> Formats
    val backgroundColor : color : Color option -> formats : Formats -> Formats

    val apply           : text : string -> format  : Format  -> unit
    val applyNewLine    : text : string -> format  : Format  -> unit
    val applyAll        : text : string -> formats : Formats -> unit
    val applyAllNewLine : text : string -> formats : Formats -> unit

    val reset : text : string -> unit

    val configure        : text : string -> config : (Formats -> Formats) -> unit
    val configureNewLine : text : string -> config : (Formats -> Formats) -> unit



    // Modalità DSL
    type Builder =

        new : unit -> Builder

        member Yield :
            formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Combine :
            format : (Formats -> Formats) * formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Delay :
            ``function`` : (unit -> (Formats -> Formats)) ->
            (Formats -> Formats)

        member Run :
            formatsFunction : (Formats -> Formats) ->
            Formats



    // Modalità imperativa
    val doRestore : text : string -> unit

    val doRestoreForegroundColor : text : string -> unit
    val doRestoreBackgroundColor : text : string -> unit

    val doBold      : text : string -> flag : bool option -> unit
    val doFaint     : text : string -> flag : bool option -> unit
    val doItalic    : text : string -> flag : bool option -> unit
    val doUnderline : text : string -> flag : bool option -> unit
    val doBlinking  : text : string -> flag : bool option -> unit
    val doReverse   : text : string -> flag : bool option -> unit
    val doHidden    : text : string -> flag : bool option -> unit
    val doStrikeout : text : string -> flag : bool option -> unit

    val doForegroundColor : text : string -> color : Color option -> unit
    val doBackgroundColor : text : string -> color : Color option -> unit

    val doReset : text : string -> unit
