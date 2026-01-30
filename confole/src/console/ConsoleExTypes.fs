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

    let consoleColorToColor consoleColor =
        match consoleColor with
        | ConsoleColor.Black       -> Black
        | ConsoleColor.DarkBlue    -> DarkBlue
        | ConsoleColor.DarkGreen   -> DarkGreen
        | ConsoleColor.DarkCyan    -> DarkCyan
        | ConsoleColor.DarkRed     -> DarkRed
        | ConsoleColor.DarkMagenta -> DarkMagenta
        | ConsoleColor.DarkYellow  -> DarkYellow
        | ConsoleColor.Gray        -> Gray
        | ConsoleColor.DarkGray    -> DarkGray
        | ConsoleColor.Blue        -> Blue
        | ConsoleColor.Green       -> Green
        | ConsoleColor.Cyan        -> Cyan
        | ConsoleColor.Red         -> Red
        | ConsoleColor.Magenta     -> Magenta
        | ConsoleColor.Yellow      -> Yellow
        | ConsoleColor.White       -> White
        | consoleColor -> failwithf "%A: Not yet supported!" consoleColor

    let colorToConsoleColor color =
        match color with
        | Black       -> ConsoleColor.Black
        | DarkBlue    -> ConsoleColor.DarkBlue
        | DarkGreen   -> ConsoleColor.DarkGreen
        | DarkCyan    -> ConsoleColor.DarkCyan
        | DarkRed     -> ConsoleColor.DarkRed
        | DarkMagenta -> ConsoleColor.DarkMagenta
        | DarkYellow  -> ConsoleColor.DarkYellow
        | Gray        -> ConsoleColor.Gray
        | DarkGray    -> ConsoleColor.DarkGray
        | Blue        -> ConsoleColor.Blue
        | Green       -> ConsoleColor.Green
        | Cyan        -> ConsoleColor.Cyan
        | Red         -> ConsoleColor.Red
        | Magenta     -> ConsoleColor.Magenta
        | Yellow      -> ConsoleColor.Yellow
        | White       -> ConsoleColor.White
        | color -> failwithf "%A: Not yet supported!" color



    type Key =
        | A | B | C | D | E | F | G | H | I | J | K | L | M
        | N | O | P | Q | R | S | T | U | V | W | X | Y | Z
        | N0 | N1 | N2 | N3 | N4
        | N5 | N6 | N7 | N8 | N9

    let consoleKeyToKey consoleKey =
        match consoleKey with
        | ConsoleKey.B  -> B
        | ConsoleKey.C  -> C
        | ConsoleKey.D  -> D
        | ConsoleKey.E  -> E
        | ConsoleKey.F  -> F
        | ConsoleKey.G  -> G
        | ConsoleKey.H  -> H
        | ConsoleKey.I  -> I
        | ConsoleKey.J  -> J
        | ConsoleKey.K  -> K
        | ConsoleKey.L  -> L
        | ConsoleKey.M  -> M
        | ConsoleKey.N  -> N
        | ConsoleKey.O  -> O
        | ConsoleKey.P  -> P
        | ConsoleKey.Q  -> Q
        | ConsoleKey.R  -> R
        | ConsoleKey.S  -> S
        | ConsoleKey.T  -> T
        | ConsoleKey.U  -> U
        | ConsoleKey.V  -> V
        | ConsoleKey.W  -> W
        | ConsoleKey.X  -> X
        | ConsoleKey.Y  -> Y
        | ConsoleKey.Z  -> Z
        | ConsoleKey.D0 -> N0
        | ConsoleKey.D1 -> N1
        | ConsoleKey.D2 -> N2
        | ConsoleKey.D3 -> N3
        | ConsoleKey.D4 -> N4
        | ConsoleKey.D5 -> N5
        | ConsoleKey.D6 -> N6
        | ConsoleKey.D7 -> N7
        | ConsoleKey.D8 -> N8
        | ConsoleKey.D9 -> N9
        | consoleKey -> failwithf "%A: Not yet supported!" consoleKey

    let keyToConsoleKey key =
        match key with
        | A  -> ConsoleKey.A
        | B  -> ConsoleKey.B
        | C  -> ConsoleKey.C
        | D  -> ConsoleKey.D
        | E  -> ConsoleKey.E
        | F  -> ConsoleKey.F
        | G  -> ConsoleKey.G
        | H  -> ConsoleKey.H
        | I  -> ConsoleKey.I
        | J  -> ConsoleKey.J
        | K  -> ConsoleKey.K
        | L  -> ConsoleKey.L
        | M  -> ConsoleKey.M
        | N  -> ConsoleKey.N
        | O  -> ConsoleKey.O
        | P  -> ConsoleKey.P
        | Q  -> ConsoleKey.Q
        | R  -> ConsoleKey.R
        | S  -> ConsoleKey.S
        | T  -> ConsoleKey.T
        | U  -> ConsoleKey.U
        | V  -> ConsoleKey.V
        | W  -> ConsoleKey.W
        | X  -> ConsoleKey.X
        | Y  -> ConsoleKey.Y
        | Z  -> ConsoleKey.Z
        | N0 -> ConsoleKey.D0
        | N1 -> ConsoleKey.D1
        | N2 -> ConsoleKey.D2
        | N3 -> ConsoleKey.D3
        | N4 -> ConsoleKey.D4
        | N5 -> ConsoleKey.D5
        | N6 -> ConsoleKey.D6
        | N7 -> ConsoleKey.D7
        | N8 -> ConsoleKey.D8
        | N9 -> ConsoleKey.D9
        | key -> failwithf "%A: Not yet supported!" key



    type ModifiersKey =
        | Control
        | Alt
        | Shift

    let consoleModifiersToModifiersKey consoleModifiers =
        match consoleModifiers with
        | ConsoleModifiers.Control -> Control
        | ConsoleModifiers.Alt     -> Alt
        | ConsoleModifiers.Shift   -> Shift
        | consoleModifiers -> failwithf "%A: Not yet supported!" consoleModifiers

    let modifiersKeyToConsoleModifiers modifiersKey =
        match modifiersKey with
        | Control -> ConsoleModifiers.Control
        | Alt     -> ConsoleModifiers.Alt
        | Shift   -> ConsoleModifiers.Shift
        | modifiersKey -> failwithf "%A: Not yet supported!" modifiersKey

#endif
