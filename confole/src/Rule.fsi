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
    Version     : 1.4.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

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



    // Modalità manuale
    val getRule  : rule  : Rule  -> string
    val getRules : rules : Rules -> string

    val getTitle : title : string -> string

    val getShowCursorBlinking : unit -> string
    val getHideCursorBlinking : unit -> string

    val getShowCursor : unit -> string
    val getHideCursor : unit -> string

    val getEnableDesignateMode  : unit -> string
    val getDisableDesignateMode : unit -> string

    val getEnableAlternativeBuffer  : unit -> string
    val getDisableAlternativeBuffer : unit -> string

    val getCursorShape : shape : Shape option -> string

    val getDefaultForegroundColor : color : Color option -> string
    val getDefaultBackgroundColor : color : Color option -> string
    val getDefaultCursorColor     : color : Color option -> string

    val getReset : unit -> string

    // Alias modalità manuale
    val getTTL : (string -> string)

    val getSCB : (unit -> string)
    val getHCB : (unit -> string)

    val getSC : (unit -> string)
    val getHC : (unit -> string)

    val getEDM : (unit -> string)
    val getDDM : (unit -> string)

    val getEAB : (unit -> string)
    val getDAB : (unit -> string)

    val getCS : (Shape option -> string)

    val getDFGC : (Color option -> string)
    val getDBGC : (Color option -> string)
    val getDCC  : (Color option -> string)



    // Modalità funzionale
    val init       : unit          -> Rules
    val initPreset : rules : Rules -> Rules
    val clear      : rules : Rules -> Rules
    val view       : rules : Rules -> unit

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
