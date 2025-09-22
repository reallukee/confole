(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Cursor

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
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

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type SaveCursor =
    interface ICursor

    new : unit -> SaveCursor

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type RestoreCursor =
    interface ICursor

    new : unit -> RestoreCursor

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type UpCursor =
    interface ICursor

    new : unit    -> UpCursor
    new : n : int -> UpCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type DownCursor =
    interface ICursor

    new : unit    -> DownCursor
    new : n : int -> DownCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type NextCursor =
    interface ICursor

    new : unit    -> NextCursor
    new : n : int -> NextCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type PreviousCursor =
    interface ICursor

    new : unit    -> PreviousCursor
    new : n : int -> PreviousCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type NextLineCursor =
    interface ICursor

    new : unit    -> NextLineCursor
    new : n : int -> NextLineCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string

type PreviousLineCursor =
    interface ICursor

    new : unit    -> PreviousLineCursor
    new : n : int -> PreviousLineCursor

    member N : int with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type MoveCursor =
    interface ICursor

    new : position : Position -> MoveCursor

    member Position : Position with get, set

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string



type Cursors =
    new : unit -> Cursors

    member NewLine : bool     with get, set
    member Cursors : ICursors with get

    new : cursors : ICursors * newLine : bool -> Cursors
    new : newLine : bool                      -> Cursors

    member Item : int -> ICursor with get

    member AddCursor  : cursor  : ICursor  -> Cursors
    member AddCursors : cursors : ICursors -> Cursors

    member AddReverseCursor : unit -> Cursors
    member AddSaveCursor    : unit -> Cursors
    member AddRestoreCursor : unit -> Cursors

    member AddUpCursor       : n : int -> Cursors
    member AddDownCursor     : n : int -> Cursors
    member AddNextCursor     : n : int -> Cursors
    member AddPreviousCursor : n : int -> Cursors

    member AddNextLineCursor     : n : int -> Cursors
    member AddPreviousLineCursor : n : int -> Cursors

    member AddMoveCursor : position : Position -> Cursors

    member Clear : unit -> Cursors
    member View  : unit -> unit

    member Apply : cursor : ICursor * newLine : bool -> unit
    member Apply : cursor : ICursor                 -> unit

    member ApplyAll : newLine : bool -> unit
    member ApplyAll : unit           -> unit

    member Reset : unit -> unit

    override Equals      : obj : obj -> bool
    override GetHashCode : unit      -> int
    override ToString    : unit      -> string
