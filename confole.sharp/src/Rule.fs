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

type Rules() =
    let mutable rules : IRule list = []

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
            rules
            |> List.rev
            |> List.item index



    member this.AddRule(rule : IRule) =
        rules <- rule :: rules

        this

    member this.AddRules(rules : IRules) =
        this.Rules <- rules @ this.Rules

        this



    member this.AddTitleRule(value) =
        rules <- new RuleTitle(value) :: rules

        this

    member this.AddShowCursorBlinkingRule() =
        rules <- new ShowCursorBlinking() :: rules

        this

    member this.AddHideCursorBlinkingRule() =
        rules <- new HideCursorBlinking() :: rules

        this

    member this.AddShowCursorRule() =
        rules <- new ShowCursor() :: rules

        this

    member this.AddHideCursorRule() =
        rules <- new HideCursor() :: rules

        this

    member this.AddEnableDesignateMode() =
        rules <- new EnableDesignateMode() :: rules

        this

    member this.AddDisableDesignateMode() =
        rules <- new DisableDesignateMode() :: rules

        this

    member this.AddEnableAlternativeBuffer() =
        rules <- new EnableAlternativeBuffer() :: rules

        this

    member this.AddDisableAlternativeBuffer() =
        rules <- new DisableAlternativeBuffer() :: rules

        this

    member this.AddDefaultForegroundColorRule(color) =
        rules <- new DefaultForegroundColor(color) :: rules

        this

    member this.AddDefaultBackgroundColorRule(color) =
        rules <- new DefaultBackgroundColor(color) :: rules

        this

    member this.AddDefaultCursorColorRule(color) =
        rules <- new DefaultCursorColor(color) :: rules

        this



    member this.Clear() =
        rules <- []

        this



    member private this.CallApply(rule : IRule, newLine) =
        rule.ToFunctional
        |> Rule.apply newLine

    member this.ApplyRule(rule : IRule, newLine) =
        this.CallApply(rule, newLine)

    member this.ApplyRule(rule : IRule) =
        this.CallApply(rule, newLine)



    member private this.CallApplyAll(newLine) =
        rules
        |> List.rev
        |> List.map (fun rule ->
            rule.ToFunctional
        )
        |> Rule.applyAll newLine

    member this.Apply(newLine) =
        this.CallApplyAll newLine

    member this.Apply() =
        this.CallApplyAll newLine



    member this.Reset() =
        rules <- []

        Rule.reset ()
