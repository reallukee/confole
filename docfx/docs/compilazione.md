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
