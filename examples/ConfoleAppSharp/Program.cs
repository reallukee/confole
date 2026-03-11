// Program.cs ** ConfoleAppSharp Example
//   Confole: https://github.com/reallukee/confole/

using System;

using Reallukee.Confole.Sharp;

namespace Reallukee.Confole.Examples;

internal class Program
{
    static void Main(string[] args)
    {
        Rules.DoTitle("ConfoleApp");

        Formats formats =
            Formats.Init()
                   .Italic(true)
                   .ForegroundColor(new RGBColor(255, 0, 0))
                   .BackgroundColor(new RGBColor(0, 0, 255));

        formats.ApplyAll("Hello, World from ConfoleApp!", true);

        Console.ReadKey(true);

        Formats.Reset("");
    }
}
