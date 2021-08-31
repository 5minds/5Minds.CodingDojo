Public Class ChangeCalculator
    Public Shared Function CalculateChange(cost As Decimal, paid As Decimal) As Dictionary(Of Decimal, Integer)
        Dim wrongPay As String = String.Empty
        Dim count As Integer
        Dim exchangeValues() As Decimal
        Dim difference As Decimal
        Dim q As Object
        Dim endproduct As Dictionary(Of Decimal, Integer) = New Dictionary(Of Decimal, Integer)

        exchangeValues = New Decimal() {100, 50, 10, 5, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01}

        If cost < paid Then
            difference = paid - cost

            For i As Integer = 0 To exchangeValues.Length - 1
                If difference >= exchangeValues(i) Then
                    q = difference / exchangeValues(i)
                    count = Int(q)
                    endproduct.Add(exchangeValues(i), count)
                    difference -= (count * exchangeValues(i))

                End If
            Next

        Else
        End If
        Return endproduct
    End Function
End Class


'If difference > exchangeValues(i) Then
'    If exchangeValues(i) > 1 Then
'        count = difference Mod exchangeValues(i)
'    Else
'        underOne = (exchangeValues(i) * 10) Mod 10
'        count = difference Mod underOne
'    End If

'    count -= 1
'    counter(i) = count
'    count *= exchangeValues(i)
'    difference -= count
'End If
