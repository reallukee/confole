namespace Reallukee.Confole

open System
open System.Linq
open System.Threading
open System.Text

#if EXPERIMENTAL

module ConsoleExTypes =

    type Color =
        | Black       | White
        | DarkBlue    | Blue
        | DarkGreen   | Green
        | DarkCyan    | Cyan
        | DarkRed     | Red
        | DarkMagenta | Magenta
        | DarkYellow  | Yellow
        | DarkGray    | Gray

    val consoleColorToColor : consoleColor : ConsoleColor -> Color
    val colorToConsoleColor : color        : Color        -> ConsoleColor



    type Key =
        | A | B | C | D | E | F | G | H | I | J | K | L | M
        | N | O | P | Q | R | S | T | U | V | W | X | Y | Z
        | N0 | N1 | N2 | N3 | N4
        | N5 | N6 | N7 | N8 | N9

    val consoleKeyToKey : consoleKey : ConsoleKey -> Key
    val keyToConsoleKey : key        : Key        -> ConsoleKey



    type ModifiersKey =
        | Control
        | Alt
        | Shift

    val consoleModifiersToModifiersKey : consoleModifiers : ConsoleModifiers -> ModifiersKey
    val modifiersKeyToConsoleModifiers : modifiersKey     : ModifiersKey     -> ConsoleModifiers

#endif
