using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvViewer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var parameter = ParseArguments(args);

            var rawLines = File.ReadAllLines(parameter.filePath);

            var presenter = new CsvPresenter();
            presenter.Print(rawLines, parameter.pageLen);
        }

        public static (string filePath, int pageLen) ParseArguments(string[] args)
        {
            var resFilePath = string.Empty;
            var resPageLen = 5;

            switch (args.Length)
            {
                case 1:
                    resFilePath = args[0];
                    break;
                case 2:
                    resFilePath = args[0];
                    resPageLen = Convert.ToInt32(args[1]);
                    break;
                default: throw new ArgumentException();
            }

            return (resFilePath, resPageLen);
        }

    }
}
