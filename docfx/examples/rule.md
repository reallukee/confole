# Rule

## Array

```fsharp
open System

open Reallukee.Confole

[
    Rule.Title                    "Confole"
    Rule.ShowCursorBlinking
    Rule.ShowCursor
    Rule.DisableDesignateMode
    Rule.DisableAlternativeBuffer
    Rule.CursorShape              (Some Rule.Shape.User)
    Rule.DefaultForegroundColor   (Color.RGB (255, 255, 255))
    Rule.DefaultBackgroundColor   (Color.RGB (0, 0, 0))
    Rule.DefaultCursorColor       (Color.RGB (255, 255, 255))
]
|> Rule.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
```



## Builder

```fsharp
open System

open Reallukee.Confole

Rule.builder {
    Rule.title                    "Confole"
    Rule.showCursorBlinking
    Rule.showCursor
    Rule.disableDesignateMode
    Rule.disableAlternativeBuffer
    Rule.cursorShape              (Some Rule.Shape.User)
    Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    Rule.defaultCursorColor       (Color.RGB (255, 255, 255))
}
|> Rule.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
```



## Configure

```fsharp
open System

open Reallukee.Confole

Rule.configure false (fun rules ->
    rules
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))
)

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
```



## Delayed Pipeline

```fsharp
open System

open Reallukee.Confole

let rules =
    Rule.init ()
    |> Rule.title                    "Confole"
    |> Rule.showCursorBlinking
    |> Rule.showCursor
    |> Rule.disableDesignateMode
    |> Rule.disableAlternativeBuffer
    |> Rule.cursorShape              (Some Rule.Shape.User)
    |> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))

Rule.applyAll false rules

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
```



## Pipeline

```fsharp
open System

open Reallukee.Confole

Rule.init ()
|> Rule.title                    "Confole"
|> Rule.showCursorBlinking
|> Rule.showCursor
|> Rule.disableDesignateMode
|> Rule.disableAlternativeBuffer
|> Rule.cursorShape              (Some Rule.Shape.User)
|> Rule.defaultForegroundColor   (Color.RGB (255, 255, 255))
|> Rule.defaultBackgroundColor   (Color.RGB (0, 0, 0))
|> Rule.defaultCursorColor       (Color.RGB (255, 255, 255))
|> Rule.applyAll false

printfn "Hello, World!"

if Environment.GetEnvironmentVariable("CI") <> "true" then
    do Console.ReadKey(true)
    |> ignore

Rule.reset ()
```
