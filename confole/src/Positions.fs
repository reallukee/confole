(*
    -------
    Confole
    -------

    Abbellisci la tua app console F# in modo funzionale

    https://github.com/reallukee/confole/

    File name   : Positions.fs

    Title       : POSITIONS
    Description : Contiene l'implementazione dei tipi e delle
                  funzioni pubbliche (e non) del modulo Positions.
                  Fornisce una lista di Positions out-of-the-box
                  accessibili tramite etichetta.

    Author      : Luca Pollicino
                  (https://github.com/reallukee/)
    Version     : 1.3.0
    License     : MIT
*)

namespace Reallukee.Confole

module Positions =

    open Position

    let private positions = [|
        "HOME", (0, 0), (0, 0)
    |]

    module RowCol =

        type Format =
            | RowCol
            | Cell

        let tryGet (position : string) format =
            let position = position.ToUpperInvariant()

            positions
            |> Array.tryFind (fun (name, _, _) ->
                name = position
            )
            |> Option.map (fun (_, rowCol, _) ->
                let row, col = rowCol

                match format with
                | RowCol -> Position.RowCol (row, col)
                | Cell ->
                    Position.Cell ({
                        row = row
                        col = col
                    })
                | format -> failwithf "%A: Not yet implemented!" format
            )

        let get position format =
            match tryGet position format with
            | Some position -> position
            | None -> failwithf "%s: Not found!" position

        let exists position =
            match tryGet position RowCol with
            | Some _ -> true
            | None -> false

    module XY =

        type Format =
            | XY
            | Coord

        let tryGet (position : string) format =
            let position = position.ToUpperInvariant()

            positions
            |> Array.tryFind (fun (name, _, _) ->
                name = position
            )
            |> Option.map (fun (_, _, xY) ->
                let x, y = xY

                match format with
                | XY -> Position.XY (x, y)
                | Coord ->
                    Position.Coord ({
                        x = x
                        y = y
                    })
                | format -> failwithf "%A: Not yet implemented!" format
            )

        let get position format =
            match tryGet position format with
            | Some position -> position
            | None -> failwithf "%s: Not found!" position

        let exists position =
            match tryGet position XY with
            | Some _ -> true
            | None -> false
