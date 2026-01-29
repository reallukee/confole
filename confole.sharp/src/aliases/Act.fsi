(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Act.fsi

    Title       : ACT
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Act.
                  Il modulo Act si occupa di sequenze VTS
                  relative al viewport del terminale.

                  Fornisce gli Alias di Action.

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
type Act =

    inherit Actions

    internal new : unit -> Act

    // Alias modalità manuale
    static member RenderIC : unit       -> string
    static member RenderIC : n    : int -> string
    static member RenderDC : unit       -> string
    static member RenderDC : n    : int -> string

    static member RenderIL : unit       -> string
    static member RenderIL : n    : int -> string
    static member RenderDL : unit       -> string
    static member RenderDL : n    : int -> string

    static member RenderED : unit          -> string
    static member RenderED : erase : Erase -> string
    static member RenderEL : unit          -> string
    static member RenderEL : erase : Erase -> string

    (*
        Modalità "funzionale"

        (Si fa per dire visto che siamo in OOP)

        /!\ IMPORTANTE!

        In OOP, la modalità “funzionale” viene gestita tramite
        una classe fluent. Le classi fluent sono potenti, ma
        hanno dei limiti: i metodi sono strettamente legate
        al tipo della classe.
        Per permettere alla classe Act di funzionare come un
        “superset” della classe Action, è quindi necessario
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

    static member Init     : unit       -> Act
    static member InitWith : act  : Act -> Act

    member Clear : unit -> Act

    member View    : unit -> Act
    member Preview : unit -> Act

    member InsertCharacter : unit       -> Act
    member InsertCharacter : n    : int -> Act
    member DeleteCharacter : unit       -> Act
    member DeleteCharacter : n    : int -> Act

    member InsertLine : unit       -> Act
    member InsertLine : n    : int -> Act
    member DeleteLine : unit       -> Act
    member DeleteLine : n    : int -> Act

    member EraseDisplay : unit          -> Act
    member EraseDisplay : erase : Erase -> Act
    member EraseLine    : unit          -> Act
    member EraseLine    : erase : Erase -> Act

    // Alias modalità "funzionale"
    member IC : unit       -> Act
    member IC : n    : int -> Act
    member DC : unit       -> Act
    member DC : n    : int -> Act

    member IL : unit       -> Act
    member IL : n    : int -> Act
    member DL : unit       -> Act
    member DL : n    : int -> Act

    member ED : unit          -> Act
    member ED : erase : Erase -> Act
    member EL : unit          -> Act
    member EL : erase : Erase -> Act

    // Alias modalità imperativa
    static member DoIC : unit       -> unit
    static member DoIC : n    : int -> unit
    static member DoDC : unit       -> unit
    static member DoDC : n    : int -> unit

    static member DoIL : unit       -> unit
    static member DoIL : n    : int -> unit
    static member DoDL : unit       -> unit
    static member DoDL : n    : int -> unit

    static member DoED : unit          -> unit
    static member DoED : erase : Erase -> unit
    static member DoEL : unit          -> unit
    static member DoEL : erase : Erase -> unit
