(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Rule.fsi

    Title       : RULE
    Description : Rule

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

    val title : string ->  Rules -> Rules

    val showCursorBlinking : Rules -> Rules
    val hideCursorBlinking : Rules -> Rules

    val showCursor : Rules -> Rules
    val hideCursor : Rules -> Rules

    val enableDesignateMode  : Rules -> Rules
    val disableDesignateMode : Rules -> Rules

    val enableAlternativeBuffer  : Rules -> Rules
    val disableAlternativeBuffer : Rules -> Rules

    val cursorShape : Shape option -> Rules -> Rules

    val defaultForegroundColor : Color -> Rules -> Rules
    val defaultBackgroundColor : Color -> Rules -> Rules
    val defaultCursorColor     : Color -> Rules -> Rules

    val clear : Rules -> Rules

    val view : Rules -> unit

    val apply    : bool -> Rule  -> unit
    val applyAll : bool -> Rules -> unit
    val reset    : unit -> unit

    val configure : bool -> (Rules -> Rules) -> unit

    type Builder =
        new : unit -> Builder

        member Yield :
            (Rules -> Rules) ->
            (Rules -> Rules)

        member Combine :
            (Rules -> Rules) * (Rules -> Rules) ->
            (Rules -> Rules)

        member Delay :
            (unit -> (Rules -> Rules)) ->
            (Rules -> Rules)

        member Run :
            (Rules -> Rules) ->
            Rules

    val builder : Builder
