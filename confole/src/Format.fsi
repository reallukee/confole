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

    val RST  : Format
    val RFGC : Format
    val RBGC : Format
    val BLD  : bool option  -> Format
    val FNT  : bool option  -> Format
    val ITC  : bool option  -> Format
    val UND  : bool option  -> Format
    val BKG  : bool option  -> Format
    val RVS  : bool option  -> Format
    val HDN  : bool option  -> Format
    val SKT  : bool option  -> Format
    val FGC  : Color option -> Format
    val BGC  : Color option -> Format

    type Formats = Format list



    // Modalità manuale
    val getFormat  : text : string -> format  : Format  -> string
    val getFormats : text : string -> formats : Formats -> string

    val getRestore : text : string -> string

    val getRestoreForegroundColor : text : string -> string
    val getRestoreBackgroundColor : text : string -> string

    val getBold      : text : string -> flag : bool option -> string
    val getFaint     : text : string -> flag : bool option -> string
    val getItalic    : text : string -> flag : bool option -> string
    val getUnderline : text : string -> flag : bool option -> string
    val getBlinking  : text : string -> flag : bool option -> string
    val getReverse   : text : string -> flag : bool option -> string
    val getHidden    : text : string -> flag : bool option -> string
    val getStrikeout : text : string -> flag : bool option -> string

    val getForegroundColor : text : string -> color : Color option -> string
    val getBackgroundColor : text : string -> color : Color option -> string

    val getReset : text : string -> string

    // Alias modalità manuale
    val getRST : (string -> string)

    val getRFGC : (string -> string)
    val getRBGC : (string -> string)

    val getBLD : (string -> bool option -> string)
    val getFNT : (string -> bool option -> string)
    val getITC : (string -> bool option -> string)
    val getUND : (string -> bool option -> string)
    val getBKG : (string -> bool option -> string)
    val getRVS : (string -> bool option -> string)
    val getHDN : (string -> bool option -> string)
    val getSKT : (string -> bool option -> string)

    val getFGC : (string -> Color option -> string)
    val getBGC : (string -> Color option -> string)



    // Modalità funzionale
    val init       : unit              -> Formats
    val initPreset : formats : Formats -> Formats
    val clear      : formats : Formats -> Formats
    val view       : formats : Formats -> unit

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

    // Alias modalità funzionale
    val rst : (Formats -> Formats)

    val rfgc : (Formats -> Formats)
    val rbgc : (Formats -> Formats)

    val bld : (bool option -> Formats -> Formats)
    val fnt : (bool option -> Formats -> Formats)
    val itc : (bool option -> Formats -> Formats)
    val und : (bool option -> Formats -> Formats)
    val bkg : (bool option -> Formats -> Formats)
    val rvs : (bool option -> Formats -> Formats)
    val hdn : (bool option -> Formats -> Formats)
    val skt : (bool option -> Formats -> Formats)

    val fgc : (Color option -> Formats -> Formats)
    val bgc : (Color option -> Formats -> Formats)



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

    // Alias modalità DSL
    val builder : Builder



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

    // Alias modalità imperativa
    val doRST : (string -> unit)

    val doRFGC : (string -> unit)
    val doRBGC : (string -> unit)

    val doBLD : (string -> bool option -> unit)
    val doFNT : (string -> bool option -> unit)
    val doITC : (string -> bool option -> unit)
    val doUND : (string -> bool option -> unit)
    val doBKG : (string -> bool option -> unit)
    val doRVS : (string -> bool option -> unit)
    val doHDN : (string -> bool option -> unit)
    val doSKT : (string -> bool option -> unit)

    val doFGC : (string -> Color option -> unit)
    val doBGC : (string -> Color option -> unit)
