(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Act.fsi

    Title       : ACT
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Act.
                  Il modulo Act si occupa di sequenze VTS
                  relative al viewport del terminale.

                  Fornisce gli Alias di Action.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open ColorConversion
open Position
open PositionConversion

module Act =

    open Action

    val IC : int option   -> Action
    val DC : int option   -> Action
    val IL : int option   -> Action
    val DL : int option   -> Action
    val ED : Erase option -> Action
    val EL : Erase option -> Action

    // Alias modalità manuale
    val renderIC : (int option -> string)
    val renderDC : (int option -> string)

    val renderIL : (int option -> string)
    val renderDL : (int option -> string)

    val renderED : (Erase option -> string)
    val renderEL : (Erase option -> string)

    // Alias modalità funzionale
    val initw : (Actions -> Actions)

    val ic : (int option -> Actions -> Actions)
    val dc : (int option -> Actions -> Actions)

    val il : (int option -> Actions -> Actions)
    val dl : (int option -> Actions -> Actions)

    val ed : (Erase option -> Actions -> Actions)
    val el : (Erase option -> Actions -> Actions)

    val applynl    : (Action  -> unit)
    val applyallnl : (Actions -> unit)

    val config   : ((Actions -> Actions) -> unit)
    val confignl : ((Actions -> Actions) -> unit)

    // Alias modalità DSL
    val builder : Builder

    // Alias modalità imperativa
    val doIC : (int option -> unit)
    val doDC : (int option -> unit)

    val doIL : (int option -> unit)
    val doDL : (int option -> unit)

    val doED : (Erase option -> unit)
    val doEL : (Erase option -> unit)
