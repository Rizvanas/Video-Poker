using System;
using System.Collections.Generic;
using Core.Application.Interfaces;
using Core.Domain.Enumerations;
using Core.Domain.Models;
using Core.Evaluators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTests.UnitTests.Evaluators
{
    [TestClass]
    public class PokerHandEvaluatorTests
    {
        private readonly IHandEvaluator _handEvaluator = new PokerHandEvaluator();
        [TestMethod]
        public void EvaluateHand_ReturnsRoyalFlush()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.KING },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.JACK },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.ACE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.QUEEN },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.TEN }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.ROYAL_FLUSH);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsStraightFlush()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.HEART, Rank=CardRank.KING },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.JACK },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.QUEEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.NINE }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.STRAIGHT_FLUSH);
        }

      
        [TestMethod]
        public void EvaluateHand_ReturnsFourOfAKind()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.NINE }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.FOUR_OF_A_KIND);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsFullHouse()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.NINE }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.FULL_HOUSE);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsFlush()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.SIX },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.SEVEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.ACE }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.FLUSH);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsStraight()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.EIGHT },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.QUEEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.JACK }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.STRAIGHT);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsThreeOfAKind()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.JACK }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.THREE_OF_A_KIND);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsTwoPair()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.JACK }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.TWO_PAIR);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsJacksOrBetter()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.QUEEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.QUEEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.ACE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.JACK }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.JACKS_OR_BETTER);
        }

        [TestMethod]
        public void EvaluateHand_ReturnsNothing()
        {
            var hand = new List<Card>
            {
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.HEART, Rank=CardRank.TEN },
                new Card { Suit = CardSuit.CLUB, Rank=CardRank.ACE },
                new Card { Suit = CardSuit.SPADE, Rank=CardRank.NINE },
                new Card { Suit = CardSuit.DIAMOND, Rank=CardRank.JACK }
            };

            var result = _handEvaluator.EvaluateHand(hand);
            Assert.IsTrue(result == HandValue.NOTHING);
        }


    }
}
