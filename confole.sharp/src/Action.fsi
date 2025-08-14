(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Action.fsi

    Title       : ACTION
    Description : Action

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
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

    new : unit -> InsertCharacterAction
    new : int -> InsertCharacterAction

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DeleteCharacterAction =
    interface IAction

    new : unit -> DeleteCharacterAction
    new : int -> DeleteCharacterAction

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type InsertLineAction =
    interface IAction

    new : unit -> InsertLineAction
    new : int -> InsertLineAction

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DeleteLineAction =
    interface IAction

    new : unit -> DeleteLineAction
    new : int -> DeleteLineAction

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type EraseDisplayAction =
    interface IAction

    new : unit -> EraseDisplayAction
    new : Erase -> EraseDisplayAction

    member Erase : Erase with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type EraseLineAction =
    interface IAction

    new : unit -> EraseLineAction
    new : Erase -> EraseLineAction

    member Erase : Erase with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type Actions =
    new : unit -> Actions

    member NewLine : bool     with get, set
    member Actions : IActions with get

    new : IActions * bool -> Actions
    new : bool -> Actions

    member Item : int -> IAction with get

    member AddAction  : IAction  -> Actions
    member AddActions : IActions -> Actions

    member AddInsertCharacterAction : int -> Actions
    member AddDeleteCharacterAction : int -> Actions

    member AddInsertLineAction : int -> Actions
    member AddDeleteLineAction : int -> Actions

    member AddEraseDisplayAction : Erase -> Actions
    member AddEraseLineAction    : Erase -> Actions

    member Clear : unit -> Actions

    member View : unit -> unit

    member Apply : IAction * bool -> unit
    member Apply : IAction        -> unit

    member ApplyAll : bool -> unit
    member ApplyAll : unit -> unit

    member Reset : unit -> unit

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
