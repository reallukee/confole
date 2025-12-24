# Cursor

## Array

```fsharp
open System

open Reallukee.Confole

[
    Cursor.Move (Some (Position.ColRow (4, 2)))
]
|> Cursor.applyAll

printfn "Hello, World!"

Cursor.reset ()
```



## Builder

```fsharp
open System

open Reallukee.Confole

Cursor.builder {
    Cursor.move (Some (Position.ColRow (4, 2)))
}
|> Cursor.applyAll

printfn "Hello, World!"

Cursor.reset ()
```



## Configure

```fsharp
open System

open Reallukee.Confole

Cursor.configure (fun cursors ->
    cursors
    |> Cursor.move (Some (Position.ColRow (4, 2)))
)

printfn "Hello, World!"

Cursor.reset ()
```



## Delayed Pipeline

```fsharp
open System

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Some (Position.ColRow (4, 2)))

Cursor.applyAll cursors

printfn "Hello, World!"

Cursor.reset ()
```



## Pipeline

```fsharp
open System

open Reallukee.Confole

Cursor.init ()
|> Cursor.move (Some (Position.ColRow (4, 2)))
|> Cursor.applyAll

printfn "Hello, World!"

Cursor.reset ()
```
