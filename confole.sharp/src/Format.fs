(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole

    File name   : Format.fs

    Title       : FORMAT
    Description : Format

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.1.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IFormat =
    abstract member ToFunctional : Format.Format with get

type IFormats = IFormat list



type RestoreFormat() =
    interface IFormat with
        member this.ToFunctional
            with get () =
                Format.Restore

    override this.Equals(obj) =
        match obj with
        | :? RestoreFormat -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type BoldFormat(flag) =
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
        | :? BoldFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type FaintFormat(flag) =
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
        | :? FaintFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type ItalicFormat(flag) =
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
        | :? ItalicFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type UnderlineFormat(flag) =
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
        | :? UnderlineFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type BlinkingFormat(flag) =
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
        | :? BlinkingFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type ReverseFormat(flag) =
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
        | :? ReverseFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type HiddenFormat(flag) =
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
        | :? HiddenFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type StrikeoutFormat(flag) =
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
        | :? StrikeoutFormat as other ->
            this.Flag && other.Flag
        | _ -> false

    override this.GetHashCode() =
        hash(this.Flag)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type RestoreForegroundColorFormat() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreForegroundColor

    override this.Equals(obj) =
        match obj with
        | :? RestoreForegroundColorFormat -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type RestoreBackgroundColorFormat() =
    interface IFormat with
        member this.ToFunctional
            with get() =
                Format.RestoreBackgroundColor

    override this.Equals(obj) =
        match obj with
        | :? RestoreBackgroundColorFormat -> true
        | _ -> false

    override this.GetHashCode() =
        0

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"



type ForegroundColorFormat(color : Color) =
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
        | :? ForegroundColorFormat as other ->
            this.Color = other.Color
        | _ -> false

    override this.GetHashCode() =
        hash(this.Color)

    override this.ToString() =
        $"{(this :> IFormat).ToFunctional}"

type BackgroundColorFormat(color : Color) =
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
        | :? BackgroundColorFormat as other ->
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



    member this.AddRestoreFormat() =
        let restoreFormat = new RestoreFormat()

        this.AddFormat(restoreFormat)



    member this.AddBoldFormat(flag) =
        let boldFormat = new BoldFormat(flag)

        this.AddFormat(boldFormat)

    member this.AddFaintFormat(flag) =
        let faintFormat = new FaintFormat(flag)

        this.AddFormat(faintFormat)

    member this.AddItalicFormat(flag) =
        let italicFormat = new ItalicFormat(flag)

        this.AddFormat(italicFormat)

    member this.AddUnderlineFormat(flag) =
        let underlineFormat = new UnderlineFormat(flag)

        this.AddFormat(underlineFormat)

    member this.AddBlinkingFormat(flag) =
        let blinkingFormat = new BlinkingFormat(flag)

        this.AddFormat(blinkingFormat)

    member this.AddReverseFormat(flag) =
        let reverseFormat = new ReverseFormat(flag)

        this.AddFormat(reverseFormat)

    member this.AddHiddenFormat(flag) =
        let hiddenFormat = new HiddenFormat(flag)

        this.AddFormat(hiddenFormat)

    member this.AddStrikeoutFormat(flag) =
        let strikeoutFormat = new StrikeoutFormat(flag)

        this.AddFormat(strikeoutFormat)



    member this.AddRestoreForegroundColorFormat() =
        let restoreForegroundColorFormat = new RestoreForegroundColorFormat()

        this.AddFormat(restoreForegroundColorFormat)

    member this.AddRestoreBackgroundColorFormat() =
        let restoreBackgroundColorFormat = new RestoreBackgroundColorFormat()

        this.AddFormat(restoreBackgroundColorFormat)



    member this.AddForegroundColorFormat(color) =
        let foregroundColorFormat = new ForegroundColorFormat(color)

        this.AddFormat(foregroundColorFormat)

    member this.AddBackgroundColorFormat(color) =
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



    member private this.CallApply(format : IFormat, newLine, text) =
        if newLine then
            Format.applyNewLine text format.ToFunctional
        else
            Format.apply text format.ToFunctional

    member this.Apply(format : IFormat, newLine, text) =
        this.CallApply(format, newLine, text)

    member this.Apply(format : IFormat, text) =
        this.CallApply(format, this.NewLine, text)



    member private this.CallApplyAll(newLine, text) =
        let formats =
            this.Formats
            |> List.rev
            |> List.map (fun format ->
                format.ToFunctional
            )

        if newLine then
            Format.applyAllNewLine text formats
        else
            Format.applyAll text formats

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
