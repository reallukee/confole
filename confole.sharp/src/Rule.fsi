(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fsi

    Title       : RULE
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Rule.
                  Il modulo Rule si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
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



[<AbstractClass>]
type RuleString =
    interface IRule

    new : rule : (string -> Rule.Rule) * value : string -> RuleString

    member Value : string with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type TitleRule =
    inherit RuleString

    new : value : string -> TitleRule



[<AbstractClass>]
type RuleEmpty =
    interface IRule

    new : rule : Rule.Rule -> RuleEmpty

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type ShowCursorBlinkingRule =
    inherit RuleEmpty

    new : unit -> ShowCursorBlinkingRule

type HideCursorBlinkingRule =
    inherit RuleEmpty

    new : unit -> HideCursorBlinkingRule

type ShowCursorRule =
    inherit RuleEmpty

    new : unit -> ShowCursorRule

type HideCursorRule =
    inherit RuleEmpty

    new : unit -> HideCursorRule

type EnableDesignateModeRule =
    inherit RuleEmpty

    new : unit -> EnableDesignateModeRule

type DisableDesignateModeRule =
    inherit RuleEmpty

    new : unit -> DisableDesignateModeRule

type EnableAlternativeBufferRule =
    inherit RuleEmpty

    new : unit -> EnableAlternativeBufferRule

type DisableAlternativeBufferRule =
    inherit RuleEmpty

    new : unit -> DisableAlternativeBufferRule



[<AbstractClass>]
type RuleShape =
    interface IRule

    new : rule : (Rule.Shape option -> Rule.Rule) * shape : Shape -> RuleShape

    member Shape : Shape with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type CursorShapeRule =
    inherit RuleShape

    new : unit          -> CursorShapeRule
    new : shape : Shape -> CursorShapeRule



[<AbstractClass>]
type RuleColor =
    interface IRule

    new : rule : (Color.Color -> Rule.Rule) * color : Sharp.Color -> RuleColor

    member Color : Sharp.Color with get, set

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

type DefaultForegroundRuleColor =
    inherit RuleColor

    new : color : Sharp.Color -> DefaultForegroundRuleColor

type DefaultBackgroundRuleColor =
    inherit RuleColor

    new : color : Sharp.Color -> DefaultBackgroundRuleColor

type DefaultCursorRuleColor =
    inherit RuleColor

    new : color : Sharp.Color -> DefaultCursorRuleColor



type Rules =
    new : unit -> Rules

    member NewLine : bool   with get, set
    member Rules   : IRules with get

    new : rules   : IRules * newLine : bool -> Rules
    new : newLine : bool                    -> Rules

    member Item : int -> IRule with get

    member AddRule  : rule  : IRule  -> Rules
    member AddRules : rules : IRules -> Rules

    member AddTitle                    : title : string -> Rules
    member AddShowCursorBlinking       : unit           -> Rules
    member AddHideCursorBlinking       : unit           -> Rules
    member AddShowCursor               : unit           -> Rules
    member AddHideCursor               : unit           -> Rules
    member AddEnableDesignateMode      : unit           -> Rules
    member AddDisableDesignateMode     : unit           -> Rules
    member AddEnableAlternativeBuffer  : unit           -> Rules
    member AddDisableAlternativeBuffer : unit           -> Rules
    member AddCursorShape              : shape : Shape  -> Rules
    member AddDefaultForegroundColor   : color : Color  -> Rules
    member AddDefaultBackgroundColor   : color : Color  -> Rules
    member AddDefaultCursorColor       : color : Color  -> Rules

    member Clear : unit -> Rules
    member View  : unit -> unit

    member Apply    : rule    : IRule * newLine : bool -> unit
    member Apply    : rule    : IRule                  -> unit
    member ApplyAll : newLine : bool                   -> unit
    member ApplyAll : unit                             -> unit

    member Reset : unit -> unit

    static member DoTitle                    : title : string -> unit
    static member DoShowCursorBlinking       : unit           -> unit
    static member DoHideCursorBlinking       : unit           -> unit
    static member DoShowCursor               : unit           -> unit
    static member DoHideCursor               : unit           -> unit
    static member DoEnableDesignateMode      : unit           -> unit
    static member DoDisableDesignateMode     : unit           -> unit
    static member DoEnableAlternativeBuffer  : unit           -> unit
    static member DoDisableAlternativeBuffer : unit           -> unit
    static member DoCursorShape              : shape : Shape  -> unit
    static member DoDefaultForegroundColor   : color : Color  -> unit
    static member DoDefaultBackgroundColor   : color : Color  -> unit
    static member DoDefaultCursorColor       : color : Color  -> unit

    static member DoReset : unit -> unit

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
