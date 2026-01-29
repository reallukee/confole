(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Fmt.fsi

    Title       : FMT
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Fmt.
                  Il modulo Fmt si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Fornisce gli Alias di Format.

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
type Fmt =

    inherit Formats

    internal new : unit -> Fmt

    // Alias modalità manuale
    static member RenderRST : text : string -> string

    static member RenderRFGC : text : string -> string
    static member RenderRBGC : text : string -> string

    static member RenderBLD : text : string               -> string
    static member RenderBLD : text : string * flag : bool -> string
    static member RenderFNT : text : string               -> string
    static member RenderFNT : text : string * flag : bool -> string
    static member RenderITC : text : string               -> string
    static member RenderITC : text : string * flag : bool -> string
    static member RenderUND : text : string               -> string
    static member RenderUND : text : string * flag : bool -> string
    static member RenderBKG : text : string               -> string
    static member RenderBKG : text : string * flag : bool -> string
    static member RenderRVS : text : string               -> string
    static member RenderRVS : text : string * flag : bool -> string
    static member RenderHDN : text : string               -> string
    static member RenderHDN : text : string * flag : bool -> string
    static member RenderSKT : text : string               -> string
    static member RenderSKT : text : string * flag : bool -> string

    static member RenderFGC : text : string                 -> string
    static member RenderFGC : text : string * color : Color -> string
    static member RenderBGC : text : string                 -> string
    static member RenderBGC : text : string * color : Color -> string

    (*
        Modalità "funzionale"

        (Si fa per dire visto che siamo in OOP)

        /!\ IMPORTANTE!

        In OOP, la modalità “funzionale” viene gestita tramite
        una classe fluent. Le classi fluent sono potenti, ma
        hanno dei limiti: i metodi sono strettamente legate
        al tipo della classe.
        Per permettere alla classe Fmt di funzionare come un
        “superset” della classe Format, è quindi necessario
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

    static member Init     : unit       -> Fmt
    static member InitWith : fmt  : Fmt -> Fmt

    member Clear : unit -> Fmt

    member View    : unit -> Fmt
    member Preview : unit -> Fmt

    member Restore : unit -> Fmt

    member RestoreForegroundColor : unit -> Fmt
    member RestoreBackgroundColor : unit -> Fmt

    member Bold      : unit        -> Fmt
    member Bold      : flag : bool -> Fmt
    member Faint     : unit        -> Fmt
    member Faint     : flag : bool -> Fmt
    member Italic    : unit        -> Fmt
    member Italic    : flag : bool -> Fmt
    member Underline : unit        -> Fmt
    member Underline : flag : bool -> Fmt
    member Blinking  : unit        -> Fmt
    member Blinking  : flag : bool -> Fmt
    member Reverse   : unit        -> Fmt
    member Reverse   : flag : bool -> Fmt
    member Hidden    : unit        -> Fmt
    member Hidden    : flag : bool -> Fmt
    member Strikeout : unit        -> Fmt
    member Strikeout : flag : bool -> Fmt

    member ForegroundColor : unit          -> Fmt
    member ForegroundColor : color : Color -> Fmt
    member BackgroundColor : unit          -> Fmt
    member BackgroundColor : color : Color -> Fmt

    // Alias modalità "funzionale"
    member RST : unit -> Fmt

    member RFGC : unit -> Fmt
    member RBGC : unit -> Fmt

    member BLD : unit        -> Fmt
    member BLD : flag : bool -> Fmt
    member FNT : unit        -> Fmt
    member FNT : flag : bool -> Fmt
    member ITC : unit        -> Fmt
    member ITC : flag : bool -> Fmt
    member UND : unit        -> Fmt
    member UND : flag : bool -> Fmt
    member BKG : unit        -> Fmt
    member BKG : flag : bool -> Fmt
    member RVS : unit        -> Fmt
    member RVS : flag : bool -> Fmt
    member HDN : unit        -> Fmt
    member HDN : flag : bool -> Fmt
    member SKT : unit        -> Fmt
    member SKT : flag : bool -> Fmt

    member FGC : unit          -> Fmt
    member FGC : color : Color -> Fmt
    member BGC : unit          -> Fmt
    member BGC : color : Color -> Fmt

    // Alias modalità imperativa
    static member DoRST : text : string -> unit

    static member DoRFGC : text : string -> unit
    static member DoRBGC : text : string -> unit

    static member DoBLD : text : string               -> unit
    static member DoBLD : text : string * flag : bool -> unit
    static member DoFNT : text : string               -> unit
    static member DoFNT : text : string * flag : bool -> unit
    static member DoITC : text : string               -> unit
    static member DoITC : text : string * flag : bool -> unit
    static member DoUND : text : string               -> unit
    static member DoUND : text : string * flag : bool -> unit
    static member DoBKG : text : string               -> unit
    static member DoBKG : text : string * flag : bool -> unit
    static member DoRVS : text : string               -> unit
    static member DoRVS : text : string * flag : bool -> unit
    static member DoHDN : text : string               -> unit
    static member DoHDN : text : string * flag : bool -> unit
    static member DoSKT : text : string               -> unit
    static member DoSKT : text : string * flag : bool -> unit

    static member DoFGC : text : string                 -> unit
    static member DoFGC : text : string * color : Color -> unit
    static member DoBGC : text : string                 -> unit
    static member DoBGC : text : string * color : Color -> unit
