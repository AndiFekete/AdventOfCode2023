namespace AoC2023
{
    public static class Day12
    {
        public static void BothParts(bool unfold)
        {
            var lines = File.ReadAllLines(Utils.InputFileName);
            var springs = lines.Select(s => s.Split(' ')[0]).ToList();
            var groupings = lines.Select(s => s.Split(" ")[1].Split(',').Select(int.Parse).ToList()).ToList();
            if (unfold)
            {
                springs = springs.Select(UnfoldString).ToList();
                groupings = groupings.Select(UnfoldList).ToList();
            }

            var possibilitiesCounts = new int[lines.Length];

            for (int i = 0; i < springs.Count; i++)
            {
                Console.WriteLine($"{i}/{springs.Count}");
                var possibleOrders = new List<string>(GetAllPossibleSprings(springs[i], 0));
                possibilitiesCounts[i] = CountValidOrders(possibleOrders, groupings[i]);
            }

            Console.WriteLine(possibilitiesCounts.Sum());
        }

        private static string UnfoldString(string s)
        {
            var temp = s;
            for (int i = 1; i < 5; i++)
            {
                s += ("?" + temp);
            }

            return s;
        }

        private static List<int> UnfoldList(List<int> list)
        {
            var temp = list;
            for (int i = 1; i < 5; i++)
            {
                list.AddRange(temp);
            }

            return temp;
        }

    private static int CountValidOrders(List<string> possibleOrders, List<int> grouping)
        {
            int count = 0;
            foreach (var springs in possibleOrders)
            {
                var current = springs.Split('.').Where(s => s != "").Select(s => s.Length).ToList();
                if (current.SequenceEqual(grouping))                
                    count++;
            }

            return count;
        }

        private static List<string> GetAllPossibleSprings(string spring, int index)
        {
            var all = new List<string>();
            if (index < spring.Length)
            {
                if (spring[index] == '?')
                {
                    all.AddRange(GetAllPossibleSprings(spring.Substring(0, index) + '.' + spring.Substring(index+1), index+1));
                    all.AddRange(GetAllPossibleSprings(spring.Substring(0, index) + '#' + spring.Substring(index+1), index+1));
                } 
                else all.AddRange(GetAllPossibleSprings(spring, index+1));
            }
            else all.Add(spring);

            return all;
        }
    }
}
