(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Cursor

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type ICursor =
    abstract member ToFunctional : Cursor.Cursor with get

type ICursors = ICursor list



type ReverseCursor() =
    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Reverse

    override this.Equals(obj) =
        match obj with
        | :? ReverseCursor -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type SaveCursor() =
    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Save

    override this.Equals(obj) =
        match obj with
        | :? SaveCursor -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type RestoreCursor() =
    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Restore

    override this.Equals(obj) =
        match obj with
        | :? RestoreCursor -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"



type UpCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        UpCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Up (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? UpCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type DownCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        DownCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Down (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? DownCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type NextCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        NextCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Next (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? NextCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type PreviousCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        PreviousCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.Previous (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? PreviousCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"



type NextLineCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        NextLineCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.NextLine (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? NextLineCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type PreviousLineCursor() =
    let mutable n_ = 1

    member this.N
        with get() =
            n_

        and set(n) =
            n_ <- n

    new(n) as this =
        PreviousLineCursor() then

        this.N <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                Cursor.PreviousLine (Some this.N)

    override this.Equals(obj) =
        match obj with
        | :? PreviousLineCursor as other ->
            this.N = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"



type CursorMove(position : Position) =
    let mutable position_ = position

    member this.Position
        with get() =
            position_

        and set(position) =
            position_ <- position

    interface ICursor with
        member this.ToFunctional
            with get() =
                let position =
                    match this.Position with
                    | :? Cell as cell ->
                        Position.ColRow (cell.Col, cell.Row)
                    | _ -> failwith "Unsupported position format!"

                Cursor.Move position

    override this.Equals(obj) =
        match obj with
        | :? CursorMove as other ->
            this.Position = other.Position
        | _ -> false

    override this.GetHashCode() =
        hash(this.Position)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"



type Cursors() =
    let mutable cursors_ = []
    let mutable newLine_ = false

    member this.Cursors
        with get() =
            cursors_

        and private set(cursors) =
            cursors_ <- cursors

    member this.NewLine
        with get() =
            newLine_

        and set(newLine) =
            newLine_ <- newLine



    new(cursors, newLine) as this =
        Cursors() then

        this.Cursors <- cursors
        this.NewLine <- newLine

    new(newLine) as this =
        Cursors() then

        this.Cursors <- []
        this.NewLine <- newLine



    member this.Item
        with get(index) =
            this.Cursors
            |> List.rev
            |> List.item index



    member this.AddCursor(cursors : ICursor) =
        this.Cursors <- cursors :: this.Cursors

        this

    member this.AddCursors(cursors : ICursors) =
        this.Cursors <- cursors @ this.Cursors

        this



    member this.AddReverseCursor() = this.AddCursor(new ReverseCursor())
    member this.AddSaveCursor()    = this.AddCursor(new SaveCursor())
    member this.AddRestoreCursor() = this.AddCursor(new RestoreCursor())

    member this.AddUpCursor(n)       = this.AddCursor(new UpCursor(n))
    member this.AddDownCursor(n)     = this.AddCursor(new DownCursor(n))
    member this.AddNextCursor(n)     = this.AddCursor(new NextCursor(n))
    member this.AddPreviousCursor(n) = this.AddCursor(new PreviousCursor(n))

    member this.AddNextLineCursor(n)     = this.AddCursor(new NextLineCursor(n))
    member this.AddPreviousLineCursor(n) = this.AddCursor(new PreviousLineCursor(n))

    member this.AddMoveCursor(position) = this.AddCursor(new CursorMove(position))



    member this.Clear() =
        this.Cursors <- []

        this



    member this.View() =
        this.Cursors
        |> List.rev
        |> List.iter (fun cursor ->
            printfn "%A" cursor
        )



    member private this.CallApply(cursor : ICursor, newLine) =
        cursor.ToFunctional
        |> Cursor.apply newLine

    member this.Apply(cursor : ICursor, newLine) =
        this.CallApply(cursor, newLine)

    member this.Apply(cursor : ICursor) =
        this.CallApply(cursor, this.NewLine)



    member private this.CallApplyAll(newLine) =
        this.Cursors
        |> List.rev
        |> List.map (fun cursor ->
            cursor.ToFunctional
        )
        |> Cursor.applyAll newLine

    member this.ApplyAll(newLine) =
        this.CallApplyAll newLine

    member this.ApplyAll() =
        this.CallApplyAll this.NewLine



    member this.Reset() =
        this.Cursors <- []

        Cursor.reset ()



    override this.Equals(obj) =
        match obj with
        | :? Cursors as other ->
            this.NewLine = other.NewLine &&
            this.Cursors.Equals(other.Cursors)
        | _ -> false

    override this.GetHashCode() =
        hash(this.NewLine, this.Cursors)

    override this.ToString() =
        let cursors =
            this.Cursors
            |> Seq.map (fun cursor ->
                cursor.ToString()
            )
            |> String.concat "; "

        $"Cursors(NewLine={this.NewLine}, Cursors=[{cursors}])"
