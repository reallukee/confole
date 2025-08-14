(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Position.fsi

    Title       : POSITION
    Description : Position

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

[<AbstractClass>]
type Position = class end

type Cell =
    inherit Position

    new : unit -> Cell
    new : int * int -> Cell

    member Col : int with get, set
    member Row : int with get, set

    override Equals      : obj  -> bool
    override GetHashCode : unit -> int
    override ToString    : unit -> string
