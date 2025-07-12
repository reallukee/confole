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
    type Rule =
        | Title                  of string
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | DefaultForegroundColor of Color
        | DefaultBackgroundColor of Color
        | DefaultCursorColor     of Color

    type Rules = Rule List

    val init :
        unit ->
        Rules

    val title : value : string -> rules : Rules -> Rules

    val showCursorBlinking : rules : Rules -> Rules
    val hideCursorBlinking : rules : Rules -> Rules

    val showCursor : rules : Rules -> Rules
    val hideCursor : rules : Rules -> Rules

    val defaultForegroundColor : color : Color -> rules : Rules -> Rules
    val defaultBackgroundColor : color : Color -> rules : Rules -> Rules
    val defaultCursorColor     : color : Color -> rules : Rules -> Rules

    val apply :
        newLine : bool ->
        rule    : Rule ->
        unit

    val applyAll :
        newLine : bool ->
        rules   : Rules ->
        unit

    val reset :
        unit ->
        unit
