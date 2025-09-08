# Uso

## F#

Installa `Confole` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole)!

```
dotnet add package Reallukee.Confole --prerelease
```

```fsharp
open System

open Reallukee.Confole

let formats =
    Format.init ()
    |> Format.italic          true
    |> Format.foregroundColor (Color.RGB (255, 0, 0))
    |> Format.backgroundColor (Color.RGB (0, 0, 255))

Format.applyAll true "Hello, World!" formats

do Console.ReadKey(true)
|> ignore

Format.reset ""
```

> [!NOTE]
> Più esempi [qui](./examples)!



## C# e Visual Basic?

> [!IMPORTANT]
> `Confole.Sharp` è wrapper OOP di `Confole`!

Installa `Confole.Sharp` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole.Sharp)!

```
dotnet add package Reallukee.Confole.Sharp --prerelease
```

```csharp
using System;

using Reallukee.Confole.Sharp;

Formats formats = new Formats();

formats.AddItalicFormat(true)
       .AddForegroundColorFormat(new RGBColor(255, 0, 0))
       .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

formats.ApplyAll("Hello, World!");

Console.ReadKey();

formats.Reset("");
```
