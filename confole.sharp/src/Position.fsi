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
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

[<AbstractClass>]
type Position = class end

type Cell =
    inherit Position

    new : unit                   -> Cell
    new : col  : int * row : int -> Cell

    member Col : int with get, set
    member Row : int with get, set

    static member fromColRow : col : int * row : int -> Cell

    override Equals      : obj  : obj -> bool
    override GetHashCode : unit       -> int
    override ToString    : unit       -> string
