namespace AoC2023
{
    public static class Utils
    {
        public static readonly string InputFileName = @"..\..\..\input.txt";

        public static void PrintStringList(List<string> data)
        {
            foreach (var line in data)
            {
                Console.WriteLine(line);
            }
        }
    }
}
