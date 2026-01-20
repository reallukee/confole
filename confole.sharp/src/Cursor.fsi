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

    static member NewLine     : bool                with get,          set
    member        CursorsList : List<Cursor.Cursor> with internal get, internal set

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
    static member Init  : unit              -> Cursors
    static member Initp : cursors : Cursors -> Cursors
    member        Clear : unit              -> Cursors
    member        View  : unit              -> Cursors

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

[<Class>]
type Cur =

    inherit Cursors

    // Alias modalità manuale
    static member RenderRVS : unit -> string
    static member RenderSV  : unit -> string
    static member RenderRST : unit -> string

    static member RenderU  : unit    -> string
    static member RenderU  : n : int -> string
    static member RenderD  : unit    -> string
    static member RenderD  : n : int -> string
    static member RenderNX : unit    -> string
    static member RenderNX : n : int -> string
    static member RenderPV : unit    -> string
    static member RenderPV : n : int -> string

    static member RenderNXL : unit    -> string
    static member RenderNXL : n : int -> string
    static member RenderPVL : unit    -> string
    static member RenderPVL : n : int -> string

    static member RenderMV : unit                -> string
    static member RenderMV : position : Position -> string

    // Alias modalità "funzionale"
    static member Init : unit -> Cur

    member RVS : unit -> Cur
    member SV  : unit -> Cur
    member RST : unit -> Cur

    member U  : unit    -> Cur
    member U  : n : int -> Cur
    member D  : unit    -> Cur
    member D  : n : int -> Cur
    member NX : unit    -> Cur
    member NX : n : int -> Cur
    member PV : unit    -> Cur
    member PV : n : int -> Cur

    member NXL : unit    -> Cur
    member NXL : n : int -> Cur
    member PVL : unit    -> Cur
    member PVL : n : int -> Cur

    member MV : unit                -> Cur
    member MV : position : Position -> Cur

    // Alias modalità imperativa
    static member DoRVS : unit -> unit
    static member DoSV  : unit -> unit
    static member DoRST : unit -> unit

    static member DoU  : unit    -> unit
    static member DoU  : n : int -> unit
    static member DoD  : unit    -> unit
    static member DoD  : n : int -> unit
    static member DoNX : unit    -> unit
    static member DoNX : n : int -> unit
    static member DoPV : unit    -> unit
    static member DoPV : n : int -> unit

    static member DoNXL : unit    -> unit
    static member DoNXL : n : int -> unit
    static member DoPVL : unit    -> unit
    static member DoPVL : n : int -> unit

    static member DoMV : unit                -> unit
    static member DoMV : position : Position -> unit
