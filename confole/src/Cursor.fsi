(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fsi

    Title       : CURSOR
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Il modulo Cursor permette di ottenere gli
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

module Cursor =

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

    type Cursor =
        | Reverse                                    // RVS
        | Save                                       // SV
        | Restore                                    // RST
        | Up           of n        : int option      // U
        | Down         of n        : int option      // D
        | Next         of n        : int option      // NX
        | Previous     of n        : int option      // PV
        | NextLine     of n        : int option      // NXL
        | PreviousLine of n        : int option      // PVL
        | Move         of position : Position option // MV

    type Cursors = Cursor list

    val defaultCursors : Cursors // Cursors di default



    (*
        Modalità manuale
        ================

        La modalità manuale contiene funzioni che, dati
        i parametri richiesti, restituiscono la stringa
        VTS corrispondente con la formattazione richiesta.

        Sarà compito tuo inviare la stringa ottenuta sullo
        stream di output del terminale.

        render      -> Data un Cursor, restituisce la stringa
                       VTS associata.
        renders     -> Data una lista di Cursor, restituisce
                       la stringa VTS associata.
        renderReset -> Restituisce la stringa che resetta
                       il comportamento del modulo Cursor.

        Le funzioni di questa sezione sono tutte chiamate
        render<CURSOR>.

        IMPORTANTE: Per fare la composizione di una lista,
                    USARE SEMPRE E COMUNQUE "init" o
                    "initWith"!
                    Creare la lista manualmente potrebbe
                    comportare errori nell'ordine di
                    composizione.
    *)

    val render  : cursor  : Cursor  -> string
    val renders : cursors : Cursors -> string

    val renderReverse : unit -> string
    val renderSave    : unit -> string
    val renderRestore : unit -> string

    val renderUp       : n : int option -> string
    val renderDown     : n : int option -> string
    val renderNext     : n : int option -> string
    val renderPrevious : n : int option -> string

    val renderNextLine     : n : int option -> string
    val renderPreviousLine : n : int option -> string

    val renderMove : position : Position option -> string

    val renderReset : unit -> string



    (*
        Modalità funzionale
        ===================

        La modalità funzionale utilizza un flow basato su
        pipeline per impostare la configurazione VTS composta.
        Tutti gli effetti collaterali sono gestiti!

        init       -> Inizializza una pipeline vuota.
        initWith   -> Inizializza una pipeline a partire da
                      una lista di Cursor.
        trunk      -> Rimuove le Cursor “di troppo”.
                      Se la stessa Cursor è presente più volte,
                      viene MANTENUTA solo l'ultima iterazione
                      (che sarebbe poi quella realmente applicata).
        clear      -> Svuota la pipeline.
        view       -> Visualizza la pipeline.
        preview    -> Visualizza la pipeline EFFETTIVAMENTE
                      applicata al terminale (trunk + view).

        apply           -> Applica una Cursor al terminale.
        applyNewLine    -> Applica una Cursor al terminale e
                           scrive un carattere di NewLine.
        applyAll        -> Applica una lista di Cursor al
                           terminale.
        applyAllNewLine -> Applica una lista di Cursor al
                           terminale e scrive un carattere
                           di NewLine.

        reset -> Applica la lista di Cursor che resetta
                 il comportamento del modulo Cursor.

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

    val init     : unit              -> Cursors
    val initWith : cursors : Cursors -> Cursors

    val trunk : cursors : Cursors -> Cursors
    val clear : cursors : Cursors -> Cursors

    val view    : cursors : Cursors -> Cursors
    val preview : cursors : Cursors -> Cursors

    val reverse : cursors : Cursors -> Cursors
    val save    : cursors : Cursors -> Cursors
    val restore : cursors : Cursors -> Cursors

    val up       : n : int option -> cursors : Cursors -> Cursors
    val down     : n : int option -> cursors : Cursors -> Cursors
    val next     : n : int option -> cursors : Cursors -> Cursors
    val previous : n : int option -> cursors : Cursors -> Cursors

    val nextLine     : n : int option -> cursors : Cursors -> Cursors
    val previousLine : n : int option -> cursors : Cursors -> Cursors

    val move : position : Position option -> cursors : Cursors -> Cursors

    val apply           : cursor  : Cursor  -> unit
    val applyNewLine    : cursor  : Cursor  -> unit
    val applyAll        : cursors : Cursors -> unit
    val applyAllNewLine : cursors : Cursors -> unit

    val reset : unit -> unit

    val configure        : config : (Cursors -> Cursors) -> unit
    val configureNewLine : config : (Cursors -> Cursors) -> unit



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
            cursorFunction : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Combine :
            cursor : (Cursors -> Cursors) * cursorFunction : (Cursors -> Cursors) ->
            (Cursors -> Cursors)

        member Delay :
            ``function`` : (unit -> (Cursors -> Cursors)) ->
            (Cursors -> Cursors)

        member Run :
            cursorsFunction : (Cursors -> Cursors) ->
            Cursors



    (*
        Modalità imperativa
        ===================

        Usa uno stile imperativo (solo di facciata) e
        immediato per applicare le VTS direttamente sul
        terminale. Nessuna astrazione, nessuna composizione,
        nessun abbellimento: SOLO funzioni pure che
        nascondono TUTTI gli effetti collaterali.

        doReset -> Applica la lista di Cursor che resetta
                   il comportamento del modulo Cursor.

        Le funzioni di questa sezione sono tutte chiamate
        do<CURSOR>.
    *)

    val doReverse : unit -> unit
    val doSave    : unit -> unit
    val doRestore : unit -> unit

    val doUp       : n : int option -> unit
    val doDown     : n : int option -> unit
    val doNext     : n : int option -> unit
    val doPrevious : n : int option -> unit

    val doNextLine     : n : int option -> unit
    val doPreviousLine : n : int option -> unit

    val doMove : position : Position option -> unit

    val doReset : unit -> unit

    (*
        WOW! Sei arrivato alla fine!
        (*) -> Biscotto TRISTE per te <3
        Lo so non sembra un biscotto...

        Mi fa ridere che metà di sto file so commenti.
    *)
