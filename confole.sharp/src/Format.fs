(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Format.fs

    Title       : FORMAT
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Format.
                  Il modulo Format si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

                  Riscrittura v4!

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
type Formats internal () =

    let mutable formats = List<Format.Format>()

    static let mutable newLine = false

    member this.FormatsList
        with internal get () =
            formats

        and internal set value =
            formats <- value

    static member NewLine
        with get () =
            newLine

        and set value =
            newLine <- value



    // Modalità manuale
    member this.Renders text =
        formats
        |> Seq.toList
        |> List.rev
        |> Format.renders text

    static member RenderRestore text = Format.renderRestore text

    static member RenderRestoreForegroundColor text = Format.renderRestoreForegroundColor text
    static member RenderRestoreBackgroundColor text = Format.renderRestoreBackgroundColor text

    static member RenderBold      text         = Format.renderBold      text None
    static member RenderBold      (text, flag) = Format.renderBold      text (Some flag)
    static member RenderFaint     text         = Format.renderFaint     text None
    static member RenderFaint     (text, flag) = Format.renderFaint     text (Some flag)
    static member RenderItalic    text         = Format.renderItalic    text None
    static member RenderItalic    (text, flag) = Format.renderItalic    text (Some flag)
    static member RenderUnderline text         = Format.renderUnderline text None
    static member RenderUnderline (text, flag) = Format.renderUnderline text (Some flag)
    static member RenderBlinking  text         = Format.renderBlinking  text None
    static member RenderBlinking  (text, flag) = Format.renderBlinking  text (Some flag)
    static member RenderReverse   text         = Format.renderReverse   text None
    static member RenderReverse   (text, flag) = Format.renderReverse   text (Some flag)
    static member RenderHidden    text         = Format.renderHidden    text None
    static member RenderHidden    (text, flag) = Format.renderHidden    text (Some flag)
    static member RenderStrikeout text         = Format.renderStrikeout text None
    static member RenderStrikeout (text, flag) = Format.renderStrikeout text (Some flag)

    static member RenderForegroundColor text          = Format.renderForegroundColor text None
    static member RenderForegroundColor (text, color) = Format.renderForegroundColor text (Some (Color.toFColor color))
    static member RenderBackgroundColor text          = Format.renderBackgroundColor text None
    static member RenderBackgroundColor (text, color) = Format.renderBackgroundColor text (Some (Color.toFColor color))

    static member RenderReset text = Format.renderReset text



    // Modalità "funzionale"
    static member Init () = Formats ()

    static member Initp (formats : Formats) =
        let newFormats = Formats.Init ()

        newFormats.FormatsList.AddRange(formats.FormatsList)

        newFormats

    member this.Clear () = formats.Clear(); this

    member this.View () =
        formats
        |> Seq.toList
        |> Format.view
        |> ignore

        this

    member this.Restore () = formats.Add(Format.Restore); this

    member this.RestoreForegroundColor () = formats.Add(Format.RestoreForegroundColor); this
    member this.RestoreBackgroundColor () = formats.Add(Format.RestoreBackgroundColor); this

    member this.Bold      ()   = formats.Add(Format.Bold      None       ); this
    member this.Bold      flag = formats.Add(Format.Bold      (Some flag)); this
    member this.Faint     ()   = formats.Add(Format.Faint     None       ); this
    member this.Faint     flag = formats.Add(Format.Faint     (Some flag)); this
    member this.Italic    ()   = formats.Add(Format.Italic    None       ); this
    member this.Italic    flag = formats.Add(Format.Italic    (Some flag)); this
    member this.Underline ()   = formats.Add(Format.Underline None       ); this
    member this.Underline flag = formats.Add(Format.Underline (Some flag)); this
    member this.Blinking  ()   = formats.Add(Format.Blinking  None       ); this
    member this.Blinking  flag = formats.Add(Format.Blinking  (Some flag)); this
    member this.Reverse   ()   = formats.Add(Format.Reverse   None       ); this
    member this.Reverse   flag = formats.Add(Format.Reverse   (Some flag)); this
    member this.Hidden    ()   = formats.Add(Format.Hidden    None       ); this
    member this.Hidden    flag = formats.Add(Format.Hidden    (Some flag)); this
    member this.Strikeout ()   = formats.Add(Format.Strikeout None       ); this
    member this.Strikeout flag = formats.Add(Format.Strikeout (Some flag)); this

    member this.ForegroundColor ()    = formats.Add(Format.ForegroundColor None                         ); this
    member this.ForegroundColor color = formats.Add(Format.ForegroundColor (Some (Color.toFColor color))); this
    member this.BackgroundColor ()    = formats.Add(Format.BackgroundColor None                         ); this
    member this.BackgroundColor color = formats.Add(Format.BackgroundColor (Some (Color.toFColor color))); this

    member this.ApplyAll text =
        formats
        |> Seq.toList
        |> List.rev
        |> Format.applyAll text

        if Formats.NewLine then
            printfn ""

    member this.ApplyAll (text, newLine) =
        formats
        |> Seq.toList
        |> List.rev
        |> Format.applyAll text

        if newLine then
            printfn ""

    static member Reset text = Format.reset text



    // Modalità imperativa
    static member DoRestore text = Format.doRestore text

    static member DoRestoreForegroundColor text = Format.doRestoreForegroundColor text
    static member DoRestoreBackgroundColor text = Format.doRestoreBackgroundColor text

    static member DoBold      text         = Format.doBold      text None
    static member DoBold      (text, flag) = Format.doBold      text (Some flag)
    static member DoFaint     text         = Format.doFaint     text None
    static member DoFaint     (text, flag) = Format.doFaint     text (Some flag)
    static member DoItalic    text         = Format.doItalic    text None
    static member DoItalic    (text, flag) = Format.doItalic    text (Some flag)
    static member DoUnderline text         = Format.doUnderline text None
    static member DoUnderline (text, flag) = Format.doUnderline text (Some flag)
    static member DoBlinking  text         = Format.doBlinking  text None
    static member DoBlinking  (text, flag) = Format.doBlinking  text (Some flag)
    static member DoReverse   text         = Format.doReverse   text None
    static member DoReverse   (text, flag) = Format.doReverse   text (Some flag)
    static member DoHidden    text         = Format.doHidden    text None
    static member DoHidden    (text, flag) = Format.doHidden    text (Some flag)
    static member DoStrikeout text         = Format.doStrikeout text None
    static member DoStrikeout (text, flag) = Format.doStrikeout text (Some flag)

    static member DoForegroundColor text          = Format.doForegroundColor text None
    static member DoForegroundColor (text, color) = Format.doForegroundColor text (Some (Color.toFColor color))
    static member DoBackgroundColor text          = Format.doBackgroundColor text None
    static member DoBackgroundColor (text, color) = Format.doBackgroundColor text (Some (Color.toFColor color))

    static member DoReset text = Format.doReset text



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

    // Alias modalità "funzionale"
    static member Init () = Fmt ()

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
