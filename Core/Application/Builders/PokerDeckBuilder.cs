
using Core.Domain.Models;
using Core.Domain.Enumerations;
using Core.Interfaces;
using Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Builders

{
    public class PokerDeckBuilder : IDeckBuilder
    {
        private readonly Random _random;
        public PokerDeckBuilder(Random random)
        {
            _random = random;
        }

        public List<Card> BuildDeck()
        {
            var suits = (CardSuit[])Enum.GetValues(typeof(CardSuit));
            var ranks = (CardRank[])Enum.GetValues(typeof(CardRank));
            var deck = CreateDeck(suits, ranks);

            return deck.Shuffle(_random).ToList();
        }

        private List<Card> CreateDeck(CardSuit[] suits, CardRank[] ranks)
        {
            var deck = new List<Card>();

            foreach (var suit in suits)
            {
                foreach (var rank in ranks)
                {
                    deck.Add(new Card
                    {
                        Suit = suit,
                        Rank = rank
                    });
                }
            }

            return deck;
        }
    }
}
