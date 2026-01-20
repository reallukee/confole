// Program.cs ** Confole.Sharp.Dev
//   Confole: https://github.com/reallukee/confole/

using System;

namespace Reallukee.Confole.Sharp;

internal class Program
{
    static void Main(string[] args)
    {
        Formats formats =
            Formats.Init()
                   .Italic(true)
                   .ForegroundColor(new RGBColor(255, 0, 0))
                   .BackgroundColor(new RGBColor(0, 0, 255));

        formats.ApplyAll("Hello, World!", true);

        Console.ReadKey(true);

        Formats.Reset("");

        // Alias

        /*
        Fmt fmt =
            Fmt.Init()
               .ITC(true)
               .FGC(new RGBColor(255, 0, 0))
               .BGC(new RGBColor(0, 0, 255));

        fmt.ApplyAll("Hello, World!", true);
        */
    }
}
