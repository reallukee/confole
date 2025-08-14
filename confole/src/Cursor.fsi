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
        | Up           of int option
        | Down         of int option
        | Next         of int option
        | Previous     of int option
        | NextLine     of int option
        | PreviousLine of int option
        | Move         of Position

    type Cursors = Cursor list

    val init : unit -> Cursors

    val reverse : Cursors -> Cursors
    val save    : Cursors -> Cursors
    val restore : Cursors -> Cursors

    val up       : int option -> Cursors -> Cursors
    val down     : int option -> Cursors -> Cursors
    val next     : int option -> Cursors -> Cursors
    val previous : int option -> Cursors -> Cursors

    val nextLine     : int option -> Cursors -> Cursors
    val previousLine : int option -> Cursors -> Cursors

    val move : Position -> Cursors -> Cursors

    val clear : Cursors -> Cursors

    val view : Cursors -> unit

    val apply    : bool -> Cursor  -> unit
    val applyAll : bool -> Cursors -> unit
    val reset    : unit -> unit

    val configure : bool -> (Cursors -> Cursors) -> unit

    type Builder =
        new : unit -> Builder

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
