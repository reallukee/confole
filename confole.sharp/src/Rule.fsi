(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Rule.fsi

    Title       : RULE
    Description : Rule

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type Rules =
    new : unit -> Rules

    member NewLine : bool   with get, set
    member Rules   : IRules with get

    new : rules   : IRules * bool -> Rules
    new : newLine : bool -> Rules

    member Item : int -> IRule with get

    member AddRule  : IRule  -> Rules
    member AddRules : IRules -> Rules

    member AddTitleRule : string -> Rules
    member AddShowCursorBlinkingRule   : unit -> Rules
    member AddHideCursorBlinkingRule   : unit -> Rules
    member AddShowCursorRule           : unit -> Rules
    member AddHideCursorRule           : unit -> Rules
    member AddEnableDesignateMode      : unit -> Rules
    member AddDisableDesignateMode     : unit -> Rules
    member AddEnableAlternativeBuffer  : unit -> Rules
    member AddDisableAlternativeBuffer : unit -> Rules
    member AddDefaultForegroundColorRule : Color -> Rules
    member AddDefaultBackgroundColorRule : Color -> Rules
    member AddDefaultCursorColorRule     : Color -> Rules

    member Clear : unit -> Rules

    member ApplyRule : IRule * bool -> unit
    member ApplyRule : IRule        -> unit

    member Apply : bool -> unit
    member Apply : unit -> unit

    member Reset : unit -> unit
