<div align="center">

<img src="./assets/confole.png" width="256px" height="256px" />

# Confole

![GitHub License](https://img.shields.io/github/license/reallukee/confole)
![GitHub Release](https://img.shields.io/github/v/release/reallukee/confole?include_prereleases)
![Github Build Workflow](https://img.shields.io/github/actions/workflow/status/reallukee/confole/build.yml)

🎨 Abbellisci la tua app console F# in modo funzionale

[Uso](#uso)
•
[Download](#download)
•
[Compilazione](#compilazione)
•
[Autore](#autore)
•
[Licenza](#licenza)



### Sì tutto ok, ma la [documentazione](./DOCS.md)?

</div>



# Uso

* [F#](#f)
* [C#](#c)



## F#

1. Installa `Confole` tramite `NuGet`:

    ```
    dotnet add package Reallukee.Confole
    ```

2. Incolla l'esempio minimale dell'uso delle API di `Confole`:

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

    È possibile anche usare le API in stile *imperativo*:

    ```fsharp
    open System

    open Reallukee.Confole

    Format.doForegroundColor "" (Color.RGB (255, 0, 0))
    Format.doBackgroundColor "" (Color.RGB (0, 0, 255))
    Format.doBold "Hello, World!" true

    printfn ""

    do Console.ReadKey(true)
    |> ignore

    Format.reset ""
    ```



## C#

> [!IMPORTANT]
> `Confole.Sharp` è wrapper OOP di `Confole`!

> [!NOTE]
> `Confole.Sharp` **INCLUDE** tutte le funzionalità di `Confole`!

1. Installa `Confole.Sharp` tramite `NuGet`:

    ```
    dotnet add package Reallukee.Confole.Sharp
    ```

2. Incolla l'esempio minimale dell'uso delle API di `Confole.Sharp`:

    ```csharp
    using System;

    using Reallukee.Confole.Sharp;

    Formats formats = new Formats();

    formats.AddItalicFormat(true)
           .AddForegroundColorFormat(new RGBColor(255, 0, 0))
           .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

    formats.ApplyAll(true, "Hello, World!");

    Console.ReadKey(true);

    formats.Reset("");
    ```

    È possibile anche usare le API in modo *statico*:

    ```csharp
    using System;

    using Reallukee.Confole.Sharp;

    Formats.DoForegroundColor("", new RGBColor(255, 0, 0));
    Formats.DoBackgroundColor("", new RGBColor(0, 0, 255));
    Formats.DoItalic("Hello, World!", true);

    Console.WriteLine();

    Console.ReadKey(true);

    Formats.DoReset("");
    ```



# Download

## GitHub

> [Download da GitHub](https://github.com/reallukee/confole/releases/latest)

## NuGet

| Pacchetto                                                                 | Versione                                                                 | Downloads                                                                   |
| :------------------------------------------------------------------------ | :----------------------------------------------------------------------- | :-------------------------------------------------------------------------- |
| [`Confole`](https://www.nuget.org/packages/Reallukee.Confole)             | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole)       | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole)       |
| [`Confole.Sharp`](https://www.nuget.org/packages/Reallukee.Confole.Sharp) | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Sharp) | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Sharp) |



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK o .NET 5.0+ SDK
* PowerShell 7+ (Per gli script)

### Compatibilità

> [!IMPORTANT]
> Confole ha come target .NET Standard 2.0!

* .NET Framework 4.6.1+
* .NET Core 2.0+
* .NET 5.0+
* Mono 5.12+



## 1. Sorgente

* [Usando `git`](#usando-git)
* [Usando `GitHub`](#usando-github)

### Usando `git`

```
git clone https://github.com/reallukee/confole.git
```

### Usando `GitHub`

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
    > *PowerShell* è la scelta ideale in ambienti .NET oriented!

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
