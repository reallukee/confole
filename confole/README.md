![confole.png](https://raw.githubusercontent.com/reallukee/confole/main/assets/confole.png)

# Confole

![GitHub License](https://img.shields.io/github/license/reallukee/confole)
![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole)
![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole)

🎨 Abbellisci la tua app console F# in modo funzionale

* [Uso](#uso)
* [Download](#download)
* [Compilazione](#compilazione)
* [Autore](#autore)
* [Licenza](#licenza)



### Si tutto ok, ma la [documentazione](https://github.com/reallukee/confole)?



# Uso

## F#

Installa `Confole` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole)!

```
dotnet add package Reallukee.Confole --prerelease
```

```fsharp
open System

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

> [!NOTE]
> Più esempi [qui](./examples)!

## C# e Visual Basic?

> [!IMPORTANT]
> `Confole.Sharp` è wrapper OOP di `Confole`!

Installa `Confole.Sharp` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole.Sharp)!

```
dotnet add package Reallukee.Confole.Sharp --prerelease
```

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

## NuGet

* [Confole](https://www.nuget.org/packages/Reallukee.Confole)
* [Confole.Sharp](https://www.nuget.org/packages/Reallukee.Confole.Sharp)



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK o .NET 5.0+ SDK
* PowerShell 7+ (Script)

### Esecuzione

> [!IMPORTANT]
> Confole ha come target .NET Standard 2.0!

* .NET Framework 4.6.1+
* .NET Core 2.0+
* .NET 5.0+
* Mono 5.12+

## 1. Sorgente

* [Usando *git*](#usando-git)
* [Usando *GitHub*](#usando-github)

### Usando *git*

```
git clone https://github.com/reallukee/confole.git
```

### Usando *GitHub*

>[Download da GitHub](https://github.com/reallukee/confole/archive/main.zip)



## 2. Compilazione

1. Usando le TUE mani:

    ```
    cd confole

    dotnet pack confole --configuration Release
    dotnet pack confole.sharp --configuration Release
    ```

2. Usando *PowerShell*:

    ```pwsh
    cd .\scripts\

    .\pack.ps1
    ```



# Autore

* [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
