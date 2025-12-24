![confole.png](https://raw.githubusercontent.com/reallukee/confole/main/assets/confole.png)

# Confole Templates

![GitHub License](https://img.shields.io/github/license/reallukee/confole)
![NuGet Version](https://img.shields.io/nuget/v/Reallukee.Confole.Templates)
![NuGet Downloads](https://img.shields.io/nuget/dt/Reallukee.Confole.Templates)

🎨 Abbellisci la tua app console F# in modo funzionale

* [Iniziamo](#iniziamo)
* [Download](#download)
* [Compilazione](#compilazione)
* [Autore](#autore)
* [Licenza](#licenza)



### Sì tutto ok, ma la [documentazione](https://github.com/reallukee/confole/)?



# Iniziamo

* [F#](#f)
* [C#](#c)



## F#

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



## C#

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



# Download

## Da GitHub

> [Download da GitHub](https://github.com/reallukee/confole/releases/latest/)

## Da NuGet

| Pacchetto                                                                         | Versione                                                                     | Downloads                                                                       |
| :-------------------------------------------------------------------------------- | :--------------------------------------------------------------------------- | :------------------------------------------------------------------------------ |
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

dotnet build ./confole.templates --configuration Release
```

Compilazione + Pacchettizzazione:

```bash
dotnet pack confole.slnx --configuration Release

dotnet pack ./confole.templates --configuration Release
```



# Autore

* [Luca Pollicino](https://github.com/reallukee/)



# Licenza

Licenza [MIT](https://github.com/reallukee/confole/blob/main/LICENSE)
