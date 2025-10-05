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



### Sì tutto ok, ma la [documentazione](https://github.com/reallukee/confole)?



# Uso

* [F#](#f)
* [C#](#c)



## F#

Installa `Confole` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole)!

```
dotnet add package Reallukee.Confole --prerelease
```

Esempio minimale dell'uso delle API di `Confole`:

```fsharp
open System

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAllNewLine "Hello, World!" formats

do Console.ReadKey(true)
|> ignore

Format.reset ""
```

È possibile anche usare le API in stile "imperativo":

```fsharp
open System

open Reallukee.Confole

Format.doForegroundColor "" (Color.RGB (255, 0, 0))
Format.doBackgroundColor "" (Color.RGB (0, 0, 255))
Format.doBold "Hello, World!" true

do Console.ReadKey(true)
|> ignore

Format.reset ""
```

> [!NOTE]
> Più esempi [qui](./examples)!



## C#?

> [!IMPORTANT]
> `Confole.Sharp` è wrapper OOP di `Confole`!

> [!NOTE]
> `Confole.Sharp` INCLUDE tutte le funzionalità di `Confole`!

Installa `Confole.Sharp` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole.Sharp)!

```
dotnet add package Reallukee.Confole.Sharp --prerelease
```

Esempio minimale dell'uso delle API di `Confole.Sharp`:

```csharp
using System;

using Reallukee.Confole.Sharp;

Formats formats = new Formats();

formats.AddItalicFormat(true)
       .AddForegroundColorFormat(new RGBColor(255, 0, 0))
       .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

formats.ApplyAll("Hello, World!");

Console.ReadKey(true);

formats.Reset("");
```

È possibile anche usare le API in modo statico:

```csharp
using System;

using Reallukee.Confole.Sharp;

Formats.DoForegroundColor("", new RGBColor(255, 0, 0));
Formats.DoBackgroundColor("", new RGBColor(0, 0, 255));
Formats.DoItalic("Hello, World!", true);

Console.ReadKey(true);

Formats.DoReset("");
```



# Download

## GitHub

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

* [Usando *Git*](#usando-git)
* [Usando *GitHub*](#usando-github)

### Usando *Git*

```
git clone https://github.com/reallukee/confole.git
```

### Usando *GitHub*

> [Download da GitHub](https://github.com/reallukee/confole/archive/main.zip)



## 2. Compilazione

1. Usando le TUE mani:

    ```bash
    cd confole
    ```

    ### Solo compilazione:

    ```bash
    # Compila Confole
    dotnet build confole --configuration Release

    # Compila Confole.Sharp
    dotnet build confole.sharp --configuration Release
    ```

    ### Compilazione + NuGet:

    ```bash
    # Compila e pacchettizza Confole
    dotnet pack confole --configuration Release

    # Compila e pacchettizza Confole.Sharp
    dotnet pack confole.sharp --configuration Release
    ```

2. Usando *PowerShell*:

    > [!TIP]
    > *PowerShell* è la scelta ideale in ambienti .NET oriented!

    ```pwsh
    cd .\confole\scripts\
    ```

    ### Solo compilazione:

    ```pwsh
    # Compila Confole
    .\build.ps1 -Target Confole

    # Compila Confole.Sharp
    .\build.ps1 -Target Confole.Sharp
    ```

    ### Compilazione + NuGet:

    ```pwsh
    # Compila e pacchettizza Confole
    .\pack.ps1 -Target Confole

    # Compila e pacchettizza Confole.Sharp
    .\pack.ps1 -Target Confole.Sharp
    ```



# Autore

* [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
