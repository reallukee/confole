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

    type Rules = Rule List

    val init :
        unit ->
        Rules

    val showCursorBlinking : rules : Rules -> Rules
    val hideCursorBlinking : rules : Rules -> Rules

    val showCursor : rules : Rules -> Rules
    val hideCursor : rules : Rules -> Rules

    val apply :
        rule : Rule ->
        unit

    val applyAll :
        rules : Rules ->
        unit

    val reset :
        unit ->
        unit
