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
    Version     : 1.0.0
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

    val init : unit -> Rules

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

    val clear : rules : Rules -> Rules

    val view : rules : Rules -> unit

    val apply    : newLine : bool -> rule  : Rule  -> unit
    val applyAll : newLine : bool -> rules : Rules -> unit

    val reset : unit -> unit

    val configure : newLine : bool -> config : (Rules -> Rules) -> unit

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
