(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Action.fsi

    Title       : ACTION
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Action.
                  Il modulo Action si occupa di sequenze VTS
                  relative al viewport del terminale.

                  Il modulo Action permette di ottenere gli
                  stessi risultati con 4 approcci diversi:

                  * Manuale
                  * Funzionale
                  * Imperativo
                  * DSL

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

// Act
module Action =

    type Erase =
        | FromCurrentToEnd
        | FromBeginToCurrent
        | FromBeginToEnd

    (*
        Le VTS presenti in questo modulo sono state tratte dalla
        guida di Microsoft sull'uso dell'API della console.

        Puoi consultare la documentazione sopra citata qui:

        https://learn.microsoft.com/windows/console/console-virtual-terminal-sequences

        NOTA BENE: L'implementazione sottostante si prende delle
                   "libertà creative" per adattarsi alle scelte
                   progettuali di Confole. Questo si traduce, tra
                   le altre cose, in naming e valori di default
                   personalizzati!

        NOTE BENE: Purtroppo a causa della mia infinita svogliatezza
                   non ho ancora scritto la documentazione in-code.
                   Punto quindi sul fatto che l'API sia così costruita
                   bene da parlare da sé!

                   Buon divertimento \(._.)/ <333!
    *)

    type Action =
        | InsertCharacter of n    : int option   // IC
        | DeleteCharacter of n    : int option   // DC
        | InsertLine      of n    : int option   // IL
        | DeleteLine      of n    : int option   // DL
        | EraseDisplay    of mode : Erase option // ED
        | EraseLine       of mode : Erase option // EL

    val IC : int option   -> Action
    val DC : int option   -> Action
    val IL : int option   -> Action
    val DL : int option   -> Action
    val ED : Erase option -> Action
    val EL : Erase option -> Action

    type Actions = Action list

    val defaultActions : Actions



    // Modalità manuale
    val render  : action  : Action  -> string
    val renders : actions : Actions -> string

    val renderInsertCharacter : n : int option -> string
    val renderDeleteCharacter : n : int option -> string

    val renderInsertLine : n : int option -> string
    val renderDeleteLine : n : int option -> string

    val renderEraseDisplay : erase : Erase option -> string
    val renderEraseLine    : erase : Erase option -> string

    val renderReset : unit -> string

    // Alias modalità manuale
    val renderIC : (int option -> string)
    val renderDC : (int option -> string)

    val renderIL : (int option -> string)
    val renderDL : (int option -> string)

    val renderED : (Erase option -> string)
    val renderEL : (Erase option -> string)



    // Modalità funzionale
    val init  : unit              -> Actions
    val initp : actions : Actions -> Actions
    val clear : actions : Actions -> Actions
    val view  : actions : Actions -> Actions

    val insertCharacter : n : int option -> actions : Actions -> Actions
    val deleteCharacter : n : int option -> actions : Actions -> Actions

    val insertLine : n : int option -> actions : Actions -> Actions
    val deleteLine : n : int option -> actions : Actions -> Actions

    val eraseDisplay : erase : Erase option -> actions : Actions -> Actions
    val eraseLine    : erase : Erase option -> actions : Actions -> Actions

    val apply           : action  : Action  -> unit
    val applyNewLine    : action  : Action  -> unit
    val applyAll        : actions : Actions -> unit
    val applyAllNewLine : actions : Actions -> unit

    val reset : unit -> unit

    val configure        : config : (Actions -> Actions) -> unit
    val configureNewLine : config : (Actions -> Actions) -> unit

    // Alias modalità funzionale
    val ic : (int option -> Actions -> Actions)
    val dc : (int option -> Actions -> Actions)

    val il : (int option -> Actions -> Actions)
    val dl : (int option -> Actions -> Actions)

    val ed : (Erase option -> Actions -> Actions)
    val el : (Erase option -> Actions -> Actions)



    // Modalità DSL
    type Builder =
        new : unit -> Builder

        member Yield :
            actionFunction : (Actions -> Actions) ->
            (Actions -> Actions)

        member Combine :
            action : (Actions -> Actions) * actionFunction : (Actions -> Actions) ->
            (Actions -> Actions)

        member Delay :
            ``function`` : (unit -> (Actions -> Actions)) ->
            (Actions -> Actions)

        member Run :
            actionsFunction : (Actions -> Actions) ->
            Actions

    // Alias modalità DSL
    val builder : Builder



    // Modalità imperativa
    val doInsertCharacter : n : int option -> unit
    val doDeleteCharacter : n : int option -> unit

    val doInsertLine : n : int option -> unit
    val doDeleteLine : n : int option -> unit

    val doEraseDisplay : erase : Erase option -> unit
    val doEraseLine    : erase : Erase option -> unit

    val doReset : unit -> unit

    // Alias modalità imperativa
    val doIC : (int option -> unit)
    val doDC : (int option -> unit)

    val doIL : (int option -> unit)
    val doDL : (int option -> unit)

    val doED : (Erase option -> unit)
    val doEL : (Erase option -> unit)
