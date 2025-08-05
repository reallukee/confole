<div align="center">

<img src="./assets/confole.png" width="256px" height="256px" />

# Confole

![License](https://img.shields.io/github/license/reallukee/confole)
![Release](https://img.shields.io/github/v/release/reallukee/confole?include_prereleases)
![Build](https://img.shields.io/github/actions/workflow/status/reallukee/confole/build.yml)

🎨 Una libreria funzionale per applicazioni console F#

[Uso](#uso)
•
[Compilazione](#compilazione)
•
[Autore](#autore)
•
[Licenza](#licenza)

</div>



<br />

> [!IMPORTANT]
> **JUST 4 FUN**



# Uso

```fsharp
open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

do Console.ReadKey(true)
|> ignore

Format.reset ""
```



# Compilazione

## 0. Requisiti

### Compilazione

> [!TIP]
> .NET 8.0+ SDK consigliata!

* .NET Core 2.0+ SDK

  *Oppure*

* .NET 5.0+ SDK

### Esecuzione

* .NET Framework 4.6.1+
* .NET Core 2.0+
* .NET 5.0+
* Mono 5.12+

## 1. Sorgente

```
git clone https://github.com/reallukee/confole.git
```

## 2. Compila

```
cd confole

dotnet restore confole

dotnet build confole --no-restore --configuration Release
```



# Autore

- [Luca Pollicino](https://github.com/reallukee)



# Licenza

Licenza [MIT](./LICENSE)
