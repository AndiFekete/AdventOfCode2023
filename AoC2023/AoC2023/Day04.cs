using System.Threading.Tasks.Sources;

namespace AoC2023
{
    public static class Day04
    {
        private static List<Card> _cards = new List<Card>();

        public static void BothParts()
        {
            var lines = File.ReadLines(Utils.InputFileName);
            double sum = 0;
            int no = 1;
            foreach (var line in lines)
            {
                var card = new Card(no++);
                var nums = line.Split(':')[1].Split('|');
                foreach (var winning in nums[0].Split(' '))
                {
                    if (winning != "") 
                        card.WinningNumbers.Add(int.Parse(winning));
                }
                foreach (var your in nums[1].Split(' '))
                {
                    if (your != "")
                        card.YourNumbers.Add(int.Parse(your));
                }

                sum += card.Score;
                _cards.Add(card);
            }
            Console.WriteLine("Score: " + sum);

            //part 2
            for (int i = 0; i < _cards.Count; i++)
            {
                if (_cards[i].MatchingNumbers > 0)
                {
                    _cards.AddRange(GetOriginals(_cards[i].Number + 1, _cards[i].MatchingNumbers));
                    Console.WriteLine("Winning cards added, card count: " + _cards.Count);
                }
            }
        }
        
        private static IEnumerable<Card> GetOriginals(int start, int count)
        {
            for (int i = start; i < start+count; i++)
            {
                yield return _cards.First(c => c.Number == i);
            }
        }
    }

    public class Card
    {
        private int _matchingNumbers = -1;
        public int Number { get; set; }
        public List<int> WinningNumbers { get; set; }
        public List<int> YourNumbers { get; set; }

        public Card()
        {
            WinningNumbers = new List<int>();
            YourNumbers = new List<int>();
        }

        public Card(int num) : this()
        {
            Number = num;
        }

        public int MatchingNumbers
        {
            get
            {
                if (_matchingNumbers == -1)
                    _matchingNumbers = WinningNumbers.Intersect(YourNumbers).Count();

                return _matchingNumbers;
            }
        }

        public double Score
        {
            get
            {
                return MatchingNumbers > 0 ? Math.Pow(2, MatchingNumbers - 1) : 0;
            }
        }
    }
}
