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

    override this.Equals(obj) =
        match obj with
        | :? FormatRestore -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type FormatBold(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get () =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get () =
                Format.Bold this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatBold as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatFaint(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Faint this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatFaint as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatItalic(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Italic this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatItalic as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatUnderline(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Underline this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatUnderline as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatBlinking(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Blinking this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatBlinking as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatReverse(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Reverse this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatReverse as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatHidden(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Hidden this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatHidden as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatStrikeout(flag) =
    let mutable flag_ = flag

    member this.Flag
        with get() =
            flag_

        and set(flag) =
            flag_ <- flag

    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.Strikeout this.Flag

    override this.Equals(obj) =
        match obj with
        | :? FormatStrikeout as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type FormatRestoreForegroundColor() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreForegroundColor

    override this.Equals(obj) =
        match obj with
        | :? FormatRestoreForegroundColor -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatRestoreBackgroundColor() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreBackgroundColor

    override this.Equals(obj) =
        match obj with
        | :? FormatRestoreBackgroundColor -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type FormatForegroundColor(color : Color) =
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
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Format.ForegroundColor color

    override this.Equals(obj) =
        match obj with
        | :? FormatForegroundColor as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FormatBackgroundColor(color : Color) =
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
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Format.BackgroundColor color

    override this.Equals(obj) =
        match obj with
        | :? FormatBackgroundColor as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



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
