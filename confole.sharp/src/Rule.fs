(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

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



type TitleRule(title) =
    let mutable title_ = title

    member this.Title
        with get() =
            title_

        and set(title) =
            title_ <- title

    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Title this.Title

    override this.Equals(obj) =
        match obj with
        | :? TitleRule as other ->
            this.Title = other.Title
        | _ -> false

    override this.GetHashCode() =
        hash(this.Title)

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type ShowCursorBlinkingRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.ShowCursorBlinking

    override this.Equals(obj) =
        match obj with
        | :? ShowCursorBlinkingRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type HideCursorBlinkingRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.HideCursorBlinking

    override this.Equals(obj) =
        match obj with
        | :? HideCursorBlinkingRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type ShowCursorRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.ShowCursor

    override this.Equals(obj) =
        match obj with
        | :? ShowCursorRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type HideCursorRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.HideCursor

    override this.Equals(obj) =
        match obj with
        | :? HideCursorRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type EnableDesignateModeRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.EnableDesignateMode

    override this.Equals(obj) =
        match obj with
        | :? EnableDesignateModeRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type DisableDesignateModeRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.DisableDesignateMode

    override this.Equals(obj) =
        match obj with
        | :? DisableDesignateModeRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type EnableAlternativeBufferRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.EnableAlternativeBuffer

    override this.Equals(obj) =
        match obj with
        | :? EnableAlternativeBufferRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type DisableAlternativeBufferRule() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.DisableAlternativeBuffer

    override this.Equals(obj) =
        match obj with
        | :? DisableAlternativeBufferRule -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type CursorShapeRule() =
    let mutable shape_ = Shape.User

    member this.Shape
        with get() =
            shape_

        and set(shape) =
            shape_ <- shape

    new(shape) as this =
        CursorShapeRule() then

        this.Shape <- shape

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

                Rule.CursorShape (Some shape)

    override this.Equals(obj) =
        match obj with
        | :? CursorShapeRule as other ->
            this.Shape = other.Shape
        | _ -> false

    override this.GetHashCode() =
        hash(this.Shape)

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



type DefaultForegroundColorRule(color : Color) =
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

                Rule.DefaultForegroundColor color

    override this.Equals(obj) =
        match obj with
        | :? DefaultForegroundColorRule as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color.GetHashCode())

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type DefaultBackgroundColorRule(color : Color) =
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

                Rule.DefaultBackgroundColor color

    override this.Equals(obj) =
        match obj with
        | :? DefaultBackgroundColorRule as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color.GetHashCode())

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"

type DefaultCursorColorRule(color : Color) =
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

                Rule.DefaultCursorColor color

    override this.Equals(obj) =
        match obj with
        | :? DefaultCursorColorRule as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color.GetHashCode())

    override this.ToString() =
        $"{(this :> IRule).ToFunctional}"



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



    member this.AddTitleRule(title) =
        let titleRule = new TitleRule(title)

        this.AddRule(titleRule)



    member this.AddShowCursorBlinkingRule() =
        let showCursorBlinkingRule = new ShowCursorBlinkingRule()

        this.AddRule(showCursorBlinkingRule)

    member this.AddHideCursorBlinkingRule() =
        let hideCursorBlinkingRule = new HideCursorBlinkingRule()

        this.AddRule(hideCursorBlinkingRule)



    member this.AddShowCursorRule() =
        let showCursorRule = new ShowCursorRule()

        this.AddRule(showCursorRule)

    member this.AddHideCursorRule() =
        let hideCursorRule = new HideCursorRule()

        this.AddRule(hideCursorRule)



    member this.AddEnableDesignateModeRule() =
        let enableDesignateModeRule = new EnableDesignateModeRule()

        this.AddRule(enableDesignateModeRule)

    member this.AddDisableDesignateModeRule() =
        let disableDesignateModeRule = new DisableDesignateModeRule()

        this.AddRule(disableDesignateModeRule)



    member this.AddEnableAlternativeBufferRule() =
        let enableAlternativeBufferRule = new EnableAlternativeBufferRule

        this.AddRule(enableAlternativeBufferRule)

    member this.AddDisableAlternativeBufferRule() =
        let disableAlternativeBufferRule = new DisableAlternativeBufferRule()

        this.AddRule(disableAlternativeBufferRule)



    member this.AddCursorShapeRule(shape) =
        let cursorShapeRule = new CursorShapeRule(shape)

        this.AddRule(cursorShapeRule)



    member this.AddDefaultForegroundColorRule(color) =
        let defaultForegroundColorRule = new DefaultForegroundColorRule(color)

        this.AddRule(defaultForegroundColorRule)

    member this.AddDefaultBackgroundColorRule(color) =
        let defaultBackgroundColorRule = new DefaultBackgroundColorRule(color)

        this.AddRule(defaultBackgroundColorRule)

    member this.AddDefaultCursorColorRule(color) =
        let defaultCursorColorRule = new DefaultCursorColorRule(color)

        this.AddRule(defaultCursorColorRule)



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
