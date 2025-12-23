# Action

## Array

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

[
    Action.EraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.EraseLine    (Some Action.Erase.FromBeginToEnd)
]
|> Action.applyAll

Action.reset ()
```



## Builder

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

Action.builder {
    Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
}
|> Action.applyAll

Action.reset ()
```



## Configure

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

Action.configure (fun actions ->
    actions
    |> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    |> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
)

Action.reset ()
```



## Delayed Pipeline

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

let actions =
    Action.init ()
    |> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
    |> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)

Action.applyAll actions

Action.reset ()
```



## Pipeline

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

Action.init ()
|> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
|> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
|> Action.applyAll

Action.reset ()
```
