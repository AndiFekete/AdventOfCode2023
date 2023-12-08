namespace AoC2023
{
    public static class Day08
    {
        private static string _instructions;
        private static Dictionary<string, (string left, string right)> _map;

        public static void PartOne()
        {
            ParseInput();

            int i = 0;
            var current = "AAA";
            while (current != "ZZZ")
            {
                current = _instructions[i%_instructions.Length] == 'L' ? _map[current].left : _map[current].right;
                i++;
            }

            Console.WriteLine(i);
        }

        public static void PartTwo()
        {
            ParseInput();
             
            int i = 0;
            var steps = new List<long>(); 
            var current = _map.Keys.Where(s => s.Last() == 'A').ToList();
            while (current.Count > 0)
            {
                for (int j = 0; j < current.Count; j++)
                {
                    current[j] = _instructions[i % _instructions.Length] == 'L' ? _map[current[j]].left : _map[current[j]].right;
                    if (current[j].Last() == 'Z')
                    {
                        Console.WriteLine($"Finished at {i+1} steps");
                        steps.Add(i+1);
                    }
                }
                current.RemoveAll(s => s.Last() == 'Z');
                Console.WriteLine($"Current count is {current.Count}");
                i++;
            }

            Console.WriteLine(steps.Aggregate((a, b) => LCM(a, b)));
        }

        private static string ParseInput()
        {
            var lines = File.ReadLines(Utils.InputFileName);

            _instructions = lines.First();
            _map = new Dictionary<string, (string left, string right)>();

            foreach (var line in lines.TakeLast(lines.Count()-2))
            {
                var split = line.Split(" = ");
                _map.Add(split[0], (split[1].Split(',')[0].TrimStart('('), split[1].Split(',')[1].TrimStart().TrimEnd(')')));
            }

            return _instructions;
        }

        static long GCF(long a, long b)
        {
            while (b != 0)
            {
                long temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static long LCM
            (long a, long b)
        {
            return (a / GCF(a, b)) * b;
        }
    }
}
