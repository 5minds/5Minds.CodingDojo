// See https://aka.ms/new-console-template for more information

var columnSizes = new[] { 3, 1, 2, 7, 1, 11, 12, 3, 8, 1 }; // { 3, 1, 2, 7, 1  };
var rowSizes = new[] { 1, 8, 4, 5, 2, 21, 5, 2, 2, 17 }; // { 1, 8, 4, 5, 2 };

var whites = 0;
var blacks = 0;

for (var columnIndex = 0; columnIndex < columnSizes.Length; columnIndex++)
{
    var columnSize = columnSizes[columnIndex];
    for (var rowIndex = 0; rowIndex < rowSizes.Length; rowIndex++)
    {
        var rowSize = rowSizes[rowIndex];
        var result = columnSize * rowSize;
        var isBlack = (columnIndex + rowIndex) % 2 > 0;
        if (isBlack)
        {
            blacks += result;
        }
        else
        {
            whites += result;
        }
    }
}

Console.WriteLine($"({whites}, {blacks})");