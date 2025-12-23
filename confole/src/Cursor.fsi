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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Cursor =
    type Cursor =
        | Reverse
        | Save
        | Restore
        | Up           of n        : int option
        | Down         of n        : int option
        | Next         of n        : int option
        | Previous     of n        : int option
        | NextLine     of n        : int option
        | PreviousLine of n        : int option
        | Move         of position : Position option

    type Cursors = Cursor list

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

    val init       : unit              -> Cursors
    val initPreset : cursors : Cursors -> Cursors
    val clear      : cursors : Cursors -> Cursors
    val view       : cursors : Cursors -> unit

    val apply        : cursor : Cursor -> unit
    val applyNewLine : cursor : Cursor -> unit

    val applyAll        : cursors : Cursors -> unit
    val applyAllNewLine : cursors : Cursors -> unit

    val reset : unit -> unit

    val configure        : config : (Cursors -> Cursors) -> unit
    val configureNewLine : config : (Cursors -> Cursors) -> unit

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

    val builder : Builder

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
