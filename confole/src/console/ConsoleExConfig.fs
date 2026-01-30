namespace Reallukee.Confole

open System
open System.Linq
open System.Threading
open System.Text

#if EXPERIMENTAL

module ConsoleExConfig =

    [<Class>]
    type internal Config internal () =

        static let mutable pollingInterval = 100

        static member PollingInterval
            with get () =
                pollingInterval

            and set value =
                pollingInterval <- value

    let getPollingInterval () =
        Config.PollingInterval

    let setPollingInterval value =
        Config.PollingInterval <- value

#endif
