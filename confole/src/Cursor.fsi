(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Il modulo Cursor permette di ottenere gli
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

module Cursor =

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

    type Cursor =
        | Reverse                                    // RVS
        | Save                                       // SV
        | Restore                                    // RST
        | Up           of n        : int option      // U
        | Down         of n        : int option      // D
        | Next         of n        : int option      // NX
        | Previous     of n        : int option      // PV
        | NextLine     of n        : int option      // NXL
        | PreviousLine of n        : int option      // PVL
        | Move         of position : Position option // MV

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

    type Cursors = Cursor list



    // Modalità manuale
    val getCursor  : cursor  : Cursor  -> string
    val getCursors : cursors : Cursors -> string

    val getReverse : unit -> string
    val getSave    : unit -> string
    val getRestore : unit -> string

    val getUp       : n : int option -> string
    val getDown     : n : int option -> string
    val getNext     : n : int option -> string
    val getPrevious : n : int option -> string

    val getNextLine     : n : int option -> string
    val getPreviousLine : n : int option -> string

    val getMove : position : Position option -> string

    val getReset : unit -> string

    // Alias modalità manuale
    val getRVS : (unit -> string)
    val getSV  : (unit -> string)
    val getRST : (unit -> string)

    val getU  : (int option -> string)
    val getD  : (int option -> string)
    val getNX : (int option -> string)
    val getPV : (int option -> string)

    val getNXL : (int option -> string)
    val getPVL : (int option -> string)

    val getMV : (Position option -> string)



    // Modalità funzionale
    val init       : unit              -> Cursors
    val initPreset : cursors : Cursors -> Cursors
    val clear      : cursors : Cursors -> Cursors
    val view       : cursors : Cursors -> unit

    val reverse : cursors : Cursors -> Cursors
    val save    : cursors : Cursors -> Cursors
    val restore : cursors : Cursors -> Cursors

    val up       : n : int option -> cursors : Cursors -> Cursors
    val down     : n : int option -> cursors : Cursors -> Cursors
    val next     : n : int option -> cursors : Cursors -> Cursors
    val previous : n : int option -> cursors : Cursors -> Cursors

    val nextLine     : n : int option -> cursors : Cursors -> Cursors
    val previousLine : n : int option -> cursors : Cursors -> Cursors

    val move : position : Position option -> cursors : Cursors -> Cursors

    val apply           : cursor  : Cursor  -> unit
    val applyNewLine    : cursor  : Cursor  -> unit
    val applyAll        : cursors : Cursors -> unit
    val applyAllNewLine : cursors : Cursors -> unit

    val reset : unit -> unit

    val configure        : config : (Cursors -> Cursors) -> unit
    val configureNewLine : config : (Cursors -> Cursors) -> unit

    // Alias modalità funzionale
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



    // Modalità DSL
    type Builder =
        new : unit -> Builder

        member Yield :
            cursorFunction : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Combine :
            cursor : (Cursors -> Cursors) * cursorFunction : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Delay :
            ``function`` : (unit -> (Cursors -> Cursors)) ->
            (Cursors -> Cursors)

        member Run :
            cursorsFunction : (Cursors -> Cursors) ->
            Cursors

    // Alias modalità DSL
    val builder : Builder



    // Modalità imperativa
    val doReverse : unit -> unit
    val doSave    : unit -> unit
    val doRestore : unit -> unit

    val doUp       : n : int option -> unit
    val doDown     : n : int option -> unit
    val doNext     : n : int option -> unit
    val doPrevious : n : int option -> unit

    val doNextLine     : n : int option -> unit
    val doPreviousLine : n : int option -> unit

    val doMove : position : Position option -> unit

    val doReset : unit -> unit

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
