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
    let render  = Action.render
    let renders = Action.renders

    let renderIC = renderInsertCharacter
    let renderDC = renderDeleteCharacter

    let renderIL = renderInsertLine
    let renderDL = renderDeleteLine

    let renderED = renderEraseDisplay
    let renderEL = renderEraseLine

    let renderReset = Action.renderReset

    // Alias modalità funzionale
    let init  = Action.init
    let initw = initWith

    let trunk = Action.trunk
    let clear = Action.clear

    let view    = Action.view
    let preview = Action.preview

    let ic = insertCharacter
    let dc = deleteCharacter

    let il = insertLine
    let dl = deleteLine

    let ed = eraseDisplay
    let el = eraseLine

    let apply      = Action.apply
    let applynl    = applyNewLine
    let applyAll   = Action.applyAll
    let applyallnl = applyAllNewLine

    let reset = Action.reset

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

    let doReset = Action.doReset
