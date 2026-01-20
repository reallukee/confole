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
type Rules internal () =

    let mutable rules = List<Rule.Rule>()

    static let mutable newLine = false

    member this.RulesList
        with internal get () =
            rules

        and internal set value =
            rules <- value

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

    static member RenderCursorShape ()    = Rule.renderCursorShape None
    static member RenderCursorShape shape = Rule.renderCursorShape (Some (Rules.OOPShapeToShape shape))

    static member RenderDefaultForegroundColor ()    = Rule.renderDefaultForegroundColor None
    static member RenderDefaultForegroundColor color = Rule.renderDefaultForegroundColor (Some (Color.toFColor color))
    static member RenderDefaultBackgroundColor ()    = Rule.renderDefaultBackgroundColor None
    static member RenderDefaultBackgroundColor color = Rule.renderDefaultBackgroundColor (Some (Color.toFColor color))
    static member RenderDefaultCursorColor     ()    = Rule.renderDefaultCursorColor     None
    static member RenderDefaultCursorColor     color = Rule.renderDefaultCursorColor     (Some (Color.toFColor color))

    static member RenderReset () = Rule.renderReset ()



    // Modalità "funzionale"
    static member Init () = Rules ()

    static member Initp (rules : Rules) =
        let newRules = Rules.Init ()

        newRules.RulesList.AddRange(rules.RulesList)

        newRules

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

    member this.EnableDesignateMode  () = rules.Add(Rule.EnableDesignateMode ); this
    member this.DisableDesignateMode () = rules.Add(Rule.DisableDesignateMode); this

    member this.EnableAlternativeBuffer  () = rules.Add(Rule.EnableAlternativeBuffer ); this
    member this.DisableAlternativeBuffer () = rules.Add(Rule.DisableAlternativeBuffer); this

    member this.CursorShape ()    = rules.Add(Rule.CursorShape None                                ); this
    member this.CursorShape shape = rules.Add(Rule.CursorShape (Some (Rules.OOPShapeToShape shape))); this

    member this.DefaultForegroundColor ()    = rules.Add(Rule.DefaultForegroundColor None                         ); this
    member this.DefaultForegroundColor color = rules.Add(Rule.DefaultForegroundColor (Some (Color.toFColor color))); this
    member this.DefaultBackgroundColor ()    = rules.Add(Rule.DefaultBackgroundColor None                         ); this
    member this.DefaultBackgroundColor color = rules.Add(Rule.DefaultBackgroundColor (Some (Color.toFColor color))); this
    member this.DefaultCursorColor     ()    = rules.Add(Rule.DefaultCursorColor     None                         ); this
    member this.DefaultCursorColor     color = rules.Add(Rule.DefaultCursorColor     (Some (Color.toFColor color))); this

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
    static member DoTitle title = Rule.doTitle title

    static member DoShowCursorBlinking () = Rule.doShowCursorBlinking ()
    static member DoHideCursorBlinking () = Rule.doHideCursorBlinking ()

    static member DoShowCursor () = Rule.doShowCursor ()
    static member DoHideCursor () = Rule.doHideCursor ()

    static member DoEnableDesignateMode  () = Rule.doEnableDesignateMode  ()
    static member DoDisableDesignateMode () = Rule.doDisableDesignateMode ()

    static member DoEnableAlternativeBuffer  () = Rule.doEnableAlternativeBuffer  ()
    static member DoDisableAlternativeBuffer () = Rule.doDisableAlternativeBuffer ()

    static member DoCursorShape ()    = Rule.doCursorShape None
    static member DoCursorShape shape = Rule.doCursorShape (Some (Rules.OOPShapeToShape shape))

    static member DoDefaultForegroundColor ()    = Rule.doDefaultForegroundColor None
    static member DoDefaultForegroundColor color = Rule.doDefaultForegroundColor (Some (Color.toFColor color))
    static member DoDefaultBackgroundColor ()    = Rule.doDefaultBackgroundColor None
    static member DoDefaultBackgroundColor color = Rule.doDefaultBackgroundColor (Some (Color.toFColor color))
    static member DoDefaultCursorColor     ()    = Rule.doDefaultCursorColor     None
    static member DoDefaultCursorColor     color = Rule.doDefaultCursorColor     (Some (Color.toFColor color))

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



[<Class>]
type Rul internal () =

    inherit Rules ()

    // Alias modalità manuale
    static member RenderTTL title = Rules.RenderTitle title

    static member RenderSCB () = Rules.RenderShowCursorBlinking ()
    static member RenderHCB () = Rules.RenderHideCursorBlinking ()

    static member RenderSC () = Rules.RenderShowCursor ()
    static member RenderHC () = Rules.RenderHideCursor ()

    static member RenderEDM () = Rules.RenderEnableDesignateMode  ()
    static member RenderDDM () = Rules.RenderDisableDesignateMode ()

    static member RenderEAB () = Rules.RenderEnableAlternativeBuffer  ()
    static member RenderDAB () = Rules.RenderDisableAlternativeBuffer ()

    static member RenderCS ()    = Rules.RenderCursorShape ()
    static member RenderCS shape = Rules.RenderCursorShape shape

    static member RenderDFGC ()    = Rules.RenderDefaultForegroundColor ()
    static member RenderDFGC color = Rules.RenderDefaultForegroundColor color
    static member RenderDBGC ()    = Rules.RenderDefaultBackgroundColor ()
    static member RenderDBGC color = Rules.RenderDefaultBackgroundColor color
    static member RenderDCC  ()    = Rules.RenderDefaultCursorColor     ()
    static member RenderDCC  color = Rules.RenderDefaultCursorColor     color

    // Alias modalità "funzionale"
    static member Init () = Rul ()

    member this.TTL title = base.Title title :?> Rul

    member this.SCB () = base.ShowCursorBlinking () :?> Rul
    member this.HCB () = base.HideCursorBlinking () :?> Rul

    member this.SC () = base.ShowCursor () :?> Rul
    member this.HC () = base.HideCursor () :?> Rul

    member this.EDM () = base.EnableDesignateMode  () :?> Rul
    member this.DDM () = base.DisableDesignateMode () :?> Rul

    member this.EAB () = base.EnableAlternativeBuffer  () :?> Rul
    member this.DAB () = base.DisableAlternativeBuffer () :?> Rul

    member this.CS ()    = base.CursorShape ()    :?> Rul
    member this.CS shape = base.CursorShape shape :?> Rul

    member this.DFGC ()    = base.DefaultForegroundColor ()    :?> Rul
    member this.DFGC color = base.DefaultForegroundColor color :?> Rul
    member this.DBGC ()    = base.DefaultBackgroundColor ()    :?> Rul
    member this.DBGC color = base.DefaultBackgroundColor color :?> Rul
    member this.DCC  ()    = base.DefaultCursorColor     ()    :?> Rul
    member this.DCC  color = base.DefaultCursorColor     color :?> Rul

    // Alias modalità imperativa
    static member DoTTL title = Rules.DoTitle title

    static member DoSCB () = Rules.DoShowCursorBlinking ()
    static member DoHCB () = Rules.DoHideCursorBlinking ()

    static member DoSC () = Rules.DoShowCursor ()
    static member DoHC () = Rules.DoHideCursor ()

    static member DoEDM () = Rules.DoEnableDesignateMode  ()
    static member DoDDM () = Rules.DoDisableDesignateMode ()

    static member DoEAB () = Rules.DoEnableAlternativeBuffer  ()
    static member DoDAB () = Rules.DoDisableAlternativeBuffer ()

    static member DoCS ()    = Rules.DoCursorShape ()
    static member DoCS shape = Rules.DoCursorShape shape

    static member DoDFGC ()    = Rules.DoDefaultForegroundColor ()
    static member DoDFGC color = Rules.DoDefaultForegroundColor color
    static member DoDBGC ()    = Rules.DoDefaultBackgroundColor ()
    static member DoDBGC color = Rules.DoDefaultBackgroundColor color
    static member DoDCC  ()    = Rules.DoDefaultCursorColor     ()
    static member DoDCC  color = Rules.DoDefaultCursorColor     color
