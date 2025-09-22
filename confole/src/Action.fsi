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
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Action =
    open Common

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

    val insertCharacter : n : int -> actions : Actions -> Actions
    val deleteCharacter : n : int -> actions : Actions -> Actions

    val insertLine : n : int -> actions : Actions -> Actions
    val deleteLine : n : int -> actions : Actions -> Actions

    val eraseDisplay : erase : Erase option -> actions : Actions -> Actions
    val eraseLine    : erase : Erase option -> actions : Actions -> Actions

    val init  : unit              -> Actions
    val clear : actions : Actions -> Actions
    val view  : actions : Actions -> unit

    val apply        : action : Action -> unit
    val applyNewLine : action : Action -> unit

    val applyAll        : actions : Actions -> unit
    val applyAllNewLine : actions : Actions -> unit

    val reset : unit -> unit

    val configure        : config : (Actions -> Actions) -> unit
    val configureNewLine : config : (Actions -> Actions) -> unit

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

    val doInsertCharacter : n : int -> unit
    val doDeleteCharacter : n : int -> unit

    val doInsertLine : n : int -> unit
    val doDeleteLine : n : int -> unit

    val doEraseDisplay : erase : Erase option -> unit
    val doEraseLine    : erase : Erase option -> unit
