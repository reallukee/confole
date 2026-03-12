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

    (*
        Hei! Come va, amico?

        Questo è un modulo di ALIAS. L'idea è semplice:
        sfruttare la potenza degli alias F# per poter
        scrivere codice più corto (e anche più enigmatico).

        Gli alias F# non rendono più grande la call stack!

        Qui dentro fornisco, ove possibile, abbreviazioni,
        e nel caso non lo fosse (immagina abbreviare "init"
        con "i"?) nomi 1:1 con il modulo originale.

        Perché?

        Così puoi scrivere il tuo codice usando SOLO Act
        e non Action. Figo, vero?
        Cosa? Non è inutile!

        Gli alias (dovrebbero) parlare da sè.

        RIASSUNTO:

            ACT ~= ACTION

        Per delucidazioni sul funzionamento dell'API
        guarda il modulo Action.
    *)

    open Action

    val IC : int option   -> Action // InsertCharacter
    val DC : int option   -> Action // DeleteCharacter
    val IL : int option   -> Action // InsertLine
    val DL : int option   -> Action // DeleteLine
    val ED : Erase option -> Action // EraseDisplay
    val EL : Erase option -> Action // EraseLine



    // Alias modalità manuale
    val render  : (Action  -> string)
    val renders : (Actions -> string)

    val renderIC : (int option -> string)
    val renderDC : (int option -> string)

    val renderIL : (int option -> string)
    val renderDL : (int option -> string)

    val renderED : (Erase option -> string)
    val renderEL : (Erase option -> string)

    val renderReset : (unit -> string)



    // Alias modalità funzionale
    val init  : (unit    -> Actions)
    val initw : (Actions -> Actions)

    val trunk : (Actions -> Actions)
    val clear : (Actions -> Actions)

    val view    : (Actions -> Actions)
    val preview : (Actions -> Actions)

    val ic : (int option -> Actions -> Actions)
    val dc : (int option -> Actions -> Actions)

    val il : (int option -> Actions -> Actions)
    val dl : (int option -> Actions -> Actions)

    val ed : (Erase option -> Actions -> Actions)
    val el : (Erase option -> Actions -> Actions)

    val apply      : (Action  -> unit)
    val applynl    : (Action  -> unit)
    val applyAll   : (Actions -> unit)
    val applyallnl : (Actions -> unit)

    val reset : (unit -> unit)

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

    val doReset : (unit -> unit)
