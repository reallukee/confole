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
                  Il modulo Rule si occupa di sequenze VTS
                  relative all'apparenza del terminale.

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

    (*
        Per ottenere qualcosa di simile alle pipeline
        funzionali di F#, utilizziamo un design pattern di
        tipo Fluent.

        La lista mutabile deve essere esposta solo in un
        contesto sicuro e può essere modificata solamente
        dalle istanze della classe Fluent stessa.

        NOTA BENE: l’API funzionale di F# utilizza il tipo
        "T' option"; per motivi di idiomaticità, questa API
        wrapper sceglie di non esporre il tipo "T' option" e
        ricorre di conseguenza all’overloading.
        Penso sia la roba più simile in un contesto
        fortemente OOP.

        Detto questo, CIAONE!
    *)

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
    static member RenderDefaultForegroundColor color = Rule.renderDefaultForegroundColor (Some (Color.ToFColor color))
    static member RenderDefaultBackgroundColor ()    = Rule.renderDefaultBackgroundColor None
    static member RenderDefaultBackgroundColor color = Rule.renderDefaultBackgroundColor (Some (Color.ToFColor color))
    static member RenderDefaultCursorColor     ()    = Rule.renderDefaultCursorColor     None
    static member RenderDefaultCursorColor     color = Rule.renderDefaultCursorColor     (Some (Color.ToFColor color))

    static member RenderReset () = Rule.renderReset ()



    // Modalità "funzionale"
    static member Init () = Rules ()

    static member InitWith (rules : Rules) =
        let newRules = Rules.Init ()

        newRules.RulesList.AddRange(rules.RulesList)

        newRules

    member this.Clear () = this.RulesList.Clear(); this

    member this.View () =
        this.RulesList
        |> Seq.toList
        |> Rule.view
        |> ignore

        this

    member this.Preview () =
        this.RulesList
        |> Seq.toList
        |> Rule.preview
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
    member this.DefaultForegroundColor color = rules.Add(Rule.DefaultForegroundColor (Some (Color.ToFColor color))); this
    member this.DefaultBackgroundColor ()    = rules.Add(Rule.DefaultBackgroundColor None                         ); this
    member this.DefaultBackgroundColor color = rules.Add(Rule.DefaultBackgroundColor (Some (Color.ToFColor color))); this
    member this.DefaultCursorColor     ()    = rules.Add(Rule.DefaultCursorColor     None                         ); this
    member this.DefaultCursorColor     color = rules.Add(Rule.DefaultCursorColor     (Some (Color.ToFColor color))); this

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
    static member DoDefaultForegroundColor color = Rule.doDefaultForegroundColor (Some (Color.ToFColor color))
    static member DoDefaultBackgroundColor ()    = Rule.doDefaultBackgroundColor None
    static member DoDefaultBackgroundColor color = Rule.doDefaultBackgroundColor (Some (Color.ToFColor color))
    static member DoDefaultCursorColor     ()    = Rule.doDefaultCursorColor     None
    static member DoDefaultCursorColor     color = Rule.doDefaultCursorColor     (Some (Color.ToFColor color))

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
