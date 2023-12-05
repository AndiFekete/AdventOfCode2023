namespace AoC2023
{
    public static class Day05
    {
        private static List<long> _seeds;
        private static List<List<(long source, long dest, long length)>> _maps = new List<List<(long source, long dest, long length)>>();

        public static void ParseInput()
        {
            var lines = File.ReadLines(Utils.InputFileName).ToList();
            
            _seeds = lines[0].Split(": ")[1].Split(" ").Select(s => long.Parse(s)).ToList();

            int i = 3;
            int m = 0;

            while (i < lines.Count)
            {
                _maps.Add(new List<(long source, long dest, long length)>());
                while (i < lines.Count && lines[i] != "")
                {
                    var split = lines[i].Split(" ");
                    _maps[m].Add((long.Parse(split[1]), long.Parse(split[0]), long.Parse(split[2])));
                    i++;
                }
                i += 2;
                m++;
            }
        }

        public static void PartOne()
        {
            var _results = new List<long>();
            foreach (var seed in _seeds)
            {
                var actual = seed;
                for (var i = 0; i < _maps.Count; i++)
                {
                    Console.WriteLine($"Looking for mapped value in map {i}.");
                    var temp = actual;
                    foreach (var map in _maps[i])
                    {
                        if (actual >= map.source && actual < map.source + map.length)
                        {
                            temp = map.dest + actual - map.source;
                        }
                    }
                    Console.WriteLine($"map{i}, {actual} --> {temp}");
                    actual = temp;
                }
                _results.Add(actual);
            }
            Console.WriteLine(_results.Min());
        }

        public static void PartTwo()
        {
            var found = false;
            long seed = 10646309;
            while (!found)
            {
                Console.WriteLine("--------------------------------" + seed + "--------------------------------");
                var actual = seed;

                for (var i = _maps.Count -1; i >= 0; i--)
                {
                    Console.WriteLine($"Looking for mapped value in map {i}.");
                    var temp = actual;
                    foreach (var map in _maps[i])
                    {
                        if (actual >= map.dest && actual < map.dest + map.length)
                        {
                            temp = map.source + actual - map.dest;
                        }
                    }
                    Console.WriteLine($"map{i}, {actual} --> {temp}");
                    actual = temp;
                }

                for (int i = 0; i < _seeds.Count; i += 2)
                {
                    if (actual >= _seeds[i] && actual< _seeds[i] + _seeds[i+1])
                    {
                        Console.WriteLine(seed);
                        return;
                    }
                }
                seed++;
            }
        }
    }
}
