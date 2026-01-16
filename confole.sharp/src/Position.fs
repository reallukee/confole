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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

[<AbstractClass>]
type Position () =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFPosition (position : Position) =
        match position with
        // RowCol
        | :? Cell  as cell  -> Position.RowCol (cell.Row, cell.Col)
        // XY
        | :? Coord as coord -> Position.XY     (coord.X, coord.Y)
        | position -> failwithf "%A: Unsupported position format!" position

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPPosition (position : Position.Position) : Position =
        match position with
        | Position.RowCol rowCol -> Cell.toOOPCell   (rowCol)
        | Position.Cell   cell   -> Cell.toOOPCell   (cell)
        | Position.XY     xY     -> Coord.toOOPCoord (xY)
        | Position.Coord  coord  -> Coord.toOOPCoord (coord)
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



    static member fromRowCol (row, col) =
        new Cell (row, col)

    static member fromXY (x, y) =
        new Cell (y, x)



    static member fromCoord (coord : Coord) =
        new Cell (coord.Y, coord.X)



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFRowCol (cell : Cell) =
        cell.Row, cell.Col

    static member internal toFCell (cell : Cell) =
        Position.rowColToCell (cell.Row, cell.Col)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPCell (rowCol : Position.RowCol) =
        let row, col = rowCol

        new Cell (row, col)

    static member internal toOOPCell (cell : Position.Cell) =
        new Cell (cell.row, cell.col)



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



    static member fromXY (x, y) =
        new Coord (x, y)

    static member fromRowCol (row, col) =
        new Coord (col, row)



    static member fromCell (cell : Cell) =
        new Coord (cell.Col, cell.Row)



    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFXY (coord : Coord) =
        coord.X, coord.Y

    static member internal toFCoord (coord : Coord) =
        Position.xYToCoord (coord.X, coord.Y)

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPCoord (xY : Position.XY) =
        let x, y = xY

        new Coord (x, y)

    static member internal toOOPCoord (coord : Position.Coord) =
        new Coord (coord.x, coord.y)



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
