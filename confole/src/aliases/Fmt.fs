(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Fmt.fs

    Title       : FMT
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Fmt.
                  Il modulo Fmt si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Fornisce gli Alias di Format.

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

module Fmt =

    open Format

    let RST        = Restore
    let RFGC       = RestoreForegroundColor
    let RBGC       = RestoreBackgroundColor
    let BLD  flag  = Bold                   flag
    let FNT  flag  = Faint                  flag
    let ITC  flag  = Italic                 flag
    let UND  flag  = Underline              flag
    let BKG  flag  = Blinking               flag
    let RVS  flag  = Reverse                flag
    let HDN  flag  = Hidden                 flag
    let SKT  flag  = Strikeout              flag
    let FGC  color = ForegroundColor        color
    let BGC  color = BackgroundColor        color

    // Alias modalità manuale
    let render  = Format.render
    let renders = Format.renders

    let renderRST = renderRestore

    let renderRFGC = renderRestoreForegroundColor
    let renderRBGC = renderRestoreBackgroundColor

    let renderBLD = renderBold
    let renderFNT = renderFaint
    let renderITC = renderItalic
    let renderUND = renderUnderline
    let renderBKG = renderBlinking
    let renderRVS = renderReverse
    let renderHDN = renderHidden
    let renderSKT = renderStrikeout

    let renderFGC = renderForegroundColor
    let renderBGC = renderBackgroundColor

    let renderReset = Format.renderReset

    // Alias modalità funzionale
    let init  = Format.init
    let initw = initWith

    let trunk = Format.trunk
    let clear = Format.clear

    let view    = Format.view
    let preview = Format.preview

    let rst = restore

    let rfgc = restoreForegroundColor
    let rbgc = restoreBackgroundColor

    let bld = bold
    let fnt = faint
    let itc = italic
    let und = underline
    let bkg = blinking
    let rvs = reverse
    let hdn = hidden
    let skt = strikeout

    let fgc = foregroundColor
    let bgc = backgroundColor

    let apply      = Format.apply
    let applynl    = applyNewLine
    let applyAll   = Format.applyAll
    let applyallnl = applyAllNewLine

    let reset = Format.reset

    let config   = configure
    let confignl = configureNewLine

    // Alias modalità DSL
    let builder = Builder ()

    // Alias modalità imperativa
    let doRST = doRestore

    let doRFGC = doRestoreForegroundColor
    let doRBGC = doRestoreBackgroundColor

    let doBLD = doBold
    let doFNT = doFaint
    let doITC = doItalic
    let doUND = doUnderline
    let doBKG = doBlinking
    let doRVS = doReverse
    let doHDN = doHidden
    let doSKT = doStrikeout

    let doFGC = doForegroundColor
    let doBGC = doBackgroundColor

    let doReset = Format.doReset
