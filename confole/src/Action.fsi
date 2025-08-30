(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Action.fsi

    Title       : ACTION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Action.
                  Il modulo Action si occupa di sequenze VTS
                  relative al viewport del terminale.

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

    val insertCharacter : n : int -> actions : Actions -> Actions
    val deleteCharacter : n : int -> actions : Actions -> Actions

    val insertLine : n : int -> actions : Actions -> Actions
    val deleteLine : n : int -> actions : Actions -> Actions

    val eraseDisplay : erase : Erase option -> actions : Actions -> Actions
    val eraseLine    : erase : Erase option -> actions : Actions -> Actions

    val clear : actions : Actions -> Actions

    val view : actions : Actions -> unit

    val apply    : newLine : bool -> action  : Action  -> unit
    val applyAll : newLine : bool -> actions : Actions -> unit

    val reset : unit -> unit

    val configure : newLine : bool -> config : (Actions -> Actions) -> unit

    type Builder =
        new : unit -> Builder

        member Yield :
            actionFunction : (Actions -> Actions) ->
            (Actions -> Actions)

        member Combine :
            action : (Actions -> Actions) * actionFunction : (Actions -> Actions) ->
            (Actions -> Actions)

        member Delay :
            ``function`` : (unit -> (Actions -> Actions)) ->
            (Actions -> Actions)

        member Run :
            actionsFunction : (Actions -> Actions) ->
            Actions

    val builder : Builder
