(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fsi

    Title       : FORMAT
    Description : Contiene le firme dei tipi e delle funzioni
                  pubbliche del modulo Format.
                  Il modulo Format si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Il modulo Format permette di ottenere gli
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

module Format =

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

    type Format =
        | Restore                                        // RST
        | RestoreForegroundColor                         // RFGC
        | RestoreBackgroundColor                         // RBGC
        | Bold                   of flag  : bool option  // BLD
        | Faint                  of flag  : bool option  // FNT
        | Italic                 of flag  : bool option  // ITC
        | Underline              of flag  : bool option  // UND
        | Blinking               of flag  : bool option  // BKG
        | Reverse                of flag  : bool option  // RVS
        | Hidden                 of flag  : bool option  // HDN
        | Strikeout              of flag  : bool option  // SKT
        | ForegroundColor        of color : Color option // FGC
        | BackgroundColor        of color : Color option // BGC

    type Formats = Format list

    val defaultFormats : Formats // Formats di default



    (*
        Modalità manuale
        ================

        La modalità manuale contiene funzioni che, dati
        i parametri richiesti, restituiscono la stringa
        VTS corrispondente con la formattazione richiesta.

        Sarà compito tuo inviare la stringa ottenuta sullo
        stream di output del terminale.

        render      -> Data un Format, restituisce la stringa
                       VTS associata.
        renders     -> Data una lista di Format, restituisce
                       la stringa VTS associata.
        renderReset -> Restituisce la stringa che resetta
                       il comportamento del modulo Format.

        Le funzioni di questa sezione sono tutte chiamate
        render<FORMAT>.

        IMPORTANTE: Per fare la composizione di una lista,f
                    USARE SEMPRE E COMUNQUE "init" o
                    "initWith"!
                    Creare la lista manualmente potrebbe
                    comportare errori nell'ordine di
                    composizione.
    *)

    val render  : text : string -> format  : Format  -> string
    val renders : text : string -> formats : Formats -> string

    val renderRestore : text : string -> string

    val renderRestoreForegroundColor : text : string -> string
    val renderRestoreBackgroundColor : text : string -> string

    val renderBold      : text : string -> flag : bool option -> string
    val renderFaint     : text : string -> flag : bool option -> string
    val renderItalic    : text : string -> flag : bool option -> string
    val renderUnderline : text : string -> flag : bool option -> string
    val renderBlinking  : text : string -> flag : bool option -> string
    val renderReverse   : text : string -> flag : bool option -> string
    val renderHidden    : text : string -> flag : bool option -> string
    val renderStrikeout : text : string -> flag : bool option -> string

    val renderForegroundColor : text : string -> color : Color option -> string
    val renderBackgroundColor : text : string -> color : Color option -> string

    val renderReset : text : string -> string



    (*
        Modalità funzionale
        ===================

        La modalità funzionale utilizza un flow basato su
        pipeline per impostare la configurazione VTS composta.
        Tutti gli effetti collaterali sono gestiti!

        init       -> Inizializza una pipeline vuota.
        initWith   -> Inizializza una pipeline a partire da
                      una lista di Format.
        trunk      -> Rimuove le Format “di troppo”.
                      Se la stessa Format è presente più volte,
                      viene MANTENUTA solo l'ultima iterazione
                      (che sarebbe poi quella realmente applicata).
        clear      -> Svuota la pipeline.
        view       -> Visualizza la pipeline.
        preview    -> Visualizza la pipeline EFFETTIVAMENTE
                      applicata al terminale (trunk + view).

        apply           -> Applica una Format al terminale.
        applyNewLine    -> Applica una Format al terminale e
                           scrive un carattere di NewLine.
        applyAll        -> Applica una lista di Format al
                           terminale.
        applyAllNewLine -> Applica una lista di Format al
                           terminale e scrive un carattere
                           di NewLine.

        reset -> Applica la lista di Format che resetta
                 il comportamento del modulo Format.

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

    val init     : unit              -> Formats
    val initWith : formats : Formats -> Formats

    val trunk : formats : Formats -> Formats
    val clear : formats : Formats -> Formats

    val view    : formats : Formats -> Formats
    val preview : formats : Formats -> Formats

    val restore : formats : Formats -> Formats

    val restoreForegroundColor : formats : Formats -> Formats
    val restoreBackgroundColor : formats : Formats -> Formats

    val bold      : flag : bool option -> formats : Formats -> Formats
    val faint     : flag : bool option -> formats : Formats -> Formats
    val italic    : flag : bool option -> formats : Formats -> Formats
    val underline : flag : bool option -> formats : Formats -> Formats
    val blinking  : flag : bool option -> formats : Formats -> Formats
    val reverse   : flag : bool option -> formats : Formats -> Formats
    val hidden    : flag : bool option -> formats : Formats -> Formats
    val strikeout : flag : bool option -> formats : Formats -> Formats

    val foregroundColor : color : Color option -> formats : Formats -> Formats
    val backgroundColor : color : Color option -> formats : Formats -> Formats

    val apply           : text : string -> format  : Format  -> unit
    val applyNewLine    : text : string -> format  : Format  -> unit
    val applyAll        : text : string -> formats : Formats -> unit
    val applyAllNewLine : text : string -> formats : Formats -> unit

    val reset : text : string -> unit

    val configure        : text : string -> config : (Formats -> Formats) -> unit
    val configureNewLine : text : string -> config : (Formats -> Formats) -> unit



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
            formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Combine :
            format : (Formats -> Formats) * formatFunction : (Formats -> Formats) ->
            (Formats -> Formats)

        member Delay :
            ``function`` : (unit -> (Formats -> Formats)) ->
            (Formats -> Formats)

        member Run :
            formatsFunction : (Formats -> Formats) ->
            Formats



    (*
        Modalità imperativa
        ===================

        Usa uno stile imperativo (solo di facciata) e
        immediato per applicare le VTS direttamente sul
        terminale. Nessuna astrazione, nessuna composizione,
        nessun abbellimento: SOLO funzioni pure che
        nascondono TUTTI gli effetti collaterali.

        doReset -> Applica la lista di Format che resetta
                   il comportamento del modulo Format.

        Le funzioni di questa sezione sono tutte chiamate
        do<FORMAT>.
    *)

    val doRestore : text : string -> unit

    val doRestoreForegroundColor : text : string -> unit
    val doRestoreBackgroundColor : text : string -> unit

    val doBold      : text : string -> flag : bool option -> unit
    val doFaint     : text : string -> flag : bool option -> unit
    val doItalic    : text : string -> flag : bool option -> unit
    val doUnderline : text : string -> flag : bool option -> unit
    val doBlinking  : text : string -> flag : bool option -> unit
    val doReverse   : text : string -> flag : bool option -> unit
    val doHidden    : text : string -> flag : bool option -> unit
    val doStrikeout : text : string -> flag : bool option -> unit

    val doForegroundColor : text : string -> color : Color option -> unit
    val doBackgroundColor : text : string -> color : Color option -> unit

    val doReset : text : string -> unit

    (*
        WOW! Sei arrivato alla fine!
        (*) -> Biscotto TRISTE per te <3
        Lo so non sembra un biscotto...

        Mi fa ridere che metà di sto file so commenti.
    *)
