using System.Runtime.InteropServices.ComTypes;

namespace AoC2023
{
    public static class Day10
    {
        public static void PartOne()
        {
            var lines = File.ReadAllLines(Utils.InputFileName);
            var maze = new List<List<char>>();
            int x = -1, y = -1;
            foreach (var line in lines)
            {
                maze.Add(new List<char>(line));
                if (line.Contains('S'))
                {
                    y = maze.Count - 1;
                    x = line.IndexOf('S');
                    Console.WriteLine($"Starting at {x},{y}");
                }
            }

            int loopLength = 1;
            int prevX = x;
            int prevY = y;
            if (x > 0 && "-FL".Contains(maze[y][x - 1]))
                x = x - 1;
            else if (x < maze[0].Count - 1 && "-J7".Contains(maze[y][x + 1]))
                x = x + 1;
            else if (y > 0 && "|F7".Contains(maze[y - 1][x])) 
                y = y - 1;
            else if (y < maze.Count - 1 && "|JL".Contains(maze[y + 1][x])) 
                y = y + 1;
            
            while (maze[y][x] != 'S')
            {
                loopLength++;
                switch (maze[y][x])
                {
                    case '|':
                        if (prevY > y)
                        {
                            prevY = y;
                            y--;
                        }
                        else
                        {
                            prevY = y;
                            y++;
                        }
                        break;
                    case '-':
                        if (prevX > x)
                        {
                            prevX = x;
                            x--;
                        }
                        else
                        {
                            prevX = x;
                            x++;
                        }
                        break;
                    case 'J':
                        if (prevX < x)
                        {
                            prevY = y;
                            prevX = x;
                            y--;
                        }
                        else
                        {
                            prevY = y;
                            prevX = x;
                            x--;
                        }
                        break;
                    case '7':
                        if (prevX < x)
                        {
                            prevY = y;
                            prevX = x;
                            y++;
                        }
                        else
                        {
                            prevY = y;
                            prevX = x;
                            x--;
                        }
                        break;
                    case 'L':
                        if (prevX > x)
                        {
                            prevY = y;
                            prevX = x;
                            y--;
                        }
                        else
                        {
                            prevY = y;
                            prevX = x;
                            x++;
                        }
                        break;
                    case 'F':
                        if (prevX > x)
                        {
                            prevY = y;
                            prevX = x;
                            y++;
                        }
                        else
                        {
                            prevY = y;
                            prevX = x;
                            x++;
                        }
                        break;
                    default:
                        throw new Exception($"oops. next tile is {maze[y][x]}");
                }
            }
            Console.WriteLine(loopLength/2);
        }
    }
}
