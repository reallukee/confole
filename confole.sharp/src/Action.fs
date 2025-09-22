(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Action.fs

    Title       : ACTION
    Description : Action

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
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



type InsertCharacterAction() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        InsertCharacterAction() then

        this.N <- n

    interface IAction with
        member this.ToFunctional
            with get() =
                Action.InsertCharacter this.N

    override this.Equals(obj) =
        match obj with
        | :? InsertCharacterAction as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"

type DeleteCharacterAction() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        DeleteCharacterAction() then

        this.N <- n

    interface IAction with
        member this.ToFunctional
            with get() =
                Action.DeleteCharacter this.N

    override this.Equals(obj) =
        match obj with
        | :? DeleteCharacterAction as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"



type InsertLineAction() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        InsertLineAction() then

        this.N <- n

    interface IAction with
        member this.ToFunctional
            with get() =
                Action.InsertLine this.N

    override this.Equals(obj) =
        match obj with
        | :? InsertLineAction as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"

type DeleteLineAction() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        DeleteLineAction() then

        this.N <- n

    interface IAction with
        member this.ToFunctional
            with get() =
                Action.DeleteLine this.N

    override this.Equals(obj) =
        match obj with
        | :? DeleteLineAction as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"



type EraseDisplayAction() =
    let mutable erase_ = Erase.FromBeginToEnd

    member this.Erase
        with get() =
            erase_

        and set(erase) =
            erase_ <- erase

    new(erase) as this =
        EraseDisplayAction() then

        this.Erase <- erase

    interface IAction with
        member this.ToFunctional
            with get() =
                let erase =
                    match this.Erase with
                    | Erase.FromCurrentToEnd   -> Action.Erase.FromCurrentToEnd
                    | Erase.FromBeginToCurrent -> Action.Erase.FromBeginToCurrent
                    | Erase.FromBeginToEnd     -> Action.Erase.FromBeginToEnd
                    | _                        -> failwith "Unknown value!"

                Action.EraseDisplay (Some erase)

    override this.Equals(obj) =
        match obj with
        | :? EraseDisplayAction as other ->
            this.Erase = other.Erase
        | _ -> false

    override this.GetHashCode() =
        hash(this.Erase)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"

type EraseLineAction() =
    let mutable erase_ = Erase.FromBeginToEnd

    member this.Erase
        with get() =
            erase_

        and set(erase) =
            erase_ <- erase

    new(erase) as this =
        EraseLineAction() then

        this.Erase <- erase

    interface IAction with
        member this.ToFunctional
            with get() =
                let erase =
                    match this.Erase with
                    | Erase.FromCurrentToEnd   -> Action.Erase.FromCurrentToEnd
                    | Erase.FromBeginToCurrent -> Action.Erase.FromBeginToCurrent
                    | Erase.FromBeginToEnd     -> Action.Erase.FromBeginToEnd
                    | _                        -> failwith "Unknown value!"

                Action.EraseLine (Some erase)

    override this.Equals(obj) =
        match obj with
        | :? EraseLineAction as other ->
            this.Erase = other.Erase
        | _ -> false

    override this.GetHashCode() =
        hash(this.Erase)

    override this.ToString() =
        $"{(this :> IAction).ToFunctional}"



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



    member this.AddInsertCharacterAction(n) =
        let insertCharacterAction = new InsertCharacterAction(n)

        this.AddAction(insertCharacterAction)

    member this.AddDeleteCharacterAction(n) =
        let deleteCharacterAction = new DeleteCharacterAction(n)

        this.AddAction(deleteCharacterAction)



    member this.AddInsertLineAction(n) =
        let insertLineAction = new InsertLineAction(n)

        this.AddAction(insertLineAction)

    member this.AddDeleteLineAction(n) =
        let deleteLineAction = new DeleteLineAction(n)

        this.AddAction(deleteLineAction)



    member this.AddEraseDisplayAction(erase) =
        let eraseDisplayAction = new EraseDisplayAction(erase)

        this.AddAction(eraseDisplayAction)

    member this.AddEraseLineAction(erase) =
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
            |> List.rev
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
