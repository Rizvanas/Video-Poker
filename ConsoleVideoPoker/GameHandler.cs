
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVideoPoker
{
    public class GameHandler
    {

        private readonly IDeckBuilder _deckBuilder;

        public GameHandler(IDeckBuilder deckBuilder)
        {
            _deckBuilder = deckBuilder;
        }

        public void Run()
        {
            var deck = _deckBuilder.BuildDeck();
        }
    }
}
