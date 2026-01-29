(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rul.fs

    Title       : RUL
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Rul.
                  Il modulo Rul si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Fornisce gli Alias di Rule.

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



    // Modalità "funzionale"
    // Sovrascrivo la logica di base.
    static member Init () = Rul ()

    static member InitWith (rul : Rul) =
        let newRul = Rul.Init ()

        newRul.RulesList.AddRange(rul.RulesList)

        newRul

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

    member this.Title title = base.Title title :?> Rul

    member this.ShowCursorBlinking () = base.ShowCursorBlinking () :?> Rul
    member this.HideCursorBlinking () = base.HideCursorBlinking () :?> Rul

    member this.ShowCursor () = base.ShowCursor () :?> Rul
    member this.HideCursor () = base.HideCursor () :?> Rul

    member this.EnableDesignateMode  () = base.EnableDesignateMode  () :?> Rul
    member this.DisableDesignateMode () = base.DisableDesignateMode () :?> Rul

    member this.EnableAlternativeBuffer  () = base.EnableAlternativeBuffer  () :?> Rul
    member this.DisableAlternativeBuffer () = base.DisableAlternativeBuffer () :?> Rul

    member this.CursorShape ()    = base.CursorShape ()    :?> Rul
    member this.CursorShape shape = base.CursorShape shape :?> Rul

    member this.DefaultForegroundColor ()    = base.DefaultForegroundColor ()    :?> Rul
    member this.DefaultForegroundColor color = base.DefaultForegroundColor color :?> Rul
    member this.DefaultBackgroundColor ()    = base.DefaultBackgroundColor ()    :?> Rul
    member this.DefaultBackgroundColor color = base.DefaultBackgroundColor color :?> Rul
    member this.DefaultCursorColor     ()    = base.DefaultCursorColor     ()    :?> Rul
    member this.DefaultCursorColor     color = base.DefaultCursorColor     color :?> Rul



    // Alias modalità "funzionale"
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
