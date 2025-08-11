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

type Shape =
    | User              = 0
    | BlinkingBlock     = 1
    | SteadyBlock       = 2
    | BlinkingUnderline = 3
    | SteadyUnderline   = 4
    | BlinkingBar       = 5
    | SteadyBar         = 6



type IRule =
    abstract member ToFunctional : Rule.Rule with get

type IRules = IRule list



type RuleTitle =
    interface IRule

    new : string -> RuleTitle

    member Title : string with get, set



type RuleShowCursorBlinking =
    interface IRule

    new : unit -> RuleShowCursorBlinking

type RuleHideCursorBlinking =
    interface IRule

    new : unit -> RuleHideCursorBlinking



type RuleShowCursor =
    interface IRule

    new : unit -> RuleShowCursor

type RuleHideCursor =
    interface IRule

    new : unit -> RuleHideCursor



type RuleEnableDesignateMode =
    interface IRule

    new : unit -> RuleEnableDesignateMode

type RuleDisableDesignateMode =
    interface IRule

    new : unit -> RuleDisableDesignateMode



type RuleEnableAlternativeBuffer =
    interface IRule

    new : unit -> RuleEnableAlternativeBuffer

type RuleDisableAlternativeBuffer =
    interface IRule

    new : unit -> RuleDisableAlternativeBuffer



type RuleCursorShape =
    interface IRule

    new : Shape -> RuleCursorShape

    member Shape : Shape with get, set



type RuleDefaultForegroundColor =
    interface IRule

    new : Color -> RuleDefaultForegroundColor

    static member fromRGB :
        int * int * int ->
        RuleDefaultForegroundColor

    static member fromHEX :
        string * string * string ->
        RuleDefaultForegroundColor

    member Color : Color with get, set

type RuleDefaultBackgroundColor =
    interface IRule

    new : Color -> RuleDefaultBackgroundColor

    static member fromRGB :
        int * int * int ->
        RuleDefaultBackgroundColor

    static member fromHEX :
        string * string * string ->
        RuleDefaultBackgroundColor

    member Color : Color with get, set

type RuleDefaultCursorColor =
    interface IRule

    new : Color -> RuleDefaultCursorColor

    static member fromRGB :
        int * int * int ->
        RuleDefaultCursorColor

    static member fromHEX :
        string * string * string ->
        RuleDefaultCursorColor

    member Color : Color with get, set



type Rules =
    new : unit -> Rules

    member NewLine : bool   with get, set
    member Rules   : IRules with get

    new : IRules * bool -> Rules
    new : bool -> Rules

    member Item : int -> IRule with get

    member AddRule  : IRule  -> Rules
    member AddRules : IRules -> Rules

    member AddTitleRule : string -> Rules

    member AddShowCursorBlinkingRule : unit -> Rules
    member AddHideCursorBlinkingRule : unit -> Rules

    member AddShowCursorRule : unit -> Rules
    member AddHideCursorRule : unit -> Rules

    member AddEnableDesignateMode  : unit -> Rules
    member AddDisableDesignateMode : unit -> Rules

    member AddEnableAlternativeBuffer  : unit -> Rules
    member AddDisableAlternativeBuffer : unit -> Rules

    member AddCursorShape : Shape -> Rules

    member AddDefaultForegroundColorRule : Color -> Rules
    member AddDefaultBackgroundColorRule : Color -> Rules
    member AddDefaultCursorColorRule     : Color -> Rules

    member Clear : unit -> Rules

    member View : unit -> unit

    member Apply : IRule * bool -> unit
    member Apply : IRule        -> unit

    member ApplyAll : bool -> unit
    member ApplyAll : unit -> unit

    member Reset : unit -> unit

    //override Equals      : obj  -> bool
    //override GetHashCode : unit -> int
    //override ToString    : unit -> string
