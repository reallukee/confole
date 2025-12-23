// Program.cs ** Confole.Sharp.Dev
//   Confole: https://github.com/reallukee/confole/

using System;

using Reallukee.Confole.Sharp;

namespace Reallukee.Confole.Sharp;

internal class Program
{
    static void Main(string[] args)
    {
        Formats formats = new Formats();

        formats.AddItalic(true)
               .AddForegroundColor(new RGBColor(255, 0, 0))
               .AddBackgroundColor(new RGBColor(0, 0, 255));

        formats.ApplyAll("Hello, World!", true);

        Console.ReadKey(true);

        formats.Reset("");
    }
}
