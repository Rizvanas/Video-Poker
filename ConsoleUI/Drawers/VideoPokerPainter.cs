using ConsoleUI.ConsoleObjects;
using ConsoleUI.Interfaces;
using Core.Domain.Enumerations;
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
        private readonly PokerCard _card;
        private readonly TextBox _infoBox;
        private readonly TextBox _titleBox;

        private readonly Position _gameBoardPos;
        private readonly Position _titlePos;
        private readonly Position _infoBoxPos1;
        private readonly Position _infoBoxPos2;
        private readonly Position _coinBoxPos;
        private readonly Position _winBoxPos;

        public VideoPokerPainter()
        {
            _gameBorder = new Rectangle { Width = 100, Height = 26, Color = ConsoleColor.DarkGray };
            _infoBox = new TextBox { Color = ConsoleColor.Black };
            _titleBox = new TextBox { Color = ConsoleColor.DarkGray, Width = _gameBorder.Width - 2 };
            _card = new PokerCard();

            _gameBoardPos = new Position { X = (Console.WindowWidth - _gameBorder.Width) / 2, Y = 0 };
            _infoBoxPos1 = new Position { X = (_gameBorder.Width + _gameBorder.Width - 11) / 2, Y = _gameBorder.Height - 2 };
            _infoBoxPos2 = new Position { X = _infoBoxPos1.X, Y = _infoBoxPos1.Y + 2 };
            _titlePos = new Position { X = _gameBoardPos.X + 2, Y = 2 };
            _coinBoxPos = new Position { X = _gameBoardPos.X + 2, Y = _titlePos.Y + 3 };
            _winBoxPos = new Position { X = _gameBoardPos.X + 2, Y = _coinBoxPos.Y + 3 };
        }

        public void Paint(Hand hand, bool shouldDeal, bool showCards, int coins)
        {
            Console.Clear();
            _gameBorder.Draw(_gameBoardPos);
            _titleBox.Draw(_titlePos, "VIDEO POKER");
            _titleBox.Draw(_coinBoxPos, $"COINS: ¢{coins}");
            _titleBox.Draw(_winBoxPos, $"YOUR HAND IS {hand.Value.ToString()}, YOU WIN: ¢{(int)hand.Value}");
            PaintCards(hand, showCards);
            _infoBox.Draw(_infoBoxPos1, shouldDeal ? "Press [space] to DEAL" : "Press [space] to DRAW");
            if (!showCards)
                _infoBox.Draw(_infoBoxPos2, "Press [1-5] to select cards for discardment");
        }

        public void PaintCards(Hand hand, bool show)
        {
            var initialPos = new Position
            {
                X = ((_gameBoardPos.X + (7 * hand.Cards.Count) / 2) + _gameBorder.Width) / 2,
                Y = (_gameBorder.Height - 6) / 2
            };

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                _card.Draw(initialPos, hand.Cards[i], show);
                initialPos.X += 7;
            }
        }
    }
}
