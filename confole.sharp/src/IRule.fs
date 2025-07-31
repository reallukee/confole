(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : IRule.fs

    Title       : IRULE
    Description : IRule

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open Reallukee.Confole

type IRule =
    abstract member ToFunctional : Rule.Rule with get

type IRules = IRule list

type RuleTitle(value) =
    member this.Title = value

    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.Title value

type ShowCursorBlinking() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.ShowCursorBlinking

type HideCursorBlinking() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.HideCursorBlinking

type ShowCursor() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.ShowCursor

type HideCursor() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.HideCursor

type EnableDesignateMode() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.EnableDesignateMode

type DisableDesignateMode() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.DisableDesignateMode

type EnableAlternativeBuffer() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.EnableAlternativeBuffer

type DisableAlternativeBuffer() =
    interface IRule with
        member this.ToFunctional
            with get() =
                Rule.Rule.DisableAlternativeBuffer

type DefaultForegroundColor(color : Color) =
    member this.Color = color

    static member fromRGB(red, green, blue) =
        DefaultForegroundColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        DefaultForegroundColor(HEXColor(red, green, blue))

    interface IRule with
        member this.ToFunctional
            with get() =
                let color =
                    match color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Rule.DefaultForegroundColor color

type DefaultBackgroundColor(color : Color) =
    member this.Color = color

    static member fromRGB(red, green, blue) =
        DefaultBackgroundColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        DefaultBackgroundColor(HEXColor(red, green, blue))

    interface IRule with
        member this.ToFunctional
            with get() =
                let color =
                    match color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Rule.DefaultBackgroundColor color

type DefaultCursorColor(color : Color) =
    member this.Color = color

    static member fromRGB(red, green, blue) =
        DefaultCursorColor(RGBColor(red, green, blue))

    static member fromHEX(red, green, blue) =
        DefaultCursorColor(HEXColor(red, green, blue))

    interface IRule with
        member this.ToFunctional
            with get() =
                let color =
                    match color with
                    | :? RGBColor as rgbColor ->
                        Color.RGB (rgbColor.Red, rgbColor.Green, rgbColor.Blue)
                    | :? HEXColor as hexColor ->
                        Color.HEX (hexColor.Red, hexColor.Green, hexColor.Blue)
                    | _ -> failwith "Unsupported color format!"

                Rule.DefaultCursorColor color
