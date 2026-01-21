(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cur.fsi

    Title       : CUR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Cur.
                  Il modulo Cur si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Fornisce gli Alias di Cursor.

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

module Cur =

    open Cursor

    val RVS : Cursor
    val SV  : Cursor
    val RST : Cursor
    val U   : int option      -> Cursor
    val D   : int option      -> Cursor
    val NX  : int option      -> Cursor
    val PV  : int option      -> Cursor
    val NXL : int option      -> Cursor
    val PVL : int option      -> Cursor
    val MV  : Position option -> Cursor

    // Alias modalità manuale
    val renderRVS : (unit -> string)
    val renderSV  : (unit -> string)
    val renderRST : (unit -> string)

    val renderU  : (int option -> string)
    val renderD  : (int option -> string)
    val renderNX : (int option -> string)
    val renderPV : (int option -> string)

    val renderNXL : (int option -> string)
    val renderPVL : (int option -> string)

    val renderMV : (Position option -> string)

    // Alias modalità funzionale
    val initw : (Cursors -> Cursors)

    val rvs : (Cursors -> Cursors)
    val sv  : (Cursors -> Cursors)
    val rst : (Cursors -> Cursors)

    val u  : (int option -> Cursors -> Cursors)
    val d  : (int option -> Cursors -> Cursors)
    val nx : (int option -> Cursors -> Cursors)
    val pv : (int option -> Cursors -> Cursors)

    val nxl : (int option -> Cursors -> Cursors)
    val pvl : (int option -> Cursors -> Cursors)

    val mv : (Position option -> Cursors -> Cursors)

    val applynl    : (Cursor  -> unit)
    val applyallnl : (Cursors -> unit)

    val config   : ((Cursors -> Cursors) -> unit)
    val confignl : ((Cursors -> Cursors) -> unit)

    // Alias modalità DSL
    val builder : Builder

    // Alias modalità imperativa
    val doRVS : (unit -> unit)
    val doSV  : (unit -> unit)
    val doRST : (unit -> unit)

    val doU  : (int option -> unit)
    val doD  : (int option -> unit)
    val doNX : (int option -> unit)
    val doPV : (int option -> unit)

    val doNXL : (int option -> unit)
    val doPVL : (int option -> unit)

    val doMV : (Position option -> unit)
