# Cursor

## Array

```fsharp
open System

open Reallukee.Confole

[
    Cursor.Move (Position.ColRow (4, 2))
]
|> Cursor.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
```



## Builder

```fsharp
open System

open Reallukee.Confole

Cursor.builder {
    Cursor.move (Position.ColRow (4, 2))
}
|> Cursor.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
```



## Configure

```fsharp
open System

open Reallukee.Confole

Cursor.configure false (fun cursors ->
    cursors
    |> Cursor.move (Position.ColRow (4, 2))
)

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
```



## Delayed Pipeline

```fsharp
open System

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Position.ColRow (4, 2))

Cursor.applyAll false cursors

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
```



## Pipeline

```fsharp
open System

open Reallukee.Confole

Cursor.init ()
|> Cursor.move (Position.ColRow (4, 2))
|> Cursor.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Cursor.reset ()
```
