(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
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
        | Up           of int option
        | Down         of int option
        | Next         of int option
        | Previous     of int option
        | NextLine     of int option
        | PreviousLine of int option
        | Move         of Position

    type Cursors = Cursor list

    val init : unit -> Cursors

    val reverse : cursors : Cursors -> Cursors
    val save    : cursors : Cursors -> Cursors
    val restore : cursors : Cursors -> Cursors

    val up       : n : int option -> cursors : Cursors -> Cursors
    val down     : n : int option -> cursors : Cursors -> Cursors
    val next     : n : int option -> cursors : Cursors -> Cursors
    val previous : n : int option -> cursors : Cursors -> Cursors

    val nextLine     : n : int option -> cursors : Cursors -> Cursors
    val previousLine : n : int option -> cursors : Cursors -> Cursors

    val move : position : Position -> cursors : Cursors -> Cursors

    val clear : cursors : Cursors -> Cursors

    val view : cursors : Cursors -> unit

    val apply    : newLine : bool -> cursor  : Cursor  -> unit
    val applyAll : newLine : bool -> cursors : Cursors -> unit

    val reset : unit -> unit

    val configure : newLine : bool -> config : (Cursors -> Cursors) -> unit

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
