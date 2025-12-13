' Program.vb ** ConfoleConsoleApp
'   Confole: https://github.com/reallukee/confole

Imports System

Imports Reallukee.Confole.Sharp

Namespace ConfoleConsoleApp

    Friend Class Program

        Public Shared Sub Main(args As String())
            #If (mode = "classic") Then
            Dim formats As New Formats()

            formats.AddItalicFormat(True) _
                   .AddForegroundColorFormat(New RGBColor(255, 0, 0)) _
                   .AddBackgroundColorFormat(New RGBColor(0, 0, 255))

            formats.ApplyAll(True, "Hello, World from ConfoleConsoleApp!")

            formats.Reset("")
            #End If
            #If (mode = "static") Then
            Formats.DoForegroundColor("", New RGBColor(255, 0, 0))
            Formats.DoBackgroundColor("", New RGBColor(0, 0, 255))
            Formats.DoItalic("Hello, World!", True)

            Console.WriteLine()

            Formats.DoReset("")
            #End If

            Console.Write("More at: ")

            #If (mode = "classic") Then
            formats.AddUnderlineFormat(True)

            formats.ApplyAll(True, "https://github.com/reallukee/confole")

            Console.ReadKey(True)

            formats.Reset("")
            #End If
            #If (mode = "static") Then
            Formats.DoItalic("https://github.com/reallukee/confole", True)

            Console.WriteLine()

            Console.ReadKey(True)

            Formats.DoReset("")
            #End If
        End Sub

    End Class

End Namespace
