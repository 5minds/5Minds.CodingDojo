Imports System
Imports ChangeRetum
Imports Xunit

Namespace ChangeReturn.Tests
    Public Class ChanceTests
        <Fact>
        Sub TestChangeCalculationFor200PaidCost150()
            Dim result = ChangeCalculator.CalculateChange(150, 200)
            Assert.Equal(1, result.Count)
            Assert.Equal(1, result.First().Value)
            Assert.Equal(50, result.First().Key)
        End Sub

        <Fact>
        Sub TestChangeCalculationFor50PaidCost22_77()
            Dim result = ChangeCalculator.CalculateChange(22.77, 50)
            Assert.Equal(6, result.Count)
            Assert.Equal(10, result.Keys(0))
            Assert.Equal(2, result.Values(0))
            Assert.Equal(5, result.Keys(1))
            Assert.Equal(1, result.Values(1))
            Assert.Equal(0.5, result.Keys(2))
            Assert.Equal(4, result.Values(2))
            Assert.Equal(0.2, result.Keys(3))
            Assert.Equal(1, result.Values(3))
            Assert.Equal(0.02, result.Keys(4))
            Assert.Equal(1, result.Values(4))
            Assert.Equal(0.01, result.Keys(5))
            Assert.Equal(1, result.Values(5))
        End Sub

        <Fact>
        Sub TestChangeCalculationForEmpty()
            Dim result = ChangeCalculator.CalculateChange(200, 150)
            Assert.Equal(0, result.Count)

        End Sub
    End Class
End Namespace

