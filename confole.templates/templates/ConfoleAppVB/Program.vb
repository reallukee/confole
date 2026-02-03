// Program.vb ** ConfoleApp
//   Confole: https://github.com/reallukee/confole/

Imports System

Imports Reallukee.Confole.Sharp

Namespace ConfoleApp

    Friend Module Program

        Sub Main(args As String())
            Rules.DoTitle("ConfoleApp")

            Dim formats = _
                Formats.Init() _
                       .Italic(True) _
                       .ForegroundColor(New RGBColor(255, 0, 0)) _
                       .BackgroundColor(New RGBColor(0, 0, 255))

            formats.ApplyAll("Hello, World from ConfoleApp!", True)

            Console.ReadKey(True)

            Formats.Reset("")
        End Sub

    End Module

End Namespace
