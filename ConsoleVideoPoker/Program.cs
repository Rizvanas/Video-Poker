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
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;

            var deckBuilder = new PokerDeckBuilder(new Random());
            var handEvaluator = new PokerHandEvaluator();
            var drawer = new VideoPokerPainter();
            var gameHandler = new GameHandler(deckBuilder, handEvaluator, drawer);
            var keypressDistributor = new KeypressDistributor();
            keypressDistributor.KeyPressed += gameHandler.OnKeyPressed;

            while (gameHandler.Run())
            {
                keypressDistributor.WaitForKeyPress();
            }
        }
    }
}
