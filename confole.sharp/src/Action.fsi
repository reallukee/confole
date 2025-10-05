(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Action.fsi

    Title       : ACTION
    Description : Action

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type Erase =
    | FromCurrentToEnd   = 0
    | FromBeginToCurrent = 1
    | FromBeginToEnd     = 2



type IAction =
    abstract member ToFunctional : Action.Action with get

type IActions = IAction list



type InsertCharacterAction =
    interface IAction

    new : unit    -> InsertCharacterAction
    new : n : int -> InsertCharacterAction

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type DeleteCharacterAction =
    interface IAction

    new : unit    -> DeleteCharacterAction
    new : n : int -> DeleteCharacterAction

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type InsertLineAction =
    interface IAction

    new : unit    -> InsertLineAction
    new : n : int -> InsertLineAction

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type DeleteLineAction =
    interface IAction

    new : unit    -> DeleteLineAction
    new : n : int -> DeleteLineAction

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type EraseDisplayAction =
    interface IAction

    new : unit          -> EraseDisplayAction
    new : erase : Erase -> EraseDisplayAction

    member Erase : Erase with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type EraseLineAction =
    interface IAction

    new : unit          -> EraseLineAction
    new : erase : Erase -> EraseLineAction

    member Erase : Erase with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type Actions =
    new : unit -> Actions

    member NewLine : bool     with get, set
    member Actions : IActions with get

    new : actions : IActions * newLine : bool -> Actions
    new : newLine : bool                      -> Actions

    member Item : int -> IAction with get

    member AddAction  : action  : IAction  -> Actions
    member AddActions : actions : IActions -> Actions

    member AddInsertCharacterAction : n : int -> Actions
    member AddDeleteCharacterAction : n : int -> Actions

    member AddInsertLineAction : n : int -> Actions
    member AddDeleteLineAction : n : int -> Actions

    member AddEraseDisplayAction : erase : Erase -> Actions
    member AddEraseLineAction    : erase : Erase -> Actions

    member Clear : unit -> Actions
    member View  : unit -> unit

    member Apply : action : IAction * newLine : bool -> unit
    member Apply : action : IAction                  -> unit

    member ApplyAll : newLine : bool -> unit
    member ApplyAll : unit           -> unit

    member Reset : unit -> unit

    static member DoInsertCharacter : n : int -> unit
    static member DoDeleteCharacter : n : int -> unit

    static member DoInsertLine : n : int -> unit
    static member DoDeleteLine : n : int -> unit

    static member DoEraseDisplay : erase : Erase -> unit
    static member DoEraseLine    : erase : Erase -> unit

    static member DoReset : unit -> unit

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string
