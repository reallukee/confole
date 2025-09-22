(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Position.fs

    Title       : POSITION
    Description : Position

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

[<AbstractClass>]
type Position() = class end

type Cell() =
    inherit Position()

    let mutable col_ = 0
    let mutable row_ = 0

    new(col, row) as this =
        Cell() then

        this.Col <- col
        this.Row <- row

    member this.Col
        with get() =
            col_

        and set(col) =
            col_ <- col

    member this.Row
        with get() =
            row_

        and set(row) =
            row_ <- row

    override this.Equals(obj) =
        match obj with
        | :? Cell as other ->
            this.Col = other.Col &&
            this.Row = other.Row
        | _ -> false

    override this.GetHashCode() =
        hash(this.Col, this.Row)

    override this.ToString() =
        $"Cell({this.Col}, {this.Row})"
