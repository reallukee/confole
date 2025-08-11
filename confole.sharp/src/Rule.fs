(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Rule.fs

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



type RuleTitle(title) =
    let mutable title_ = title

    member this.Title
        with get() =
            title_

        and set(value) =
            title_ <- value

    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Title this.Title



type RuleShowCursorBlinking() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.ShowCursorBlinking

type RuleHideCursorBlinking() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.HideCursorBlinking



type RuleShowCursor() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.ShowCursor

type RuleHideCursor() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.HideCursor



type RuleEnableDesignateMode() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.EnableDesignateMode

type RuleDisableDesignateMode() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.DisableDesignateMode



type RuleEnableAlternativeBuffer() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.EnableAlternativeBuffer

type RuleDisableAlternativeBuffer() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.DisableAlternativeBuffer



type RuleCursorShape(shape) =
    let mutable shape_ = shape

    member this.Shape
        with get() =
            shape_

        and set(value) =
            shape_ <- value

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
                    | _                       -> failwith "Unknown value!"

                Rule.CursorShape shape



type RuleDefaultForegroundColor(color : Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(value) =
            color_ <- value

    static member fromRGB(red, green, blue) =
        RuleDefaultForegroundColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        RuleDefaultForegroundColor(HEXColor(red, green, blue))

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

                Rule.DefaultForegroundColor color

type RuleDefaultBackgroundColor(color : Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(value) =
            color_ <- value

    static member fromRGB(red, green, blue) =
        RuleDefaultBackgroundColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        RuleDefaultBackgroundColor(HEXColor(red, green, blue))

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

                Rule.DefaultBackgroundColor color

type RuleDefaultCursorColor(color : Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(value) =
            color_ <- value

    static member fromRGB(red, green, blue) =
        RuleDefaultCursorColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        RuleDefaultCursorColor(HEXColor(red, green, blue))

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

                Rule.DefaultCursorColor color



type Rules() =
    let mutable rules = []
    let mutable newLine = false

    member this.Rules
        with get() =
            rules

        and private set(value) =
            rules <- value

    member this.NewLine
        with get() =
            newLine

        and set(value) =
            newLine <- value



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



    member this.AddTitleRule(title) = this.AddRule(new RuleTitle(title))

    member this.AddShowCursorBlinkingRule() = this.AddRule(new RuleShowCursorBlinking())
    member this.AddHideCursorBlinkingRule() = this.AddRule(new RuleHideCursorBlinking())

    member this.AddShowCursorRule() = this.AddRule(new RuleShowCursor())
    member this.AddHideCursorRule() = this.AddRule(new RuleHideCursor())

    member this.AddEnableDesignateMode()  = this.AddRule(new RuleEnableDesignateMode())
    member this.AddDisableDesignateMode() = this.AddRule(new RuleDisableDesignateMode())

    member this.AddEnableAlternativeBuffer()  = this.AddRule(new RuleEnableAlternativeBuffer())
    member this.AddDisableAlternativeBuffer() = this.AddRule(new RuleDisableAlternativeBuffer())

    member this.AddCursorShape(shape) = this.AddRule(new RuleCursorShape(shape))

    member this.AddDefaultForegroundColorRule(color) = this.AddRule(new RuleDefaultForegroundColor(color))
    member this.AddDefaultBackgroundColorRule(color) = this.AddRule(new RuleDefaultBackgroundColor(color))
    member this.AddDefaultCursorColorRule(color) = this.AddRule(new RuleDefaultCursorColor(color))



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
        rule.ToFunctional
        |> Rule.apply newLine

    member this.Apply(rule : IRule, newLine) =
        this.CallApply(rule, newLine)

    member this.Apply(rule : IRule) =
        this.CallApply(rule, this.NewLine)



    member private this.CallApplyAll(newLine) =
        this.Rules
        |> List.rev
        |> List.map (fun rule ->
            rule.ToFunctional
        )
        |> Rule.applyAll newLine

    member this.ApplyAll(newLine) =
        this.CallApplyAll newLine

    member this.ApplyAll() =
        this.CallApplyAll this.NewLine



    member this.Reset() =
        this.Rules <- []

        Rule.reset ()
