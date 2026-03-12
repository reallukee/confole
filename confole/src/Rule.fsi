(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fsi

    Title       : RULE
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Rule.
                  Il modulo Rule si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Il modulo Rule permette di ottenere gli
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

module Rule =

    type Shape =
        | User
        | BlinkingBlock
        | SteadyBlock
        | BlinkingUnderline
        | SteadyUnderline
        | BlinkingBar
        | SteadyBar

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

    type Rule =
        | Title                    of title : string       // TTL
        | ShowCursorBlinking                               // SCB
        | HideCursorBlinking                               // HCB
        | ShowCursor                                       // SC
        | HideCursor                                       // HC
        | EnableDesignateMode                              // EDM
        | DisableDesignateMode                             // DDM
        | EnableAlternativeBuffer                          // EAB
        | DisableAlternativeBuffer                         // DAB
        | CursorShape              of shape : Shape option // CS
        | DefaultForegroundColor   of color : Color option // DFGC
        | DefaultBackgroundColor   of color : Color option // DBGC
        | DefaultCursorColor       of color : Color option // DCC

    type Rules = Rule list

    val defaultRules : Rules // Rules di default



    (*
        Modalità manuale
        ================

        La modalità manuale contiene funzioni che, dati
        i parametri richiesti, restituiscono la stringa
        VTS corrispondente con la formattazione richiesta.

        Sarà compito tuo inviare la stringa ottenuta sullo
        stream di output del terminale.

        render      -> Data un Rule, restituisce la stringa
                       VTS associata.
        renders     -> Data una lista di Rule, restituisce
                       la stringa VTS associata.
        renderReset -> Restituisce la stringa che resetta
                       il comportamento del modulo Rule.

        Le funzioni di questa sezione sono tutte chiamate
        render<RULE>.

        IMPORTANTE: Per fare la composizione di una lista,f
                    USARE SEMPRE E COMUNQUE "init" o
                    "initWith"!
                    Creare la lista manualmente potrebbe
                    comportare errori nell'ordine di
                    composizione.
    *)

    val render  : rule  : Rule  -> string
    val renders : rules : Rules -> string

    val renderTitle : title : string -> string

    val renderShowCursorBlinking : unit -> string
    val renderHideCursorBlinking : unit -> string

    val renderShowCursor : unit -> string
    val renderHideCursor : unit -> string

    val renderEnableDesignateMode  : unit -> string
    val renderDisableDesignateMode : unit -> string

    val renderEnableAlternativeBuffer  : unit -> string
    val renderDisableAlternativeBuffer : unit -> string

    val renderCursorShape : shape : Shape option -> string

    val renderDefaultForegroundColor : color : Color option -> string
    val renderDefaultBackgroundColor : color : Color option -> string
    val renderDefaultCursorColor     : color : Color option -> string

    val renderReset : unit -> string



    (*
        Modalità funzionale
        ===================

        La modalità funzionale utilizza un flow basato su
        pipeline per impostare la configurazione VTS composta.
        Tutti gli effetti collaterali sono gestiti!

        init       -> Inizializza una pipeline vuota.
        initWith   -> Inizializza una pipeline a partire da
                      una lista di Rule.
        trunk      -> Rimuove le Rule “di troppo”.
                      Se la stessa Rule è presente più volte,
                      viene MANTENUTA solo l'ultima iterazione
                      (che sarebbe poi quella realmente applicata).
        clear      -> Svuota la pipeline.
        view       -> Visualizza la pipeline.
        preview    -> Visualizza la pipeline EFFETTIVAMENTE
                      applicata al terminale (trunk + view).

        apply           -> Applica una Rule al terminale.
        applyNewLine    -> Applica una Rule al terminale e
                           scrive un carattere di NewLine.
        applyAll        -> Applica una lista di Rule al
                           terminale.
        applyAllNewLine -> Applica una lista di Rule al
                           terminale e scrive un carattere
                           di NewLine.

        reset -> Applica la lista di Rule che resetta
                 il comportamento del modulo Rule.

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

    val init     : unit          -> Rules
    val initWith : rules : Rules -> Rules

    val trunk : rules : Rules -> Rules
    val clear : rules : Rules -> Rules

    val view    : rules : Rules -> Rules
    val preview : rules : Rules -> Rules

    val title : title : string -> rules : Rules -> Rules

    val showCursorBlinking : rules : Rules -> Rules
    val hideCursorBlinking : rules : Rules -> Rules

    val showCursor : rules : Rules -> Rules
    val hideCursor : rules : Rules -> Rules

    val enableDesignateMode  : rules : Rules -> Rules
    val disableDesignateMode : rules : Rules -> Rules

    val enableAlternativeBuffer  : rules : Rules -> Rules
    val disableAlternativeBuffer : rules : Rules -> Rules

    val cursorShape : shape : Shape option -> rules : Rules -> Rules

    val defaultForegroundColor : color : Color option -> rules : Rules -> Rules
    val defaultBackgroundColor : color : Color option -> rules : Rules -> Rules
    val defaultCursorColor     : color : Color option -> rules : Rules -> Rules

    val apply           : rule  : Rule  -> unit
    val applyNewLine    : rule  : Rule  -> unit
    val applyAll        : rules : Rules -> unit
    val applyAllNewLine : rules : Rules -> unit

    val reset : unit -> unit

    val configure        : config : (Rules -> Rules) -> unit
    val configureNewLine : config : (Rules -> Rules) -> unit



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
            ruleFunction : (Rules -> Rules) ->
            (Rules -> Rules)

        member Combine :
            rule : (Rules -> Rules) * ruleFunction : (Rules -> Rules) ->
            (Rules -> Rules)

        member Delay :
            ``function`` : (unit -> (Rules -> Rules)) ->
            (Rules -> Rules)

        member Run :
            rulesFunction : (Rules -> Rules) ->
            Rules



    (*
        Modalità imperativa
        ===================

        Usa uno stile imperativo (solo di facciata) e
        immediato per applicare le VTS direttamente sul
        terminale. Nessuna astrazione, nessuna composizione,
        nessun abbellimento: SOLO funzioni pure che
        nascondono TUTTI gli effetti collaterali.

        doReset -> Applica la lista di Rule che resetta
                   il comportamento del modulo Rule.

        Le funzioni di questa sezione sono tutte chiamate
        do<RULE>.
    *)

    val doTitle : title : string -> unit

    val doShowCursorBlinking : unit -> unit
    val doHideCursorBlinking : unit -> unit

    val doShowCursor : unit -> unit
    val doHideCursor : unit -> unit

    val doEnableDesignateMode  : unit -> unit
    val doDisableDesignateMode : unit -> unit

    val doEnableAlternativeBuffer  : unit -> unit
    val doDisableAlternativeBuffer : unit -> unit

    val doCursorShape : shape : Shape option -> unit

    val doDefaultForegroundColor : color : Color option -> unit
    val doDefaultBackgroundColor : color : Color option -> unit
    val doDefaultCursorColor     : color : Color option -> unit

    val doReset : unit -> unit

    (*
        WOW! Sei arrivato alla fine!
        (*) -> Biscotto TRISTE per te <3
        Lo so non sembra un biscotto...

        Mi fa ridere che metà di sto file so commenti.
    *)
