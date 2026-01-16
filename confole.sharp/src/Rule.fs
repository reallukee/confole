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

                  Riscrittura v4!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open System
open System.Collections
open System.Collections.Generic

open Reallukee.Confole

type Shape =
    | User              = 0
    | BlinkingBlock     = 1
    | SteadyBlock       = 2
    | BlinkingUnderline = 3
    | SteadyUnderline   = 4
    | BlinkingBar       = 5
    | SteadyBar         = 6

[<Class>]
type Rules private () =

    let mutable rules = List<Rule.Rule>()

    static let mutable newLine = false

    member this.RulesList
        with internal get () =
            rules

    static member NewLine
        with get () =
            newLine

        and set value =
            newLine <- value



    // Modalità manuale
    member this.Renders () =
        rules
        |> Seq.toList
        |> List.rev
        |> Rule.renders

    static member RenderTitle title = Rule.renderTitle title

    static member RenderShowCursorBlinking () = Rule.renderShowCursorBlinking ()
    static member RenderHideCursorBlinking () = Rule.renderHideCursorBlinking ()

    static member RenderShowCursor () = Rule.renderShowCursor ()
    static member RenderHideCursor () = Rule.renderHideCursor ()

    static member RenderEnableDesignateMode  () = Rule.renderEnableDesignateMode  ()
    static member RenderDisableDesignateMode () = Rule.renderDisableDesignateMode ()

    static member RenderEnableAlternativeBuffer  () = Rule.renderEnableAlternativeBuffer  ()
    static member RenderDisableAlternativeBuffer () = Rule.renderDisableAlternativeBuffer ()



    static member RenderCursorShape () = Rule.renderCursorShape None

    static member RenderCursorShape shape =
        let shape = Rules.OOPShapeToShape shape

        Rule.renderCursorShape (Some shape)



    static member RenderDefaultForegroundColor () = Rule.renderDefaultForegroundColor None

    static member RenderDefaultForegroundColor color =
        let color = Color.toFColor color

        Rule.renderDefaultForegroundColor (Some color)

    static member RenderDefaultBackgroundColor () = Rule.renderDefaultBackgroundColor None

    static member RenderDefaultBackgroundColor color =
        let color = Color.toFColor color

        Rule.renderDefaultBackgroundColor (Some color)

    static member RenderDefaultCursorColor () = Rule.renderDefaultCursorColor None

    static member RenderDefaultCursorColor color =
        let color = Color.toFColor color

        Rule.renderDefaultCursorColor (Some color)



    static member RenderReset () = Rule.renderReset ()



    // Modalità "funzionale"
    static member Init () = new Rules()

    member this.Clear () = rules.Clear(); this

    member this.View () =
        rules
        |> Seq.toList
        |> Rule.view
        |> ignore

        this



    member this.Title title = rules.Add(Rule.Title title); this

    member this.ShowCursorBlinking () = rules.Add(Rule.ShowCursorBlinking); this
    member this.HideCursorBlinking () = rules.Add(Rule.HideCursorBlinking); this

    member this.ShowCursor () = rules.Add(Rule.ShowCursor); this
    member this.HideCursor () = rules.Add(Rule.HideCursor); this

    member this.EnableDesignateMode  () = rules.Add(Rule.EnableDesignateMode) ; this
    member this.DisableDesignateMode () = rules.Add(Rule.DisableDesignateMode); this

    member this.EnableAlternativeBuffer  () = rules.Add(Rule.EnableAlternativeBuffer) ; this
    member this.DisableAlternativeBuffer () = rules.Add(Rule.DisableAlternativeBuffer); this



    member this.CursorShape () = rules.Add(Rule.CursorShape None); this

    member this.CursorShape shape =
        let shape = Rules.OOPShapeToShape shape

        rules.Add(Rule.CursorShape (Some shape))

        this



    member this.DefaultForegroundColor () = rules.Add(Rule.DefaultForegroundColor None); this

    member this.DefaultForegroundColor color =
        let color = Color.toFColor color

        rules.Add(Rule.DefaultForegroundColor (Some color))

        this

    member this.DefaultBackgroundColor () = rules.Add(Rule.DefaultBackgroundColor None); this

    member this.DefaultBackgroundColor color =
        let color = Color.toFColor color

        rules.Add(Rule.DefaultBackgroundColor (Some color))

        this

    member this.DefaultCursorColor () = rules.Add(Rule.DefaultCursorColor None); this

    member this.DefaultCursorColor color =
        let color = Color.toFColor color

        rules.Add(Rule.DefaultCursorColor (Some color))

        this



    member this.ApplyAll () =
        rules
        |> Seq.toList
        |> List.rev
        |> Rule.applyAll

        if Rules.NewLine then
            printfn ""

    member this.ApplyAll newLine =
        rules
        |> Seq.toList
        |> List.rev
        |> Rule.applyAll

        if newLine then
            printfn ""

    static member Reset () = Rule.reset ()



    // Modalità imperativa
    static member DoTitle title  = Rule.doTitle title

    static member DoShowCursorBlinking () = Rule.doShowCursorBlinking ()
    static member DoHideCursorBlinking () = Rule.doHideCursorBlinking ()

    static member DoShowCursor () = Rule.doShowCursor ()
    static member DoHideCursor () = Rule.doHideCursor ()

    static member DoEnableDesignateMode  () = Rule.doEnableDesignateMode  ()
    static member DoDisableDesignateMode () = Rule.doDisableDesignateMode ()

    static member DoEnableAlternativeBuffer  () = Rule.doEnableAlternativeBuffer  ()
    static member DoDisableAlternativeBuffer () = Rule.doDisableAlternativeBuffer ()



    static member DoCursorShape () = Rule.doCursorShape None

    static member DoCursorShape shape =
        let shape = Rules.OOPShapeToShape shape

        Rule.doCursorShape (Some shape)



    static member DoDefaultForegroundColor () = Rule.doDefaultForegroundColor None

    static member DoDefaultForegroundColor color =
        let color = Color.toFColor color

        Rule.doDefaultForegroundColor (Some color)

    static member DoDefaultBackgroundColor () = Rule.doDefaultBackgroundColor None

    static member DoDefaultBackgroundColor color =
        let color = Color.toFColor color

        Rule.doDefaultBackgroundColor (Some color)

    static member DoDefaultCursorColor () = Rule.doDefaultCursorColor None

    static member DoDefaultCursorColor color =
        let color = Color.toFColor color

        Rule.doDefaultCursorColor (Some color)



    static member DoReset () = Rule.doReset ()



    // Compatibilità!
    //   Converte DU in ENUM e ENUM in DU.
    static member private OOPShapeToShape shape =
        match shape with
        | Shape.User              -> Rule.Shape.User
        | Shape.BlinkingBlock     -> Rule.Shape.BlinkingBlock
        | Shape.SteadyBlock       -> Rule.Shape.SteadyBlock
        | Shape.BlinkingUnderline -> Rule.Shape.BlinkingUnderline
        | Shape.SteadyUnderline   -> Rule.Shape.SteadyUnderline
        | Shape.BlinkingBar       -> Rule.Shape.BlinkingBar
        | Shape.SteadyBar         -> Rule.Shape.SteadyBar
        | shape -> failwithf "%A: Unsupported shape format!" shape

    static member private ShapeToOOPShape shape =
        match shape with
        | Rule.Shape.User              -> Shape.User
        | Rule.Shape.BlinkingBlock     -> Shape.BlinkingBlock
        | Rule.Shape.SteadyBlock       -> Shape.SteadyBlock
        | Rule.Shape.BlinkingUnderline -> Shape.BlinkingUnderline
        | Rule.Shape.SteadyUnderline   -> Shape.SteadyUnderline
        | Rule.Shape.BlinkingBar       -> Shape.BlinkingBar
        | Rule.Shape.SteadyBar         -> Shape.SteadyBar
        | shape -> failwithf "%A: Unsupported shape format!" shape
