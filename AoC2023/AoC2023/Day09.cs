namespace AoC2023
{
    public static class Day09
    {

        public static void BothParts()
        {
            var extrapolatedValues = new List<long>();
            var extrapolatedHistoryValues = new List<long>();
            var lines = File.ReadAllLines(Utils.InputFileName);
            foreach (var line in lines)
            {
                var values = line.Split(" ").Select(s => long.Parse(s)).ToList();
                extrapolatedValues.Add(Extrapolate(values));
                values.Reverse();
                extrapolatedHistoryValues.Add(Extrapolate(values));
            }

            Console.WriteLine(extrapolatedValues.Sum());
            Console.WriteLine(extrapolatedHistoryValues.Sum());
        }

        private static long Extrapolate(List<long> values)
        {
            var diffs = new List<List<long>>() {values};
            while (diffs.Last().Any(n => n != 0))
            {
                diffs.Add(diffs.Last().Zip(diffs.Last().Skip(1), (x, y) => y - x).ToList());
            }

            long result = 0;
            for (int i = diffs.Count - 2; i >= 0; i--)
            {
                result = diffs[i].Last() + result;
            }
            return result;
        }
    }
}
