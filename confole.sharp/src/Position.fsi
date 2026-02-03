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
type Position =

    internal new : unit -> Position

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFPosition : position : Position -> Position.Position

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPPosition : position : Position.Position -> Position



and Cell =

    inherit Position

    new : unit                   -> Cell
    new : row  : int * col : int -> Cell

    member Row : int with get, set
    member Col : int with get, set

    static member FromRowCol : row : int * col : int -> Cell
    static member FromXY     : x   : int * y   : int -> Cell

    static member FromCoord : coord : Coord -> Cell

    static member Get    : position : string                             -> Cell
    static member TryGet : position : string * outPosition : byref<Cell> -> bool
    static member Exists : position : string                             -> bool

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFRowCol : cell : Cell -> Position.RowCol
    static member internal ToFCell   : cell : Cell -> Position.Cell

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPCell : rowCol : Position.RowCol -> Cell
    static member internal ToOOPCell : cell   : Position.Cell   -> Cell



and Coord =

    inherit Position

    new : unit                 -> Coord
    new : x    : int * y : int -> Coord

    member X : int with get, set
    member Y : int with get, set

    static member FromXY     : x   : int * y   : int -> Coord
    static member FromRowCol : row : int * col : int -> Coord

    static member FromCell : cell : Cell -> Coord

    static member Get    : position : string                              -> Coord
    static member TryGet : position : string * outPosition : byref<Coord> -> bool
    static member Exists : position : string                              -> bool

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string

    // Conversioni a tipi funzionali
    //   Usati internamente!
    static member internal ToFXY    : coord : Coord -> Position.XY
    static member internal ToFCoord : coord : Coord -> Position.Coord

    // Conversioni a tipi OOP
    //   Usati internamente!
    static member internal ToOOPCoord : xY    : Position.XY    -> Coord
    static member internal ToOOPCoord : coord : Position.Coord -> Coord
