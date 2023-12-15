namespace AoC2023
{
    public static class Day13
    {
        public static void PartOne()
        {
            var maps = File.ReadAllText(Utils.InputFileName).ReplaceLineEndings("\n").Split("\n\n").Select(s => s.Split("\n")).ToArray();
            var result = 0;
            foreach (var map in maps)
            {
                int vertical = GetVerticalMirror(map);
                if (vertical > 0)
                {
                    result += vertical;
                }
                else
                {
                    result += 100 * GetHorizontalMirror(map);
                }
            }
            Console.WriteLine(result);
        }

        public static void PartTwo()
        {
            var maps = File.ReadAllText(Utils.InputFileName).ReplaceLineEndings("\n").Split("\n\n").Select(s => s.Split("\n")).ToArray();
            var result = 0;
            foreach (var map in maps)
            {
                int vertical = GetVerticalMirrorWithSmudge(map);
                if (vertical > 0)
                {
                    result += vertical;
                }
                else
                {
                    result += 100 * GetHorizontalMirrorWithSmudge(map);
                }
                Console.WriteLine(result);
            }
            Console.WriteLine(result);
        }

        private static int GetVerticalMirror(string[] map)
        {
            int height = map.Length;
            int width = map[0].Length;

            for (int i = 1; i < width; i++)
            {
                bool isVerticalMirror = true;
                int rightSide = width - i;
                int mirrorWidth = Math.Min(rightSide, i);

                for (int d = 0; d < mirrorWidth && isVerticalMirror; d++)
                {
                    for (int row = 0; row < height; row++)
                    {
                        if (map[row][i - 1 - d] != map[row][i + d])
                        {
                            isVerticalMirror = false;
                        }
                    }
                }

                if (isVerticalMirror) return i;
            }

            return 0;
        }

        private static int GetHorizontalMirror(string[] map)
        {
            int height = map.Length;
            int width = map[0].Length;

            for (int i = 1; i < height; i++)
            {
                bool isHorizontalMirror = true;
                int upperPart = height - i;
                int mirrorHeight = Math.Min(upperPart, i);

                for (int d = 0; d < mirrorHeight && isHorizontalMirror; d++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (map[i - 1 - d][col] != map[i + d][col])
                        {
                            isHorizontalMirror = false;
                        }
                    }
                }

                if (isHorizontalMirror) return i;
            }

            return 0;
        }

        private static int GetVerticalMirrorWithSmudge(string[] map)
        {
            int height = map.Length;
            int width = map[0].Length;

            for (int i = 1; i < width; i++)
            {
                int smudges = 0;
                int rightSide = width - i;
                int mirrorWidth = Math.Min(rightSide, i);

                for (int d = 0; d < mirrorWidth; d++)
                {
                    for (int row = 0; row < height; row++)
                    {
                        if (map[row][i - 1 - d] != map[row][i + d])
                        {
                            smudges++;
                        }
                    }
                }

                if (smudges == 1) return i;
            }

            return 0;
        }

        private static int GetHorizontalMirrorWithSmudge(string[] map)
        {
            int height = map.Length;
            int width = map[0].Length;

            for (int i = 1; i < height; i++)
            {
                int smudges = 0;
                int upperPart = height - i;
                int mirrorHeight = Math.Min(upperPart, i);

                for (int d = 0; d < mirrorHeight; d++)
                {
                    for (int col = 0; col < width; col++)
                    {
                        if (map[i - 1 - d][col] != map[i + d][col])
                        {
                            smudges++;
                        }
                    }
                }

                if (smudges == 1) return i;
            }

            return 0;
        }
    }
}
