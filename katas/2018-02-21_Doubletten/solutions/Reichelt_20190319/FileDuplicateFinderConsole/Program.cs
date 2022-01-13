using FileDuplicateFinder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileDuplicateFinderConsole
{
    /// <summary>
    /// Console application for testing the FileDuplicateFinder library
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Default path for testing
            const string SearchPath = "U:\\";

            // Requirement: default comparision method = name & size, otherwise user wants to compare only file size
            Console.WriteLine("Bitte Methode auswählen: <1> Dateigröße und Dateiname (Default) <2> Nur Dateigröße");

            try
            {
                List<IDuplicate> listOfFileDuplicates;

                switch (Console.ReadKey().Key)
                {
                    default:
                    case ConsoleKey.D1:
                        listOfFileDuplicates = new FileDuplicateCheck().FindCandidates(SearchPath, CompareModeEnum.FileSize_FileName).ToList();
                        break;
                    case ConsoleKey.D2:
                        listOfFileDuplicates = new FileDuplicateCheck().FindCandidates(SearchPath).ToList();
                        break;
                }

                // Console output
                Console.WriteLine(Environment.NewLine + Environment.NewLine + "Doppelte Dateien:");
                listOfFileDuplicates.ForEach(
                    duplicate =>
                    {
                        duplicate.FilePaths.ToList().ForEach(duplicateFile => Console.WriteLine(duplicateFile));
                    });
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("\nFehler beim Ermitteln von Dubletten: Das angegebene Verzeichnis existiert nicht oder ist nicht lesbar!");
            }
            catch (Exception)
            {
                Console.WriteLine("\nFehler beim Ermitteln von Dubletten!");
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
