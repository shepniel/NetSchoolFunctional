using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFuncional
{
    public class Card : IComparable
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank.ToString()} of {Suit.ToString()}";
        }

        public int CompareTo(object obj)
        {
            return this.Rank.CompareTo(((Card)obj).Rank);
        }
    }
}
