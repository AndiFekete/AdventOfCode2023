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
                bool found = false;
                int oldVertical = GetVerticalMirror(map);
                int oldHorizontal = GetHorizontalMirror(map);
                for (int i = 0; !found && i < map.Length; i++)
                {
                    for (int j = 0; !found && j < map[i].Length; j++)
                    {
                        char inserted = map[i][j] == '.' ? '#' : '.';
                        var tempmap = (string[])map.Clone();
                        tempmap[i] = tempmap[i].Substring(0, j) + inserted + tempmap[i].Substring(j+1, map[i].Length - j - 1);

                        int vertical = GetVerticalMirror(tempmap);
                        if (vertical > 0 && vertical != oldVertical)
                        {
                            found = true;
                            result += vertical;
                        }
                        else
                        {
                            int horizontal = GetHorizontalMirror(tempmap);
                            if (horizontal > 0 && horizontal != oldHorizontal)
                            {
                                found = true;
                                result += 100 * horizontal;
                            }
                        }
                    }
                }
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
    }
}
