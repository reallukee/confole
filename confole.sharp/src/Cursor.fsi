(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Cursor.
                  Il modulo Cursor si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type ICursor =
    abstract member ToFunctional : Cursor.Cursor with get

type ICursors = ICursor list



[<AbstractClass>]
type CursorEmpty =
    interface ICursor

    new : cursor : Cursor.Cursor -> CursorEmpty

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type ReverseCursor =
    inherit CursorEmpty

    new : unit -> ReverseCursor

type SaveCursor =
    inherit CursorEmpty

    new : unit -> SaveCursor

type RestoreCursor =
    inherit CursorEmpty

    new : unit -> RestoreCursor



[<AbstractClass>]
type CursorN =
    interface ICursor

    new : cursor : (int option -> Cursor.Cursor) * n : int -> CursorN

    member N : int with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type UpCursor =
    inherit CursorN

    new : unit       -> UpCursor
    new : n    : int -> UpCursor

type DownCursor =
    inherit CursorN

    new : unit       -> DownCursor
    new : n    : int -> DownCursor

type NextCursor =
    inherit CursorN

    new : unit       -> NextCursor
    new : n    : int -> NextCursor

type PreviousCursor =
    inherit CursorN

    new : unit       -> PreviousCursor
    new : n    : int -> PreviousCursor

type NextLineCursor =
    inherit CursorN

    new : unit       -> NextLineCursor
    new : n    : int -> NextLineCursor

type PreviousLineCursor =
    inherit CursorN

    new : unit       -> PreviousLineCursor
    new : n    : int -> PreviousLineCursor



[<AbstractClass>]
type CursorPosition =
    interface ICursor

    new : cursor : (Position.Position option -> Cursor.Cursor) * position : Sharp.Position -> CursorPosition

    member Position : Sharp.Position with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type MoveCursor =
    inherit CursorPosition

    new : unit                      -> MoveCursor
    new : position : Sharp.Position -> MoveCursor



type Cursors =
    new : unit -> Cursors

    member NewLine : bool     with get, set
    member Cursors : ICursors with get

    new : cursors : ICursors * newLine : bool -> Cursors
    new : newLine : bool                      -> Cursors

    member Item : int -> ICursor with get

    member AddCursor  : cursor  : ICursor  -> Cursors
    member AddCursors : cursors : ICursors -> Cursors

    member AddReverse      : unit                -> Cursors
    member AddSave         : unit                -> Cursors
    member AddRestore      : unit                -> Cursors
    member AddUp           : n        : int      -> Cursors
    member AddDown         : n        : int      -> Cursors
    member AddNext         : n        : int      -> Cursors
    member AddPrevious     : n        : int      -> Cursors
    member AddNextLine     : n        : int      -> Cursors
    member AddPreviousLine : n        : int      -> Cursors
    member AddMove         : position : Position -> Cursors

    member Clear : unit -> Cursors
    member View  : unit -> unit

    member Apply    : cursor  : ICursor * newLine : bool -> unit
    member Apply    : cursor  : ICursor                  -> unit
    member ApplyAll : newLine : bool                     -> unit
    member ApplyAll : unit                               -> unit

    member Reset : unit -> unit

    static member DoReverse      : unit                -> unit
    static member DoSave         : unit                -> unit
    static member DoRestore      : unit                -> unit
    static member DoUp           : n        : int      -> unit
    static member DoDown         : n        : int      -> unit
    static member DoNext         : n        : int      -> unit
    static member DoPrevious     : n        : int      -> unit
    static member DoNextLine     : n        : int      -> unit
    static member DoPreviousLine : n        : int      -> unit
    static member DoMove         : position : Position -> unit

    static member DoReset : unit -> unit

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
