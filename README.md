<div align="center">

<img src="./assets/confole.png" width="256px" height="256px" />

# Confole

![License](https://img.shields.io/github/license/reallukee/confole)
![Release](https://img.shields.io/github/v/release/reallukee/confole?include_prereleases)
![Build](https://img.shields.io/github/actions/workflow/status/reallukee/confole/build.yml)

🎨 Una libreria funzionale per applicazioni console F#

[Uso](#uso)
•
[Download](#download)
•
[Compilazione](#compilazione)
•
[Autore](#autore)
•
[Licenza](#licenza)

</div>



<div align="center">

# > [Documentazione](./DOCS.md) <

</div>



# Uso

```fsharp
open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

do Console.ReadKey(true)
|> ignore

Format.reset ""
```

> Più esempi [qui](./examples)!

## C# e Visual Basic?

> [!TIP]
> `Confole.Sharp` è wrapper OOP di `Confole`!

```csharp
using System;

using Reallukee.Confole.Sharp;

Formats formats = new Formats();

formats.AddItalicFormat(true)
       .AddForegroundColorFormat(new RGBColor(255, 0, 0))
       .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

formats.ApplyAll("Hello, World!");

Console.ReadKey();

formats.Reset("");
```



# Download

> [Download](https://github.com/reallukee/confole/releases/latest)



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK

  *Oppure*

* .NET 5.0+ SDK

### Esecuzione

> [!IMPORTANT]
> Confole ha come target .NET Standard 2.0!

* .NET Framework 4.6.1+
* .NET Core 2.0+
* .NET 5.0+
* Mono 5.12+

## 1. Sorgente

```
git clone https://github.com/reallukee/confole.git
```

## 2. Compila

```
cd confole

dotnet restore confole

dotnet build confole --no-restore --configuration Release
```



# Autore

- [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
