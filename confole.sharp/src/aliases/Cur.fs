(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cur.fs

    Title       : CUR
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Cur.
                  Il modulo Cur si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Fornisce gli Alias di Cursor.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole.Sharp

open System
open System.Collections
open System.Collections.Generic

open Reallukee.Confole

[<Class>]
type Cur internal () =

    inherit Cursors ()

    // Alias modalità manuale
    static member RenderRVS () = Cursors.RenderReverse ()
    static member RenderSV  () = Cursors.RenderSave    ()
    static member RenderRST () = Cursors.RenderRestore ()

    static member RenderU  () = Cursors.RenderUp       ()
    static member RenderU  n  = Cursors.RenderUp       n
    static member RenderD  () = Cursors.RenderDown     ()
    static member RenderD  n  = Cursors.RenderDown     n
    static member RenderNX () = Cursors.RenderNext     ()
    static member RenderNX n  = Cursors.RenderNext     n
    static member RenderPV () = Cursors.RenderPrevious ()
    static member RenderPV n  = Cursors.RenderPrevious n

    static member RenderNXL () = Cursors.RenderNextLine     ()
    static member RenderNXL n  = Cursors.RenderNextLine     n
    static member RenderPVL () = Cursors.RenderPreviousLine ()
    static member RenderPVL n  = Cursors.RenderPreviousLine n

    static member RenderMV ()       = Cursors.RenderMove ()
    static member RenderMV position = Cursors.RenderMove position



    // Modalità "funzionale"
    // Sovrascrivo la logica di base.
    static member Init () = Cur ()

    static member InitWith (cur : Cur) =
        let newCur = Cur.Init ()

        newCur.CursorsList.AddRange(cur.CursorsList)

        newCur

    member this.Clear () = this.CursorsList.Clear(); this

    member this.View () =
        this.CursorsList
        |> Seq.toList
        |> Cursor.view
        |> ignore

        this

    member this.Preview () =
        this.CursorsList
        |> Seq.toList
        |> Cursor.preview
        |> ignore

        this

    member this.Reverse () = base.Reverse () :?> Cur
    member this.Save    () = base.Save    () :?> Cur
    member this.Restore () = base.Restore () :?> Cur

    member this.Up       () = base.Up       () :?> Cur
    member this.Up       n  = base.Up       n  :?> Cur
    member this.Down     () = base.Down     () :?> Cur
    member this.Down     n  = base.Down     n  :?> Cur
    member this.Next     () = base.Next     () :?> Cur
    member this.Next     n  = base.Next     n  :?> Cur
    member this.Previous () = base.Previous () :?> Cur
    member this.Previous n  = base.Previous n  :?> Cur

    member this.NextLine     () = base.NextLine     () :?> Cur
    member this.NextLine     n  = base.NextLine     n  :?> Cur
    member this.PreviousLine () = base.PreviousLine () :?> Cur
    member this.PreviousLine n  = base.PreviousLine n  :?> Cur

    member this.Move ()       = base.Move ()       :?> Cur
    member this.Move position = base.Move position :?> Cur



    // Alias modalità "funzionale"
    member this.RVS () = base.Reverse () :?> Cur
    member this.SV  () = base.Save    () :?> Cur
    member this.RST () = base.Restore () :?> Cur

    member this.U  () = base.Up       () :?> Cur
    member this.U  n  = base.Up       n  :?> Cur
    member this.D  () = base.Down     () :?> Cur
    member this.D  n  = base.Down     n  :?> Cur
    member this.NX () = base.Next     () :?> Cur
    member this.NX n  = base.Next     n  :?> Cur
    member this.PV () = base.Previous () :?> Cur
    member this.PV n  = base.Previous n  :?> Cur

    member this.NXL () = base.NextLine     () :?> Cur
    member this.NXL n  = base.NextLine     n  :?> Cur
    member this.PVL () = base.PreviousLine () :?> Cur
    member this.PVL n  = base.PreviousLine n  :?> Cur

    member this.MV ()       = base.Move ()       :?> Cur
    member this.MV position = base.Move position :?> Cur



    // Alias modalità imperativa
    static member DoRVS () = Cursors.DoReverse ()
    static member DoSV  () = Cursors.DoSave    ()
    static member DoRST () = Cursors.DoRestore ()

    static member DoU  () = Cursors.DoUp       ()
    static member DoU  n  = Cursors.DoUp       n
    static member DoD  () = Cursors.DoDown     ()
    static member DoD  n  = Cursors.DoDown     n
    static member DoNX () = Cursors.DoNext     ()
    static member DoNX n  = Cursors.DoNext     n
    static member DoPV () = Cursors.DoPrevious ()
    static member DoPV n  = Cursors.DoPrevious n

    static member DoNXL () = Cursors.DoNextLine     ()
    static member DoNXL n  = Cursors.DoNextLine     n
    static member DoPVL () = Cursors.DoPreviousLine ()
    static member DoPVL n  = Cursors.DoPreviousLine n

    static member DoMV ()       = Cursors.DoMove ()
    static member DoMV position = Cursors.DoMove position
