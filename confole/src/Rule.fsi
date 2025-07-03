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

module Rule =
    type Rule =
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | ForegroundColor of Color
        | BackgroundColor of Color

    type Rules = Rule List

    val initRules :
        unit ->
        Rules

    val showCursorBlinking :
        rules : Rules ->
        Rules

    val hideCursorBlinking :
        rules : Rules ->
        Rules

    val showCursor :
        rules : Rules ->
        Rules

    val hideCursor :
        rules : Rules ->
        Rules

    val foregroundColor :
        color : Color ->
        rules : Rules ->
        Rules

    val backgroundColor :
        color : Color ->
        rules : Rules ->
        Rules

    val applyRule :
        rule : Rule ->
        unit

    val applyRules :
        rules : Rules ->
        unit

    val resetRules :
        unit ->
        unit
