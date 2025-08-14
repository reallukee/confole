(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Action.fsi

    Title       : ACTION
    Description : Action

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Action =
    type Erase =
        | FromCurrentToEnd
        | FromBeginToCurrent
        | FromBeginToEnd

    type Action =
        | InsertCharacter of int
        | DeleteCharacter of int
        | InsertLine      of int
        | DeleteLine      of int
        | EraseDisplay    of Erase option
        | EraseLine       of Erase option

    type Actions = Action list

    val init : unit -> Actions

    val insertCharacter : int -> Actions -> Actions
    val deleteCharacter : int -> Actions -> Actions

    val insertLine : int -> Actions -> Actions
    val deleteLine : int -> Actions -> Actions

    val eraseDisplay : Erase option -> Actions -> Actions
    val eraseLine    : Erase option -> Actions -> Actions

    val clear : Actions -> Actions

    val view : Actions -> unit

    val apply    : bool -> Action  -> unit
    val applyAll : bool -> Actions -> unit
    val reset    : unit -> unit

    val configure : bool -> (Actions -> Actions) -> unit

    type Builder =
        new : unit -> Builder

        member Yield :
            (Actions -> Actions) ->
            (Actions -> Actions)

        member Combine :
            (Actions -> Actions) * (Actions -> Actions) ->
            (Actions -> Actions)

        member Delay :
            (unit -> (Actions -> Actions)) ->
            (Actions -> Actions)

        member Run :
            (Actions -> Actions) ->
            Actions

    val builder : Builder
