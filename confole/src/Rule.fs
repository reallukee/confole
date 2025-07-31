(*
    -------
    Confole
    -------

    Una libreria funzionale per applicazioni console F#

    File name   : Rule.fs

    Title       : RULE
    Description : Rule

    Author      : Luca Pollicino
                  (https://github.com/reallukee)
    Version     : 1.0.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Rule =
    let private ESC = "\u001B"
    let private CSI = "\u001B["
    let private OSC = "\u001B]"

    let private BELL = "\u0007"

    type Rule =
        | Title                    of string
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | EnableDesignateMode
        | DisableDesignateMode
        | EnableAlternativeBuffer
        | DisableAlternativeBuffer
        | DefaultForegroundColor   of Color
        | DefaultBackgroundColor   of Color
        | DefaultCursorColor       of Color

    type Rules = Rule list

    let init () : Rules =
        []

    let title value rules = Title value :: rules

    let showCursorBlinking rules = ShowCursorBlinking :: rules
    let hideCursorBlinking rules = HideCursorBlinking :: rules

    let showCursor rules = ShowCursor :: rules
    let hideCursor rules = HideCursor :: rules

    let enableDesignateMode  rules = EnableDesignateMode  :: rules
    let disableDesignateMode rules = DisableDesignateMode :: rules

    let enableAlternativeBuffer  rules = EnableAlternativeBuffer  :: rules
    let disableAlternativeBuffer rules = DisableAlternativeBuffer :: rules

    let defaultForegroundColor color rules = DefaultForegroundColor color :: rules
    let defaultBackgroundColor color rules = DefaultBackgroundColor color :: rules
    let defaultCursorColor     color rules = DefaultCursorColor     color :: rules

    let clear (rules : Rules) : Rules =
        []

    let apply newLine rule =
        match rule with
        | Title value -> printf "%s0;%s%s" OSC value BELL

        | ShowCursorBlinking -> printf "%s?12h" CSI
        | HideCursorBlinking -> printf "%s?12l" CSI

        | ShowCursor -> printf "%s?25h" CSI
        | HideCursor -> printf "%s?25l" CSI

        | EnableDesignateMode  -> printf "%s0" CSI
        | DisableDesignateMode -> printf "%sB" CSI

        | EnableAlternativeBuffer  -> printf "%s?1049h" CSI
        | DisableAlternativeBuffer -> printf "%s?1049l" CSI

        | DefaultForegroundColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "%s10;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultBackgroundColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "%s11;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultCursorColor color ->
            colorHEX color
            |> fun (red, green, blue) ->
                printf "%s12;rgb:%s/%s/%s%s\\" OSC red green blue ESC

        | _ -> failwith "Not yet implemented!"

        if newLine then
            printfn ""

    let applyAll newLine rules =
        rules
        |> List.rev
        |> List.iter (fun item ->
            apply false item
        )

        if newLine then
            printfn ""

    let reset () =
        [
            ShowCursorBlinking

            ShowCursor

            DisableDesignateMode

            DisableAlternativeBuffer

            DefaultForegroundColor (RGB (255, 255, 255))
            DefaultBackgroundColor (RGB (0, 0, 0))
            DefaultCursorColor     (RGB (255, 255, 255))
        ]
        |> applyAll false

    let configure newLine config =
        init ()
        |> config
        |> applyAll newLine

    type Builder () =
        member _.Yield ruleF : Rules -> Rules =
            ruleF

        member _.Combine (acc : Rules -> Rules, ruleF) : Rules -> Rules =
            acc >> ruleF

        member _.Delay f : Rules -> Rules =
            f ()

        member _.Run rulesF : Rules =
            rulesF (init ())

    let builder = Builder ()
