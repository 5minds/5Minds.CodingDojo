// See https://aka.ms/new-console-template for more information

using System.Security.Cryptography.X509Certificates;
using System.Xml;

var cs = new int[] { 3, 1, 2, 7, 1 };
var rs = new int[] { 1, 8, 4, 5, 2 };

var (whiteSquare, blackSquare) = GetWhiteAndBlackSquare(cs, rs);

Console.WriteLine($"Die Flächen betragen: ({whiteSquare}, {blackSquare})");

var cs1 = new int[] {3, 1, 2, 7, 1, 11, 12, 3, 8, 1 };
var rs1 = new int[] { 1, 8, 4, 5, 2, 21, 5, 2, 2, 17 };

(whiteSquare, blackSquare) = GetWhiteAndBlackSquare(cs1, rs1);

Console.WriteLine($"Die Flächen betragen: ({whiteSquare}, {blackSquare})");

var cs2 = new int[] { 3 };
var rs2 = new int[] { 2 };

(whiteSquare, blackSquare) = GetWhiteAndBlackSquare(cs2, rs2);

Console.WriteLine($"Die Flächen betragen: ({whiteSquare}, {blackSquare})");

(int, int) GetWhiteAndBlackSquare(int[] cs, int[] rs)
{
    var whiteSquare = 0;
    var blackSquare = 0;

    for (var column = 0; column < cs.Length; column++)
    {
        for (var row = 0; row < rs.Length; row++)
        {
            if (column%2 == 0)
            {
                if (row%2 == 0)
                {
                    whiteSquare += cs[column] * rs[row];
                }
                else
                {
                    blackSquare += cs[column] * rs[row];
                }
            }
            else
            {
                if (row%2 == 0)
                {
                    blackSquare += cs[column] * rs[row];
                }
                else
                {
                    whiteSquare += cs[column] * rs[row];
                }
            }
        }
    }
    
    return (whiteSquare, blackSquare);
}