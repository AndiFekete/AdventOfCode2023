using System.CodeDom.Compiler;
using System.Globalization;

namespace AoC2023
{
    public static class Day18
    {
        private static List<Position> _trenches;
        private static List<List<char>> _map;
        private static int _minX;
        private static int _minY;

        public static void PartOne()
        {
            _trenches = new List<Position>() {new(0,0)};
            var lines = File.ReadAllLines(Utils.InputFileName);

            foreach (var line in lines)
            {
                var current = _trenches.Last();
                var split = line.Split(' ');
                switch (split[0])
                {
                    case "U":
                        for (int i = 0; i < int.Parse(split[1]); i++)
                        {
                            _trenches.Add(new Position(current.X, current.Y-1));
                            current = _trenches.Last();
                        }
                        break;
                    case "D":
                        for (int i = 0; i < int.Parse(split[1]); i++)
                        {
                            _trenches.Add(new Position(current.X, current.Y + 1));
                            current = _trenches.Last();
                        }
                        break;
                    case "L":
                        for (int i = 0; i < int.Parse(split[1]); i++)
                        {
                            _trenches.Add(new Position(current.X - 1, current.Y));
                            current = _trenches.Last();
                        }
                        break;
                    case "R":
                        for (int i = 0; i < int.Parse(split[1]); i++)
                        {
                            _trenches.Add(new Position(current.X + 1, current.Y));
                            current = _trenches.Last();
                        }
                        break;
                }
            }

            GenerateMap();
            Utils.PrintStringList(_map.Select(c => new string(c.ToArray())).ToList());
            FloodFill(288,1);

            int result = _map.Sum(line => line.Count(c => c == '#'));
            Console.WriteLine(result);
        }

        public static void PartTwo()
        {
            _trenches = new List<Position>() { new(0, 0) };
            var lines = File.ReadAllLines(Utils.InputFileName);

            foreach (var line in lines)
            {
                var current = _trenches.Last();
                string hex = line.Split(" ")[2];
                int steps = int.Parse(hex.Substring(2, 5), NumberStyles.HexNumber);

                switch (hex[7])
                {
                    case '3':
                        for (int i = 0; i < steps; i++)
                        {
                            _trenches.Add(new Position(current.X, current.Y - 1));
                            current = _trenches.Last();
                        }
                        break;
                    case '1':
                        for (int i = 0; i < steps; i++)
                        {
                            _trenches.Add(new Position(current.X, current.Y + 1));
                            current = _trenches.Last();
                        }
                        break;
                    case '2':
                        for (int i = 0; i < steps; i++)
                        {
                            _trenches.Add(new Position(current.X - 1, current.Y));
                            current = _trenches.Last();
                        }
                        break;
                    case '0':
                        for (int i = 0; i < steps; i++)
                        {
                            _trenches.Add(new Position(current.X + 1, current.Y));
                            current = _trenches.Last();
                        }
                        break;
                }
            }

            GenerateMap();
            Utils.PrintStringList(_map.Select(c => new string(c.ToArray())).ToList());
            FloodFill(1, 1);

            int result = _map.Sum(line => line.Count(c => c == '#'));
            Console.WriteLine(result);
        }

        private static void GenerateMap()
        {
            int minX = _trenches.Select(t => t.X).Min();
            int minY = _trenches.Select(t => t.Y).Min();
            int maxX = _trenches.Select(t => t.X).Max();
            int maxY = _trenches.Select(t => t.Y).Max();

            _map = new List<List<char>>();
            for (int i = 0; i <= maxY - minY + 1; i++)
            {
                _map.Add(Enumerable.Range(minX, maxX - minX + 1).Select(n => '.').ToList());
            }

            foreach (var trench in _trenches)
            {
                _map[trench.Y - minY][trench.X - minX] = '#';
            }
        }

        private static void FloodFill(int x, int y)
        {
            Queue<Position> queue = new Queue<Position>();
            queue.Enqueue(new Position(x,y));

            while (queue.Count > 0)
            {
                var pos = queue.Dequeue();
                if (_map[pos.Y][pos.X] == '.')
                {
                    _map[pos.Y][pos.X] = '#';

                    if (pos.Y > 0 && _map[pos.Y - 1][pos.X] == '.')
                        queue.Enqueue(new Position(pos.X, pos.Y-1));
                    if (pos.Y < _map.Count - 1 && _map[pos.Y + 1][pos.X] == '.')
                        queue.Enqueue(new Position(pos.X, pos.Y+1));
                    if (pos.X > 0 && _map[pos.Y][pos.X-1] == '.')
                        queue.Enqueue(new Position(pos.X-1, pos.Y));
                    if (pos.X < _map[0].Count - 1 && _map[pos.Y][pos.X+1] == '.')
                        queue.Enqueue(new Position(pos.X+1, pos.Y));
                }
            }

        }
    }
}
