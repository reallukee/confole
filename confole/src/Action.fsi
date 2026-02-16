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

open Microsoft.FSharp.Reflection

open Color
open ColorConversion
open Position
open PositionConversion

module Action =

    type Erase =
        | FromCurrentToEnd
        | FromBeginToCurrent
        | FromBeginToEnd

    (*
        DICHIARAZIONE DI INTENTI
        ========================

        *** LEGGERE BENE!!! ***

        Le VTS presenti in questo modulo sono state tratte dalla
        guida di Microsoft sull'uso dell'API della console.

        Confole è, per scelta progettuale, STATELESS. Confole
        NON SA (e non vuole sapere) cosa è attivo. Sono pochi
        gli emulatori di terminale che prevedono sequenze VTS
        in grado di restituire lo stato attuale della
        configurazione VTS.

        Mantenere uno stato interno rischierebbe solo di
        alimentare una discrepanza tra ciò che è e ciò
        che “dovrebbe essere”.

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

        NOTA BENE: Il funzionamento delle VTS DIPENDE TOTALMENTE
                   dall'emulatore di terminale in uso.
                   Verifica che il tuo terminale supporti le VTS
                   utilizzate prima di dare la colpa a Confole.
                   In caso di malfunzionamenti cambiare emulatore
                   di terminale o usare il modulo ConsoleEx
                   (attualmente sperimentale, non so se sarà mai
                   stabile LoL).

                   Buon divertimento \(._.)/ <333!
    *)

    type Action =
        | InsertCharacter of n    : int option   // IC
        | DeleteCharacter of n    : int option   // DC
        | InsertLine      of n    : int option   // IL
        | DeleteLine      of n    : int option   // DL
        | EraseDisplay    of mode : Erase option // ED
        | EraseLine       of mode : Erase option // EL

    type Actions = Action list

    val defaultActions : Actions // Actions di default



    (*
        Modalità manuale
        ================

        La modalità manuale contiene funzioni che, dati
        i parametri richiesti, restituiscono la stringa
        VTS corrispondente con la formattazione richiesta.

        Sarà compito tuo inviare la stringa ottenuta sullo
        stream di output del terminale.

        render      -> Data un Action, restituisce la stringa
                       VTS associata.
        renders     -> Data una lista di Action, restituisce
                       la stringa VTS associata.
        renderReset -> Restituisce la stringa che resetta
                       il comportamento del modulo Action.

        Le funzioni di questa sezione sono tutte chiamate
        render<ACTION>.

        IMPORTANTE: Per fare la composizione di una lista,f
                    USARE SEMPRE E COMUNQUE "init" o
                    "initWith"!
                    Creare la lista manualmente potrebbe
                    comportare errori nell'ordine di
                    composizione.
    *)

    val render  : action  : Action  -> string
    val renders : actions : Actions -> string

    val renderInsertCharacter : n : int option -> string
    val renderDeleteCharacter : n : int option -> string

    val renderInsertLine : n : int option -> string
    val renderDeleteLine : n : int option -> string

    val renderEraseDisplay : erase : Erase option -> string
    val renderEraseLine    : erase : Erase option -> string

    val renderReset : unit -> string



    (*
        Modalità funzionale
        ===================

        La modalità funzionale utilizza un flow basato su
        pipeline per impostare la configurazione VTS composta.
        Tutti gli effetti collaterali sono gestiti!

        init       -> Inizializza una pipeline vuota.
        initWith   -> Inizializza una pipeline a partire da
                      una lista di Action.
        trunk      -> Rimuove le Action “di troppo”.
                      Se la stessa Action è presente più volte,
                      viene MANTENUTA solo l'ultima iterazione
                      (che sarebbe poi quella realmente applicata).
        clear      -> Svuota la pipeline.
        view       -> Visualizza la pipeline.
        preview    -> Visualizza la pipeline EFFETTIVAMENTE
                      applicata al terminale (trunk + view).

        apply           -> Applica una Action al terminale.
        applyNewLine    -> Applica una Action al terminale e
                           scrive un carattere di NewLine.
        applyAll        -> Applica una lista di Action al
                           terminale.
        applyAllNewLine -> Applica una lista di Action al
                           terminale e scrive un carattere
                           di NewLine.

        reset -> Applica la lista di Action che resetta
                 il comportamento del modulo Action.

        configure        -> Combina Pipeline e DSL.
        configureNewLine -> Combina Pipeline e DSL e scrive
                            un carattere di NewLine.

        Tratti distintivi: Non esiste un naming system
                           per questa modalità. Se non ha
                           un prefisso è funzionale.

        IMPORTANTE: Per fare la composizione di una lista,
                    USARE SEMPRE E COMUNQUE "init" o
                    "initWith"!
                    Creare la lista manualmente potrebbe
                    comportare errori nell'ordine di
                    composizione.
    *)

    val init     : unit              -> Actions
    val initWith : actions : Actions -> Actions

    val trunk : actions : Actions -> Actions
    val clear : actions : Actions -> Actions

    val view    : actions : Actions -> Actions
    val preview : actions : Actions -> Actions

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



    (*
        Modalità DSL
        ============

        Usa un DSL per applicare la configurazione VTS al
        terminale. Poco altro da aggiungere.
        Cercati come funzionano i DSL in F#, io non te li
        spiegherò di certo.

        Marameo.
    *)

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



    (*
        Modalità imperativa
        ===================

        Usa uno stile imperativo (solo di facciata) e
        immediato per applicare le VTS direttamente sul
        terminale. Nessuna astrazione, nessuna composizione,
        nessun abbellimento: SOLO funzioni pure che
        nascondono TUTTI gli effetti collaterali.

        doReset -> Applica la lista di Action che resetta
                   il comportamento del modulo Action.

        Le funzioni di questa sezione sono tutte chiamate
        do<ACTION>.
    *)

    val doInsertCharacter : n : int option -> unit
    val doDeleteCharacter : n : int option -> unit

    val doInsertLine : n : int option -> unit
    val doDeleteLine : n : int option -> unit

    val doEraseDisplay : erase : Erase option -> unit
    val doEraseLine    : erase : Erase option -> unit

    val doReset : unit -> unit

    (*
        WOW! Sei arrivato alla fine!
        (*) -> Biscotto TRISTE per te <3
        Lo so non sembra un biscotto...

        Mi fa ridere che metà di sto file so commenti.
    *)
