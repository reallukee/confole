(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Action.fs

    Title       : ACTION
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Action.
                  Il modulo Action si occupa di wrappare
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

type Erase =
    | FromCurrentToEnd   = 0
    | FromBeginToCurrent = 1
    | FromBeginToEnd     = 2

[<Class>]
type Actions internal () =

    let mutable actions = List<Action.Action>()

    static let mutable newLine = false

    member this.ActionsList
        with internal get () =
            actions

        and internal set value =
            actions <- value

    static member NewLine
        with get () =
            newLine

        and set value =
            newLine <- value



    // Modalità manuale
    member this.Renders () =
        actions
        |> Seq.toList
        |> List.rev
        |> Action.renders

    static member RenderInsertCharacter () = Action.renderInsertCharacter None
    static member RenderInsertCharacter n  = Action.renderInsertCharacter (Some n)
    static member RenderDeleteCharacter () = Action.renderDeleteCharacter None
    static member RenderDeleteCharacter n  = Action.renderDeleteCharacter (Some n)

    static member RenderInsertLine () = Action.renderInsertLine None
    static member RenderInsertLine n  = Action.renderInsertLine (Some n)
    static member RenderDeleteLine () = Action.renderDeleteLine None
    static member RenderDeleteLine n  = Action.renderDeleteLine (Some n)

    static member RenderEraseDisplay ()    = Action.renderEraseDisplay None
    static member RenderEraseDisplay erase = Action.renderEraseDisplay (Some (Actions.OOPEraseToErase erase))
    static member RenderEraseLine    ()    = Action.renderEraseLine    None
    static member RenderEraseLine    erase = Action.renderEraseLine    (Some (Actions.OOPEraseToErase erase))

    static member RenderReset () = Action.renderReset ()



    // Modalità "funzionale"
    static member Init () = Actions ()

    static member Initp (actions : Actions) =
        let newActions = Actions.Init ()

        newActions.ActionsList.AddRange(actions.ActionsList)

        newActions

    member this.Clear () = actions.Clear(); this

    member this.View () =
        actions
        |> Seq.toList
        |> Action.view
        |> ignore

        this

    member this.InsertCharacter () = actions.Add(Action.InsertCharacter None    ); this
    member this.InsertCharacter n  = actions.Add(Action.InsertCharacter (Some n)); this
    member this.DeleteCharacter () = actions.Add(Action.DeleteCharacter None    ); this
    member this.DeleteCharacter n  = actions.Add(Action.DeleteCharacter (Some n)); this

    member this.InsertLine () = actions.Add(Action.InsertLine None    ); this
    member this.InsertLine n  = actions.Add(Action.InsertLine (Some n)); this
    member this.DeleteLine () = actions.Add(Action.DeleteLine None    ); this
    member this.DeleteLine n  = actions.Add(Action.DeleteLine (Some n)); this

    member this.EraseDisplay ()    = actions.Add(Action.EraseDisplay None                                  ); this
    member this.EraseDisplay erase = actions.Add(Action.EraseDisplay (Some (Actions.OOPEraseToErase erase))); this
    member this.EraseLine    ()    = actions.Add(Action.EraseLine    None                                  ); this
    member this.EraseLine    erase = actions.Add(Action.EraseLine    (Some (Actions.OOPEraseToErase erase))); this

    member this.ApplyAll () =
        actions
        |> Seq.toList
        |> List.rev
        |> Action.applyAll

        if Actions.NewLine then
            printfn ""

    member this.ApplyAll newLine =
        actions
        |> Seq.toList
        |> List.rev
        |> Action.applyAll

        if newLine then
            printfn ""

    static member Reset () = Action.reset ()



    // Modalità imperativa
    static member DoInsertCharacter () = Action.doInsertCharacter None
    static member DoInsertCharacter n  = Action.doInsertCharacter (Some n)
    static member DoDeleteCharacter () = Action.doDeleteCharacter None
    static member DoDeleteCharacter n  = Action.doDeleteCharacter (Some n)

    static member DoInsertLine () = Action.doInsertLine None
    static member DoInsertLine n  = Action.doInsertLine (Some n)
    static member DoDeleteLine () = Action.doDeleteLine None
    static member DoDeleteLine n  = Action.doDeleteLine (Some n)

    static member DoEraseDisplay ()    = Action.doEraseDisplay None
    static member DoEraseDisplay erase = Action.doEraseDisplay (Some (Actions.OOPEraseToErase erase))
    static member DoEraseLine    ()    = Action.doEraseLine    None
    static member DoEraseLine    erase = Action.doEraseLine    (Some (Actions.OOPEraseToErase erase))

    static member DoReset () = Action.doReset ()



    // Compatibilità!
    //   Converte DU in ENUM e ENUM in DU.
    static member private OOPEraseToErase erase =
        match erase with
        | Erase.FromCurrentToEnd   -> Action.Erase.FromCurrentToEnd
        | Erase.FromBeginToCurrent -> Action.Erase.FromBeginToCurrent
        | Erase.FromBeginToEnd     -> Action.Erase.FromBeginToEnd
        | erase -> failwithf "%A: Unsupported erase format!" erase

    static member private EraseToOOPErase erase =
        match erase with
        | Action.Erase.FromCurrentToEnd   -> Erase.FromCurrentToEnd
        | Action.Erase.FromBeginToCurrent -> Erase.FromBeginToCurrent
        | Action.Erase.FromBeginToEnd     -> Erase.FromBeginToEnd
        | erase -> failwithf "%A: Unsupported erase format!" erase



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

    // Alias modalità "funzionale"
    static member Init () = Act ()

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
