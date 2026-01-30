namespace Reallukee.Confole

open System
open System.Linq
open System.Threading
open System.Text

#if EXPERIMENTAL

module ConsoleExConfig =

    [<Class>]
    type internal Config =

        internal new : unit -> Config

        static member PollingInterval : int with get, set

    val getPollingInterval : unit -> int
    val setPollingInterval : int  -> unit

#endif
