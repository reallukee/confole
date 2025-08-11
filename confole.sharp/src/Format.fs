(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : Format.fs

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



type FormatRestore() =
    interface IFormat with
        member this.ToFunctional
            with get () =
                Format.Restore



type FormatBold(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get () =
            flag_

        and set value =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get () =
                Format.Bold this.Flag

type FormatFaint(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Faint this.Flag

type FormatItalic(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Italic this.Flag

type FormatUnderline(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Underline this.Flag

type FormatBlinking(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Blinking this.Flag

type FormatReverse(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Reverse this.Flag

type FormatHidden(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Hidden this.Flag

type FormatStrikeout(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(value) =
            flag_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Strikeout this.Flag



type FormatRestoreForegroundColor() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreForegroundColor

type FormatRestoreBackgroundColor() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreBackgroundColor



type FormatForegroundColor(color : Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(value) =
            color_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                let color =
                    match this.Color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Format.ForegroundColor color

type FormatBackgroundColor(color : Color) =
    let mutable color_ = color

    member this.Color
        with get() =
            color_

        and set(value) =
            color_ <- value

    interface IFormat with
        member this.ToFunctional
            with get() =
                let color =
                    match this.Color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Format.BackgroundColor color



type Formats() =
    let mutable formats = []
    let mutable newLine = false

    member this.Formats
        with get() =
            formats

        and set(value) =
            formats <- value

    member this.NewLine
        with get() =
            newLine

        and set(value) =
            newLine <- value



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



    member this.AddRestoreFormat() = this.AddFormat(new FormatRestore())

    member this.AddBoldFormat(flag)      = this.AddFormat(new FormatBold(flag))
    member this.AddFaintFormat(flag)     = this.AddFormat(new FormatFaint(flag))
    member this.AddItalicFormat(flag)    = this.AddFormat(new FormatItalic(flag))
    member this.AddUnderlineFormat(flag) = this.AddFormat(new FormatUnderline(flag))
    member this.AddBlinkingFormat(flag)  = this.AddFormat(new FormatBlinking(flag))
    member this.AddReverseFormat(flag)   = this.AddFormat(new FormatReverse(flag))
    member this.AddHiddenFormat(flag)    = this.AddFormat(new FormatHidden(flag))
    member this.AddStrikeoutFormat(flag) = this.AddFormat(new FormatStrikeout(flag))

    member this.AddRestoreForegroundColorFormat() = this.AddFormat(new FormatRestoreForegroundColor())
    member this.AddRestoreBackgroundColorFormat() = this.AddFormat(new FormatRestoreBackgroundColor())

    member this.AddForegroundColorFormat(color) = this.AddFormat(new FormatForegroundColor(color))
    member this.AddBackgroundColorFormat(color) = this.AddFormat(new FormatBackgroundColor(color))



    member this.Clear() =
        this.Formats <- []

        this



    member this.View() =
        this.Formats
        |> List.rev
        |> List.iter (fun format ->
            printfn "%A" format
        )



    member private this.CallApply(format : IFormat, newLine, text) =
        format.ToFunctional
        |> Format.apply newLine text

    member this.Apply(format : IFormat, newLine, text) =
        this.CallApply(format, newLine, text)

    member this.Apply(format : IFormat, text) =
        this.CallApply(format, this.NewLine, text)



    member private this.CallApplyAll(newLine, text) =
        this.Formats
        |> List.rev
        |> List.map (fun format ->
            format.ToFunctional
        )
        |> Format.applyAll newLine text

    member this.ApplyAll(newLine, text) =
        this.CallApplyAll(newLine, text)

    member this.ApplyAll(text) =
        this.CallApplyAll(this.NewLine, text)



    member this.Reset(text) =
        this.Formats <- []

        Format.reset text
