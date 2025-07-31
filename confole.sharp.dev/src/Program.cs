using System;

using Reallukee.Confole.Sharp;

namespace Reallukee.Confole.Sharp;

internal class Program
{
    static void Main(string[] args)
    {
        Rules rules = new Rules();

        rules.AddTitleRule("Confole");
        rules.AddShowCursorBlinkingRule();
        rules.AddShowCursorRule();
        rules.AddDisableDesignateMode();
        rules.AddDisableAlternativeBuffer();
        rules.AddDefaultForegroundColorRule(new RGBColor(255, 0, 0));
        rules.AddDefaultBackgroundColorRule(new RGBColor(0, 0, 0));
        rules.AddDefaultCursorColorRule(new RGBColor(255, 255, 0));

        //rules.AddRule(new RuleTitle("Confole"));
        //rules.AddRule(new ShowCursorBlinking());
        //rules.AddRule(new ShowCursor());
        //rules.AddRule(new DisableDesignateMode());
        //rules.AddRule(new DisableAlternativeBuffer());
        //rules.AddRule(DefaultForegroundColor.fromRGB(255, 0, 0));
        //rules.AddRule(DefaultBackgroundColor.fromRGB(0, 0, 0));
        //rules.AddRule(DefaultCursorColor.fromRGB(255, 255, 0));

        rules.Apply();

        Console.WriteLine("Hello, World!");

        Console.ReadKey();

        rules.Reset();

        Console.ReadKey();
    }
}
