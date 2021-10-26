using System;

namespace GiggleMaps
{
    public class HouseCalculator
    {
        public static int GetNumberOfVisitedHouses(char[] directions, bool outputGrid)
        {
            // Get movement range
            int right = 0;
            int left = 0;
            int bottom = 0;
            int top = 0;
            foreach (char dir in directions)
            {
                if (dir == 'V') bottom++;
                if (dir == 'v') bottom++;
                if (dir == '^') top++;
                if (dir == '<') left++;
                if (dir == '>') right++;
            }

            // Get max movement
            int horizontalMax = Math.Max(left, right);
            int verticalMax = Math.Max(top, bottom);

            // Add one, so the grid width is not zero
            horizontalMax = horizontalMax == 0 ? horizontalMax + 1 : horizontalMax;
            verticalMax = verticalMax == 0 ? verticalMax + 1 : verticalMax;

            // Add one, if the movement is only one-sided
            if (right == 0 && left > 0 || right > 0 && left == 0) horizontalMax++;
            if (top == 0 && bottom > 0 || top > 0 && bottom == 0) verticalMax++;

            // Optional: Adjust the size of the resulting grid. Safe value is 2, so santa can't go out of bounds
            horizontalMax *= 1;
            verticalMax *= 1;

            // Set grid dimensions to be odd, so santa always starts in the center
            int horizontalOddSize = horizontalMax % 2 == 0 ? horizontalMax + 1 : horizontalMax;
            int verticalOddSize = verticalMax % 2 == 0 ? verticalMax + 1 : verticalMax;

            // Create grid and set start position
            int width = horizontalOddSize;
            int height = verticalOddSize;
            int[,] grid = new int[width, height];
            int currentX = width / 2;
            int currentY = height / 2;

            // Set path
            for (int i = 0; i < directions.Length + 1; i++)
            {
                // Increment house before moving to text house
                grid[currentX, currentY] += 1;

                // Increment last house and break
                if (i == directions.Length) break;

                // Reposition santa
                switch (directions[i])
                {
                    case '^':
                        currentY -= 1;
                        break;
                    case 'v':
                    case 'V':
                        currentY += 1;
                        break;
                    case '<':
                        currentX -= 1;
                        break;
                    case '>':
                        currentX += 1;
                        break;
                    default:
                        break;
                }
            }

            // Output visited houses
            int housesVisited = 0;
            foreach (var item in grid) if (item > 0) housesVisited++;
            Console.WriteLine("Number of houses visited: {0}", housesVisited);

            // Output grid to console
            if (outputGrid) Visualizer.OutputGrid(grid, width, height, currentX, currentY);

            return housesVisited;
        }
    }
}
