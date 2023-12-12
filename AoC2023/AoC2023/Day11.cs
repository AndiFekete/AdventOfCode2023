using System.Security.Cryptography.X509Certificates;

namespace AoC2023
{
    public static class Day11
    {
        public static void BothParts(int addedSpace)
        {
            var space = File.ReadAllLines(Utils.InputFileName).ToList();
            var emptyColumns = Enumerable.Range(0, space[0].Length).ToList();
            var emptyRows = Enumerable.Range(0, space.Count).ToList();

            var galaxies = new List<(int x, int y)>();
            for (int i = 0; i < space.Count; i++)
            {
                for (int j = 0; j < space[i].Length; j++)
                {
                    if (space[i][j] == '#')
                    {
                        emptyRows.Remove(i);
                        emptyColumns.Remove(j); 
                        galaxies.Add((i,j));
                    }
                }
            }

            int helper = 0;
            foreach (var col in emptyColumns)
            {
                var gg = galaxies.Where(g => g.y > col + helper * addedSpace).ToList();
                for (int i = 0; i<gg.Count; i++)
                {
                    int ind = galaxies.IndexOf((gg[i].x, gg[i].y));
                    galaxies[ind] = (gg[i].x, gg[i].y + addedSpace);
                }

                helper++;
            }

            helper = 0;
            foreach (var row in emptyRows)
            {
                var gg = galaxies.Where(g => g.x > row + helper * addedSpace).ToList();
                for (int i = 0; i < gg.Count; i++)
                {
                    int ind = galaxies.IndexOf((gg[i].x, gg[i].y));
                    galaxies[ind] = (gg[i].x + addedSpace, gg[i].y );
                }

                helper++;
            }
            
            var distances = new List<long>();
            foreach (var (x,y) in galaxies)
            {
                foreach (var (x1, y1) in galaxies)
                {
                    var dist = Math.Abs(x-x1) + Math.Abs(y-y1);
                    distances.Add(dist);
                }
            }

            Console.WriteLine(distances.Sum()/2);
        }
    }
}