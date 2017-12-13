namespace wacken
{
    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            List<Path> situation1 = new List<Path>(){
                new Path(){point1 = "point1", point2 = "point2"},
                new Path(){point1 = "point1", point2 = "point3"},
                new Path(){point1 = "point1", point2 = "point4"},
                new Path(){point1 = "point2", point2 = "point3"},
                new Path(){point1 = "point2", point2 = "point5"},
                new Path(){point1 = "point3", point2 = "point4"},
                new Path(){point1 = "point4", point2 = "point5"},
                new Path(){point1 = "point4", point2 = "point7"},
                new Path(){point1 = "point4", point2 = "point8"},
                new Path(){point1 = "point5", point2 = "point6"},
                new Path(){point1 = "point5", point2 = "point7"},
                new Path(){point1 = "point5", point2 = "point8"},
                new Path(){point1 = "point6", point2 = "point7"},
                new Path(){point1 = "point7", point2 = "point8"}
            };

            List<Path> situation2 = new List<Path>(){
                new Path(){point1 = "point1", point2 = "point2"},
                new Path(){point1 = "point1", point2 = "point3"},
                new Path(){point1 = "point1", point2 = "point4"},
                new Path(){point1 = "point1", point2 = "point5"},
                new Path(){point1 = "point2", point2 = "point3"},
                new Path(){point1 = "point2", point2 = "point4"},
                new Path(){point1 = "point2", point2 = "point5"},
                new Path(){point1 = "point3", point2 = "point4"},
                new Path(){point1 = "point3", point2 = "point7"},
                new Path(){point1 = "point4", point2 = "point8"},
                new Path(){point1 = "point5", point2 = "point6"},
                new Path(){point1 = "point5", point2 = "point7"},
                new Path(){point1 = "point6", point2 = "point7"},
                new Path(){point1 = "point7", point2 = "point8"},
            };

            List<string> points = new List<string>(){ "point1", "point2", "point3", "point4", "point5", "point6", "point7", "point8"};

            testSituation(situation2, points);

        }

        static void testSituation(List<Path> paths, List<string> points) {
            foreach (string point in points) {
                findPossiblePaths(point, paths, point, new List<string>(){point});
            }
        }

        static void findPossiblePaths(string startPoint, List<Path> situation, string currentPoint, List<string> route) {
            List<Path> currentSituation = new List<Path>(situation);

            bool validRouteFound = currentSituation.Count == 0 && startPoint == currentPoint;
            if (validRouteFound) {
                printRoute(route);
                return;
            }

            foreach (Path currentPath in currentSituation) {
                bool currentPointIsPartOfCurrentPath = currentPath.point1 == currentPoint ||
                                                       currentPath.point2 == currentPoint;

                if (!currentPointIsPartOfCurrentPath) {
                    continue;
                }

                string targetPoint = currentPath.point1;
                if (currentPath.point1 == currentPoint) {
                    targetPoint = currentPath.point2;
                }
                
                List<Path> remainingPossiblePaths = new List<Path>(currentSituation);
                List<string> currentRoute = new List<string>(route);
                currentRoute.Add(targetPoint);
                remainingPossiblePaths.Remove(currentPath);
                findPossiblePaths(startPoint, remainingPossiblePaths, targetPoint, currentRoute);
            }
        }

        public static void printRoute(List<string> route) {
            Console.WriteLine("route: ");
            foreach (string routePoint in route) {
                Console.Write(routePoint + " -> ");
            }
        }
    }
}
