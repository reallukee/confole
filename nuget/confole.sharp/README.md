![confole.png](https://raw.githubusercontent.com/reallukee/confole/main/assets/confole.png)

# Confole#

![GitHub License](https://img.shields.io/github/license/reallukee/confole)
![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Sharp)
![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Sharp)

🎨 Abbellisci la tua app console F# in modo funzionale

* [Iniziamo](#iniziamo)
* [Download](#download)
* [Compilazione](#compilazione)
* [Autore](#autore)
* [Licenza](#licenza)



### Sì tutto ok, ma la [documentazione](https://github.com/reallukee/confole)?



# Iniziamo

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

    formats.AddItalicFormat(true)
           .AddForegroundColorFormat(new RGBColor(255, 0, 0))
           .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

    formats.ApplyAll(true, "Hello, World!");

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

> [Download da GitHub](https://github.com/reallukee/confole/releases/latest)

## Da NuGet

| Pacchetto                                                                         | Versione                                                                     | Downloads                                                                       |
| :-------------------------------------------------------------------------------- | :--------------------------------------------------------------------------- | :------------------------------------------------------------------------------ |
| [`Confole#`](https://www.nuget.org/packages/Reallukee.Confole.Sharp)              | ![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Sharp)     | ![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Sharp)     |



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
```

Compilazione + Pacchettizzazione:

```bash
dotnet pack confole.slnx --configuration Release
```



# Autore

* [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
