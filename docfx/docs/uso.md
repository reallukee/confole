# Uso

* [F#](#f)
* [C# e Visual Basic](#c-e-visual-basic)



## F#

Installa `Confole` tramite [NuGet](https://www.nuget.org/packages/Reallukee.Confole)!

```
dotnet add package Reallukee.Confole --prerelease
```

Esempio minimale dell'uso delle API di Confole!

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

Esempio minimale dell'uso delle API di Confole.Sharp!



### C#

```csharp
using System;

using Reallukee.Confole.Sharp;

Formats formats = new Formats();

formats.AddItalicFormat(true)
       .AddForegroundColorFormat(new RGBColor(255, 0, 0))
       .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

formats.ApplyAll("Hello, World!");

Console.ReadKey(true);

formats.Reset("");
```



### Visual Basic

```vb
Imports System

Imports Reallukee.Confole.Sharp

Module Program
    Sub Main()
        Dim formats As New Formats()

        formats.AddItalicFormat(True)
        formats.AddForegroundColorFormat(New RGBColor(255, 0, 0))
        formats.AddBackgroundColorFormat(New RGBColor(0, 0, 255))

        formats.ApplyAll("Hello, World!")

        Console.ReadKey(true)

        formats.Reset("")
    End Sub
End Module
```
