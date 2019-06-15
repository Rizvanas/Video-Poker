using Core.Builders;
using System;

namespace ConsoleVideoPoker
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameHandler = new GameHandler(new PokerDeckBuilder(new Random()));
            gameHandler.Run();

            Console.WriteLine("Hello World!");
        }
    }
}
