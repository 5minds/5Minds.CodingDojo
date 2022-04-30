using System;
using System.Threading.Tasks;

namespace PangramChecker.Application
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var validator = new PangramValidator();
            foreach (var arg in args)
            {
                Console.WriteLine(string.Concat('"', arg, '"', validator.GetPangramType(arg) switch
                {
                    EPangramType.Perfect => " contains all alphabet letters exactly once.",
                    EPangramType.Imperfect => " contains all alphabet letters more than once.",
                    EPangramType.Invalid => " does not contain all alphabet letters at least once.",
                    _ => throw new ArgumentOutOfRangeException()
                }));
            }
        }
    }
}