namespace AoC2023
{
    public static class Day01
    {
        public static void BothParts(bool isPartTwo)
        {
            var lines = File.ReadLines(Utils.InputFileName);
            int sum = 0;
            foreach (var line in lines)
            {
                var newline = line;
                if (isPartTwo)
                {
                    newline = line.Replace("one", "one1one").Replace("two", "two2two").Replace("three", "three3three")
                        .Replace("four", "four4four").Replace("five", "five5five").Replace("six", "six6six").Replace("seven", "seven7seven")
                        .Replace("eight", "eight8eight").Replace("nine", "nine9nine");
                }
                
                int x = newline.First(c => char.IsDigit(c)) - 48;
                int y = newline.Last(c => char.IsDigit(c)) - 48;
                sum += 10 * x + y;
            }

            Console.WriteLine(sum);
        }
    }
}
