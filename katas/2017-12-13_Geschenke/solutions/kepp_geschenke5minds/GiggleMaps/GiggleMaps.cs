using System;
using System.IO;

namespace GiggleMaps
{
    class GiggleMaps
    {
        static void Main(string[] args)
        {
            string inputFile = "input.txt";
            int numberOfAllHousesVisited = 0;
            bool visualize = false;

            // Check if input file exists
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("Input file is missing!");
                return;
            }

            // Read file per line
            foreach (String line in File.ReadLines(inputFile))
            {
                // Reset directions
                char[] directions = new char[] { };

                // Get new directions
                foreach (char dir in line)
                {
                    // Check for valid directions
                    if (dir.Equals('V')
                    || dir.Equals('v')
                    || dir.Equals('^')
                    || dir.Equals('<')
                    || dir.Equals('>'))
                    {
                        // Resize array to push new direction
                        Array.Resize(ref directions, directions.Length + 1);
                        directions[directions.GetUpperBound(0)] = dir;
                    }
                }

                // Output number of visited houses per line in the input file
                numberOfAllHousesVisited += HouseCalculator.GetNumberOfVisitedHouses(directions, visualize);
            }

            // Output sum of all houses visited
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("Sum of all houses visited: {0}", numberOfAllHousesVisited);
        }
    }
}
