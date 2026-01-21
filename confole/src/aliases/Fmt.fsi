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

    open Format

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

    // Alias modalità manuale
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

    // Alias modalità funzionale
    val initw : (Formats -> Formats)

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

    val applynl    : (string -> Format  -> unit)
    val applyallnl : (string -> Formats -> unit)

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
