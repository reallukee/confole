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

    type Cursors = Cursor list

    val init :
        unit ->
        Cursors

    val reverse : Cursors -> Cursors
    val save    : Cursors -> Cursors
    val restore : Cursors -> Cursors

    val up       : int -> Cursors -> Cursors
    val down     : int -> Cursors -> Cursors
    val next     : int -> Cursors -> Cursors
    val previous : int -> Cursors -> Cursors

    val nextLine     : int -> Cursors -> Cursors
    val previousLine : int -> Cursors -> Cursors

    val move : Position -> Cursors -> Cursors

    val clear : Cursors -> Cursors

    val apply    : bool -> Cursor -> unit
    val applyAll : bool -> Cursors -> unit
    val reset    : unit -> unit

    val configure : bool -> (Cursors -> Cursors) -> unit

    type Builder =
        new :
            unit ->
            Builder

        member Yield :
            (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Combine :
            (Cursors -> Cursors) * (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Delay :
            (unit -> (Cursors -> Cursors)) ->
            (Cursors -> Cursors)

        member Run :
            (Cursors -> Cursors) ->
            Cursors

    val builder : Builder
