using System.Security.Cryptography.X509Certificates;

namespace AoC2023
{
    public static class Day14
    {
        private static char[][] _platform;
        
        public static void PartOne()
        {
            _platform = File.ReadAllLines(Utils.InputFileName).Select(line => line.ToCharArray()).ToArray();
            int height = _platform.Length;
            int width = _platform[0].Length;

            for (int n = 0; n < 1000000000; n++)
            {
                Console.WriteLine($"{n}th round");
                for (int j = 0; j < width; j++)
                {
                    for (int i = 1; i < height; i++)
                    {
                        if (_platform[i][j] == 'O')
                        {
                            int curr = i-1;
                            while (curr >= 0 && _platform[curr][j] == '.')
                            {
                                curr--;
                            }

                            if (curr < i - 1)
                            {
                                _platform[i][j] = '.';
                                _platform[curr+1][j] = 'O';
                            }
                        
                        }
                    }
                }
            }

            int result = 0;
            for (int i = 0; i < height; i++)
            {
                result += (height - i) * _platform[i].Count(c => c == 'O');
            }
            Console.WriteLine(result);
        }
    }
}
