(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rul.fsi

    Title       : RUL
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Rul.
                  Il modulo Rul si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Fornisce gli Alias di Rule.

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

module Rul =

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

        Così puoi scrivere il tuo codice usando SOLO Rul
        e non Rule. Figo, vero?
        Cosa? Non è inutile!

        Gli alias (dovrebbero) parlare da sè.

        RIASSUNTO:

            RUL ~= RULE

        Per delucidazioni sul funzionamento dell'API
        guarda il modulo Rule.
    *)

    open Rule

    val TTL  : string       -> Rule // Title
    val SCB  : Rule                 // ShowCursorBlinking
    val HCB  : Rule                 // HideCursorBlinking
    val SC   : Rule                 // ShowCursor
    val HC   : Rule                 // HideCursor
    val EDM  : Rule                 // EnableDesignateMode
    val DDM  : Rule                 // DisableDesignateMode
    val EAB  : Rule                 // EnableAlternativeBuffer
    val DAB  : Rule                 // DisableAlternativeBuffer
    val CS   : Shape option -> Rule // CursorShape
    val DFGC : Color option -> Rule // DefaultForegroundColor
    val DBGC : Color option -> Rule // DefaultBackgroundColor
    val DCC  : Color option -> Rule // DefaultCursorColor



    // Alias modalità manuale
    val render  : (Rule  -> string)
    val renders : (Rules -> string)

    val renderTTL : (string -> string)

    val renderSCB : (unit -> string)
    val renderHCB : (unit -> string)

    val renderSC : (unit -> string)
    val renderHC : (unit -> string)

    val renderEDM : (unit -> string)
    val renderDDM : (unit -> string)

    val renderEAB : (unit -> string)
    val renderDAB : (unit -> string)

    val renderCS : (Shape option -> string)

    val renderDFGC : (Color option -> string)
    val renderDBGC : (Color option -> string)
    val renderDCC  : (Color option -> string)

    val renderReset : (unit -> string)



    // Alias modalità funzionale
    val init  : (unit    -> Rules)
    val initw : (Rules -> Rules)

    val trunk : (Rules -> Rules)
    val clear : (Rules -> Rules)

    val view    : (Rules -> Rules)
    val preview : (Rules -> Rules)

    val ttl : (string -> Rules -> Rules)

    val scb : (Rules -> Rules)
    val hcb : (Rules -> Rules)

    val sc : (Rules -> Rules)
    val hc : (Rules -> Rules)

    val edm : (Rules -> Rules)
    val ddm : (Rules -> Rules)

    val eab : (Rules -> Rules)
    val dab : (Rules -> Rules)

    val cs : (Shape option -> Rules -> Rules)

    val dfgc : (Color option -> Rules -> Rules)
    val dbgc : (Color option -> Rules -> Rules)
    val dcc  : (Color option -> Rules -> Rules)

    val apply      : (Rule  -> unit)
    val applynl    : (Rule  -> unit)
    val applyAll   : (Rules -> unit)
    val applyallnl : (Rules -> unit)

    val reset : (unit -> unit)

    val config   : ((Rules -> Rules) -> unit)
    val confignl : ((Rules -> Rules) -> unit)



    // Alias modalità DSL
    val builder : Builder



    // Alias modalità imperativa
    val doTTL : (string -> unit)

    val doSCB : (unit -> unit)
    val doHCB : (unit -> unit)

    val doSC : (unit -> unit)
    val doHC : (unit -> unit)

    val doEDM : (unit -> unit)
    val doDDM : (unit -> unit)

    val doEAB : (unit -> unit)
    val doDAB : (unit -> unit)

    val doCS : (Shape option -> unit)

    val doDFGC : (Color option -> unit)
    val doDBGC : (Color option -> unit)
    val doDCC  : (Color option -> unit)

    val doReset : (unit -> unit)
