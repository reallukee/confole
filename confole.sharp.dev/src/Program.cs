using System;

using Reallukee.Confole.Sharp;

namespace Reallukee.Confole.Sharp;

internal class Program
{
    static void Main(string[] args)
    {
        Rules rules = new Rules(false);

        rules.AddTitleRule("Confole")
             .AddShowCursorBlinkingRule()
             .AddShowCursorRule()
             .AddDisableDesignateModeRule()
             .AddDisableAlternativeBufferRule()
             .AddCursorShapeRule(Shape.User)
             .AddDefaultForegroundColorRule(new RGBColor(255, 0, 0))
             .AddDefaultBackgroundColorRule(new RGBColor(0, 0, 0))
             .AddDefaultCursorColorRule(new RGBColor(255, 255, 0));

        rules.ApplyAll();

        Console.WriteLine("Hello, World!");

        Console.ReadKey(true);

        rules.Reset();
    }
}
