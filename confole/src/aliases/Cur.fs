(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cur.fs

    Title       : CUR
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Cur.
                  Il modulo Cur si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Fornisce gli Alias di Cursor.

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

module Cur =

    open Cursor

    let RVS          = Reverse
    let SV           = Save
    let RST          = Restore
    let U   n        = Up           n
    let D   n        = Down         n
    let NX  n        = Next         n
    let PV  n        = Previous     n
    let NXL n        = NextLine     n
    let PVL n        = PreviousLine n
    let MV  position = Move         position

    // Alias modalità manuale
    let renderRVS = renderReverse
    let renderSV  = renderSave
    let renderRST = renderRestore

    let renderU  = renderUp
    let renderD  = renderDown
    let renderNX = renderNext
    let renderPV = renderPrevious

    let renderNXL = renderNextLine
    let renderPVL = renderPreviousLine

    let renderMV = renderMove

    // Alias modalità funzionale
    let initw = initWith

    let rvs = reverse
    let sv  = save
    let rst = restore

    let u  = up
    let d  = down
    let nx = next
    let pv = previous

    let nxl = nextLine
    let pvl = previousLine

    let mv = move

    let applynl    = applyNewLine
    let applyallnl = applyAllNewLine

    let config   = configure
    let confignl = configureNewLine

    // Alias modalità DSL
    let builder = Builder ()

    // Alias modalità imperativa
    let doRVS = doReverse
    let doSV  = doSave
    let doRST = doRestore

    let doU  = doUp
    let doD  = doDown
    let doNX = doNext
    let doPV = doPrevious

    let doNXL = doNextLine
    let doPVL = doPreviousLine

    let doMV = doMove
