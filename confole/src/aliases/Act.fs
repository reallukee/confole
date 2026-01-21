(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Act.fs

    Title       : ACT
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Act.
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

    let IC n     = InsertCharacter n
    let DC n     = DeleteCharacter n
    let IL n     = InsertLine      n
    let DL n     = DeleteLine      n
    let ED erase = EraseDisplay    erase
    let EL erase = EraseLine       erase

    // Alias modalità manuale
    let renderIC = renderInsertCharacter
    let renderDC = renderDeleteCharacter

    let renderIL = renderInsertLine
    let renderDL = renderDeleteLine

    let renderED = renderEraseDisplay
    let renderEL = renderEraseLine

    // Alias modalità funzionale
    let initw = initWith

    let ic = insertCharacter
    let dc = deleteCharacter

    let il = insertLine
    let dl = deleteLine

    let ed = eraseDisplay
    let el = eraseLine

    let applynl    = applyNewLine
    let applyallnl = applyAllNewLine

    let config   = configure
    let confignl = configureNewLine

    // Alias modalità DSL
    let builder = Builder ()

    // Alias modalità imperativa
    let doIC = doInsertCharacter
    let doDC = doDeleteCharacter

    let doIL = doInsertLine
    let doDL = doDeleteLine

    let doED = doEraseDisplay
    let doEL = doEraseLine
