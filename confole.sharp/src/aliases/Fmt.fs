(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Fmt.fs

    Title       : FMT
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Fmt.
                  Il modulo Fmt si occupa di sequenze VTS
                  relative alla formattazione del terminale.

                  Fornisce gli Alias di Format.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open System
open System.Collections
open System.Collections.Generic

open Reallukee.Confole

[<Class>]
type Fmt internal () =

    inherit Formats ()

    // Alias modalità manuale
    static member RenderRST text = Formats.RenderRestore text

    static member RenderRFGC text = Formats.RenderRestoreForegroundColor text
    static member RenderRBGC text = Formats.RenderRestoreBackgroundColor text

    static member RenderBLD text         = Formats.RenderBold      text
    static member RenderBLD (text, flag) = Formats.RenderBold      (text, flag)
    static member RenderFNT text         = Formats.RenderFaint     text
    static member RenderFNT (text, flag) = Formats.RenderFaint     (text, flag)
    static member RenderITC text         = Formats.RenderItalic    text
    static member RenderITC (text, flag) = Formats.RenderItalic    (text, flag)
    static member RenderUND text         = Formats.RenderUnderline text
    static member RenderUND (text, flag) = Formats.RenderUnderline (text, flag)
    static member RenderBKG text         = Formats.RenderBlinking  text
    static member RenderBKG (text, flag) = Formats.RenderBlinking  (text, flag)
    static member RenderRVS text         = Formats.RenderReverse   text
    static member RenderRVS (text, flag) = Formats.RenderReverse   (text, flag)
    static member RenderHDN text         = Formats.RenderHidden    text
    static member RenderHDN (text, flag) = Formats.RenderHidden    (text, flag)
    static member RenderSKT text         = Formats.RenderStrikeout text
    static member RenderSKT (text, flag) = Formats.RenderStrikeout (text, flag)

    static member RenderFGC text          = Formats.RenderForegroundColor text
    static member RenderFGC (text, color) = Formats.RenderForegroundColor (text, color)
    static member RenderBGC text          = Formats.RenderBackgroundColor text
    static member RenderBGC (text, color) = Formats.RenderBackgroundColor (text, color)



    // Modalità "funzionale"
    // Sovrascrivo la logica di base.
    static member Init () = Fmt ()

    static member InitWith (fmt : Fmt) =
        let newFmt = Fmt.Init ()

        newFmt.FormatsList.AddRange(fmt.FormatsList)

        newFmt

    member this.Clear () = this.FormatsList.Clear(); this

    member this.View () =
        this.FormatsList
        |> Seq.toList
        |> Format.view
        |> ignore

        this

    member this.Preview () =
        this.FormatsList
        |> Seq.toList
        |> Format.preview
        |> ignore

        this

    member this.Restore () = base.Restore () :?> Fmt

    member this.RestoreForegroundColor () = base.RestoreForegroundColor () :?> Fmt
    member this.RestoreBackgroundColor () = base.RestoreBackgroundColor () :?> Fmt

    member this.Bold      ()   = base.Bold      ()   :?> Fmt
    member this.Bold      flag = base.Bold      flag :?> Fmt
    member this.Faint     ()   = base.Faint     ()   :?> Fmt
    member this.Faint     flag = base.Faint     flag :?> Fmt
    member this.Italic    ()   = base.Italic    ()   :?> Fmt
    member this.Italic    flag = base.Italic    flag :?> Fmt
    member this.Underline ()   = base.Underline ()   :?> Fmt
    member this.Underline flag = base.Underline flag :?> Fmt
    member this.Blinking  ()   = base.Blinking  ()   :?> Fmt
    member this.Blinking  flag = base.Blinking  flag :?> Fmt
    member this.Reverse   ()   = base.Reverse   ()   :?> Fmt
    member this.Reverse   flag = base.Reverse   flag :?> Fmt
    member this.Hidden    ()   = base.Hidden    ()   :?> Fmt
    member this.Hidden    flag = base.Hidden    flag :?> Fmt
    member this.Strikeout ()   = base.Strikeout ()   :?> Fmt
    member this.Strikeout flag = base.Strikeout flag :?> Fmt

    member this.ForegroundColor ()    = base.ForegroundColor ()    :?> Fmt
    member this.ForegroundColor color = base.ForegroundColor color :?> Fmt
    member this.BackgroundColor ()    = base.BackgroundColor ()    :?> Fmt
    member this.BackgroundColor color = base.BackgroundColor color :?> Fmt



    // Alias modalità "funzionale"
    member this.RST () = base.Restore () :?> Fmt

    member this.RFGC () = base.RestoreForegroundColor () :?> Fmt
    member this.RBGC () = base.RestoreBackgroundColor () :?> Fmt

    member this.BLD ()   = base.Bold      ()   :?> Fmt
    member this.BLD flag = base.Bold      flag :?> Fmt
    member this.FNT ()   = base.Faint     ()   :?> Fmt
    member this.FNT flag = base.Faint     flag :?> Fmt
    member this.ITC ()   = base.Italic    ()   :?> Fmt
    member this.ITC flag = base.Italic    flag :?> Fmt
    member this.UND ()   = base.Underline ()   :?> Fmt
    member this.UND flag = base.Underline flag :?> Fmt
    member this.BKG ()   = base.Blinking  ()   :?> Fmt
    member this.BKG flag = base.Blinking  flag :?> Fmt
    member this.RVS ()   = base.Reverse   ()   :?> Fmt
    member this.RVS flag = base.Reverse   flag :?> Fmt
    member this.HDN ()   = base.Hidden    ()   :?> Fmt
    member this.HDN flag = base.Hidden    flag :?> Fmt
    member this.SKT ()   = base.Strikeout ()   :?> Fmt
    member this.SKT flag = base.Strikeout flag :?> Fmt

    member this.FGC ()    = base.ForegroundColor ()    :?> Fmt
    member this.FGC color = base.ForegroundColor color :?> Fmt
    member this.BGC ()    = base.BackgroundColor ()    :?> Fmt
    member this.BGC color = base.BackgroundColor color :?> Fmt



    // Alias modalità imperativa
    static member DoRST text = Formats.DoRestore text

    static member DoRFGC text = Formats.DoRestoreForegroundColor text
    static member DoRBGC text = Formats.DoRestoreBackgroundColor text

    static member DoBLD text         = Formats.DoBold      text
    static member DoBLD (text, flag) = Formats.DoBold      (text, flag)
    static member DoFNT text         = Formats.DoFaint     text
    static member DoFNT (text, flag) = Formats.DoFaint     (text, flag)
    static member DoITC text         = Formats.DoItalic    text
    static member DoITC (text, flag) = Formats.DoItalic    (text, flag)
    static member DoUND text         = Formats.DoUnderline text
    static member DoUND (text, flag) = Formats.DoUnderline (text, flag)
    static member DoBKG text         = Formats.DoBlinking  text
    static member DoBKG (text, flag) = Formats.DoBlinking  (text, flag)
    static member DoRVS text         = Formats.DoReverse   text
    static member DoRVS (text, flag) = Formats.DoReverse   (text, flag)
    static member DoHDN text         = Formats.DoHidden    text
    static member DoHDN (text, flag) = Formats.DoHidden    (text, flag)
    static member DoSKT text         = Formats.DoStrikeout text
    static member DoSKT (text, flag) = Formats.DoStrikeout (text, flag)

    static member DoFGC text          = Formats.DoForegroundColor text
    static member DoFGC (text, color) = Formats.DoForegroundColor (text, color)
    static member DoBGC text          = Formats.DoBackgroundColor text
    static member DoBGC (text, color) = Formats.DoBackgroundColor (text, color)
