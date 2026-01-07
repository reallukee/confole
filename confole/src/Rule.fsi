(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fsi

    Title       : RULE
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Rule.
                  Il modulo Rule si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Il modulo Rule permette di ottenere gli
                  stessi risultati con 4 approcci diversi:

                  * Manuale
                  * Funzionale
                  * Imperativo
                  * DSL

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open ColorConversion
open Position
open PositionConversion

// Rul
module Rule =

    type Shape =
        | User
        | BlinkingBlock
        | SteadyBlock
        | BlinkingUnderline
        | SteadyUnderline
        | BlinkingBar
        | SteadyBar

     (*
        Le VTS presenti in questo modulo sono state tratte dalla
        guida di Microsoft sull'uso dell'API della console.

        Puoi consultare la documentazione sopra citata qui:

        https://learn.microsoft.com/windows/console/console-virtual-terminal-sequences

        NOTA BENE: L'implementazione sottostante si prende delle
                   "libertà creative" per adattarsi alle scelte
                   progettuali di Confole. Questo si traduce, tra
                   le altre cose, in naming e valori di default
                   personalizzati!

        NOTE BENE: Purtroppo a causa della mia infinita svogliatezza
                   non ho ancora scritto la documentazione in-code.
                   Punto quindi sul fatto che l'API sia così costruita
                   bene da parlare da sé!

                   Buon divertimento \(._.)/ <333!
    *)

    type Rule =
        | Title                    of title : string       // TTL
        | ShowCursorBlinking                               // SCB
        | HideCursorBlinking                               // HCB
        | ShowCursor                                       // SC
        | HideCursor                                       // HC
        | EnableDesignateMode                              // EDM
        | DisableDesignateMode                             // DDM
        | EnableAlternativeBuffer                          // EAB
        | DisableAlternativeBuffer                         // DAB
        | CursorShape              of shape : Shape option // CS
        | DefaultForegroundColor   of color : Color option // DFGC
        | DefaultBackgroundColor   of color : Color option // DBGC
        | DefaultCursorColor       of color : Color option // DCC

    val TTL  : string       -> Rule
    val SCB  : Rule
    val HCB  : Rule
    val SC   : Rule
    val HC   : Rule
    val EDM  : Rule
    val DDM  : Rule
    val EAB  : Rule
    val DAB  : Rule
    val CS   : Shape option -> Rule
    val DFGC : Color option -> Rule
    val DBGC : Color option -> Rule
    val DCC  : Color option -> Rule

    type Rules = Rule list

    val defaultRules : Rules



    // Modalità manuale
    val render  : rule  : Rule  -> string
    val renders : rules : Rules -> string

    val renderTitle : title : string -> string

    val renderShowCursorBlinking : unit -> string
    val renderHideCursorBlinking : unit -> string

    val renderShowCursor : unit -> string
    val renderHideCursor : unit -> string

    val renderEnableDesignateMode  : unit -> string
    val renderDisableDesignateMode : unit -> string

    val renderEnableAlternativeBuffer  : unit -> string
    val renderDisableAlternativeBuffer : unit -> string

    val renderCursorShape : shape : Shape option -> string

    val renderDefaultForegroundColor : color : Color option -> string
    val renderDefaultBackgroundColor : color : Color option -> string
    val renderDefaultCursorColor     : color : Color option -> string

    val renderReset : unit -> string

    // Alias modalità manuale
    val renderTTL : (string -> string)

    val renderSCB : (unit -> string)
    val renderHCB : (unit -> string)

    val renderSC : (unit -> string)
    val renderHC : (unit -> string)

    val renderEDM : (unit -> string)
    val renderDDM : (unit -> string)

    val renderEAB : (unit -> string)
    val renderDAB : (unit -> string)

    val renderCS : (Shape option -> string)

    val renderDFGC : (Color option -> string)
    val renderDBGC : (Color option -> string)
    val renderDCC  : (Color option -> string)



    // Modalità funzionale
    val init  : unit          -> Rules
    val initp : rules : Rules -> Rules
    val clear : rules : Rules -> Rules
    val view  : rules : Rules -> Rules

    val title : title : string -> rules : Rules -> Rules

    val showCursorBlinking : rules : Rules -> Rules
    val hideCursorBlinking : rules : Rules -> Rules

    val showCursor : rules : Rules -> Rules
    val hideCursor : rules : Rules -> Rules

    val enableDesignateMode  : rules : Rules -> Rules
    val disableDesignateMode : rules : Rules -> Rules

    val enableAlternativeBuffer  : rules : Rules -> Rules
    val disableAlternativeBuffer : rules : Rules -> Rules

    val cursorShape : shape : Shape option -> rules : Rules -> Rules

    val defaultForegroundColor : color : Color option -> rules : Rules -> Rules
    val defaultBackgroundColor : color : Color option -> rules : Rules -> Rules
    val defaultCursorColor     : color : Color option -> rules : Rules -> Rules

    val apply           : rule  : Rule  -> unit
    val applyNewLine    : rule  : Rule  -> unit
    val applyAll        : rules : Rules -> unit
    val applyAllNewLine : rules : Rules -> unit

    val reset : unit -> unit

    val configure        : config : (Rules -> Rules) -> unit
    val configureNewLine : config : (Rules -> Rules) -> unit

    // Alias modalità funzionale
    val ttl : (string -> Rules -> Rules)

    val scb : (Rules -> Rules)
    val hcb : (Rules -> Rules)

    val sc : (Rules -> Rules)
    val hc : (Rules -> Rules)

    val edm : (Rules -> Rules)
    val ddm : (Rules -> Rules)

    val eab : (Rules -> Rules)
    val dab : (Rules -> Rules)

    val cs : (Shape option -> Rules -> Rules)

    val dfgc : (Color option -> Rules -> Rules)
    val dbgc : (Color option -> Rules -> Rules)
    val dcc  : (Color option -> Rules -> Rules)



    // Modalità DSL
    type Builder =
        new : unit -> Builder

        member Yield :
            ruleFunction : (Rules -> Rules) ->
            (Rules -> Rules)

        member Combine :
            rule : (Rules -> Rules) * ruleFunction : (Rules -> Rules) ->
            (Rules -> Rules)

        member Delay :
            ``function`` : (unit -> (Rules -> Rules)) ->
            (Rules -> Rules)

        member Run :
            rulesFunction : (Rules -> Rules) ->
            Rules

    // Alias modalità DSL
    val builder : Builder



    // Modalità imperativa
    val doTitle : title : string -> unit

    val doShowCursorBlinking : unit -> unit
    val doHideCursorBlinking : unit -> unit

    val doShowCursor : unit -> unit
    val doHideCursor : unit -> unit

    val doEnableDesignateMode  : unit -> unit
    val doDisableDesignateMode : unit -> unit

    val doEnableAlternativeBuffer  : unit -> unit
    val doDisableAlternativeBuffer : unit -> unit

    val doCursorShape : shape : Shape option -> unit

    val doDefaultForegroundColor : color : Color option -> unit
    val doDefaultBackgroundColor : color : Color option -> unit
    val doDefaultCursorColor     : color : Color option -> unit

    val doReset : unit -> unit

    // Alias modalità imperativa
    val doTTL : (string -> unit)

    val doSCB : (unit -> unit)
    val doHCB : (unit -> unit)

    val doSC : (unit -> unit)
    val doHC : (unit -> unit)

    val doEDM : (unit -> unit)
    val doDDM : (unit -> unit)

    val doEAB : (unit -> unit)
    val doDAB : (unit -> unit)

    val doCS : (Shape option -> unit)

    val doDFGC : (Color option -> unit)
    val doDBGC : (Color option -> unit)
    val doDCC  : (Color option -> unit)
