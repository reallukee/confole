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

[<Class>]
type Cursors =

    (*
        Wrapper OOP modulo Cursor: v4

        Cosa manca?

        * render    : Perchè? Richiederebbe il wrapping della DU.
        * apply     : Perchè? Richiederebbe il wrapping della DU.
        * configure : Perchè? Richiederebbe il wrapping della DU.
        * Builder   : I DSL in C# non esistono.

        Detto questo buon uso!

        MIAO a tutti!
    *)

    static member NewLine     : bool                with get,         set
    member        CursorsList : List<Cursor.Cursor> with internal get

    // Modalità manuale
    member Renders : unit -> string

    static member RenderReverse : unit -> string
    static member RenderSave    : unit -> string
    static member RenderRestore : unit -> string

    static member RenderUp       : unit    -> string
    static member RenderUp       : n : int -> string
    static member RenderDown     : unit    -> string
    static member RenderDown     : n : int -> string
    static member RenderNext     : unit    -> string
    static member RenderNext     : n : int -> string
    static member RenderPrevious : unit    -> string
    static member RenderPrevious : n : int -> string

    static member RenderNextLine     : unit    -> string
    static member RenderNextLine     : n : int -> string
    static member RenderPreviousLine : unit    -> string
    static member RenderPreviousLine : n : int -> string

    static member RenderMove : unit                -> string
    static member RenderMove : position : Position -> string

    static member RenderReset : unit -> string

    // Modalità "funzionale"
    static member Init  : unit -> Cursors
    member        Clear : unit -> Cursors
    member        View  : unit -> Cursors

    member Reverse : unit -> Cursors
    member Save    : unit -> Cursors
    member Restore : unit -> Cursors

    member Up       : unit    -> Cursors
    member Up       : n : int -> Cursors
    member Down     : unit    -> Cursors
    member Down     : n : int -> Cursors
    member Next     : unit    -> Cursors
    member Next     : n : int -> Cursors
    member Previous : unit    -> Cursors
    member Previous : n : int -> Cursors

    member NextLine     : unit    -> Cursors
    member NextLine     : n : int -> Cursors
    member PreviousLine : unit    -> Cursors
    member PreviousLine : n : int -> Cursors

    member Move : unit                -> Cursors
    member Move : position : Position -> Cursors

    member ApplyAll : unit           -> unit
    member ApplyAll : newLine : bool -> unit

    static member Reset : unit -> unit

    // Modalità imperativa
    static member DoReverse : unit -> unit
    static member DoSave    : unit -> unit
    static member DoRestore : unit -> unit

    static member DoUp       : unit    -> unit
    static member DoUp       : n : int -> unit
    static member DoDown     : unit    -> unit
    static member DoDown     : n : int -> unit
    static member DoNext     : unit    -> unit
    static member DoNext     : n : int -> unit
    static member DoPrevious : unit    -> unit
    static member DoPrevious : n : int -> unit

    static member DoNextLine     : unit    -> unit
    static member DoNextLine     : n : int -> unit
    static member DoPreviousLine : unit    -> unit
    static member DoPreviousLine : n : int -> unit

    static member DoMove : unit                -> unit
    static member DoMove : position : Position -> unit

    static member DoReset : unit -> unit
