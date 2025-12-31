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

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



[<AbstractClass>]
type FormatEmpty(format) =
    interface IFormat with
        member this.ToFunctional
            with get() =
                format

    override this.Equals(obj) =
        match obj with
        | :? FormatEmpty as other ->
            this.GetType() = other.GetType()
        | _ -> false

    override this.GetHashCode() =
        this.GetType().GetHashCode()

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type RestoreFormat() =
    inherit FormatEmpty(Format.Format.Restore)

type RestoreForegroundColorFormat() =
    inherit FormatEmpty(Format.Format.RestoreForegroundColor)

type RestoreBackgroundColorFormat() =
    inherit FormatEmpty(Format.Format.RestoreBackgroundColor)



[<AbstractClass>]
type FormatFlag(format, flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                format (Some flag)

    override this.Equals(obj) =
        match obj with
        | :? FormatFlag as other ->
            this.GetType() = other.GetType() &&
            this.Flag      = other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type BoldFormat(flag) =
    inherit FormatFlag(Format.Format.Bold, flag)

type FaintFormat(flag) =
    inherit FormatFlag(Format.Format.Faint, flag)

type ItalicFormat(flag) =
    inherit FormatFlag(Format.Format.Italic, flag)

type UnderlineFormat(flag) =
    inherit FormatFlag(Format.Format.Underline, flag)

type BlinkingFormat(flag) =
    inherit FormatFlag(Format.Format.Blinking, flag)

type ReverseFormat(flag) =
    inherit FormatFlag(Format.Format.Reverse, flag)

type HiddenFormat(flag) =
    inherit FormatFlag(Format.Format.Hidden, flag)

type StrikeoutFormat(flag) =
    inherit FormatFlag(Format.Format.Strikeout, flag)



[<AbstractClass>]
type FormatColor(format, color : Sharp.Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(color) =
            color_ <- color

    interface IFormat with
        member this.ToFunctional
            with get() =
                let color =
                    match this.Color with
                    | :? Sharp.XTermColor as xTermColor ->
                        Color.XTerm (xTermColor.Id)
                    | :? Sharp.RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? Sharp.HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                format (Some color)

    override this.Equals(obj) =
        match obj with
        | :? FormatColor as other ->
            this.GetType() = other.GetType() &&
            this.Color.Equals(other.Color)
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type ForegroundColorFormat(color) =
    inherit FormatColor(Format.Format.ForegroundColor, color)

type BackgroundColorFormat(color) =
    inherit FormatColor(Format.Format.BackgroundColor, color)



type Formats() =
    let mutable formats_ = []
    let mutable newLine_ = false

    member this.Formats
        with get() =
            formats_

        and set(formats) =
            formats_ <- formats

    member this.NewLine
        with get() =
            newLine_

        and set(newLine) =
            newLine_ <- newLine

    new(formats, newLine) as this =
        Formats() then
            this.Formats <- formats
            this.NewLine <- newLine

    new(newLine) as this =
        Formats() then
            this.Formats <- []
            this.NewLine <- newLine

    member this.Item
        with get(index) =
            this.Formats
            |> List.rev
            |> List.item index



    member this.AddFormat(format : IFormat) =
        this.Formats <- format :: this.Formats

        this

    member this.AddFormats(formats : IFormats) =
        this.Formats <- formats @ this.Formats

        this



    member this.AddRestore() =
        let restoreFormat = new RestoreFormat()

        this.AddFormat(restoreFormat)

    member this.AddRestoreForegroundColor() =
        let restoreForegroundColorFormat = new RestoreForegroundColorFormat()

        this.AddFormat(restoreForegroundColorFormat)

    member this.AddRestoreBackgroundColor() =
        let restoreBackgroundColorFormat = new RestoreBackgroundColorFormat()

        this.AddFormat(restoreBackgroundColorFormat)

    member this.AddBold(flag) =
        let boldFormat = new BoldFormat(flag)

        this.AddFormat(boldFormat)

    member this.AddFaint(flag) =
        let faintFormat = new FaintFormat(flag)

        this.AddFormat(faintFormat)

    member this.AddItalic(flag) =
        let italicFormat = new ItalicFormat(flag)

        this.AddFormat(italicFormat)

    member this.AddUnderline(flag) =
        let underlineFormat = new UnderlineFormat(flag)

        this.AddFormat(underlineFormat)

    member this.AddBlinking(flag) =
        let blinkingFormat = new BlinkingFormat(flag)

        this.AddFormat(blinkingFormat)

    member this.AddReverse(flag) =
        let reverseFormat = new ReverseFormat(flag)

        this.AddFormat(reverseFormat)

    member this.AddHidden(flag) =
        let hiddenFormat = new HiddenFormat(flag)

        this.AddFormat(hiddenFormat)

    member this.AddStrikeout(flag) =
        let strikeoutFormat = new StrikeoutFormat(flag)

        this.AddFormat(strikeoutFormat)

    member this.AddForegroundColor(color) =
        let foregroundColorFormat = new ForegroundColorFormat(color)

        this.AddFormat(foregroundColorFormat)

    member this.AddBackgroundColor(color) =
        let backgroundColorFormat = new BackgroundColorFormat(color)

        this.AddFormat(backgroundColorFormat)



    member this.Clear() =
        this.Formats <- []

        this

    member this.View() =
        this.Formats
        |> List.rev
        |> List.iter (fun format ->
            printfn "%A" format
        )



    member private this.CallApply(format : IFormat, text, newLine) =
        if newLine then
            Format.applyNewLine text format.ToFunctional
        else
            Format.apply text format.ToFunctional

    member this.Apply(format : IFormat, text, newLine) =
        this.CallApply(format, text, newLine)

    member this.Apply(format : IFormat, text) =
        this.CallApply(format, text, this.NewLine)

    member private this.CallApplyAll(text, newLine) =
        let formats =
            this.Formats
            |> List.map (fun format ->
                format.ToFunctional
            )

        if newLine then
            Format.applyAllNewLine text formats
        else
            Format.applyAll text formats

    member this.ApplyAll(text, newLine) =
        this.CallApplyAll(text, newLine)

    member this.ApplyAll(text) =
        this.CallApplyAll(text, this.NewLine)



    member this.Reset(text) =
        this.Formats <- []

        Format.reset text



    static member DoRestore(text) =
        let restoreFormat = new RestoreFormat() :> IFormat

        Format.apply text restoreFormat.ToFunctional

    static member DoRestoreForegroundColor(text) =
        let restoreForegroundColorFormat = new RestoreForegroundColorFormat() :> IFormat

        Format.apply text restoreForegroundColorFormat.ToFunctional

    static member DoRestoreBackgroundColor(text) =
        let restoreBackgroundColorFormat = new RestoreBackgroundColorFormat() :> IFormat

        Format.apply text restoreBackgroundColorFormat.ToFunctional

    static member DoBold(text, flag) =
        let boldFormat = new BoldFormat(flag) :> IFormat

        Format.apply text boldFormat.ToFunctional

    static member DoFaint(text, flag) =
        let faintFormat = new FaintFormat(flag) :> IFormat

        Format.apply text faintFormat.ToFunctional

    static member DoItalic(text, flag) =
        let italicFormat = new ItalicFormat(flag) :> IFormat

        Format.apply text italicFormat.ToFunctional

    static member DoUnderline(text, flag) =
        let underlineFormat = new UnderlineFormat(flag) :> IFormat

        Format.apply text underlineFormat.ToFunctional

    static member DoBlinking(text, flag) =
        let blinkingFormat = new BlinkingFormat(flag) :> IFormat

        Format.apply text blinkingFormat.ToFunctional

    static member DoReverse(text, flag) =
        let reverseFormat = new ReverseFormat(flag) :> IFormat

        Format.apply text reverseFormat.ToFunctional

    static member DoHidden(text, flag) =
        let hiddenFormat = new HiddenFormat(flag) :> IFormat

        Format.apply text hiddenFormat.ToFunctional

    static member DoStrikeout(text, flag) =
        let strikeoutFormat = new StrikeoutFormat(flag) :> IFormat

        Format.apply text strikeoutFormat.ToFunctional

    static member DoForegroundColor(text, color) =
        let foregroundColorFormat = new ForegroundColorFormat(color) :> IFormat

        Format.apply text foregroundColorFormat.ToFunctional

    static member DoBackgroundColor(text, color) =
        let backgroundColorFormat = new BackgroundColorFormat(color) :> IFormat

        Format.apply text backgroundColorFormat.ToFunctional



    static member DoReset(text) =
        Format.reset text



    override this.Equals(obj) =
        match obj with
        | :? Formats as other ->
            this.NewLine = other.NewLine &&
            this.Formats.Equals(other.Formats)
        | _ -> false

    override this.GetHashCode() =
        hash(this.NewLine, this.Formats)

    override this.ToString() =
        let formats =
            this.Formats
            |> Seq.map (fun format ->
                format.ToString()
            )
            |> String.concat "; "

        $"Formats(NewLine={this.NewLine}, Formats=[{formats}])"
