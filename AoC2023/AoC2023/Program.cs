namespace AoC2023
{
    internal class Program
    {

        private static readonly string _inputFileName = @"..\..\..\input.txt";

        static void Main(string[] args)
        {
            //Day 1
            Day01.BothParts(isPartTwo: false); 
            Day01.BothParts(isPartTwo: true);
        }
    }
}