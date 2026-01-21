(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rul.fs

    Title       : RUL
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Rul.
                  Il modulo Rul si occupa di sequenze VTS
                  relative all'apparenza del terminale.

                  Fornisce gli Alias di Rule.

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

module Rul =

    open Rule

    let TTL  title = Title                    title
    let SCB        = ShowCursorBlinking
    let HCB        = HideCursorBlinking
    let SC         = ShowCursor
    let HC         = HideCursor
    let EDM        = EnableDesignateMode
    let DDM        = DisableDesignateMode
    let EAB        = EnableAlternativeBuffer
    let DAB        = DisableAlternativeBuffer
    let CS   shape = CursorShape              shape
    let DFGC color = DefaultForegroundColor   color
    let DBGC color = DefaultBackgroundColor   color
    let DCC  color = DefaultCursorColor       color

    // Alias modalità manuale
    let renderTTL = renderTitle

    let renderSCB = renderShowCursorBlinking
    let renderHCB = renderHideCursorBlinking

    let renderSC = renderShowCursor
    let renderHC = renderHideCursor

    let renderEDM = renderEnableDesignateMode
    let renderDDM = renderDisableDesignateMode

    let renderEAB = renderEnableAlternativeBuffer
    let renderDAB = renderDisableAlternativeBuffer

    let renderCS = renderCursorShape

    let renderDFGC = renderDefaultForegroundColor
    let renderDBGC = renderDefaultBackgroundColor
    let renderDCC  = renderDefaultCursorColor

    // Alias modalità funzionale
    let initw = initWith

    let ttl = title

    let scb = showCursorBlinking
    let hcb = hideCursorBlinking

    let sc = showCursor
    let hc = hideCursor

    let edm = enableDesignateMode
    let ddm = disableDesignateMode

    let eab = enableAlternativeBuffer
    let dab = disableAlternativeBuffer

    let cs = cursorShape

    let dfgc = defaultForegroundColor
    let dbgc = defaultBackgroundColor
    let dcc  = defaultCursorColor

    let applynl    = applyNewLine
    let applyallnl = applyAllNewLine

    let config   = configure
    let confignl = configureNewLine

    // Alias modalità DSL
    let builder = Builder ()

    // Alias modalità imperativa
    let doTTL = doTitle

    let doSCB = doShowCursorBlinking
    let doHCB = doHideCursorBlinking

    let doSC = doShowCursor
    let doHC = doHideCursor

    let doEDM = doEnableDesignateMode
    let doDDM = doDisableDesignateMode

    let doEAB = doEnableAlternativeBuffer
    let doDAB = doDisableAlternativeBuffer

    let doCS = doCursorShape

    let doDFGC = doDefaultForegroundColor
    let doDBGC = doDefaultBackgroundColor
    let doDCC  = doDefaultCursorColor
