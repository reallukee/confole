(*
    --------
    Confole#
    --------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Cursor.fs

    Title       : CURSOR
    Description : Contiene l'implementazione delle classi,
                  delle interfacce e delle enumerazioni
                  pubbliche (e non) del modulo Cursor.
                  Il modulo Cursor si occupa di sequenze VTS
                  relative al cursore del terminale.

                  Il modulo Cursor si occupa di wrappare
                  in modo OOP e C#-Friendly l'omonimo
                  modulo funzionale!

                  Riscrittura v4!

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
type Cursors internal () =

    (*
        Per ottenere qualcosa di simile alle pipeline
        funzionali di F#, utilizziamo un design pattern di
        tipo Fluent.

        La lista mutabile deve essere esposta solo in un
        contesto sicuro e può essere modificata solamente
        dalle istanze della classe Fluent stessa.

        NOTA BENE: l’API funzionale di F# utilizza il tipo
        "T' option"; per motivi di idiomaticità, questa API
        wrapper sceglie di non esporre il tipo "T' option" e
        ricorre di conseguenza all’overloading.
        Penso sia la roba più simile in un contesto
        fortemente OOP.

        Detto questo, CIAONE!
    *)

    let mutable cursors = List<Cursor.Cursor>()

    static let mutable newLine = false

    member this.CursorsList
        with internal get () =
            cursors

        and internal set value =
            cursors <- value

    static member NewLine
        with get () =
            newLine

        and set value =
            newLine <- value



    // Modalità manuale
    member this.Renders () =
        cursors
        |> Seq.toList
        |> List.rev
        |> Cursor.renders

    static member RenderReverse () = Cursor.renderReverse ()
    static member RenderSave    () = Cursor.renderSave    ()
    static member RenderRestore () = Cursor.renderRestore ()

    static member RenderUp       () = Cursor.renderUp       None
    static member RenderUp       n  = Cursor.renderUp       (Some n)
    static member RenderDown     () = Cursor.renderDown     None
    static member RenderDown     n  = Cursor.renderDown     (Some n)
    static member RenderNext     () = Cursor.renderNext     None
    static member RenderNext     n  = Cursor.renderNext     (Some n)
    static member RenderPrevious () = Cursor.renderPrevious None
    static member RenderPrevious n  = Cursor.renderPrevious (Some n)

    static member RenderNextLine     () = Cursor.renderNextLine     None
    static member RenderNextLine     n  = Cursor.renderNextLine     (Some n)
    static member RenderPreviousLine () = Cursor.renderPreviousLine None
    static member RenderPreviousLine n  = Cursor.renderPreviousLine (Some n)

    static member RenderMove ()       = Cursor.renderMove None
    static member RenderMove position = Cursor.renderMove (Some (Position.ToFPosition position))

    static member RenderReset () = Cursor.renderReset ()



    // Modalità "funzionale"
    static member Init () = Cursors ()

    static member InitWith (cursors : Cursors) =
        let newCursors = Cursors.Init ()

        newCursors.CursorsList.AddRange(cursors.CursorsList)

        newCursors

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

    member this.Reverse () = cursors.Add(Cursor.Reverse); this
    member this.Save    () = cursors.Add(Cursor.Save   ); this
    member this.Restore () = cursors.Add(Cursor.Restore); this

    member this.Up       () = cursors.Add(Cursor.Up       None    ); this
    member this.Up       n  = cursors.Add(Cursor.Up       (Some n)); this
    member this.Down     () = cursors.Add(Cursor.Down     None    ); this
    member this.Down     n  = cursors.Add(Cursor.Down     (Some n)); this
    member this.Next     () = cursors.Add(Cursor.Next     None    ); this
    member this.Next     n  = cursors.Add(Cursor.Next     (Some n)); this
    member this.Previous () = cursors.Add(Cursor.Previous None    ); this
    member this.Previous n  = cursors.Add(Cursor.Previous (Some n)); this

    member this.NextLine     () = cursors.Add(Cursor.NextLine     None    ); this
    member this.NextLine     n  = cursors.Add(Cursor.NextLine     (Some n)); this
    member this.PreviousLine () = cursors.Add(Cursor.PreviousLine None    ); this
    member this.PreviousLine n  = cursors.Add(Cursor.PreviousLine (Some n)); this

    member this.Move ()       = cursors.Add(Cursor.Move None                                  ); this
    member this.Move position = cursors.Add(Cursor.Move (Some (Position.ToFPosition position))); this

    member this.ApplyAll () =
        cursors
        |> Seq.toList
        |> List.rev
        |> Cursor.applyAll

        if Cursors.NewLine then
            printfn ""

    member this.ApplyAll newLine =
        cursors
        |> Seq.toList
        |> List.rev
        |> Cursor.applyAll

        if newLine then
            printfn ""

    static member Reset () = Cursor.reset ()



    // Modalità imperativa
    static member DoReverse () = Cursor.doReverse ()
    static member DoSave    () = Cursor.doSave    ()
    static member DoRestore () = Cursor.doRestore ()

    static member DoUp       () = Cursor.doUp       None
    static member DoUp       n  = Cursor.doUp       (Some n)
    static member DoDown     () = Cursor.doDown     None
    static member DoDown     n  = Cursor.doDown     (Some n)
    static member DoNext     () = Cursor.doNext     None
    static member DoNext     n  = Cursor.doNext     (Some n)
    static member DoPrevious () = Cursor.doPrevious None
    static member DoPrevious n  = Cursor.doPrevious (Some n)

    static member DoNextLine     () = Cursor.doNextLine     None
    static member DoNextLine     n  = Cursor.doNextLine     (Some n)
    static member DoPreviousLine () = Cursor.doPreviousLine None
    static member DoPreviousLine n  = Cursor.doPreviousLine (Some n)

    static member DoMove ()       = Cursor.doMove None
    static member DoMove position = Cursor.doMove (Some (Position.ToFPosition position))

    static member DoReset () = Cursor.doReset ()
