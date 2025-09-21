# Action

## Array

```fsharp
open System

open Reallukee.Confole

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

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

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

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

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

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

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

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

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Action.init ()
|> Action.eraseDisplay (Some Action.Erase.FromBeginToEnd)
|> Action.eraseLine    (Some Action.Erase.FromBeginToEnd)
|> Action.applyAll

Action.reset ()
```
