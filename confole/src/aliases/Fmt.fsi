(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Fmt.fsi

    Title       : FMT
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Fmt.
                  Il modulo Fmt si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Fornisce gli Alias di Format.

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

module Fmt =

    (*
        Hei! Come va, amico?

        Questo è un modulo di ALIAS. L'idea è semplice:
        sfruttare la potenza degli alias F# per poter
        scrivere codice più corto (e anche più enigmatico).

        Gli alias F# non rendono più grande la call stack!

        Qui dentro fornisco, ove possibile, abbreviazioni,
        e nel caso non lo fosse (immagina abbreviare "init"
        con "i"?) nomi 1:1 con il modulo originale.

        Perché?

        Così puoi scrivere il tuo codice usando SOLO Fmt
        e non Format. Figo, vero?
        Cosa? Non è inutile!

        Gli alias (dovrebbero) parlare da sè.

        RIASSUNTO:

            FMT ~= FORMAT

        Per delucidazioni sul funzionamento dell'API
        guarda il modulo Format.
    *)

    open Format

    val RST  : Format                 // Restore
    val RFGC : Format                 // RestoreForegroundColor
    val RBGC : Format                 // RestoreBackgroundColor
    val BLD  : bool option  -> Format // Bold
    val FNT  : bool option  -> Format // Faint
    val ITC  : bool option  -> Format // Italic
    val UND  : bool option  -> Format // Underline
    val BKG  : bool option  -> Format // Blinking
    val RVS  : bool option  -> Format // Reverse
    val HDN  : bool option  -> Format // Hidden
    val SKT  : bool option  -> Format // Strikeout
    val FGC  : Color option -> Format // ForegroundColor
    val BGC  : Color option -> Format // BackgroundColor



    // Alias modalità manuale
    val render  : (string -> Format  -> string)
    val renders : (string -> Formats -> string)

    val renderRST : (string -> string)

    val renderRFGC : (string -> string)
    val renderRBGC : (string -> string)

    val renderBLD : (string -> bool option -> string)
    val renderFNT : (string -> bool option -> string)
    val renderITC : (string -> bool option -> string)
    val renderUND : (string -> bool option -> string)
    val renderBKG : (string -> bool option -> string)
    val renderRVS : (string -> bool option -> string)
    val renderHDN : (string -> bool option -> string)
    val renderSKT : (string -> bool option -> string)

    val renderFGC : (string -> Color option -> string)
    val renderBGC : (string -> Color option -> string)

    val renderReset : (string -> string)



    // Alias modalità funzionale
    val init  : (unit    -> Formats)
    val initw : (Formats -> Formats)

    val trunk : (Formats -> Formats)
    val clear : (Formats -> Formats)

    val view    : (Formats -> Formats)
    val preview : (Formats -> Formats)

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

    val apply      : (string -> Format  -> unit)
    val applynl    : (string -> Format  -> unit)
    val applyAll   : (string -> Formats -> unit)
    val applyallnl : (string -> Formats -> unit)

    val reset : (string -> unit)

    val config   : (string -> (Formats -> Formats) -> unit)
    val confignl : (string -> (Formats -> Formats) -> unit)



    // Alias modalità DSL
    val builder : Builder



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

    val doReset : (string -> unit)
