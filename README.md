<div align="center">

<img src="./assets/confole.png" alt="confole.png" width="256px" height="256px" />

# Confole

![GitHub License](https://img.shields.io/github/license/reallukee/confole)
![GitHub Release](https://img.shields.io/github/v/release/reallukee/confole?include_prereleases)
![GitHub Build Workflow](https://img.shields.io/github/actions/workflow/status/reallukee/confole/build.yml)

🎨 Abbellisci la tua app console F# in modo funzionale

[Iniziamo](#iniziamo)
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



# Iniziamo

* [F#](#f)
* [C#](#c)



## F#

### Usando i template

1. Installa `Confole.Templates` tramite `NuGet`:

    ```
    dotnet new install Reallukee.Confole.Templates
    ```

2. Crea un nuovo progetto da template:

    ```
    dotnet new confole-app --language F# --name MyApp
    ```

    È possibile anche usare le API in stile *imperativo*:

    ```
    dotnet new confole-app --language F# --name MyApp --mode imperative
    ```

3. Esegui il template!

    ```
    dotnet run MyApp
    ```

### Usando le mani

1. Installa `Confole` tramite `NuGet`:

    ```
    dotnet add package Reallukee.Confole
    ```

2. Incolla l'esempio minimale dell'uso dell'API di `Confole`:

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

    È possibile anche usare le API in stile *imperativo*:

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

3. Esegui il progetto!

    ```
    dotnet run
    ```



## C#

> [!IMPORTANT]
> `Confole.Sharp` è wrapper OOP di `Confole`!

> [!NOTE]
> `Confole.Sharp` **INCLUDE** tutte le funzionalità di `Confole`!

### Usando i template

1. Installa `Confole.Templates` tramite `NuGet`:

    ```
    dotnet new install Reallukee.Confole.Templates
    ```

2. Crea un nuovo progetto da template:

    ```
    dotnet new confole-app --language C# --name MyApp
    ```

    È possibile anche usare le API in modo *statico*:

    ```
    dotnet new confole-app --language C# --name MyApp --mode static
    ```

3. Esegui il template!

    ```
    dotnet run MyApp
    ```

### Usando le mani

1. Installa `Confole.Sharp` tramite `NuGet`:

    ```
    dotnet add package Reallukee.Confole.Sharp
    ```

2. Incolla l'esempio minimale dell'uso dell'API di `Confole.Sharp`:

    ```csharp
    using System;

    using Reallukee.Confole.Sharp;

    Formats formats = new Formats();

    formats.AddItalic(true)
           .AddForegroundColor(new RGBColor(255, 0, 0))
           .AddBackgroundColor(new RGBColor(0, 0, 255));

    formats.ApplyAll("Hello, World!", true);

    Console.ReadKey(true);

    formats.Reset("");
    ```

    È possibile anche usare le API in modo *statico*:

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

3. Esegui il progetto!

    ```
    dotnet run
    ```



# Download

## Da GitHub

> [Download da GitHub](https://github.com/reallukee/confole/releases/latest/)

## Da NuGet

| Pacchetto                                                                         | Versione                                                                     | Downloads                                                                       |
| :-------------------------------------------------------------------------------- | :--------------------------------------------------------------------------- | :------------------------------------------------------------------------------ |
| [`Confole`](https://www.nuget.org/packages/Reallukee.Confole)                     | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole)           | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole)           |
| [`Confole#`](https://www.nuget.org/packages/Reallukee.Confole.Sharp)              | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Sharp)     | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Sharp)     |
| [`Confole Templates`](https://www.nuget.org/packages/Reallukee.Confole.Templates) | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Templates) | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Templates) |



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK o .NET 5.0+ SDK
* PowerShell 7+ (Per gli script)

### Compatibilità

Confole ha come target [.NET Standard 2.0](https://learn.microsoft.com/dotnet/standard/net-standard?tabs=net-standard-2-0)!

Sono quindi supportati i seguenti runtime:

* .NET Framework 4.6.1+
* .NET Core 2.0+ o .NET 5.0+
* Mono 5.4 o Mono 6.4

> [!NOTE]
> Per maggiori informazioni [qui](https://learn.microsoft.com/dotnet/standard/net-standard?tabs=net-standard-2-0#select-net-standard-version)!



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

### Usando *PowerShell*

> [!TIP]
> *PowerShell* è la scelta ideale in ambienti .NET oriented!

```pwsh
cd .\confole\scripts\
```

Solo compilazione:

```pwsh
.\build.ps1
```

Compilazione + Pacchettizzazione:

```pwsh
.\pack.ps1
```

### Usando le mani

```bash
cd confole
```

Solo compilazione:

```bash
dotnet build confole.slnx --configuration Release

dotnet build ./confole --configuration Release
dotnet build ./confole.sharp --configuration Release
dotnet build ./confole.templates --configuration Release
```

Compilazione + Pacchettizzazione:

```bash
dotnet pack confole.slnx --configuration Release

dotnet pack ./confole --configuration Release
dotnet pack ./confole.sharp --configuration Release
dotnet pack ./confole.templates --configuration Release
```



# Autore

* [Luca Pollicino](https://github.com/reallukee/)



# Licenza

Licenza [MIT](./LICENSE)
