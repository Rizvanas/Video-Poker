using ConsoleUI.Enumerations;
using Core.Domain.Enumerations;
using Core.Domain.Models;
using System;

namespace ConsoleUI.ConsoleObjects
{
    public class PokerCard : Rectangle
    {
        public void Draw(Position pos, Card card, bool show)
        {
            Height = 6;
            Width = 7;
            if (!show)
            {
                DrawClosedCard(pos);
            }
            else
            {
                DrawSuit(pos, card.Suit);
                DrawRank(pos, card.Rank);
                if (card.IsSelected)
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                Draw(pos);
                Console.ResetColor();
            }
        }

        private void DrawSuit(Position pos, CardSuit suit)
        {
            string suitSymbol = GetDrawingSymbol(suit);
            if(suit == CardSuit.DIAMOND || suit == CardSuit.HEART)
                Console.ForegroundColor = ConsoleColor.Red;
            WriteAt(suitSymbol, pos, 1, 1);
            WriteAt(suitSymbol, pos, 1, Height - 1);
            WriteAt(suitSymbol, pos, Width - 2, 1);
            WriteAt(suitSymbol, pos, Width - 2, Height - 1);
            Console.ResetColor();
        }

        private void DrawRank(Position pos, CardRank rank)
        {
            WriteAt(rank.ToString(), pos, (Width - rank.ToString().Length) / 2, Height / 2);
        }

        private string GetDrawingSymbol(CardSuit suit)
        {
            if (suit == CardSuit.CLUB)
                return DrawingSymbols.CLUB;
            if (suit == CardSuit.HEART)
                return DrawingSymbols.HEART;
            if (suit == CardSuit.DIAMOND)
                return DrawingSymbols.DIAMOND;
            return DrawingSymbols.SPADE;
        }  

        private void DrawClosedCard(Position pos)
        {
            for (int i = 0; i < Width; i++)
            {
                Draw(pos);
                pos.X++; pos.Y++; 
                Height-=2; Width-=2;
            }
        }
    }
}
