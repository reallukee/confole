(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fs

    Title       : RULE
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Rule.
                  Il modulo Rule si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
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
type RuleString(rule, value) =
    let mutable value_ = value

    member this.Value
        with get() =
            value_

        and set(value) =
            value_ <- value

    interface IRule with
        member this.ToFunctional
            with get() =
                rule value

    override this.Equals(obj) =
        match obj with
        | :? RuleString as other ->
            this.GetType() = other.GetType() &&
            this.Value     = other.Value
        | _ -> false

    override this.GetHashCode() =
        hash(this.Value)

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type TitleRule(value) =
    inherit RuleString(Rule.Rule.Title, value)



[<AbstractClass>]
type RuleEmpty(rule) =
    interface IRule with
        member this.ToFunctional
            with get() =
                rule

    override this.Equals(obj) =
        match obj with
        | :? RuleEmpty as other ->
            this.GetType() = other.GetType()
        | _ -> false

    override this.GetHashCode() =
        this.GetType().GetHashCode()

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type ShowCursorBlinkingRule() =
    inherit RuleEmpty(Rule.Rule.ShowCursorBlinking)

type HideCursorBlinkingRule() =
    inherit RuleEmpty(Rule.Rule.HideCursorBlinking)

type ShowCursorRule() =
    inherit RuleEmpty(Rule.Rule.ShowCursor)

type HideCursorRule() =
    inherit RuleEmpty(Rule.Rule.HideCursor)

type EnableDesignateModeRule() =
    inherit RuleEmpty(Rule.Rule.EnableDesignateMode)

type DisableDesignateModeRule() =
    inherit RuleEmpty(Rule.Rule.DisableDesignateMode)

type EnableAlternativeBufferRule() =
    inherit RuleEmpty(Rule.Rule.EnableAlternativeBuffer)

type DisableAlternativeBufferRule() =
    inherit RuleEmpty(Rule.Rule.DisableAlternativeBuffer)



[<AbstractClass>]
type RuleShape(rule, shape) =
    let mutable shape_ = shape

    member this.Shape
        with get() =
            shape_

        and set(shape) =
            shape_ <- shape

    interface IRule with
        member this.ToFunctional
            with get() =
                let shape =
                    match this.Shape with
                    | Shape.User              -> Rule.Shape.User
                    | Shape.BlinkingBlock     -> Rule.Shape.BlinkingBlock
                    | Shape.SteadyBlock       -> Rule.Shape.SteadyBlock
                    | Shape.BlinkingUnderline -> Rule.Shape.BlinkingUnderline
                    | Shape.SteadyUnderline   -> Rule.Shape.SteadyUnderline
                    | Shape.BlinkingBar       -> Rule.Shape.BlinkingBar
                    | Shape.SteadyBar         -> Rule.Shape.SteadyBar
                    | _ -> failwith "Unknown value!"

                rule (Some shape)

    override this.Equals(obj) =
        match obj with
        | :? RuleShape as other ->
            this.GetType() = other.GetType() &&
            this.Shape     = other.Shape
        | _ -> false

    override this.GetHashCode() =
        hash(this.Shape)

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type CursorShapeRule() =
    inherit RuleShape(Rule.Rule.CursorShape, Shape.User)

    new(shape) as this =
        CursorShapeRule() then
            this.Shape <- shape



[<AbstractClass>]
type RuleColor(rule, color : Sharp.Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(color) =
            color_ <- color

    interface IRule with
        member this.ToFunctional
            with get() =
                let color =
                    match this.Color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                rule (Some color)

    override this.Equals(obj) =
        match obj with
        | :? RuleColor as other ->
            this.GetType() = other.GetType() &&
            this.Color.Equals(other.Color)
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color)

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type DefaultForegroundRuleColor(color) =
    inherit RuleColor(Rule.Rule.DefaultForegroundColor, color)

type DefaultBackgroundRuleColor(color) =
    inherit RuleColor(Rule.Rule.DefaultBackgroundColor, color)

type DefaultCursorRuleColor(color) =
    inherit RuleColor(Rule.Rule.DefaultCursorColor, color)



type Rules() =
    let mutable rules_ = []
    let mutable newLine_ = false

    member this.Rules
        with get() =
            rules_

        and private set(rules) =
            rules_ <- rules

    member this.NewLine
        with get() =
            newLine_

        and set(newLine) =
            newLine_ <- newLine

    new(rules, newLine) as this =
        Rules() then
            this.Rules   <- rules
            this.NewLine <- newLine

    new(newLine) as this =
        Rules() then
            this.Rules   <- []
            this.NewLine <- newLine

    member this.Item
        with get(index) =
            this.Rules
            |> List.rev
            |> List.item index



    member this.AddRule(rule : IRule) =
        this.Rules <- rule :: this.Rules

        this

    member this.AddRules(rules : IRules) =
        this.Rules <- rules @ this.Rules

        this



    member this.AddTitle(title) =
        let titleRule = new TitleRule(title)

        this.AddRule(titleRule)

    member this.AddShowCursorBlinking() =
        let showCursorBlinkingRule = new ShowCursorBlinkingRule()

        this.AddRule(showCursorBlinkingRule)

    member this.AddHideCursorBlinking() =
        let hideCursorBlinkingRule = new HideCursorBlinkingRule()

        this.AddRule(hideCursorBlinkingRule)

    member this.AddShowCursor() =
        let showCursorRule = new ShowCursorRule()

        this.AddRule(showCursorRule)

    member this.AddHideCursor() =
        let hideCursorRule = new HideCursorRule()

        this.AddRule(hideCursorRule)

    member this.AddEnableDesignateMode() =
        let enableDesignateModeRule = new EnableDesignateModeRule()

        this.AddRule(enableDesignateModeRule)

    member this.AddDisableDesignateMode() =
        let disableDesignateModeRule = new DisableDesignateModeRule()

        this.AddRule(disableDesignateModeRule)

    member this.AddEnableAlternativeBuffer() =
        let enableAlternativeBufferRule = new EnableAlternativeBufferRule()

        this.AddRule(enableAlternativeBufferRule)

    member this.AddDisableAlternativeBuffer() =
        let disableAlternativeBufferRule = new DisableAlternativeBufferRule()

        this.AddRule(disableAlternativeBufferRule)

    member this.AddCursorShape(shape) =
        let cursorShapeRule = new CursorShapeRule(shape)

        this.AddRule(cursorShapeRule)

    member this.AddDefaultForegroundColor(color) =
        let defaultForegroundRuleColor = new DefaultForegroundRuleColor(color)

        this.AddRule(defaultForegroundRuleColor)

    member this.AddDefaultBackgroundColor(color) =
        let defaultBackgroundRuleColor = new DefaultBackgroundRuleColor(color)

        this.AddRule(defaultBackgroundRuleColor)

    member this.AddDefaultCursorColor(color) =
        let defaultCursorRuleColor = new DefaultCursorRuleColor(color)

        this.AddRule(defaultCursorRuleColor)



    member this.Clear() =
        this.Rules <- []

        this

    member this.View() =
        this.Rules
        |> List.rev
        |> List.iter (fun rule ->
            printfn "%A" rule
        )



    member private this.CallApply(rule : IRule, newLine) =
        if newLine then
            Rule.applyNewLine rule.ToFunctional
        else
            Rule.apply rule.ToFunctional

    member this.Apply(rule : IRule, newLine) =
        this.CallApply(rule, newLine)

    member this.Apply(rule : IRule) =
        this.CallApply(rule, this.NewLine)

    member private this.CallApplyAll(newLine) =
        let rules =
            this.Rules
            |> List.map (fun rule ->
                rule.ToFunctional
            )

        if newLine then
            Rule.applyAllNewLine rules
        else
            Rule.applyAll rules

    member this.ApplyAll(newLine) =
        this.CallApplyAll newLine

    member this.ApplyAll() =
        this.CallApplyAll this.NewLine



    member this.Reset() =
        this.Rules <- []

        Rule.reset ()



    static member DoTitle(title) =
        let titleRule = new TitleRule(title) :> IRule

        Rule.apply titleRule.ToFunctional

    static member DoShowCursorBlinking() =
        let showCursorBlinkingRule = new ShowCursorBlinkingRule() :> IRule

        Rule.apply showCursorBlinkingRule.ToFunctional

    static member DoHideCursorBlinking() =
        let hideCursorBlinkingRule = new HideCursorBlinkingRule() :> IRule

        Rule.apply hideCursorBlinkingRule.ToFunctional

    static member DoShowCursor() =
        let showCursorRule = new ShowCursorRule() :> IRule

        Rule.apply showCursorRule.ToFunctional

    static member DoHideCursor() =
        let hideCursorRule = new HideCursorRule() :> IRule

        Rule.apply hideCursorRule.ToFunctional

    static member DoEnableDesignateMode() =
        let enableDesignateModeRule = new EnableDesignateModeRule() :> IRule

        Rule.apply enableDesignateModeRule.ToFunctional

    static member DoDisableDesignateMode() =
        let disableDesignateModeRule = new DisableDesignateModeRule() :> IRule

        Rule.apply disableDesignateModeRule.ToFunctional

    static member DoEnableAlternativeBuffer() =
        let enableAlternativeBufferRule = new EnableAlternativeBufferRule() :> IRule

        Rule.apply enableAlternativeBufferRule.ToFunctional

    static member DoDisableAlternativeBuffer() =
        let disableAlternativeBufferRule = new DisableAlternativeBufferRule() :> IRule

        Rule.apply disableAlternativeBufferRule.ToFunctional

    static member DoCursorShape(shape) =
        let cursorShapeRule = new CursorShapeRule(shape) :> IRule

        Rule.apply cursorShapeRule.ToFunctional

    static member DoDefaultForegroundColor(color) =
        let defaultForegroundRuleColor = new DefaultForegroundRuleColor(color) :> IRule

        Rule.apply defaultForegroundRuleColor.ToFunctional

    static member DoDefaultBackgroundColor(color) =
        let defaultBackgroundRuleColor = new DefaultBackgroundRuleColor(color) :> IRule

        Rule.apply defaultBackgroundRuleColor.ToFunctional

    static member DoDefaultCursorColor(color) =
        let defaultCursorRuleColor = new DefaultCursorRuleColor(color) :> IRule

        Rule.apply defaultCursorRuleColor.ToFunctional



    static member DoReset() =
        Rule.reset ()



    override this.Equals(obj) =
        match obj with
        | :? Rules as other ->
            this.NewLine = other.NewLine &&
            this.Rules.Equals(other.Rules)
        | _ -> false

    override this.GetHashCode() =
        hash(this.NewLine, this.Rules)

    override this.ToString() =
        let rules =
            this.Rules
            |> Seq.map (fun rule ->
                rule.ToString()
            )
            |> String.concat "; "

        $"Rules(NewLine={this.NewLine}, Rules=[{rules}])"
