// Program.cs ** ConfoleConsoleApp
//   Confole: https://github.com/reallukee/confole

using System;

using Reallukee.Confole.Sharp;

namespace ConfoleConsoleApp;

internal class Program
{
    public static void Main(string[] args)
    {
        #if (mode == "classic")
        Formats formats = new Formats();

        formats.AddItalicFormat(true)
               .AddForegroundColorFormat(new RGBColor(255, 0, 0))
               .AddBackgroundColorFormat(new RGBColor(0, 0, 255));

        formats.ApplyAll(true, "Hello, World from ConfoleConsoleApp!");

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
        formats.AddUnderlineFormat(true);

        formats.ApplyAll(true, "https://github.com/reallukee/confole");

        Console.ReadKey(true);

        formats.Reset("");
        #endif
        #if (mode == "static")
        Formats.DoItalic("https://github.com/reallukee/confole", true);

        Console.WriteLine();

        Console.ReadKey(true);

        Formats.DoReset("");
        #endif
    }
}
