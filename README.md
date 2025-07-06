<div align="center">

<img src="./assets/confole.png" width="256px" height="256px" />

# Confole

![License](https://img.shields.io/github/license/reallukee/confole)
![.NET](https://img.shields.io/badge/.net-standard_2.0-512bd4)
![Build](https://img.shields.io/github/actions/workflow/status/reallukee/confole/build.yml)

🎨 Una libreria funzionale per applicazioni console F#

[Uso](#uso)
•
[Compilazione](#compilazione)
•
[Autore](#autore)
•
[Licenza](#licenza)

</div>



> [!IMPORTANT]
> **JUST 4 FUN**

# Uso

* [`Rule`](#rule)
* [`Cursor`](#cursor)
* [`Format`](#format)



## `Rule`

```fsharp
// Import Confole in F# Interactive
#r @"./confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let rules =
    Rule.init ()
    |> Rule.hideCursorBlinking
    |> Rule.hideCursor
    |> Rule.defaultForegroundColor (Color.RGB (255, 255, 255))
    |> Rule.defaultBackgroundColor (Color.RGB (0, 0, 0))
    |> Rule.defaultCursorColor     (Color.RGB (255, 255, 255))

printfn "Hello, World!"

Rule.reset ()

(* Oppure *)

Rule.init ()
|> Rule.hideCursorBlinking
|> Rule.hideCursor
|> Rule.defaultForegroundColor (Color.RGB (255, 255, 255))
|> Rule.defaultBackgroundColor (Color.RGB (0, 0, 0))
|> Rule.defaultCursorColor     (Color.RGB (255, 255, 255))
|> Rule.applyAll

Rule.applyAll rules

printfn "Hello, World!"

Rule.reset ()
```



## `Cursor`

```fsharp
// Import Confole in F# Interactive
#r @"./confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let cursors =
    Cursor.init ()
    |> Cursor.move (Position.ColRow (4, 2))

Cursor.applyAll false cursors

printfn "Hello, World!"

Cursor.reset ()

(* Oppure *)

Cursor.init ()
|> Cursor.move (Position.ColRow (4, 2))
|> Cursor.applyAll false

printfn "Hello, World!"

Cursor.reset ()
```



## `Format`

```fsharp
// Import Confole in F# Interactive
#r @"./confole/bin/Release/netstandard2.0/confole.dll"

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

Format.reset ""

(* Oppure *)

Format.init ()
|> Format.italic true
|> Format.foregroundColor (Color.RGB (255, 0, 0))
|> Format.backgroundColor (Color.RGB (0, 0, 255))
|> Format.applyAll true "Hello, World!"

Format.reset ""
```



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK

  *Oppure*

* .NET 5.0+ SDK

## 1. Sorgente

```
git clone https://github.com/reallukee/confole.git
```

## 2. Compila

```
cd confole/confole

dotnet build
```



# Autore

- [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
