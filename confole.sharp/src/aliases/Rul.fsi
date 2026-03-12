(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rul.fsi

    Title       : RUL
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Rul.
                  Il modulo Rul si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Fornisce gli Alias di Rule.

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
type Rul =

    inherit Rules

    internal new : unit -> Rul

    // Alias modalità manuale
    static member RenderTTL : title : string -> string

    static member RenderSCB : unit -> string
    static member RenderHCB : unit -> string

    static member RenderSC : unit -> string
    static member RenderHC : unit -> string

    static member RenderEDM : unit -> string
    static member RenderDDM : unit -> string

    static member RenderEAB : unit -> string
    static member RenderDAB : unit -> string

    static member RenderCS : unit          -> string
    static member RenderCS : shape : Shape -> string

    static member RenderDFGC : unit          -> string
    static member RenderDFGC : color : Color -> string
    static member RenderDBGC : unit          -> string
    static member RenderDBGC : color : Color -> string
    static member RenderDCC  : unit          -> string
    static member RenderDCC  : color : Color -> string

    (*
        Modalità "funzionale"

        (Si fa per dire visto che siamo in OOP)

        /!\ IMPORTANTE!

        In OOP, la modalità “funzionale” viene gestita tramite
        una classe fluent. Le classi fluent sono potenti, ma
        hanno dei limiti: i metodi sono strettamente legate
        al tipo della classe.
        Per permettere alla classe Rul di funzionare come un
        “superset” della classe Rule, è quindi necessario
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

    static member Init     : unit       -> Rul
    static member InitWith : rul  : Rul -> Rul

    member Clear : unit -> Rul

    member View    : unit -> Rul
    member Preview : unit -> Rul

    member Title : title : string -> Rul

    member ShowCursorBlinking : unit -> Rul
    member HideCursorBlinking : unit -> Rul

    member ShowCursor : unit -> Rul
    member HideCursor : unit -> Rul

    member EnableDesignateMode  : unit -> Rul
    member DisableDesignateMode : unit -> Rul

    member EnableAlternativeBuffer  : unit -> Rul
    member DisableAlternativeBuffer : unit -> Rul

    member CursorShape : unit          -> Rul
    member CursorShape : shape : Shape -> Rul

    member DefaultForegroundColor : unit          -> Rul
    member DefaultForegroundColor : color : Color -> Rul
    member DefaultBackgroundColor : unit          -> Rul
    member DefaultBackgroundColor : color : Color -> Rul
    member DefaultCursorColor     : unit          -> Rul
    member DefaultCursorColor     : color : Color -> Rul

    // Alias modalità "funzionale"
    member TTL : title : string -> Rul

    member SCB : unit -> Rul
    member HCB : unit -> Rul

    member SC : unit -> Rul
    member HC : unit -> Rul

    member EDM : unit -> Rul
    member DDM : unit -> Rul

    member EAB : unit -> Rul
    member DAB : unit -> Rul

    member CS : unit          -> Rul
    member CS : shape : Shape -> Rul

    member DFGC : unit          -> Rul
    member DFGC : color : Color -> Rul
    member DBGC : unit          -> Rul
    member DBGC : color : Color -> Rul
    member DCC  : unit          -> Rul
    member DCC  : color : Color -> Rul

    // Alias modalità imperativa
    static member DoTTL : title : string -> unit

    static member DoSCB : unit -> unit
    static member DoHCB : unit -> unit

    static member DoSC : unit -> unit
    static member DoHC : unit -> unit

    static member DoEDM : unit -> unit
    static member DoDDM : unit -> unit

    static member DoEAB : unit -> unit
    static member DoDAB : unit -> unit

    static member DoCS : unit          -> unit
    static member DoCS : shape : Shape -> unit

    static member DoDFGC : unit          -> unit
    static member DoDFGC : color : Color -> unit
    static member DoDBGC : unit          -> unit
    static member DoDBGC : color : Color -> unit
    static member DoDCC  : unit          -> unit
    static member DoDCC  : color : Color -> unit
