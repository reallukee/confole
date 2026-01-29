(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Act.fs

    Title       : ACT
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Act.
                  Il modulo Act si occupa di sequenze VTS
                  relative al viewport del terminale.

                  Fornisce gli Alias di Action.

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
type Act internal () =

    inherit Actions ()

    // Alias modalità manuale
    static member RenderIC () = Actions.RenderInsertCharacter ()
    static member RenderIC n  = Actions.RenderInsertCharacter n
    static member RenderDC () = Actions.RenderDeleteCharacter ()
    static member RenderDC n  = Actions.RenderDeleteCharacter n

    static member RenderIL () = Actions.RenderInsertLine ()
    static member RenderIL n  = Actions.RenderInsertLine n
    static member RenderDL () = Actions.RenderDeleteLine ()
    static member RenderDL n  = Actions.RenderDeleteLine n

    static member RenderED ()    = Actions.RenderEraseDisplay ()
    static member RenderED erase = Actions.RenderEraseDisplay erase
    static member RenderEL ()    = Actions.RenderEraseLine    ()
    static member RenderEL erase = Actions.RenderEraseLine    erase



    // Modalità "funzionale"
    // Sovrascrivo la logica di base.
    static member Init () = Act ()

    static member InitWith (act : Act) =
        let newAct = Act.Init ()

        newAct.ActionsList.AddRange(act.ActionsList)

        newAct

    member this.Clear () = this.ActionsList.Clear(); this

    member this.View () =
        this.ActionsList
        |> Seq.toList
        |> Action.view
        |> ignore

        this

    member this.Preview () =
        this.ActionsList
        |> Seq.toList
        |> Action.preview
        |> ignore

        this

    member this.InsertCharacter () = base.InsertCharacter () :?> Act
    member this.InsertCharacter n  = base.InsertCharacter n  :?> Act
    member this.DeleteCharacter () = base.DeleteCharacter () :?> Act
    member this.DeleteCharacter n  = base.DeleteCharacter n  :?> Act

    member this.InsertLine () = base.InsertLine () :?> Act
    member this.InsertLine n  = base.InsertLine n  :?> Act
    member this.DeleteLine () = base.DeleteLine () :?> Act
    member this.DeleteLine n  = base.DeleteLine n  :?> Act

    member this.EraseDisplay ()    = base.EraseDisplay ()    :?> Act
    member this.EraseDisplay erase = base.EraseDisplay erase :?> Act
    member this.EraseLine    ()    = base.EraseLine    ()    :?> Act
    member this.EraseLine    erase = base.EraseLine    erase :?> Act



    // Alias modalità "funzionale"
    member this.IC () = base.InsertCharacter () :?> Act
    member this.IC n  = base.InsertCharacter n  :?> Act
    member this.DC () = base.DeleteCharacter () :?> Act
    member this.DC n  = base.DeleteCharacter n  :?> Act

    member this.IL () = base.InsertLine () :?> Act
    member this.IL n  = base.InsertLine n  :?> Act
    member this.DL () = base.DeleteLine () :?> Act
    member this.DL n  = base.DeleteLine n  :?> Act

    member this.ED ()    = base.EraseDisplay ()    :?> Act
    member this.ED erase = base.EraseDisplay erase :?> Act
    member this.EL ()    = base.EraseLine    ()    :?> Act
    member this.EL erase = base.EraseLine    erase :?> Act



    // Alias modalità imperativa
    static member DoIC () = Actions.DoInsertCharacter ()
    static member DoIC n  = Actions.DoInsertCharacter n
    static member DoDC () = Actions.DoDeleteCharacter ()
    static member DoDC n  = Actions.DoDeleteCharacter n

    static member DoIL () = Actions.DoInsertLine ()
    static member DoIL n  = Actions.DoInsertLine n
    static member DoDL () = Actions.DoDeleteLine ()
    static member DoDL n  = Actions.DoDeleteLine n

    static member DoED ()    = Actions.DoEraseDisplay ()
    static member DoED erase = Actions.DoEraseDisplay erase
    static member DoEL ()    = Actions.DoEraseLine    ()
    static member DoEL erase = Actions.DoEraseLine    erase
