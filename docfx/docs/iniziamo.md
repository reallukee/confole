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
