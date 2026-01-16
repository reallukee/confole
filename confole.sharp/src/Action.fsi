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

                  Riscrittura v4!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open System
open System.Collections
open System.Collections.Generic

open Reallukee.Confole

type Erase =
    | FromCurrentToEnd   = 0
    | FromBeginToCurrent = 1
    | FromBeginToEnd     = 2

[<Class>]
type Actions =

    (*
        Wrapper OOP modulo Action: v4

        Cosa manca?

        * render    : Perchè? Richiederebbe il wrapping della DU.
        * apply     : Perchè? Richiederebbe il wrapping della DU.
        * configure : Perchè? Richiederebbe il wrapping della DU.
        * Builder   : I DSL in C# non esistono.

        Detto questo buon uso!

        MIAO a tutti!
    *)

    static member NewLine     : bool                with get,         set
    member        ActionsList : List<Action.Action> with internal get

    // Modalità manuale
    member Renders : unit -> string

    static member RenderInsertCharacter : unit    -> string
    static member RenderInsertCharacter : n : int -> string
    static member RenderDeleteCharacter : unit    -> string
    static member RenderDeleteCharacter : n : int -> string

    static member RenderInsertLine : unit    -> string
    static member RenderInsertLine : n : int -> string
    static member RenderDeleteLine : unit    -> string
    static member RenderDeleteLine : n : int -> string

    static member RenderEraseDisplay : unit          -> string
    static member RenderEraseDisplay : erase : Erase -> string
    static member RenderEraseLine    : unit          -> string
    static member RenderEraseLine    : erase : Erase -> string

    static member RenderReset : unit -> string

    // Modalità "funzionale"
    static member Init  : unit -> Actions
    member        Clear : unit -> Actions
    member        View  : unit -> Actions

    member InsertCharacter : unit    -> Actions
    member InsertCharacter : n : int -> Actions
    member DeleteCharacter : unit    -> Actions
    member DeleteCharacter : n : int -> Actions

    member InsertLine : unit    -> Actions
    member InsertLine : n : int -> Actions
    member DeleteLine : unit    -> Actions
    member DeleteLine : n : int -> Actions

    member EraseDisplay : unit          -> Actions
    member EraseDisplay : erase : Erase -> Actions
    member EraseLine    : unit          -> Actions
    member EraseLine    : erase : Erase -> Actions

    member ApplyAll : unit           -> unit
    member ApplyAll : newLine : bool -> unit

    static member Reset : unit -> unit

    // Modalità imperativa
    static member DoInsertCharacter : unit    -> unit
    static member DoInsertCharacter : n : int -> unit
    static member DoDeleteCharacter : unit    -> unit
    static member DoDeleteCharacter : n : int -> unit

    static member DoInsertLine : unit    -> unit
    static member DoInsertLine : n : int -> unit
    static member DoDeleteLine : unit    -> unit
    static member DoDeleteLine : n : int -> unit

    static member DoEraseDisplay : unit          -> unit
    static member DoEraseDisplay : erase : Erase -> unit
    static member DoEraseLine    : unit          -> unit
    static member DoEraseLine    : erase : Erase -> unit

    static member DoReset : unit -> unit
