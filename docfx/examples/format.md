# Format

## Array

```fsharp
open System

open Reallukee.Confole

[
    Format.Italic          true
    Format.ForegroundColor (Color.RGB (255, 0, 0))
    Format.BackgroundColor (Color.RGB (0, 0, 255))
]
|> Format.applyAllNewLine "Hello, World!"

Format.reset ""
```



## Builder

```fsharp
open System

open Reallukee.Confole

Format.builder {
    Format.italic          true
    Format.foregroundColor (Color.RGB (255, 0, 0))
    Format.backgroundColor (Color.RGB (0, 0, 255))
}
|> Format.applyAllNewLine "Hello, World!"

Format.reset ""
```



## Configure

```fsharp
open System

open Reallukee.Confole

Format.configureNewLine "Hello, World!" (fun formats ->
    formats
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))
)

Format.reset ""
```



## Delayed Pipeline

```fsharp
open System

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAllNewLine "Hello, World!" formats

Format.reset ""
```



## Pipeline

```fsharp
open System

open Reallukee.Confole

Format.init ()
|> Format.italic          true
|> Format.foregroundColor (Color.RGB (255, 0, 0))
|> Format.backgroundColor (Color.RGB (0, 0, 255))
|> Format.applyAllNewLine "Hello, World!"

Format.reset ""
```
