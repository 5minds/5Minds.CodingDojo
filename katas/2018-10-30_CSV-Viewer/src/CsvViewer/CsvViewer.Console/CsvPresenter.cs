using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CsvViewer
{
    public class CsvPresenter
    {
        private IEnumerable<string> pageLines;
        private int FirstLineOfLastPage;
        string[] rawLines;
        int pageLen;

        public CsvPresenter(string[] rawLines, int pageLen)
        {
            this.rawLines = rawLines;
            this.pageLen = pageLen;

            SelectPageLinesForFirstPage();
        }

        public void DisplayCurrentPage()
        {
            var dataLines = this.GetRecordFromPageLines();

            var colWidths = this.CalculateColumnWidths(dataLines);

            var headline = CreateDisplayLineForRecord(dataLines.First(), colWidths);

            var underline = this.GetUnderline(colWidths);

            var displayLines = new[] { headline, underline }.Concat(dataLines.Where((r, i) => i > 0).Select(r => CreateDisplayLineForRecord(r, colWidths)));

            Console.WriteLine(string.Join("\n", displayLines));
        }

        private IEnumerable<string[]> GetRecordFromPageLines()
        {
            return pageLines.Select(l => ConvertLineToRecordFields(l, ","));
        }

        private int[] CalculateColumnWidths(IEnumerable<string[]> records)
        {
            return Enumerable.Range(0, records.First().Count())
                                                  .Select(i => records.Select(r => r[i].Length).Max())
                                                  .ToArray();
        }

        private string GetUnderline(int[] colWidths)
        {
            var underlineRecord = Enumerable.Range(0, colWidths.Length).Select(i => new string('-', colWidths[i]));
            var underline = string.Join("+", underlineRecord);

            return underline;
        }

        public void SelectPageLinesForFirstPage()
        {
            pageLines = rawLines.Take(pageLen + 1);
            FirstLineOfLastPage = 1;
        }

        public void SelectPageLinesForLastPage()
        {
            FirstLineOfLastPage = rawLines.Length - (rawLines.Length - 1) % pageLen;
            pageLines = new[] { rawLines[0] }.Concat(rawLines.Where((l, i) => i > 0 && i >= FirstLineOfLastPage));
        }

        public void SelectPageLinesForNextPage()
        {
            FirstLineOfLastPage += pageLen;
            if (FirstLineOfLastPage >= rawLines.Length)
            {
                FirstLineOfLastPage = rawLines.Length - (rawLines.Length - 1) % pageLen;
            }

            pageLines = new[] { rawLines[0] }.Concat(rawLines.Where((l, i) => i > 0 && i >= FirstLineOfLastPage && i < (FirstLineOfLastPage + pageLen)));
        }

        public void SelectPageLinesForPreviousPage()
        {
            FirstLineOfLastPage -= pageLen;
            if (FirstLineOfLastPage < 1)
            {
                FirstLineOfLastPage = 1;
            }

            pageLines = new[] { rawLines[0] }.Concat(rawLines.Where((l, i) => i > 0 && i >= FirstLineOfLastPage && i < (FirstLineOfLastPage + pageLen)));
        }

        private static string[] ConvertLineToRecordFields(string line, string delimiter)
        {
            return ConvertLineToRecordFields(line, delimiter, new List<string>()).ToArray();
        }

        private static List<string> ConvertLineToRecordFields(string line, string delimiter, List<string> fields)
        {
            if (line == "")
            {
                return fields;
            }

            if (line.StartsWith("\""))
            {
                line = line.Substring(1);
                var iApo = line.IndexOf("\"");
                fields.Add(line.Substring(0, iApo).Trim());

                line = line.Substring(iApo + 1);
                var iDelim = line.IndexOf(delimiter);
                if (iDelim >= 0)
                    line = line.Substring(iDelim + 1);
                else
                    line = "";
            }
            else
            {
                var iDelim = line.IndexOf(delimiter);
                if (iDelim >= 0)
                {
                    fields.Add(line.Substring(0, iDelim).Trim());
                    line = line.Substring(iDelim + 1);
                }
                else
                {
                    fields.Add(line.Trim());
                    line = "";
                }
            }

            return ConvertLineToRecordFields(line, delimiter, fields);
        }


        private static string CreateDisplayLineForRecord(string[] recordFields, int[] colWidths)
        {
            return string.Join("|", recordFields.Select((f, i) => f.PadRight(colWidths[i])));
        }
    }
}

