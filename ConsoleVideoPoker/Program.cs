using ConsoleUI.Drawers;
using Core.Builders;
using Core.Evaluators;
using System;
using System.Text;

namespace ConsoleVideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WindowWidth = Console.LargestWindowWidth;
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.CursorVisible = false;

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
