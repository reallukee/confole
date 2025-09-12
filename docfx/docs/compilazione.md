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

    ```pwsh
    cd .\confole\scripts\
    ```

    > [!TIP]
    > Sia `build.ps1` che `pack.ps1` accettano il parametro `-Target` che permette
    > di specificare quali progetti compilare e/o pacchetizzare.
    >
    > Il valore di default di `-Target` è `All`.
    >
    > Gli altri valori accettati sono:
    > * `Confole`
    > * `Confole.Sharp`

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
