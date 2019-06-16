
using Core.Domain.Models;
using Core.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleVideoPoker
{
    public class GameHandler
    {

        private readonly IDeckBuilder _deckBuilder;
        private readonly IHandEvaluator _handEvaluator;

        public GameHandler(IDeckBuilder deckBuilder, IHandEvaluator handEvaluator)
        {
            _deckBuilder = deckBuilder;
            _handEvaluator = handEvaluator;
        }

        public void Run()
        {
            var deck = _deckBuilder.BuildDeck();
            var cards = deck.Take(5).ToList();

            var hand = new Hand
            {
                Cards = cards,
                Value = _handEvaluator.EvaluateHand(cards),
                Size = cards.Count
            };
        }
    }
}
