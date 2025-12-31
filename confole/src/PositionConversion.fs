(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : PositionConversion.fs

    Title       : POSITION CONVERSION
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo
                  PositionConversion.
                  Questo modulo parla da solo! Dai si
                  capisce cosa fa!!!
                  MIAO! MIAO! MIAO!

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module PositionConversion =

    open System

    open Position

    (*
        ----------
        IMPORTANTE
        ----------

        Ecco a te, umile viaggiatore del Web, che per qualche
        oscuro motivo sei finito nel mio repository.

        Questi sono messaggi per me, ma anche per te, forse?

        L'attuale implementazione di questo modulo presenta
        delle criticità NOTE.

        1) Filosofia Imperativa.
           Confole, all'interno di Reallukee.Confole, cerca,
           per quanto possibile, di applicare un'implementazione
           functional-first. Tutto questo però senza sacrificare
           versatilità ed efficienza sintattica.

           Terminato il pippone filosofico. Questo modulo
           FUNZIONA (a quanto pare, il test xUnit non è
           ancora ultimato), MAAA, e dico MAAA, bisognerebbe
           rivedere sia la firma che l'implementazione delle
           funzioni, cercando qualcosa di più IDIOMATICO.
           Bella parola, vero?

        2) Assenza di controlli.
           Sì, mancano i controlli.
           Fine. Collegandosi al punto 1), bisognerebbe
           gestire al meglio questa componente. Metodi 'tryGet'
           e 'get'? Eccezioni? Eccezioni custom?
           Insomma, da vedere.

        Si dà per scontato che TU, sì, dico proprio TU,
        o anche IO in realtà, usi l'API non fornendo casi limite.

        VERIFICARE IL CORRETTO FUNZIONAMENTO DELL'API!

        L'autore pigro di codesta libreria.
    *)

    let colRowToXY (colRow : ColRow) =
        let col, row = colRow

        let x = col
        let y = row

        x, y

    let xYToColRow (xY : XY) =
        let x, y = xY

        let col = x
        let row = y

        col, row

    let cellToCoord cell =
        let col, row = cellToColRow cell

        let x = col
        let y = row

        {
            x = x
            y = y
        }

    let coordToCell coord =
        let x, y = coordToXY coord

        let col = x
        let row = y

        {
            col = col
            row = row
        }
