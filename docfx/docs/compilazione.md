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
