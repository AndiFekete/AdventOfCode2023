using System.Numerics;

namespace AoC2023
{
    public class Day02
    {
        public static void BothParts()
        {
            var lines = File.ReadLines(Utils.InputFileName);
            int p1sum = 0;
            BigInteger p2sum = 0;
            var games = new List<List<Dictionary<string, int>>>();
            foreach (var line in lines)
            {
                var game = new List<Dictionary<string, int>>();
                var sets = line.Split(':')[1].Split(';').ToList();
                foreach (var set in sets)
                {
                    Dictionary<string,int> current = ReadSet(set);
                    game.Add(current);
                }
                games.Add(game);

                if (GamePossible(game))
                    p1sum += games.Count;

                p2sum += CalculatePower(game);
            }

            Console.WriteLine("Part 1: " + p1sum);
            Console.WriteLine("Part 2: " + p2sum);
        }

        private static BigInteger CalculatePower(List<Dictionary<string, int>> game)
        {
            var maxBlue = game.Select(set => set["blue"]).Max();
            var maxGreen = game.Select(set => set["green"]).Max();
            var maxRed = game.Select(set => set["red"]).Max();

            return maxBlue*maxGreen*maxRed;
        }

        private static bool GamePossible(List<Dictionary<string, int>> game)
        {
            foreach (var set in game)
            {
                if (set["blue"] > 14 || set["green"] > 13 || set["red"] > 12) return false;
            }
            return true;
        }

        private static Dictionary<string, int> ReadSet(string set)
        {
            var result = new Dictionary<string, int>
            {
                { "blue", 0 },
                { "green", 0 },
                { "red", 0 }
            };

            var cubes = set.Split(',').ToList();
            foreach (var c in cubes)
            {
                if (c.Contains("blue"))
                    result["blue"] = int.Parse(c.TrimStart().Split(" ")[0]);
                if (c.Contains("green"))
                    result["green"] = int.Parse(c.TrimStart().Split(" ")[0]);
                if (c.Contains("red"))
                    result["red"] = int.Parse(c.TrimStart().Split(" ")[0]);
            }

            return result;
        }
    }
}
