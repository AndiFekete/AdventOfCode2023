using System.Numerics;

namespace AoC2023
{
    public static class Day03
    {
        private static List<Symbol> _symbols = new List<Symbol>();
        public static List<Number> _numbers = new List<Number>();

        public static void PartOne()
        {
            int sum = 0;
            ParseInput();
            foreach (var number in _numbers)
            {
                if (IsAdjacentWithSymbol(number))
                {
                    Console.WriteLine(string.Format("Number {0} is a part number", number.Value));
                    sum += number.Value;
                }
            }
            Console.WriteLine(sum);
        }

        public static void PartTwo()
        {
            BigInteger sum = 0;
            ParseInput();
            foreach (var gear in _symbols.Where(s => s.CanBeGear))
            {
                var adjNumbers = GetAdjacentNumbers(gear);
                if (adjNumbers.Count == 2)
                {
                    Console.WriteLine(string.Format("{0},{1} is a gear!", gear.Position.X, gear.Position.Y));
                    sum += adjNumbers[0] * adjNumbers[1];
                }
            }
            Console.WriteLine(sum);
        }

        private static List<int> GetAdjacentNumbers(Symbol gear)
        {
            var adjNumbers = new List<int>();
            foreach (var number in _numbers) 
            {
                var minX = number.Position.X - 1;
                var maxX = number.Position.X + number.Length;
                var minY = number.Position.Y - 1;
                var maxY = number.Position.Y + 1;
                if (gear.Position.X <= maxX && gear.Position.X >= minX && gear.Position.Y <= maxY && gear.Position.Y >= minY)
                    adjNumbers.Add(number.Value);
            }

            return adjNumbers;
        }

        private static bool IsAdjacentWithSymbol(Number number)
        {
            var minX = number.Position.X - 1;
            var maxX = number.Position.X + number.Length;
            var minY = number.Position.Y - 1;
            var maxY = number.Position.Y + 1;

            foreach (var symbol in _symbols)
            {
                if (symbol.Position.X <= maxX && symbol.Position.X >= minX && symbol.Position.Y <= maxY && symbol.Position.Y >= minY) return true;
            }

            return false;
        }

        private static void ParseInput()
        {
            var lines = File.ReadLines(Utils.InputFileName).ToList();
            for (int y = 0; y < lines.Count(); y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    if (lines[y][x] == '.') continue;

                    if (char.IsDigit(lines[y][x]))
                    {
                        Console.WriteLine(string.Format("Found a number at {0},{1}", x, y));
                        var number = string.Concat(lines[y].Substring(x).TakeWhile(c => char.IsDigit(c)));
                        _numbers.Add(new Number(new Position(x, y), int.Parse(number), number.Length));
                        x = x + number.Length - 1;
                    }
                    else
                    {
                        Console.WriteLine(string.Format("Found a symbol at {0},{1}: {2}", x, y, lines[y][x]));
                        _symbols.Add(new Symbol(new Position(x, y), lines[y][x] == '*'));
                    }
                }
            }
        }
    }

    public class Symbol
    {
        public Position Position { get; set; }
        public bool CanBeGear { get; set; }

        public Symbol(Position position, bool isGear)
        {
            Position = position;
            CanBeGear = isGear;
        }
    }

    public class Number
    {
        public Position Position { get; set; }
        public int Length { get; set; }
        public int Value { get; set; }

        public Number(Position pos, int value, int length)
        {
            Position = pos;
            Value = value;
            Length = length;
        }
    }
}
