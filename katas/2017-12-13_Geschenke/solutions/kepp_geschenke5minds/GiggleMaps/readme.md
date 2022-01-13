## Solution for the code kata 'Geschenke'

Gigglemaps is the new navigation system named after Santa Claus' drunken elf _Giggle McGiggles_.

Santa is delivering the presents and his elf is sending him the next waypoints. Unfortunately the elf got drunk, so the route is not exact. It may be that Santa is coming more than one time to the same house.

The task is to find the number of all visited houses on his route (a route is one line from the input file).

### Requirements

- Output the number of visited houses on his route(s)
- Bonus: Output the number of all visited houses
- Bonus: Output the travelled path and show the number of visits per house

### How to run

- install [.NET Core 3.1](https://dotnet.microsoft.com/download)
- navigate to solution directory
- to run the program run `dotnet run`
- to show the bonus visualization set the bool value of the variable `visualize` to true (GiggleMaps.cs, Line 12) and run `dotnet run`

### Additional visualization info

- grid bounds are blue
- the travelled path is green
- santa is red
- the start point is yellow
- the numbers represent the visits per route
