(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Position.fsi

    Title       : POSITION
    Description : Contiene le firme delle classi, delle
                  interfacce e delle enumerazioni pubbliche
                  del modulo Position.
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
type Position =

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFPosition : position : Position -> Position.Position

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPPosition : position : Position.Position -> Position



and Cell =

    inherit Position

    new : unit                   -> Cell
    new : row  : int * col : int -> Cell

    member Row : int with get, set
    member Col : int with get, set

    static member fromRowCol : row : int * col : int -> Cell
    static member fromXY     : x   : int * y   : int -> Cell

    static member fromCoord : coord : Coord -> Cell

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFRowCol : cell : Cell -> Position.RowCol
    static member internal toFCell   : cell : Cell -> Position.Cell

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPCell : rowCol : Position.RowCol -> Cell
    static member internal toOOPCell : cell   : Position.Cell   -> Cell

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string



and Coord =

    inherit Position

    new : unit                 -> Coord
    new : x    : int * y : int -> Coord

    member X : int with get, set
    member Y : int with get, set

    static member fromXY     : x   : int * y   : int -> Coord
    static member fromRowCol : row : int * col : int -> Coord

    static member fromCell : cell : Cell -> Coord

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal toFXY    : coord : Coord -> Position.XY
    static member internal toFCoord : coord : Coord -> Position.Coord

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal toOOPCoord : xY    : Position.XY    -> Coord
    static member internal toOOPCoord : coord : Position.Coord -> Coord

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
