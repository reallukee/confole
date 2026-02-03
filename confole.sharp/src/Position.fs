(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Position.fs

    Title       : POSITION
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Position.

                  Il modulo Position si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!
                  Questo modulo wrappa anche i moduli Positions
                  e PositionConversion.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

[<AbstractClass>]
type Position internal () =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFPosition (position : Position) =
        match position with
        // RowCol
        | :? Cell  as cell  -> Position.RowCol (cell.Row, cell.Col)
        // XY
        | :? Coord as coord -> Position.XY     (coord.X, coord.Y)
        | position -> failwithf "%A: Unsupported position format!" position

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPPosition (position : Position.Position) : Position =
        match position with
        | Position.RowCol rowCol -> Cell.ToOOPCell   rowCol
        | Position.Cell   cell   -> Cell.ToOOPCell   cell
        | Position.XY     xY     -> Coord.ToOOPCoord xY
        | Position.Coord  coord  -> Coord.ToOOPCoord coord
        | position -> failwithf "%A: Unsupported position format!" position



and Cell () =

    inherit Position ()

    let mutable row = 0
    let mutable col = 0



    new (row, col) as this =
        Cell () then
            this.Row <- row
            this.Col <- col



    member this.Row
        with get () =
            row

        and set value =
            row <- value

    member this.Col
        with get () =
            col

        and set value =
            col <- value



    static member FromRowCol (row, col) =
        new Cell (row, col)

    static member FromXY (x, y) =
        new Cell (y + 1, x + 1)



    static member FromCoord (coord : Coord) =
        new Cell (coord.Y, coord.X)



    static member Get position =
        let position = Positions.RowCol.get position Positions.RowCol.Format.RowCol

        let row, col =
            match position with
            | Position.Position.RowCol (row, col) -> row, col
            | _ -> failwith "It can't happen :)"

        Cell.FromRowCol(row, col)

    static member TryGet (position, outPosition : byref<Cell>) =
        let position = Positions.RowCol.tryGet position Positions.RowCol.Format.RowCol

        match position with
        | Some position ->
            let row, col =
                match position with
                | Position.Position.RowCol (row, col) -> row, col
                | _ -> failwith "It can't happen :)"

            outPosition <- Cell.FromRowCol(row, col)

            true

        | None -> false

    static member Exists position =
        Positions.RowCol.exists position



    override this.Equals obj =
        match obj with
        | :? Cell as other ->
            this.Row = other.Row &&
            this.Col = other.Col
        | _ -> false

    override this.GetHashCode () =
        hash (this.Row, this.Col)

    override this.ToString () =
        $"Cell({this.Row}, {this.Col})"



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFRowCol (cell : Cell) =
        cell.Row, cell.Col

    static member internal ToFCell (cell : Cell) =
        Position.rowColToCell (cell.Row, cell.Col)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPCell (rowCol : Position.RowCol) =
        let row, col = rowCol

        new Cell (row, col)

    static member internal ToOOPCell (cell : Position.Cell) =
        new Cell (cell.row, cell.col)



and Coord () =

    inherit Position ()

    let mutable x = 0
    let mutable y = 0



    new (x, y) as this =
        Coord () then
            this.X <- x
            this.Y <- y



    member this.X
        with get () =
            x

        and set value =
            x <- value

    member this.Y
        with get () =
            y

        and set value =
            y <- value



    static member FromXY (x, y) =
        new Coord (x, y)

    static member FromRowCol (row, col) =
        new Coord (col - 1, row - 1)



    static member FromCell (cell : Cell) =
        new Coord (cell.Col, cell.Row)



    static member Get position =
        let position = Positions.XY.get position Positions.XY.Format.XY

        let x, y =
            match position with
            | Position.Position.XY (x, y) -> x, y
            | _ -> failwith "It can't happen :)"

        Coord.FromXY(x, y)

    static member TryGet (position, outPosition : byref<Coord>) =
        let position = Positions.XY.tryGet position Positions.XY.Format.XY

        match position with
        | Some position ->
            let x, y =
                match position with
                | Position.Position.XY (x, y) -> x, y
                | _ -> failwith "It can't happen :)"

            outPosition <- Coord.FromXY(x, y)

            true

        | None -> false

    static member Exists position =
        Positions.XY.exists position



    override this.Equals obj =
        match obj with
        | :? Coord as other ->
            this.X = other.X &&
            this.Y = other.Y
        | _ -> false

    override this.GetHashCode () =
        hash (this.X, this.Y)

    override this.ToString () =
        $"Cell({this.X}, {this.Y})"



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFXY (coord : Coord) =
        coord.X, coord.Y

    static member internal ToFCoord (coord : Coord) =
        Position.xYToCoord (coord.X, coord.Y)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPCoord (xY : Position.XY) =
        let x, y = xY

        new Coord (x, y)

    static member internal ToOOPCoord (coord : Position.Coord) =
        new Coord (coord.x, coord.y)
