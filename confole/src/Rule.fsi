(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Rule.fsi

    Title       : RULE
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Rule.
                  Il modulo Rule si occupa di sequenze VTS
                  relative all'apparenza del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Rule =
    open Common

    type Shape =
        | User
        | BlinkingBlock
        | SteadyBlock
        | BlinkingUnderline
        | SteadyUnderline
        | BlinkingBar
        | SteadyBar

    type Rule =
        | Title                    of string
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | EnableDesignateMode
        | DisableDesignateMode
        | EnableAlternativeBuffer
        | DisableAlternativeBuffer
        | CursorShape              of Shape option
        | DefaultForegroundColor   of Color
        | DefaultBackgroundColor   of Color
        | DefaultCursorColor       of Color

    type Rules = Rule list

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

    val defaultForegroundColor : color : Color -> rules : Rules -> Rules
    val defaultBackgroundColor : color : Color -> rules : Rules -> Rules
    val defaultCursorColor     : color : Color -> rules : Rules -> Rules

    val init  : unit          -> Rules
    val clear : rules : Rules -> Rules
    val view  : rules : Rules -> unit

    val apply        : rule : Rule -> unit
    val applyNewLine : rule : Rule -> unit

    val applyAll        : rules : Rules -> unit
    val applyAllNewLine : rules : Rules -> unit

    val reset : unit -> unit

    val configure        : config : (Rules -> Rules) -> unit
    val configureNewLine : config : (Rules -> Rules) -> unit

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

    val builder : Builder

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

    val doDefaultForegroundColor : color : Color -> unit
    val doDefaultBackgroundColor : color : Color -> unit
    val doDefaultCursorColor     : color : Color -> unit
