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
type Position() = class end



and Cell() =
    inherit Position()

    let mutable row_ = 0
    let mutable col_ = 0



    new(row, col) as this =
        Cell() then
            this.Row <- row
            this.Col <- col



    member this.Row
        with get() =
            row_

        and set(row) =
            row_ <- row

    member this.Col
        with get() =
            col_

        and set(col) =
            col_ <- col



    static member fromRowCol(row, col) =
        new Cell(row, col)

    static member fromXY(x, y) =
        new Cell(y, x)



    static member fromCoord(coord : Coord) =
        new Cell(coord.Y, coord.X)



    override this.Equals(obj) =
        match obj with
        | :? Cell as other ->
            this.Row = other.Row &&
            this.Col = other.Col
        | _ -> false

    override this.GetHashCode() =
        hash(this.Row, this.Col)

    override this.ToString() =
        $"Cell({this.Row}, {this.Col})"



and Coord() =
    inherit Position()

    let mutable x_ = 0
    let mutable y_ = 0



    new(x, y) as this =
        Coord() then
            this.X <- x
            this.Y <- y



    member this.X
        with get() =
            x_

        and set(x) =
            x_ <- x

    member this.Y
        with get() =
            y_

        and set(y) =
            y_ <- y



    static member fromXY(x, y) =
        new Coord(x, y)

    static member fromRowCol(row, col) =
        new Coord(col, row)



    static member fromCell(cell : Cell) =
        new Coord(cell.Col, cell.Row)



    override this.Equals(obj) =
        match obj with
        | :? Coord as other ->
            this.X = other.X &&
            this.Y = other.Y
        | _ -> false

    override this.GetHashCode() =
        hash(this.X, this.Y)

    override this.ToString() =
        $"Cell({this.X}, {this.Y})"
