(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Cursor

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color

module Cursor =
    type Cursor =
        | Up of int
        | Down of int
        | Next of int
        | Previous of int
        | NextLine of int
        | PreviousLine of int

    type Cursors = Cursor List

    val init :
        unit ->
        Cursors

    val up : n : int -> cursors : Cursors -> Cursors
    val down : n : int -> cursors : Cursors -> Cursors
    val next : n : int -> cursors : Cursors -> Cursors
    val previous : n : int -> cursors : Cursors -> Cursors
    val nextLine : n : int -> cursors : Cursors -> Cursors
    val previousLine : n : int -> cursors : Cursors -> Cursors

    val apply :
        cursor : Cursor ->
        unit

    val applyAll :
        cursors : Cursors ->
        unit

    val reset :
        unit ->
        unit
