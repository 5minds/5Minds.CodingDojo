Imports System

Module Program
    Sub Main(args As String())
        Console.WriteLine(args(0))
        Console.WriteLine(args(1))
        For Each arg As KeyValuePair(Of Decimal, Integer) In ChangeCalculator.CalculateChange(args(0), args(1))
            Console.WriteLine(Str(arg.Key) + " - " + Str(arg.Value) + "Euro")
        Next
        Console.ReadKey()
    End Sub
End Module
