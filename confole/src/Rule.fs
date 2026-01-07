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

                  Il modulo Rule permette di ottenere gli
                  stessi risultati con 4 approcci diversi:

                  * Manuale
                  * Funzionale
                  * Imperativo
                  * DSL

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

open Color
open ColorConversion
open Position
open PositionConversion

// Rul
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
        | Title                    of title : string       // TTL
        | ShowCursorBlinking                               // SCB
        | HideCursorBlinking                               // HCB
        | ShowCursor                                       // SC
        | HideCursor                                       // HC
        | EnableDesignateMode                              // EDM
        | DisableDesignateMode                             // DDM
        | EnableAlternativeBuffer                          // EAB
        | DisableAlternativeBuffer                         // DAB
        | CursorShape              of shape : Shape option // CS
        | DefaultForegroundColor   of color : Color option // DFGC
        | DefaultBackgroundColor   of color : Color option // DBGC
        | DefaultCursorColor       of color : Color option // DCC

    let TTL  title = Title                    title
    let SCB        = ShowCursorBlinking
    let HCB        = HideCursorBlinking
    let SC         = ShowCursor
    let HC         = HideCursor
    let EDM        = EnableDesignateMode
    let DDM        = DisableDesignateMode
    let EAB        = EnableAlternativeBuffer
    let DAB        = DisableAlternativeBuffer
    let CS   shape = CursorShape              shape
    let DFGC color = DefaultForegroundColor   color
    let DBGC color = DefaultBackgroundColor   color
    let DCC  color = DefaultCursorColor       color

    type Rules = Rule list

    let defaultRules = [
        ShowCursorBlinking
        ShowCursor

        DisableDesignateMode
        DisableAlternativeBuffer

        CursorShape              None

        DefaultForegroundColor   None
        DefaultBackgroundColor   None
        DefaultCursorColor       None
    ]



    let render rule =
        match rule with
        | Title title -> sprintf "%s0;%s%s" OSC title Bell

        | ShowCursorBlinking -> sprintf "%s?12h" CSI
        | HideCursorBlinking -> sprintf "%s?12l" CSI

        | ShowCursor -> sprintf "%s?25h" CSI
        | HideCursor -> sprintf "%s?25l" CSI

        | EnableDesignateMode  -> sprintf "%s(0" ESC
        | DisableDesignateMode -> sprintf "%s(B" ESC

        | EnableAlternativeBuffer  -> sprintf "%s?1049h" CSI
        | DisableAlternativeBuffer -> sprintf "%s?1049l" CSI

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

            sprintf "%s%d%sq" CSI shape SP

        | DefaultForegroundColor color ->
            let color = defaultArg color (Color.RGB (255, 255, 255))

            let red, green, blue =
                match color with
                | XTerm id -> xTermToHEX id
                | XTermColor color ->
                    xTermColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | RGB (red, green, blue) -> rgbToHEX (red, green, blue)
                | RGBColor color ->
                    rgbColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | HEX (red, green, blue) -> red, green, blue
                | HEXColor color -> color.red, color.green, color.blue
                | color -> failwithf "%A: Unsupported color format!" color

            sprintf "%s10;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultBackgroundColor color ->
            let color = defaultArg color (Color.RGB (0, 0, 0))

            let red, green, blue =
                match color with
                | XTerm id -> xTermToHEX id
                | XTermColor color ->
                    xTermColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | RGB (red, green, blue) -> rgbToHEX (red, green, blue)
                | RGBColor color ->
                    rgbColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | HEX (red, green, blue) -> red, green, blue
                | HEXColor color -> color.red, color.green, color.blue
                | color -> failwithf "%A: Unsupported color format!" color

            sprintf "%s11;rgb:%s/%s/%s%s\\" OSC red green blue ESC
        | DefaultCursorColor color ->
            let color = defaultArg color (Color.RGB (255, 255, 255))

            let red, green, blue =
                match color with
                | XTerm id -> xTermToHEX id
                | XTermColor color ->
                    xTermColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | RGB (red, green, blue) -> rgbToHEX (red, green, blue)
                | RGBColor color ->
                    rgbColorToHEXColor color
                    |> fun color -> color.red, color.green, color.blue
                | HEX (red, green, blue) -> red, green, blue
                | HEXColor color -> color.red, color.green, color.blue
                | color -> failwithf "%A: Unsupported color format!" color

            sprintf "%s12;rgb:%s/%s/%s%s\\" OSC red green blue ESC

        | rule -> failwithf "%A: Not yet implemented!" rule

    let renders rules =
        rules
        |> List.rev
        |> List.map (fun rule ->
            render rule
        )
        |> String.concat ""

    let renderTitle title = render (Title title)

    let renderShowCursorBlinking () = render ShowCursorBlinking
    let renderHideCursorBlinking () = render HideCursorBlinking

    let renderShowCursor () = render ShowCursor
    let renderHideCursor () = render HideCursor

    let renderEnableDesignateMode  () = render EnableDesignateMode
    let renderDisableDesignateMode () = render DisableDesignateMode

    let renderEnableAlternativeBuffer  () = render EnableAlternativeBuffer
    let renderDisableAlternativeBuffer () = render DisableAlternativeBuffer

    let renderCursorShape shape = render (CursorShape shape)

    let renderDefaultForegroundColor color = render (DefaultForegroundColor color)
    let renderDefaultBackgroundColor color = render (DefaultBackgroundColor color)
    let renderDefaultCursorColor     color = render (DefaultCursorColor     color)

    let renderReset () = renders defaultRules

    let renderTTL = renderTitle

    let renderSCB = renderShowCursorBlinking
    let renderHCB = renderHideCursorBlinking

    let renderSC = renderShowCursor
    let renderHC = renderHideCursor

    let renderEDM = renderEnableDesignateMode
    let renderDDM = renderDisableDesignateMode

    let renderEAB = renderEnableAlternativeBuffer
    let renderDAB = renderDisableAlternativeBuffer

    let renderCS = renderCursorShape

    let renderDFGC = renderDefaultForegroundColor
    let renderDBGC = renderDefaultBackgroundColor
    let renderDCC  = renderDefaultCursorColor



    let init () : Rules = []

    let initp (rules : Rules) = rules

    let clear (rules : Rules) : Rules = []

    let view (rules : Rules) =
        rules
        |> List.rev
        |> List.iter (fun rule ->
            printfn "%A" rule
        )

        rules

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

    let apply rule =
        printf "%s" (render rule)

    let applyNewLine rule =
        apply rule

        printfn ""

    let applyAll rules =
        rules
        |> List.rev
        |> List.iter (fun rule ->
            apply rule
        )

    let applyAllNewLine rules =
        applyAll rules

        printfn ""

    let reset () =
        defaultRules
        |> applyAll

    let configure config =
        init ()
        |> config
        |> applyAll

    let configureNewLine config =
        configure config

        printfn ""

    let ttl = title

    let scb = showCursorBlinking
    let hcb = hideCursorBlinking

    let sc = showCursor
    let hc = hideCursor

    let edm = enableDesignateMode
    let ddm = disableDesignateMode

    let eab = enableAlternativeBuffer
    let dab = disableAlternativeBuffer

    let cs = cursorShape

    let dfgc = defaultForegroundColor
    let dbgc = defaultBackgroundColor
    let dcc  = defaultCursorColor



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
    let doDefaultCursorColor     color = apply (DefaultCursorColor     color)

    let doReset () = reset ()

    let doTTL = doTitle

    let doSCB = doShowCursorBlinking
    let doHCB = doHideCursorBlinking

    let doSC = doShowCursor
    let doHC = doHideCursor

    let doEDM = doEnableDesignateMode
    let doDDM = doDisableDesignateMode

    let doEAB = doEnableAlternativeBuffer
    let doDAB = doDisableAlternativeBuffer

    let doCS = doCursorShape

    let doDFGC = doDefaultForegroundColor
    let doDBGC = doDefaultBackgroundColor
    let doDCC  = doDefaultCursorColor
