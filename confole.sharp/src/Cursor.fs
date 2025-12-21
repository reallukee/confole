(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Cursor.
                  Il modulo Cursor si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type ICursor =
    abstract member ToFunctional : Cursor.Cursor with get

type ICursors = ICursor list



[<AbstractClass>]
type CursorEmpty(cursor) =
    interface ICursor with
        member this.ToFunctional
            with get() =
                cursor

    override this.Equals(obj) =
        match obj with
        | :? CursorEmpty as other ->
            this.GetType() = other.GetType()
        | _ -> false

    override this.GetHashCode() =
        this.GetType().GetHashCode()

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type ReverseCursor() =
    inherit CursorEmpty(Cursor.Cursor.Reverse)

type SaveCursor() =
    inherit CursorEmpty(Cursor.Cursor.Save)

type RestoreCursor() =
    inherit CursorEmpty(Cursor.Cursor.Restore)



[<AbstractClass>]
type CursorN(cursor, n) =
    let mutable n_ = n

    member this.N
        with get() =
            n_

        and set(n) =
           n_ <- n

    interface ICursor with
        member this.ToFunctional
            with get() =
                cursor (Some n)

    override this.Equals(obj) =
        match obj with
        | :? CursorN as other ->
            this.GetType() = other.GetType() &&
            this.N         = other.N
        | _ -> false

    override this.GetHashCode() =
        hash(this.N)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type UpCursor() =
    inherit CursorN(Cursor.Cursor.Up, 1)

    new(n) as this =
        UpCursor() then
            this.N <- n

type DownCursor() =
    inherit CursorN(Cursor.Cursor.Down, 1)

    new(n) as this =
        DownCursor() then
            this.N <- n

type NextCursor() =
    inherit CursorN(Cursor.Cursor.Next, 1)

    new(n) as this =
        NextCursor() then
            this.N <- n

type PreviousCursor() =
    inherit CursorN(Cursor.Cursor.Previous, 1)

    new(n) as this =
        PreviousCursor() then
            this.N <- n

type NextLineCursor() =
    inherit CursorN(Cursor.Cursor.NextLine, 1)

    new(n) as this =
        NextLineCursor() then
            this.N <- n

type PreviousLineCursor() =
    inherit CursorN(Cursor.Cursor.PreviousLine, 1)

    new(n) as this =
        PreviousLineCursor() then
            this.N <- n



[<AbstractClass>]
type CursorPosition(cursor, position : Sharp.Position) =
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

                cursor (Some position)

    override this.Equals(obj) =
        match obj with
        | :? CursorPosition as other ->
            this.GetType() = other.GetType() &&
            this.Position.Equals(other.Position)
        | _ -> false

    override this.GetHashCode() =
        hash(this.Position)

    override this.ToString() =
        $"{(this :> ICursor).ToFunctional}"

type MoveCursor() =
    inherit CursorPosition(Cursor.Cursor.Move, new Cell(0, 0))

    new(position) as this =
        MoveCursor() then
            this.Position <- position



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



    member this.AddCursor(cursor : ICursor) =
        this.Cursors <- cursor :: this.Cursors

        this

    member this.AddCursors(cursors : ICursors) =
        this.Cursors <- cursors @ this.Cursors

        this



    member this.AddReverse() =
        let reverseCursor = new ReverseCursor()

        this.AddCursor(reverseCursor)

    member this.AddSave() =
        let saveCursor = new SaveCursor()

        this.AddCursor(saveCursor)

    member this.AddRestore() =
        let restoreCursor = new RestoreCursor()

        this.AddCursor(restoreCursor)

    member this.AddUp(n) =
        let upCursor = new UpCursor(n)

        this.AddCursor(upCursor)

    member this.AddDown(n) =
        let downCursor = new DownCursor(n)

        this.AddCursor(downCursor)

    member this.AddNext(n) =
        let nextCursor = new NextCursor(n)

        this.AddCursor(nextCursor)

    member this.AddPrevious(n) =
        let previousLine = new PreviousCursor(n)

        this.AddCursor(previousLine)

    member this.AddNextLine(n) =
        let nextLineCursor = new NextLineCursor(n)

        this.AddCursor(nextLineCursor)

    member this.AddPreviousLine(n) =
        let previousLineCursor = new PreviousLineCursor(n)

        this.AddCursor(previousLineCursor)

    member this.AddMove(position) =
        let moveCursor = new MoveCursor(position)

        this.AddCursor(moveCursor)



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
        if newLine then
            Cursor.applyNewLine cursor.ToFunctional
        else
            Cursor.apply cursor.ToFunctional

    member this.Apply(cursor : ICursor, newLine) =
        this.CallApply(cursor, newLine)

    member this.Apply(cursor : ICursor) =
        this.CallApply(cursor, this.NewLine)

    member private this.CallApplyAll(newLine) =
        let cursors =
            this.Cursors
            |> List.map (fun cursor ->
                cursor.ToFunctional
            )

        if newLine then
            Cursor.applyAllNewLine cursors
        else
            Cursor.applyAll cursors

    member this.ApplyAll(newLine) =
        this.CallApplyAll newLine

    member this.ApplyAll() =
        this.CallApplyAll this.NewLine



    member this.Reset() =
        this.Cursors <- []

        Cursor.reset ()



    static member DoReverse() =
        let reverseCursor = new ReverseCursor() :> ICursor

        Cursor.apply reverseCursor.ToFunctional

    static member DoSave() =
        let saveCursor = new SaveCursor() :> ICursor

        Cursor.apply saveCursor.ToFunctional

    static member DoRestore() =
        let restoreCursor = new RestoreCursor() :> ICursor

        Cursor.apply restoreCursor.ToFunctional

    static member DoUp(n) =
        let upCursor = new UpCursor(n) :> ICursor

        Cursor.apply upCursor.ToFunctional

    static member DoDown(n) =
        let downCursor = new DownCursor(n) :> ICursor

        Cursor.apply downCursor.ToFunctional

    static member DoNext(n) =
        let nextCursor = new NextCursor(n) :> ICursor

        Cursor.apply nextCursor.ToFunctional

    static member DoPrevious(n) =
        let previousCursor = new PreviousCursor(n) :> ICursor

        Cursor.apply previousCursor.ToFunctional

    static member DoNextLine(n) =
        let nextLineCursor = new NextLineCursor(n) :> ICursor

        Cursor.apply nextLineCursor.ToFunctional

    static member DoPreviousLine(n) =
        let previousLineCursor = new PreviousLineCursor(n) :> ICursor

        Cursor.apply previousLineCursor.ToFunctional

    static member DoMove(position) =
        let moveCursor = new MoveCursor(position) :> ICursor

        Cursor.apply moveCursor.ToFunctional



    static member DoReset() =
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
