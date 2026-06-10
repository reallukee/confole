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

    Oppure un progetto vuoto:

    ```
    dotnet new confole-empty-app --language F# --name MyApp
    ```

3. Esegui il template.

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
        |> Format.italic          (Some true)
        |> Format.foregroundColor (Some (Color.RGB (255, 0, 0)))
        |> Format.backgroundColor (Some (Color.RGB (0, 0, 255)))

    Format.applyAllNewLine "Hello, World!" formats

    do Console.ReadKey(true)
    |> ignore

    Format.reset ""
    ```

    Oppure il *nuovo* modulo di Alias:

    ```fsharp
    open System

    open Reallukee.Confole

    let fmt =
        Format.init ()
        |> Fmt.itc (Some true)
        |> Fmt.fgc (Some (Color.RGB (255, 0, 0)))
        |> Fmt.bgc (Some (Color.RGB (0, 0, 255)))

    Fmt.applyallnl "Hello, World!" fmt

    do Console.ReadKey(true)
    |> ignore

    Format.reset ""
    ```

    > [!NOTE]
    > Altri esempi [qui](./examples/)!

3. Esegui il progetto.

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

    Oppure un progetto vuoto:

    ```
    dotnet new confole-empty-app --language C# --name MyApp
    ```

3. Esegui il template.

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

    Formats formats =
        Formats.Init()
               .Italic(true)
               .ForegroundColor(new RGBColor(255, 0, 0))
               .BackgroundColor(new RGBColor(0, 0, 255));

    formats.ApplyAll("Hello, World!", true);

    Console.ReadKey(true);

    Formats.Reset("");
    ```

    Oppure il *nuovo* modulo di Alias:

    ```csharp
    using System;

    using Reallukee.Confole.Sharp;

    Fmt fmt =
        Fmt.Init()
            .ITC(true)
            .FGC(new RGBColor(255, 0, 0))
            .BGC(new RGBColor(0, 0, 255));

    fmt.ApplyAll("Hello, World!", true);

    Console.ReadKey(true);

    Formats.Reset("");
    ```

    > [!NOTE]
    > Altri esempi [qui](./examples/)!

3. Esegui il progetto.

    ```
    dotnet run
    ```
