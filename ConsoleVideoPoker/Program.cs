using ConsoleUI.Drawers;
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
            var painter = new VideoPokerPainter();

            var gameHandler = new GameHandler(deckBuilder, handEvaluator, painter);
            var keypressDistributor = new KeypressDistributor();
            keypressDistributor.KeyPressed += gameHandler.OnKeyPressed;

            while (gameHandler.Run())
            {
                keypressDistributor.WaitForKeyPress();
            }
        }
    }
}
