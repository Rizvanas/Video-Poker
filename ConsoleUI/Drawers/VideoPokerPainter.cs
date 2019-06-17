using ConsoleUI.ConsoleObjects;
using Core.Domain.Models;
using System;
using System.Text;

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
        private readonly Position _gameOverPos;

        public VideoPokerPainter()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.CursorVisible = false;

            _gameBorder = new Rectangle { Width = 100, Height = 26, Color = ConsoleColor.DarkGray };
            _infoBox = new TextBox { Color = ConsoleColor.Black };
            _titleBox = new TextBox { Color = ConsoleColor.DarkGray, Width = _gameBorder.Width - 2 };
            _card = new PokerCard();

            _gameBoardPos = new Position { X = (Console.WindowWidth - _gameBorder.Width) / 2, Y = 0 };
            _infoBoxPos1 = new Position { X = (_gameBorder.Width + _gameBorder.Width - 11) / 2, Y = _gameBorder.Height - 2 };
            _infoBoxPos2 = new Position { X = _infoBoxPos1.X, Y = _infoBoxPos1.Y - 2 };
            _titlePos = new Position { X = _gameBoardPos.X + 2, Y = 2 };
            _coinBoxPos = new Position { X = _gameBoardPos.X + 2, Y = _titlePos.Y + 3 };
            _winBoxPos = new Position { X = _gameBoardPos.X + 2, Y = _coinBoxPos.Y + 3 };
            _gameOverPos = new Position { X = _titlePos.X, Y= (_gameBorder.Height - 6) / 2 + 3 };
        }

        public void Paint(Hand hand, bool shouldDeal, bool showCards, int coins)
        {
            Console.Clear();
            _gameBorder.Draw(_gameBoardPos);
            if (coins == 0)
            {
                _titleBox.Draw(_gameOverPos, "GAME OVER");
                _infoBox.Draw(_infoBoxPos1, $"Press [spacebar] to RESTART or [esc] to QUIT");
            }
            else
            {
                _titleBox.Draw(_titlePos, "VIDEO POKER");
                _titleBox.Draw(_coinBoxPos, $"COINS: ¢{coins}");

                if (shouldDeal && showCards)
                    _titleBox.Draw(_winBoxPos, $"YOUR HAND HAS {hand.Value.ToString()}, YOU WIN: ¢{(int)hand.Value}");

                PaintCards(hand, showCards);
                _infoBox.Draw(_infoBoxPos1, $"Press [spacebar] to {(shouldDeal ? "DEAL" : "DRAW")}");

                if (!shouldDeal)
                    _infoBox.Draw(_infoBoxPos2, "Press [1-5] to toggle cards for discardment");
            }
        }

        public void PaintCards(Hand hand, bool show)
        {
            var initialPos = new Position
            {
                X = (((_gameBoardPos.X + (7 * hand.Cards.Count) / 2) + _gameBorder.Width) / 2) + 3,
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
