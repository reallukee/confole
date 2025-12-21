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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type Erase =
    | FromCurrentToEnd   = 0
    | FromBeginToCurrent = 1
    | FromBeginToEnd     = 2



type IAction =
    abstract member ToFunctional : Action.Action with get

type IActions = IAction list



[<AbstractClass>]
type ActionN(action, n) =
    let mutable n_ = n

    member this.N
        with get() =
            n_

        and set(n) =
           n_ <- n

    interface IAction with
        member this.ToFunctional
            with get() =
                action (Some n)

    override this.Equals(obj) =
        match obj with
        | :? ActionN as other ->
            this.GetType() = other.GetType() &&
            this.N         = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"

type InsertCharacterAction() =
    inherit ActionN(Action.Action.InsertCharacter, 0)

    new(n) as this =
        InsertCharacterAction() then
            this.N <- n

type DeleteCharacterAction() =
    inherit ActionN(Action.Action.DeleteCharacter, 0)

    new(n) as this =
        DeleteCharacterAction() then
            this.N <- n

type InsertLineAction() =
    inherit ActionN(Action.Action.InsertLine, 0)

    new(n) as this =
        InsertLineAction() then
            this.N <- n

type DeleteLineAction() =
    inherit ActionN(Action.Action.DeleteLine, 0)

    new(n) as this =
        DeleteLineAction() then
            this.N <- n



[<AbstractClass>]
type ActionErase(action, erase) =
    let mutable erase_ = erase

    member this.Erase
        with get() =
            erase_

        and set(erase) =
            erase_ <- erase

    interface IAction with
        member this.ToFunctional
            with get() =
                let erase =
                    match this.Erase with
                    | Erase.FromCurrentToEnd   -> Action.Erase.FromCurrentToEnd
                    | Erase.FromBeginToCurrent -> Action.Erase.FromBeginToCurrent
                    | Erase.FromBeginToEnd     -> Action.Erase.FromBeginToEnd
                    | _ -> failwith "Unknown value!"

                action (Some erase)

    override this.Equals(obj) =
        match obj with
        | :? ActionErase as other ->
            this.GetType() = other.GetType() &&
            this.Erase     = other.Erase
        | _ -> false

    override this.GetHashCode() =
        hash(this.Erase)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"

type EraseDisplayAction() =
    inherit ActionErase(Action.Action.EraseDisplay, Erase.FromBeginToEnd)

    new(erase) as this =
        EraseDisplayAction() then
            this.Erase <- erase

type EraseLineAction() =
    inherit ActionErase(Action.Action.EraseLine, Erase.FromBeginToEnd)

    new(erase) as this =
        EraseLineAction() then
            this.Erase <- erase



type Actions() =
    let mutable actions_ = []
    let mutable newLine_ = false

    member this.Actions
        with get() =
            actions_

        and private set(actions) =
            actions_ <- actions

    member this.NewLine
        with get() =
            newLine_

        and set(newLine) =
            newLine_ <- newLine

    new(actions, newLine) as this =
        Actions() then
            this.Actions <- actions
            this.NewLine <- newLine

    new(newLine) as this =
        Actions() then
            this.Actions <- []
            this.NewLine <- newLine

    member this.Item
        with get(index) =
            this.Actions
            |> List.rev
            |> List.item index



    member this.AddAction(action : IAction) =
        this.Actions <- action :: this.Actions

        this

    member this.AddActions(actions : IActions) =
        this.Actions <- actions @ this.Actions

        this



    member this.AddInsertCharacter(n) =
        let insertCharacterAction = new InsertCharacterAction(n)

        this.AddAction(insertCharacterAction)

    member this.AddDeleteCharacter(n) =
        let deleteCharacterAction = new DeleteCharacterAction(n)

        this.AddAction(deleteCharacterAction)

    member this.AddInsertLine(n) =
        let insertLineAction = new InsertLineAction(n)

        this.AddAction(insertLineAction)

    member this.AddDeleteLine(n) =
        let deleteLineAction = new DeleteLineAction(n)

        this.AddAction(deleteLineAction)

    member this.AddEraseDisplay(erase) =
        let eraseDisplayAction = new EraseDisplayAction(erase)

        this.AddAction(eraseDisplayAction)

    member this.AddEraseLine(erase) =
        let eraseLineAction = new EraseLineAction(erase)

        this.AddAction(eraseLineAction)



    member this.Clear() =
        this.Actions <- []

        this

    member this.View() =
        this.Actions
        |> List.rev
        |> List.iter (fun action ->
            printfn "%A" action
        )



    member private this.CallApply(action : IAction, newLine) =
        if newLine then
            Action.applyNewLine action.ToFunctional
        else
            Action.apply action.ToFunctional

    member this.Apply(action : IAction, newLine) =
        this.CallApply(action, newLine)

    member this.Apply(action : IAction) =
        this.CallApply(action, this.NewLine)

    member private this.CallApplyAll(newLine) =
        let actions =
            this.Actions
            |> List.map (fun action ->
                action.ToFunctional
            )

        if newLine then
            Action.applyAllNewLine actions
        else
            Action.applyAll actions

    member this.ApplyAll(newLine) =
        this.CallApplyAll newLine

    member this.ApplyAll() =
        this.CallApplyAll this.NewLine



    member this.Reset() =
        this.Actions <- []

        Action.reset ()



    static member DoInsertCharacter(n) =
        let insertCharacterAction = new InsertCharacterAction(n) :> IAction

        Action.apply insertCharacterAction.ToFunctional

    static member DoDeleteCharacter(n) =
        let deleteCharacterAction = new DeleteCharacterAction(n) :> IAction

        Action.apply deleteCharacterAction.ToFunctional

    static member DoInsertLine(n) =
        let insertLineAction = new InsertCharacterAction(n) :> IAction

        Action.apply insertLineAction.ToFunctional

    static member DoDeleteLine(n) =
        let deleteLineAction = new DeleteLineAction(n) :> IAction

        Action.apply deleteLineAction.ToFunctional

    static member DoEraseDisplay(erase) =
        let eraseDisplayAction = new EraseDisplayAction(erase) :> IAction

        Action.apply eraseDisplayAction.ToFunctional

    static member DoEraseLine(erase) =
        let eraseLineAction = new EraseLineAction(erase) :> IAction

        Action.apply eraseLineAction.ToFunctional



    static member DoReset() =
        Action.reset ()



    override this.Equals(obj) =
        match obj with
        | :? Actions as other ->
            this.NewLine = other.NewLine &&
            this.Actions.Equals(other.Actions)
        | _ -> false

    override this.GetHashCode() =
        hash(this.NewLine, this.Actions)

    override this.ToString() =
        let actions =
            this.Actions
            |> Seq.map (fun action ->
                action.ToString()
            )
            |> String.concat "; "

        $"Actions(NewLine={this.NewLine}, Actions=[{actions}])"
