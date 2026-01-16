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
type Formats private () =

    let mutable formats = List<Format.Format>()

    static let mutable newLine = false

    member this.FormatsList
        with internal get () =
            formats

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



    static member RenderForegroundColor text = Format.renderForegroundColor text None

    static member RenderForegroundColor (text, color) =
        let color = Color.toFColor color

        Format.renderForegroundColor text (Some color)

    static member RenderBackgroundColor text = Format.renderBackgroundColor text None

    static member RenderBackgroundColor (text, color) =
        let color = Color.toFColor color

        Format.renderBackgroundColor text (Some color)



    static member RenderReset text = Format.renderReset text



    // Modalità "funzionale"
    static member Init () = new Formats()

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



    member this.ForegroundColor () = formats.Add(Format.ForegroundColor None); this

    member this.ForegroundColor color =
        let color = Color.toFColor color

        formats.Add(Format.ForegroundColor (Some color))

        this

    member this.BackgroundColor () = formats.Add(Format.BackgroundColor None); this

    member this.BackgroundColor color =
        let color = Color.toFColor color

        formats.Add(Format.BackgroundColor (Some color))

        this



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



    static member DoForegroundColor text = Format.doForegroundColor text None

    static member DoForegroundColor (text, color) =
        let color = Color.toFColor color

        Format.doForegroundColor text (Some color)

    static member DoBackgroundColor text = Format.doBackgroundColor text None

    static member DoBackgroundColor (text, color) =
        let color = Color.toFColor color

        Format.doBackgroundColor text (Some color)



    static member DoReset text = Format.doReset text
