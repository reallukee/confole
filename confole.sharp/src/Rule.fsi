(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fsi

    Title       : RULE
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Rule.
                  Il modulo Rule si occupa di wrappare
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

type Shape =
    | User              = 0
    | BlinkingBlock     = 1
    | SteadyBlock       = 2
    | BlinkingUnderline = 3
    | SteadyUnderline   = 4
    | BlinkingBar       = 5
    | SteadyBar         = 6

[<Class>]
type Rules =

    (*
        Wrapper OOP modulo Rule: v4

        Cosa manca?

        * render    : Perchè? Richiederebbe il wrapping della DU.
        * apply     : Perchè? Richiederebbe il wrapping della DU.
        * configure : Perchè? Richiederebbe il wrapping della DU.
        * Builder   : I DSL in C# non esistono.

        Detto questo buon uso!

        MIAO a tutti!
    *)

    static member NewLine   : bool            with get,         set
    member        RulesList : List<Rule.Rule> with internal get

    // Modalità manuale
    member Renders : unit -> string

    static member RenderTitle : title : string -> string

    static member RenderShowCursorBlinking : unit -> string
    static member RenderHideCursorBlinking : unit -> string

    static member RenderShowCursor : unit -> string
    static member RenderHideCursor : unit -> string

    static member RenderEnableDesignateMode  : unit -> string
    static member RenderDisableDesignateMode : unit -> string

    static member RenderEnableAlternativeBuffer  : unit -> string
    static member RenderDisableAlternativeBuffer : unit -> string

    static member RenderCursorShape : unit          -> string
    static member RenderCursorShape : shape : Shape -> string

    static member RenderDefaultForegroundColor : unit          -> string
    static member RenderDefaultForegroundColor : color : Color -> string
    static member RenderDefaultBackgroundColor : unit          -> string
    static member RenderDefaultBackgroundColor : color : Color -> string
    static member RenderDefaultCursorColor     : unit          -> string
    static member RenderDefaultCursorColor     : color : Color -> string

    static member RenderReset : unit -> string

    // Modalità "funzionale"
    static member Init  : unit -> Rules
    member        Clear : unit -> Rules
    member        View  : unit -> Rules

    member Title : title : string -> Rules

    member ShowCursorBlinking : unit -> Rules
    member HideCursorBlinking : unit -> Rules

    member ShowCursor : unit -> Rules
    member HideCursor : unit -> Rules

    member EnableDesignateMode  : unit -> Rules
    member DisableDesignateMode : unit -> Rules

    member EnableAlternativeBuffer  : unit -> Rules
    member DisableAlternativeBuffer : unit -> Rules

    member CursorShape : unit          -> Rules
    member CursorShape : shape : Shape -> Rules

    member DefaultForegroundColor : unit          -> Rules
    member DefaultForegroundColor : color : Color -> Rules
    member DefaultBackgroundColor : unit          -> Rules
    member DefaultBackgroundColor : color : Color -> Rules
    member DefaultCursorColor     : unit          -> Rules
    member DefaultCursorColor     : color : Color -> Rules

    member ApplyAll : unit           -> unit
    member ApplyAll : newLine : bool -> unit

    static member Reset : unit -> unit

    // Modalità imperativa
    static member DoTitle : title : string -> unit

    static member DoShowCursorBlinking : unit -> unit
    static member DoHideCursorBlinking : unit -> unit

    static member DoShowCursor : unit -> unit
    static member DoHideCursor : unit -> unit

    static member DoEnableDesignateMode  : unit -> unit
    static member DoDisableDesignateMode : unit -> unit

    static member DoEnableAlternativeBuffer  : unit -> unit
    static member DoDisableAlternativeBuffer : unit -> unit

    static member DoCursorShape : unit          -> unit
    static member DoCursorShape : shape : Shape -> unit

    static member DoDefaultForegroundColor : unit          -> unit
    static member DoDefaultForegroundColor : color : Color -> unit
    static member DoDefaultBackgroundColor : unit          -> unit
    static member DoDefaultBackgroundColor : color : Color -> unit
    static member DoDefaultCursorColor     : unit          -> unit
    static member DoDefaultCursorColor     : color : Color -> unit

    static member DoReset : unit -> unit
