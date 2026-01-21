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

    open Rule

    val TTL  : string       -> Rule
    val SCB  : Rule
    val HCB  : Rule
    val SC   : Rule
    val HC   : Rule
    val EDM  : Rule
    val DDM  : Rule
    val EAB  : Rule
    val DAB  : Rule
    val CS   : Shape option -> Rule
    val DFGC : Color option -> Rule
    val DBGC : Color option -> Rule
    val DCC  : Color option -> Rule

    // Alias modalità manuale
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

    // Alias modalità funzionale
    val initw : (Rules -> Rules)

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

    val applynl    : (Rule  -> unit)
    val applyallnl : (Rules -> unit)

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
