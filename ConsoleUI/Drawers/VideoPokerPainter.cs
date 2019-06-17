using ConsoleUI.ConsoleObjects;
using ConsoleUI.Interfaces;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Drawers
{
    public class VideoPokerPainter
    {
        private readonly Rectangle _gameBorder;
        private readonly Rectangle rectangle;

        private readonly TextBox _infoBox;

        public VideoPokerPainter()
        {
            _gameBorder = new Rectangle
            {
                Width = 100,
                Height = 26,
                Color = ConsoleColor.DarkGray
            };

            rectangle = new Rectangle     
            {
                Width = 30,
                Height = 5,
                Color = ConsoleColor.DarkGray
            };

            _infoBox = new TextBox
            {
                Color = ConsoleColor.DarkGray
            };
        }
        public void Paint(Hand hand)
        {
            var gameBoardPos = new Position { X = (Console.WindowWidth - _gameBorder.Width) / 2, Y = 0 };
            var infoBoxPos = new Position { X = (Console.WindowWidth - _gameBorder.Width) / 2 + 3, Y = 2 };
            var infoBoxPos1 = new Position { X = (Console.WindowWidth - _gameBorder.Width) / 2 + 3, Y =  5};

            _gameBorder.Draw(gameBoardPos);
            _infoBox.Draw(infoBoxPos, "Royal Flush-----800");
            _infoBox.Draw(infoBoxPos1, "Straigth Flush---50");

        }

    }
}
