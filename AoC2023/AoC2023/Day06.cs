namespace AoC2023
{
    public static class Day06
    {
        public static void BothParts()
        {
            var lines = File.ReadLines(Utils.InputFileName).ToArray();
            var times = lines[0].Split(":")[1].Trim().Split(" ").Where(s => s!="").Select(s => int.Parse(s)).ToList();
            var records = lines[1].Split(":")[1].Trim().Split(" ").Where(s => s != "").Select(s => int.Parse(s)).ToList();
            var time = long.Parse(new string(lines[0].Split(":")[1].Where(c => c != ' ').ToArray()));
            var record = long.Parse(new string(lines[1].Split(":")[1].Where(c => c != ' ').ToArray()));
            var noOfWays = new List<double>();
            double null1, null2;

            for (int i = 0; i < times.Count; i++) 
            {
                //null points for (time-t)t > record
                //timet-t^2-record > 0

                null1= (-times[i] + Math.Sqrt(times[i] * times[i] - 4 * records[i])) / -2;
                null2 = (-times[i] - Math.Sqrt(times[i] * times[i] - 4 * records[i])) / -2;

                if (Math.Ceiling(null1) == null1) null1 += 0.1;
                if (Math.Floor(null2) == null2) null2 -= 0.1;
                noOfWays.Add(Math.Floor(null2) - Math.Ceiling(null1) + 1);
            }
            double result = 1;
            foreach (var w in noOfWays) {
                result *= w;
            }

            Console.WriteLine("Part 1: " + result);

            null1 = (-time + Math.Sqrt(time * time - 4 * record)) / -2;
            null2 = (-time - Math.Sqrt(time * time - 4 * record)) / -2;

            if (Math.Ceiling(null1) == null1) null1 += 0.1;
            if (Math.Floor(null2) == null2) null2 -= 0.1;
            Console.WriteLine("Part 2: " + (Math.Floor(null2) - Math.Ceiling(null1) + 1));
        }

        public static void PartTwo()
        {
            var lines = File.ReadLines(Utils.InputFileName).ToArray();
            var time = long.Parse(new string(lines[0].Split(":")[1].Where(c => c != ' ').ToArray()));
            var record = long.Parse(new string(lines[1].Split(":")[1].Where(c => c != ' ').ToArray()));
            var noOfWays = new List<double>();

                //null points for (time-t)t > record
                //timet-t^2-record > 0

                var null1 = (-time + Math.Sqrt(time * time- 4 * record)) / -2;
                var null2 = (-time - Math.Sqrt(time * time - 4 * record)) / -2;

                if (Math.Ceiling(null1) == null1) null1 += 0.1;
                if (Math.Floor(null2) == null2) null2 -= 0.1;
                noOfWays.Add(Math.Floor(null2) - Math.Ceiling(null1) + 1);
            
            double result = 1;
            foreach (var w in noOfWays)
            {
                result *= w;
            }

            Console.WriteLine(result);
        }
    }
}
