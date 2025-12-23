(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Rule.fs

    Title       : RULE
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Rule.
                  Il modulo Rule si occupa di sequenze VTS
                  relative all'apparenza del terminale.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.2.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open Position

module Rule =
    type Shape =
        | User
        | BlinkingBlock
        | SteadyBlock
        | BlinkingUnderline
        | SteadyUnderline
        | BlinkingBar
        | SteadyBar

    type Rule =
        | Title                    of title : string
        | ShowCursorBlinking
        | HideCursorBlinking
        | ShowCursor
        | HideCursor
        | EnableDesignateMode
        | DisableDesignateMode
        | EnableAlternativeBuffer
        | DisableAlternativeBuffer
        | CursorShape              of shape : Shape option
        | DefaultForegroundColor   of color : Color
        | DefaultBackgroundColor   of color : Color
        | DefaultCursorColor       of color : Color

    type Rules = Rule list



    let title title rules = Title title :: rules

    let showCursorBlinking rules = ShowCursorBlinking :: rules
    let hideCursorBlinking rules = HideCursorBlinking :: rules

    let showCursor rules = ShowCursor :: rules
    let hideCursor rules = HideCursor :: rules

    let enableDesignateMode  rules = EnableDesignateMode  :: rules
    let disableDesignateMode rules = DisableDesignateMode :: rules

    let enableAlternativeBuffer  rules = EnableAlternativeBuffer  :: rules
    let disableAlternativeBuffer rules = DisableAlternativeBuffer :: rules

    let cursorShape shape rules = CursorShape shape :: rules

    let defaultForegroundColor color rules = DefaultForegroundColor color :: rules
    let defaultBackgroundColor color rules = DefaultBackgroundColor color :: rules
    let defaultCursorColor     color rules = DefaultCursorColor     color :: rules



    let init () : Rules = []

    let initPreset (rules : Rules) =
        rules

    let clear (rules : Rules) : Rules = []

    let view (rules : Rules) =
        rules
        |> List.rev
        |> List.iter (fun rule ->
            printfn "%A" rule
        )



    let apply rule =
        match rule with
        | Title title -> printf "%s0;%s%s" OSC title Bell

        | ShowCursorBlinking -> printf "%s?12h" CSI
        | HideCursorBlinking -> printf "%s?12l" CSI

        | ShowCursor -> printf "%s?25h" CSI
        | HideCursor -> printf "%s?25l" CSI

        | EnableDesignateMode  -> printf "%s(0" ESC
        | DisableDesignateMode -> printf "%s(B" ESC

        | EnableAlternativeBuffer  -> printf "%s?1049h" CSI
        | DisableAlternativeBuffer -> printf "%s?1049l" CSI

        | CursorShape shape ->
            let shape =
                match shape with
                | Some User              -> 0
                | Some BlinkingBlock     -> 1
                | Some SteadyBlock       -> 2
                | Some BlinkingUnderline -> 3
                | Some SteadyUnderline   -> 4
                | Some BlinkingBar       -> 5
                | Some SteadyBar         -> 6
                | None                   -> 0

            printf "%s%d%sq" CSI shape SP

        | DefaultForegroundColor color ->
            colorToHEX color
            |> fun (red, green, blue) ->
                printf "%s10;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultBackgroundColor color ->
            colorToHEX color
            |> fun (red, green, blue) ->
                printf "%s11;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultCursorColor color ->
            colorToHEX color
            |> fun (red, green, blue) ->
                printf "%s12;rgb:%s/%s/%s%s\\" OSC red green blue ESC

        | _ -> failwith "Not yet implemented!"

    let applyNewLine rule =
        apply rule

        printfn ""

    let applyAll rules =
        rules
        |> List.rev
        |> List.iter (fun item ->
            apply item
        )

    let applyAllNewLine rules =
        applyAll rules

        printfn ""



    let reset () =
        [
            ShowCursorBlinking
            ShowCursor

            DisableDesignateMode
            DisableAlternativeBuffer

            CursorShape              (Some User)

            DefaultForegroundColor   (RGB (255, 255, 255))
            DefaultBackgroundColor   (RGB (0, 0, 0))
            DefaultCursorColor       (RGB (255, 255, 255))
        ]
        |> applyAll



    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""



    type Builder () =
        member _.Yield ruleFunction : Rules -> Rules =
            ruleFunction

        member _.Combine (rule : Rules -> Rules, ruleFunction) : Rules -> Rules =
            rule >> ruleFunction

        member _.Delay ``function`` : Rules -> Rules =
            ``function`` ()

        member _.Run rulesFunction : Rules =
            rulesFunction (init ())

    let builder = Builder ()



    let doTitle title = apply (Title title)

    let doShowCursorBlinking () = apply ShowCursorBlinking
    let doHideCursorBlinking () = apply HideCursorBlinking

    let doShowCursor () = apply ShowCursor
    let doHideCursor () = apply HideCursor

    let doEnableDesignateMode  () = apply EnableDesignateMode
    let doDisableDesignateMode () = apply DisableDesignateMode

    let doEnableAlternativeBuffer  () = apply EnableAlternativeBuffer
    let doDisableAlternativeBuffer () = apply DisableAlternativeBuffer

    let doCursorShape shape = apply (CursorShape shape)

    let doDefaultForegroundColor color = apply (DefaultForegroundColor color)
    let doDefaultBackgroundColor color = apply (DefaultBackgroundColor color)
    let doDefaultCursorColor     color = apply (DefaultCursorColor color)
