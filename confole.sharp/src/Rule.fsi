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



type TitleRule =
    interface IRule

    new : string -> TitleRule

    member Title : string with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type ShowCursorBlinkingRule =
    interface IRule

    new : unit -> ShowCursorBlinkingRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type HideCursorBlinkingRule =
    interface IRule

    new : unit -> HideCursorBlinkingRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type ShowCursorRule =
    interface IRule

    new : unit -> ShowCursorRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type HideCursorRule =
    interface IRule

    new : unit -> HideCursorRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type EnableDesignateModeRule =
    interface IRule

    new : unit -> EnableDesignateModeRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DisableDesignateModeRule =
    interface IRule

    new : unit -> DisableDesignateModeRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type EnableAlternativeBufferRule =
    interface IRule

    new : unit -> EnableAlternativeBufferRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DisableAlternativeBufferRule =
    interface IRule

    new : unit -> DisableAlternativeBufferRule

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type CursorShapeRule =
    interface IRule

    new : unit -> CursorShapeRule
    new : Shape -> CursorShapeRule

    member Shape : Shape with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



type DefaultForegroundColorRule =
    interface IRule

    new : Color -> DefaultForegroundColorRule

    member Color : Color with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DefaultBackgroundColorRule =
    interface IRule

    new : Color -> DefaultBackgroundColorRule

    member Color : Color with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string

type DefaultCursorColorRule =
    interface IRule

    new : Color -> DefaultCursorColorRule

    member Color : Color with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string



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

    member AddEnableDesignateModeRule  : unit -> Rules
    member AddDisableDesignateModeRule : unit -> Rules

    member AddEnableAlternativeBufferRule  : unit -> Rules
    member AddDisableAlternativeBufferRule : unit -> Rules

    member AddCursorShapeRule : Shape -> Rules

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

    static member SetTitleRule : string -> unit

    static member SetShowCursorBlinkingRule : unit -> unit
    static member SetHideCursorBlinkingRule : unit -> unit

    static member SetShowCursorRule : unit -> unit
    static member SetHideCursorRule : unit -> unit

    static member SetEnableDesignateModeRule  : unit -> unit
    static member SetDisableDesignateModeRule : unit -> unit

    static member SetEnableAlternativeBufferRule  : unit -> unit
    static member SetDisableAlternativeBufferRule : unit -> unit

    static member SetCursorShapeRule : Shape -> unit

    static member SetDefaultForegroundColorRule : Color -> unit
    static member SetDefaultBackgroundColorRule : Color -> unit
    static member SetDefaultCursorColorRule     : Color -> unit

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
