using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgFuncional
{
    public class Poker
    {
        public Card HighCard(List<Card> pokerHand)
        {
            //pokerHand.Sort();

            //return pokerHand[pokerHand.Count - 1];

            return pokerHand.OrderByDescending(x => x.Rank).FirstOrDefault();
        }

        public bool IsPair(List<Card> pokerHand)
        {
            //A A 7 9 4

            return pokerHand.GroupBy(x => x.Rank).ToDictionary(g => g.Key, g => g.Count()).Any(x => x.Value == 2);

            pokerHand.Sort();

            for (int i = 0; i < pokerHand.Count - 1; i++)
                if (pokerHand[i].Rank == pokerHand[i + 1].Rank)
                    return true;
            return false;
        }

        public bool IsTwoPair(List<Card> pokerHand)
        {

            return pokerHand.GroupBy(x => x.Rank).ToDictionary(g => g.Key, g => g.Count()).Count(x => x.Value == 2) == 2;
            pokerHand.Sort();
            var count = 0;

            for (int i = 0; i < pokerHand.Count - 1; i++)
            {
                if (pokerHand[i].Rank == pokerHand[i + 1].Rank)
                {
                    i++;
                    count++;

                    if (count == 2)
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public bool IsThreeOfAKind(List<Card> pokerHand)
        {

            return pokerHand.GroupBy(x => x.Rank).ToDictionary(g => g.Key, g => g.Count()).Any(x => x.Value == 3);

            var dicc = ToDicc(pokerHand);

            var pair = false;
            var three = false;

            foreach (var d in dicc)
            {
                if (d.Value == 3)
                {
                    three = true;
                }
                if (d.Value == 2)
                {
                    pair = true;
                }
            }
            return pair && three;

        }


        private Dictionary<Rank, int> ToDicc(List<Card> pokerHand)
        {
            pokerHand.Sort();

            var dicc = new Dictionary<Rank, int>();

            for (int i = 0; i < pokerHand.Count; i++)
            {
                if (!dicc.ContainsKey(pokerHand[i].Rank))
                {
                    dicc[pokerHand[i].Rank]++;
                }
                else
                {
                    dicc[pokerHand[i].Rank] = 1;
                }
            }

            return dicc;

        }

        public bool IsFullHouse(List<Card> pokerHand)
        {

            return IsThreeOfAKind(pokerHand) && IsPair(pokerHand);

            //var dicc = ToDicc(pokerHand);

            //var pair = false;
            //var three = false;

            //foreach (var d in dicc)
            //{
            //    if (d.Value == 3)
            //    {
            //        three = true;
            //    }
            //    if (d.Value == 2)
            //    {
            //        pair = true;
            //    }
            //}
            //return pair && three;
        }

        public bool IsFlush(List<Card> pokerHand)
        {
            #region Imperativo
            //Imperative 
            //Check with a "pivot Card" if this card has a different
            //suit then it's not a flush
            pokerHand.Sort();
            Card pivotCard = pokerHand[0];
            foreach (Card card in pokerHand)
                if (card.Suit != pivotCard.Suit)
                    return false;
            return true;
            #endregion
            #region Linq
            return pokerHand.All(currentCard => currentCard.Suit == pokerHand.First().Suit);
            #endregion
        }

        public bool IsStraight(List<Card> pokerHand)
        {
            #region Imperative
            //Imperative Version
            //Should be in order since we are evaluating that
            //If next Card rank in iteration is different 
            //from pivot card are not in sequence
            pokerHand.Sort();
            var pivotCard = pokerHand[0].Rank + 1;
            var pivotCardSuit = pokerHand[0];
            for (int i = 1; i < pokerHand.Count; i++)
            {
                if (pokerHand[i].Rank != pivotCard)
                    return false;
                pivotCard++;
            }
            return true;
            #endregion
        }

        public bool IsStraightFlush(List<Card> pokerHand)
        {
            //Re-using others Methods :p
            return IsStraight(pokerHand) 
                && IsFlush(pokerHand);
        }

        public bool IsRoyalFlush(List<Card> pokerHand)
        {
            //Re-using others Methods :p
            return IsStraight(pokerHand) 
                && IsFlush(pokerHand) 
                && (int)HighCard(pokerHand).Rank == 14;
        }
    }
}
