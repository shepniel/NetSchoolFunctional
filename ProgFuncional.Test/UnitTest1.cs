using System;
using System.Collections.Generic;
using Xunit;

namespace ProgFuncional.Test
{
    public class UnitTest1
    {
        [Fact]
        public void CanDescribeCard()
        {
            var card = new Card(Rank.Ace, Suit.Spades);

            Assert.Equal("Ace of Spades", card.ToString());
        }

        [Fact]
        public void HighCardTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Jack, Suit.Spades),
        new Card(Rank.Nine, Suit.Diamonds),
        new Card(Rank.Ten, Suit.Diamonds),
        new Card(Rank.Seven, Suit.Diamonds),
    };
            var poker = new Poker();

            var highCard = poker.HighCard(pokerHand);

            Assert.Equal(Rank.Ace, highCard.Rank);
        }


        [Fact]
        public void IsPairTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Ace, Suit.Spades),
        new Card(Rank.Nine, Suit.Diamonds),
        new Card(Rank.Ten, Suit.Diamonds),
        new Card(Rank.Seven, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsPair(pokerHand));
        }

        [Fact]
        public void IsTwoPairTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Ace, Suit.Spades),
        new Card(Rank.Nine, Suit.Diamonds),
        new Card(Rank.Nine, Suit.Spades),
        new Card(Rank.Seven, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsTwoPair(pokerHand));
        }


        [Fact]
        public void IsThreeOfAKindTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Ace, Suit.Spades),
        new Card(Rank.Ace, Suit.Clubs),
        new Card(Rank.Ten, Suit.Diamonds),
        new Card(Rank.Seven, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsThreeOfAKind(pokerHand));
        }

        [Fact]
        public void IsFullHouseTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Ace, Suit.Spades),
        new Card(Rank.Nine, Suit.Diamonds),
        new Card(Rank.Nine, Suit.Clubs),
        new Card(Rank.Nine, Suit.Spades),
    };
            var poker = new Poker();

            Assert.True(poker.IsFullHouse(pokerHand));
        }

        [Fact]
        public void IsFlushTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ace, Suit.Diamonds),
        new Card(Rank.Two, Suit.Diamonds),
        new Card(Rank.Nine, Suit.Diamonds),
        new Card(Rank.Ten, Suit.Diamonds),
        new Card(Rank.Seven, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsFlush(pokerHand));
        }


        [Fact]
        public void IsStraightTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Two, Suit.Diamonds),
        new Card(Rank.Three, Suit.Spades),
        new Card(Rank.Four, Suit.Diamonds),
        new Card(Rank.Five, Suit.Diamonds),
        new Card(Rank.Six, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsStraight(pokerHand));
        }

        [Fact]
        public void IsStraightFlushTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Five, Suit.Diamonds),
        new Card(Rank.Six, Suit.Diamonds),
        new Card(Rank.Seven, Suit.Diamonds),
        new Card(Rank.Eight, Suit.Diamonds),
        new Card(Rank.Nine, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsStraightFlush(pokerHand));
        }


        [Fact]
        public void IsRoyalFlushTest_True()
        {
            var pokerHand = new List<Card>(){
        new Card(Rank.Ten, Suit.Diamonds),
        new Card(Rank.Jack, Suit.Diamonds),
        new Card(Rank.Queen, Suit.Diamonds),
        new Card(Rank.King, Suit.Diamonds),
        new Card(Rank.Ace, Suit.Diamonds),
    };
            var poker = new Poker();

            Assert.True(poker.IsRoyalFlush(pokerHand));
        }


    }
}
