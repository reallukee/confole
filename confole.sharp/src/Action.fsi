(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Action.fsi

    Title       : ACTION
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Action.
                  Il modulo Action si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
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



[<AbstractClass>]
type ActionN =
    interface IAction

    new : action : (int option -> Action.Action) * n : int -> ActionN

    member N : int with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type InsertCharacterAction =
    inherit ActionN

    new : unit       -> InsertCharacterAction
    new : n    : int -> InsertCharacterAction

type DeleteCharacterAction =
    inherit ActionN

    new : unit       -> DeleteCharacterAction
    new : n    : int -> DeleteCharacterAction

type InsertLineAction =
    inherit ActionN

    new : unit       -> InsertLineAction
    new : n    : int -> InsertLineAction

type DeleteLineAction =
    inherit ActionN

    new : unit       -> DeleteLineAction
    new : n    : int -> DeleteLineAction



[<AbstractClass>]
type ActionErase =
    interface IAction

    new : action : (Action.Erase option -> Action.Action) * erase : Erase -> ActionErase

    member Erase : Erase with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type EraseDisplayAction =
    inherit ActionErase

    new : unit          -> EraseDisplayAction
    new : erase : Erase -> EraseDisplayAction

type EraseLineAction =
    inherit ActionErase

    new : unit          -> EraseLineAction
    new : erase : Erase -> EraseLineAction



type Actions =
    new : unit -> Actions

    member NewLine : bool     with get, set
    member Actions : IActions with get

    new : actions : IActions * newLine : bool -> Actions
    new : newLine : bool                      -> Actions

    member Item : int -> IAction with get

    member AddAction  : action  : IAction  -> Actions
    member AddActions : actions : IActions -> Actions

    member AddInsertCharacter : n     : int   -> Actions
    member AddDeleteCharacter : n     : int   -> Actions
    member AddInsertLine      : n     : int   -> Actions
    member AddDeleteLine      : n     : int   -> Actions
    member AddEraseDisplay    : erase : Erase -> Actions
    member AddEraseLine       : erase : Erase -> Actions

    member Clear : unit -> Actions
    member View  : unit -> unit

    member Apply    : action  : IAction * newLine : bool -> unit
    member Apply    : action  : IAction                  -> unit
    member ApplyAll : newLine : bool                     -> unit
    member ApplyAll : unit                               -> unit

    member Reset : unit -> unit

    static member DoInsertCharacter : n     : int   -> unit
    static member DoDeleteCharacter : n     : int   -> unit
    static member DoInsertLine      : n     : int   -> unit
    static member DoDeleteLine      : n     : int   -> unit
    static member DoEraseDisplay    : erase : Erase -> unit
    static member DoEraseLine       : erase : Erase -> unit

    static member DoReset : unit -> unit

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
