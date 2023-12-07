using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace AoC2023
{
    public static class Day07
    {
        private static List<Hand> _handsPartOne = new List<Hand>();
        private static List<Hand> _handsPartTwo = new List<Hand>();

        public static void BothParts()
        {
            var lines = File.ReadLines(Utils.InputFileName);
            foreach (var line in lines)
            {
                var split = line.Split(' ');
                _handsPartOne.Add(new Hand(split[0], int.Parse(split[1]), true));
                _handsPartTwo.Add(new Hand(split[0], int.Parse(split[1]), false));
            }

            var ranked = _handsPartOne.OrderBy(hand => hand).ToList();
            var ranked2 = _handsPartTwo.OrderBy(hand => hand).ToList();
            foreach (var hand in ranked2)
            { Console.WriteLine(hand.Cards + " " + hand.Type); }

            long winnings = 0;
            for (int i = 0; i<ranked.Count(); i++)
            {
                winnings += (i + 1) * ranked[i].Bid;
            }
            Console.WriteLine("Part1: " + winnings);
            
            winnings = 0;
            for (int i = 0; i<ranked2.Count(); i++)
            {
                winnings += (i + 1) * ranked2[i].Bid;
            }
            Console.WriteLine("Part2: " + winnings);
        }
    }

    public class Hand : IComparable
    {
        private readonly string _order1 = "23456789TJQKA";
        private readonly string _order2 = "J23456789TQKA";
        private bool _partOne;
        private HandType? _type;

        public string Cards { get; set; }
        public int Bid { get; set;}
        public HandType Type 
        { 
            get
            {
                if (_type == null)
                {
                    _type = HandType.HIGHCARD;
                    var grouped = Cards.GroupBy(card => card).OrderByDescending(group => group.Count());
                    if (_partOne || !Cards.Contains('J'))
                    {
                        if (grouped.Count() == 1)
                            _type = HandType.FIVE;
                        else if (grouped.First().Count() == 4)
                            _type =  HandType.FOUR;
                        else if (grouped.First().Count() == 3)
                        {
                            if (grouped.Where(group => group.Count() == 2).Count() == 1)
                                _type =  HandType.FULL;
                            else _type =  HandType.THREE;
                        }
                        else if (grouped.First().Count() == 2)
                        {
                            if (grouped.Where(group => group.Count() == 2).Count() == 2)
                                _type =  HandType.TWOPAIR;
                            else _type =  HandType.ONEPAIR;
                        }
                    }
                    else
                    {
                        var js = grouped.First(group => group.Key == 'J').Count();

                        if (grouped.Count() == 1 || grouped.First().Count() == 4)
                            _type =  HandType.FIVE;

                        else if (grouped.First().Count() == 3)
                        {
                            if (js == 3)
                            {
                                if (grouped.Last().Count() == 2) _type = HandType.FIVE;
                                else _type = HandType.FOUR;
                            }
                            else if (js == 2)
                            {   
                                _type =  HandType.FIVE;
                            }
                            else if (js == 1)
                            {
                                _type =  HandType.FOUR;
                            }
                        }
                        else if (grouped.First(group => group.Key != 'J').Count() == 2)
                        {
                            if (js == 2) _type = HandType.FOUR;
                            else
                            {
                                if (grouped.Where(group => group.Count() == 2).Count() == 2)
                                    _type = HandType.FULL;
                                else _type = HandType.THREE;
                            }
                        }
                        else if (grouped.First(group => group.Key != 'J').Count() == 1)
                        {
                            if (js == 2) _type =  HandType.THREE;
                            else _type =  HandType.ONEPAIR;
                        }
                    }
                }
                return _type.Value;
            }
        }

        public Hand(string cards, int bid, bool partOne)
        {
            Cards = cards;
            Bid = bid;
            _partOne = partOne;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            Hand otherHand = obj as Hand;
            if (otherHand != null)
            {
                if (otherHand.Type == Type)
                {
                    return Tiebreaker(this.Cards, otherHand.Cards);
                }
                else
                {
                    return this.Type.CompareTo(otherHand.Type);
                }
            }
            else
                throw new ArgumentException("Object is not a Hand");
           
        }

        private int Tiebreaker(string cards1, string cards2)
        {
            var order = _partOne ? _order1 : _order2;
            for (int i = 0; i < cards1.Length; i++)
            {
                if (order.IndexOf(cards1[i]) > order.IndexOf(cards2[i]))
                    return 1;
                if (order.IndexOf(cards1[i]) < order.IndexOf(cards2[i]))
                    return -1;
            }
            return 0;
        }
    }

    public enum HandType
    {
        HIGHCARD = 0,
        ONEPAIR = 1,
        TWOPAIR = 2,
        THREE = 3,
        FULL = 4,
        FOUR = 5,
        FIVE = 6
    }
}
