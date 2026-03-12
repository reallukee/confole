(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cur.fsi

    Title       : CUR
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Cur.
                  Il modulo Cur si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Fornisce gli Alias di Cursor.

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
type Cur =

    inherit Cursors

    internal new : unit -> Cur

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

    (*
        Modalità "funzionale"

        (Si fa per dire visto che siamo in OOP)

        /!\ IMPORTANTE!

        In OOP, la modalità “funzionale” viene gestita tramite
        una classe fluent. Le classi fluent sono potenti, ma
        hanno dei limiti: i metodi sono strettamente legate
        al tipo della classe.
        Per permettere alla classe Cur di funzionare come un
        “superset” della classe Cursor, è quindi necessario
        sovrascrivere alcuni metodi.
        L'override (statico o istanza) cambia semplicemente
        il tipo di restituzione tramite casting.

        Questo problema potrebbe essere aggirato tramite la
        stesura di apposite super-classi con template e/o
        interfacce MA EI, non ho voglia!

        No scherzo, semplicemente questo è un Wrapper,
        non voglio avere troppo boilerplate.

                                       |\__/,|   (`\
        Franceschino CI osserva...   _.|o o  |_   ) )
                                     -(((---(((--------
    *)

    static member Init     : unit       -> Cur
    static member InitWith : cur  : Cur -> Cur

    member Clear : unit -> Cur

    member View    : unit -> Cur
    member Preview : unit -> Cur

    member Reverse : unit -> Cur
    member Save    : unit -> Cur
    member Restore : unit -> Cur

    member Up       : unit       -> Cur
    member Up       : n    : int -> Cur
    member Down     : unit       -> Cur
    member Down     : n    : int -> Cur
    member Next     : unit       -> Cur
    member Next     : n    : int -> Cur
    member Previous : unit       -> Cur
    member Previous : n    : int -> Cur

    member NextLine     : unit       -> Cur
    member NextLine     : n    : int -> Cur
    member PreviousLine : unit       -> Cur
    member PreviousLine : n    : int -> Cur

    member Move : unit                -> Cur
    member Move : position : Position -> Cur

    // Alias modalità "funzionale"
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
