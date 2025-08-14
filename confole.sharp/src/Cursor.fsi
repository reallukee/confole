(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Cursor

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type ICursor =
    abstract member ToFunctional : Cursor.Cursor with get

type ICursors = ICursor list



type ReverseCursor =
    interface ICursor

    new : unit -> ReverseCursor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type SaveCursor =
    interface ICursor

    new : unit -> SaveCursor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type RestoreCursor =
    interface ICursor

    new : unit -> RestoreCursor

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type UpCursor =
    interface ICursor

    new : unit -> UpCursor
    new : int -> UpCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DownCursor =
    interface ICursor

    new : unit -> DownCursor
    new : int -> DownCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type NextCursor =
    interface ICursor

    new : unit -> NextCursor
    new : int -> NextCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type PreviousCursor =
    interface ICursor

    new : unit -> PreviousCursor
    new : int -> PreviousCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type NextLineCursor =
    interface ICursor

    new : unit -> NextLineCursor
    new : int -> NextLineCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type PreviousLineCursor =
    interface ICursor

    new : unit -> PreviousLineCursor
    new : int -> PreviousLineCursor

    member N : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type CursorMove =
    interface ICursor

    new : Position -> CursorMove

    member Position : Position with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type Cursors =
    new : unit -> Cursors

    member NewLine : bool     with get, set
    member Cursors : ICursors with get

    new : ICursors * bool -> Cursors
    new : bool -> Cursors

    member Item : int -> ICursor with get

    member AddCursor  : ICursor  -> Cursors
    member AddCursors : ICursors -> Cursors

    member AddReverseCursor : unit -> Cursors
    member AddSaveCursor    : unit -> Cursors
    member AddRestoreCursor : unit -> Cursors

    member AddUpCursor       : int -> Cursors
    member AddDownCursor     : int -> Cursors
    member AddNextCursor     : int -> Cursors
    member AddPreviousCursor : int -> Cursors

    member AddNextLineCursor     : int -> Cursors
    member AddPreviousLineCursor : int -> Cursors

    member AddMoveCursor : Position -> Cursors

    member Clear : unit -> Cursors

    member View : unit -> unit

    member Apply : ICursor * bool -> unit
    member Apply : ICursor        -> unit

    member ApplyAll : bool -> unit
    member ApplyAll : unit -> unit

    member Reset : unit -> unit

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
