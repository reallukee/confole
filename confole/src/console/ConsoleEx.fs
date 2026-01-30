namespace Reallukee.Confole

open System
open System.Linq
open System.Threading
open System.Text

#if EXPERIMENTAL

module ConsoleEx =

    open ConsoleExTypes
    open ConsoleExConfig

    let clear () = Console.Clear()

    let cls = clear

    let beep frequency duration = Console.Beep(frequency, duration)

    let sleep (duration : int) = Thread.Sleep(duration)



    // Properties
    let isCapsLockOn   () = Console.CapsLock
    let isNumberLockOn () = Console.NumberLock

    let getTitle ()    = Console.Title
    let setTitle title = Console.Title <- title

    let getWindowWidth  ()     = Console.WindowWidth
    let getWindowHeight ()     = Console.WindowHeight
    let setWindowWidth  width  = Console.WindowWidth  <- width
    let setWindowHeight height = Console.WindowHeight <- height

    let getBufferWidth  ()     = Console.BufferWidth
    let getBufferHeight ()     = Console.BufferHeight
    let setBufferWidth  width  = Console.BufferWidth  <- width
    let setBufferHeight height = Console.BufferHeight <- height

    let windowMaxWidth  () = Console.LargestWindowWidth
    let windowMaxHeight () = Console.LargestWindowHeight

    let showCursor () = Console.CursorVisible <- true
    let hideCursor () = Console.CursorVisible <- false

    let getForegroundColor ()    = consoleColorToColor Console.ForegroundColor
    let getBackgroundColor ()    = consoleColorToColor Console.BackgroundColor
    let setForegroundColor color = Console.ForegroundColor <- (colorToConsoleColor color)
    let setBackgroundColor color = Console.BackgroundColor <- (colorToConsoleColor color)

    let getfgc = getForegroundColor
    let getbgc = getBackgroundColor
    let setfgc = setForegroundColor
    let setbgc = setBackgroundColor

    let resetColor () = Console.ResetColor ()



    // I/O
    let waitKey () =
        do Console.ReadKey()
        |> ignore

    let waitKeySilent () =
        do Console.ReadKey(true)
        |> ignore

    let waitk   = waitKey
    let waitks  = waitKeySilent

    let waitThisKey (key, modifiersKey) =
        let rec loop () =
            let input = Console.ReadKey()

            let inputKey = consoleKeyToKey input.Key

            if Option.isNone modifiersKey then
                let inputModifiersKey = consoleModifiersToModifiersKey input.Modifiers

                if not (inputKey = key) && not (inputModifiersKey = modifiersKey.Value) then
                    loop ()
            else
                if not (inputKey = key) then
                    loop ()

        loop ()

    let waitThisKeySilent (key, modifiersKey) =
        let rec loop () =
            let input = Console.ReadKey(true)

            let inputKey = consoleKeyToKey input.Key

            if Option.isNone modifiersKey then
                let inputModifiersKey = consoleModifiersToModifiersKey input.Modifiers

                if not (inputKey = key) && not (inputModifiersKey = modifiersKey.Value) then
                    loop ()
            else
                if not (inputKey = key) then
                    loop ()

        loop ()

    let readKey () =
        let input = Console.ReadKey()

        let modifiersKey =
            #if NET5_0_OR_GREATER
            if input.Modifiers = ConsoleModifiers.None then
            #else
            if not (input.Modifiers.HasFlag(ConsoleModifiers.Control)) &&
               not (input.Modifiers.HasFlag(ConsoleModifiers.Alt))     &&
               not (input.Modifiers.HasFlag(ConsoleModifiers.Shift))   then
            #endif
                None
            else
                Some (consoleModifiersToModifiersKey input.Modifiers)

        consoleKeyToKey input.Key, modifiersKey

    let readKeySilent () =
        let input = Console.ReadKey(true)

        let modifiersKey =
            #if NET5_0_OR_GREATER
            if input.Modifiers = ConsoleModifiers.None then
            #else
            if not (input.Modifiers.HasFlag(ConsoleModifiers.Control)) &&
               not (input.Modifiers.HasFlag(ConsoleModifiers.Alt))     &&
               not (input.Modifiers.HasFlag(ConsoleModifiers.Shift))   then
            #endif
                None
            else
                Some (consoleModifiersToModifiersKey input.Modifiers)

        consoleKeyToKey input.Key, modifiersKey

    let readk   = readKey
    let readks  = readKeySilent



    // Cursor
    let cursorX   ()  = Console.CursorLeft
    let cursorY   ()  = Console.CursorTop
    let cursorRow ()  = Console.CursorTop  - 1
    let cursorCol ()  = Console.CursorLeft - 1
    let goToX     x   = Console.CursorLeft <- x
    let goToY     y   = Console.CursorTop  <- y
    let goToRow   row = Console.CursorTop  <- row - 1
    let goToCol   col = Console.CursorLeft <- col - 1

    let cursorXY () =
        #if NET5_0_OR_GREATER
            let mutable x = 0
            let mutable y = 0

            Console.GetCursorPosition().ToTuple().Deconstruct<int, int>(ref x, ref y)

            x, y
        #else
            Console.CursorLeft, Console.CursorTop
        #endif

    let cursorRowCol () =
        #if NET5_0_OR_GREATER
            let mutable row = 0
            let mutable col = 0

            Console.GetCursorPosition().ToTuple().Deconstruct<int, int>(ref col, ref row)

            row - 1, col - 1
        #else
            Console.CursorTop - 1, Console.CursorLeft - 1
        #endif

    let goToXY xY =
        let x, y = xY

        Console.SetCursorPosition(x, y)

    let goToRowCol rowCol =
        let row, col = rowCol

        Console.SetCursorPosition(col - 1, row - 1)

    let goUp       () = Console.CursorTop  - 1 |> ignore; ()
    let goDown     () = Console.CursorTop  + 1 |> ignore; ()
    let goNext     () = Console.CursorLeft + 1 |> ignore; ()
    let goPrevious () = Console.CursorLeft - 1 |> ignore; ()

#endif
