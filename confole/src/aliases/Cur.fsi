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

        Così puoi scrivere il tuo codice usando SOLO Cur
        e non Cursor. Figo, vero?
        Cosa? Non è inutile!

        Gli alias (dovrebbero) parlare da sè.

        RIASSUNTO:

            CUR ~= CURSOR

        Per delucidazioni sul funzionamento dell'API
        guarda il modulo Cursor.
    *)

    open Cursor

    val RVS : Cursor                    // Reverse
    val SV  : Cursor                    // Save
    val RST : Cursor                    // Restore
    val U   : int option      -> Cursor // Up
    val D   : int option      -> Cursor // Down
    val NX  : int option      -> Cursor // Next
    val PV  : int option      -> Cursor // Previous
    val NXL : int option      -> Cursor // NextLine
    val PVL : int option      -> Cursor // PreviousLine
    val MV  : Position option -> Cursor // Move



    // Alias modalità manuale
    val render  : (Cursor  -> string)
    val renders : (Cursors -> string)

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

    val renderReset : (unit -> string)



    // Alias modalità funzionale
    val init  : (unit    -> Cursors)
    val initw : (Cursors -> Cursors)

    val trunk : (Cursors -> Cursors)
    val clear : (Cursors -> Cursors)

    val view    : (Cursors -> Cursors)
    val preview : (Cursors -> Cursors)

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

    val apply      : (Cursor  -> unit)
    val applynl    : (Cursor  -> unit)
    val applyAll   : (Cursors -> unit)
    val applyallnl : (Cursors -> unit)

    val reset : (unit -> unit)

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

    val doReset : (unit -> unit)
