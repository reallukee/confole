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
open Position

module Cursor =
    type Cursor =
        | Reverse
        | Save
        | Restore
        | Up           of int
        | Down         of int
        | Next         of int
        | Previous     of int
        | NextLine     of int
        | PreviousLine of int
        | Move         of Position

    type Cursors = Cursor List

    val init :
        unit ->
        Cursors

    val reverse : cursors : Cursors -> Cursors
    val save    : cursors : Cursors -> Cursors
    val restore : cursors : Cursors -> Cursors

    val up       : n : int -> cursors : Cursors -> Cursors
    val down     : n : int -> cursors : Cursors -> Cursors
    val next     : n : int -> cursors : Cursors -> Cursors
    val previous : n : int -> cursors : Cursors -> Cursors

    val nextLine     : n : int -> cursors : Cursors -> Cursors
    val previousLine : n : int -> cursors : Cursors -> Cursors

    val move : position : Position -> cursors : Cursors -> Cursors

    val apply :
        newLine : bool ->
        cursor  : Cursor ->
        unit

    val applyAll :
        newLine : bool ->
        cursors : Cursors ->
        unit

    val reset :
        unit ->
        unit

    val configure :
        newLine : bool ->
        config  : (Cursors -> Cursors) ->
        unit

    type CursorsBuilder =
        new :
            unit ->
            CursorsBuilder

        member Yield :
            cursorF : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Combine :
            acc : (Cursors -> Cursors) * cursorF : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Delay :
            f : (unit -> (Cursors -> Cursors)) ->
            (Cursors -> Cursors)

        member Run :
            cursorsF : (Cursors -> Cursors) ->
            Cursors

    val builder : CursorsBuilder
