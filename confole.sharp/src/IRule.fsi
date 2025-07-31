(*
    --------
    Confole#
    --------

    Una libreria funzionale per applicazioni console F#

    File name   : IRule.fsi

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

type RuleTitle =
    interface IRule

    new : value : string -> RuleTitle

    member Title : string

type ShowCursorBlinking =
    interface IRule

    new : unit -> ShowCursorBlinking

type HideCursorBlinking =
    interface IRule

    new : unit -> HideCursorBlinking

type ShowCursor =
    interface IRule

    new : unit -> ShowCursor

type HideCursor =
    interface IRule

    new : unit -> HideCursor

type EnableDesignateMode =
    interface IRule

    new : unit -> EnableDesignateMode

type DisableDesignateMode =
    interface IRule

    new : unit -> DisableDesignateMode

type EnableAlternativeBuffer =
    interface IRule

    new : unit -> EnableAlternativeBuffer

type DisableAlternativeBuffer =
    interface IRule

    new : unit -> DisableAlternativeBuffer

type DefaultForegroundColor =
    interface IRule

    new : color : Color -> DefaultForegroundColor

    static member fromRGB :
        red : int * green : int * blue : int ->
        DefaultForegroundColor

    static member fromHEX :
        red : string * green : string * blue : string ->
        DefaultForegroundColor

    member Color : Color

type DefaultBackgroundColor =
    interface IRule

    new : color : Color -> DefaultBackgroundColor

    static member fromRGB :
        red : int * green : int * blue : int ->
        DefaultBackgroundColor

    static member fromHEX :
        red : string * green : string * blue : string ->
        DefaultBackgroundColor

    member Color : Color

type DefaultCursorColor =
    interface IRule

    new : color : Color -> DefaultCursorColor

    static member fromRGB :
        red : int * green : int * blue : int ->
        DefaultCursorColor

    static member fromHEX :
        red : string * green : string * blue : string ->
        DefaultCursorColor

    member Color : Color
