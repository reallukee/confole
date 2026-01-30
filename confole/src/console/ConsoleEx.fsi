namespace Reallukee.Confole

open System
open System.Linq
open System.Threading
open System.Text

#if EXPERIMENTAL

module ConsoleEx =

    open ConsoleExTypes
    open ConsoleExConfig

    val clear : unit -> unit

    val cls : (unit -> unit)

    val beep : frequency : int -> duration : int -> unit

    val sleep : duration : int -> unit



    // Properties
    val isCapsLockOn   : unit -> bool
    val isNumberLockOn : unit -> bool

    val getTitle : unit           -> string
    val setTitle : title : string -> unit

    val getWindowWidth  : unit         -> int
    val getWindowHeight : unit         -> int
    val setWindowWidth  : width  : int -> unit
    val setWindowHeight : height : int -> unit

    val getBufferWidth  : unit         -> int
    val getBufferHeight : unit         -> int
    val setBufferWidth  : width  : int -> unit
    val setBufferHeight : height : int -> unit

    val windowMaxWidth  : unit -> int
    val windowMaxHeight : unit -> int

    val showCursor : unit -> unit
    val hideCursor : unit -> unit

    val getForegroundColor : unit          -> Color
    val getBackgroundColor : unit          -> Color
    val setForegroundColor : color : Color -> unit
    val setBackgroundColor : color : Color -> unit

    val getfgc : (unit  -> Color)
    val setfgc : (Color -> unit )
    val getbgc : (unit  -> Color)
    val setbgc : (Color -> unit )

    val resetColor : unit -> unit



    // I/O
    val waitKey       : unit -> unit
    val waitKeySilent : unit -> unit

    val waitk  : (unit -> unit)
    val waitks : (unit -> unit)

    val waitThisKey       : key : Key * modifiersKey : ModifiersKey option -> unit
    val waitThisKeySilent : key : Key * modifiersKey : ModifiersKey option -> unit

    val readKey       : unit -> Key * ModifiersKey option
    val readKeySilent : unit -> Key * ModifiersKey option

    val readk  : (unit -> Key * ModifiersKey option)
    val readks : (unit -> Key * ModifiersKey option)



    // Cursor
    val cursorX   : unit       -> int
    val cursorY   : unit       -> int
    val cursorRow : unit       -> int
    val cursorCol : unit       -> int
    val goToX     : x    : int -> unit
    val goToY     : y    : int -> unit
    val goToRow   : row  : int -> unit
    val goToCol   : col  : int -> unit

    val cursorXY     : unit               -> int * int
    val cursorRowCol : unit               -> int * int
    val goToXY       : xY     : int * int -> unit
    val goToRowCol   : rowCol : int * int -> unit

    val goUp       : unit -> unit
    val goDown     : unit -> unit
    val goNext     : unit -> unit
    val goPrevious : unit -> unit

#endif
