// Program.cs ** ChangeOutputColorSharp Example
//   Confole: https://github.com/reallukee/confole/

using System;

using Reallukee.Confole.Sharp;

namespace Reallukee.Confole.Sharp.Examples;

internal class Program
{
    static void Red()
    {
        Console.WriteLine("Red");

        for (int i = 0; i < 16; i++)
        {
            Formats.DoForegroundColor("", RGBColor.FromRGB(i * 17, 0, 0));
            Formats.DoBackgroundColor("   ", RGBColor.FromRGB(i * 17, 0, 0));
        }

        Formats.DoReset("");

        Console.WriteLine("");
    }

    static void Green()
    {
        Console.WriteLine("Green");

        for (int i = 0; i < 16; i++)
        {
            Formats.DoForegroundColor("", RGBColor.FromRGB(0, i * 17, 0));
            Formats.DoBackgroundColor("   ", RGBColor.FromRGB(0, i * 17, 0));
        }

        Formats.DoReset("");

        Console.WriteLine("");
    }

    static void Blue()
    {
        Console.WriteLine("Blue");

        for (int i = 0; i < 16; i++)
        {
            Formats.DoForegroundColor("", RGBColor.FromRGB(0, 0, i * 17));
            Formats.DoBackgroundColor("   ", RGBColor.FromRGB(0, 0, i * 17));
        }

        Formats.DoReset("");

        Console.WriteLine("");
    }

    static void Main(string[] args)
    {
        Red();
        Green();
        Blue();

        Console.ReadKey();
    }
}
