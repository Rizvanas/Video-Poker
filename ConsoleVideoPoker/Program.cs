using Core.Builders;
using Core.Evaluators;
using System;

namespace ConsoleVideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var deckBuilder = new PokerDeckBuilder(new Random());
            var handEvaluator = new PokerHandEvaluator();
            var gameHandler = new GameHandler(deckBuilder, handEvaluator);

            gameHandler.Run();
        }
    }
}
