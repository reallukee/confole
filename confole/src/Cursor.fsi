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

open Microsoft.FSharp.Reflection

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

    type Cursors = Cursor list

    val defaultCursors : Cursors



    // Modalità manuale
    val render  : cursor  : Cursor  -> string
    val renders : cursors : Cursors -> string

    val renderReverse : unit -> string
    val renderSave    : unit -> string
    val renderRestore : unit -> string

    val renderUp       : n : int option -> string
    val renderDown     : n : int option -> string
    val renderNext     : n : int option -> string
    val renderPrevious : n : int option -> string

    val renderNextLine     : n : int option -> string
    val renderPreviousLine : n : int option -> string

    val renderMove : position : Position option -> string

    val renderReset : unit -> string



    // Modalità funzionale
    val init     : unit              -> Cursors
    val initWith : cursors : Cursors -> Cursors

    val trunk : cursors : Cursors -> Cursors
    val clear : cursors : Cursors -> Cursors

    val view    : cursors : Cursors -> Cursors
    val preview : cursors : Cursors -> Cursors

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
