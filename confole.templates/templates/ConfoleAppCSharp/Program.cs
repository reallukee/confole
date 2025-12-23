// Program.cs ** ConfoleApp
//   Confole: https://github.com/reallukee/confole/

using System;

using Reallukee.Confole.Sharp;

namespace ConfoleApp;

internal class Program
{
    public static void Main(string[] args)
    {
        #if (mode == "classic")
        Formats formats = new Formats();

        formats.AddItalic(true)
               .AddForegroundColor(new RGBColor(255, 0, 0))
               .AddBackgroundColor(new RGBColor(0, 0, 255));

        formats.ApplyAll("Hello, World from ConfoleApp!", true);

        formats.Reset("");
        #endif
        #if (mode == "static")
        Formats.DoForegroundColor("", new RGBColor(255, 0, 0));
        Formats.DoBackgroundColor("", new RGBColor(0, 0, 255));
        Formats.DoItalic("Hello, World!", true);

        Console.WriteLine();

        Formats.DoReset("");
        #endif

        Console.Write("More at: ");

        #if (mode == "classic")
        formats.AddUnderline(true);

        formats.ApplyAll("https://github.com/reallukee/confole/", true);

        Console.ReadKey(true);

        formats.Reset("");
        #endif
        #if (mode == "static")
        Formats.DoItalic("https://github.com/reallukee/confole/", true);

        Console.WriteLine();

        Console.ReadKey(true);

        Formats.DoReset("");
        #endif
    }
}
