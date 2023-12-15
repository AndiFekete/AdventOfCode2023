namespace AoC2023
{
    public static class Day15
    {
        private static List<List<Lens>> _boxes;

        public static void PartOne()
        {
            var input = File.ReadAllText(Utils.InputFileName).ReplaceLineEndings("").Split(',');
            long result = input.Select(Hash).Sum();
            Console.WriteLine(result);
        }

        public static void PartTwo()
        {
            var input = File.ReadAllText(Utils.InputFileName).ReplaceLineEndings("").Split(',');
            _boxes = Enumerable.Range(0,256).Select(i => new List<Lens>()).ToList();
            foreach (var step in input)
            {
                if (step.Contains('='))
                {
                    var label = step.Split('=')[0];
                    var focus = int.Parse(step.Split('=')[1]);
                    var i = Hash(label);
                    var lens = _boxes[i].FirstOrDefault(l => l.Label == label);

                    if (lens != null)
                    {
                        var j = _boxes[i].IndexOf(lens);
                        _boxes[i][j].Focus = focus;
                        Console.WriteLine($"Set {label} {focus} into box {i}");
                    }
                    else
                    {
                        _boxes[i].Add(new Lens(label, focus));
                        Console.WriteLine($"Put {label} {focus} in box {i}");
                    }
                }
                else
                {
                    var label = step.TrimEnd('-');
                    var i = Hash(label);
                    var lens = _boxes[i].FirstOrDefault(l => l.Label == label);

                    if (lens != null)
                    {
                        _boxes[i].Remove(lens);
                        Console.WriteLine($"Removed {label} from box {i}");
                    }
                }
            }

            var result = 0;
            for (int i = 0; i < _boxes.Count; i++)
            {
                for (int j = 0; j < _boxes[i].Count; j++)
                {
                    result += (i + 1) * (j + 1) * _boxes[i][j].Focus;
                }
            }
            Console.WriteLine(result);
        }

        public static int Hash(string s)
        {
            int hash = 0;
            foreach (var c in s)
            {
                hash += (int)c;
                hash *= 17;
                hash = hash % 256;
            }
            return hash;
        }
    }

    public class Lens
    {
        public string Label { get; set; }
        public int Focus { get; set; }

        public Lens(string label, int focus)
        {
            Label = label;
            Focus = focus;
        }
    }
}
