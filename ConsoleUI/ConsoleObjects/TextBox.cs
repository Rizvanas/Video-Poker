using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ConsoleObjects
{
    public class TextBox : Rectangle
    {
        public void Draw(Position position, string text)
        {
            Width = text.Length + 2;
            Height = 2;

            Console.ForegroundColor = Color;
            base.Draw(new Position { X = position.X - 1, Y = position.Y - 1});
            Console.SetCursorPosition(position.X, position.Y);
            WriteAt(text, position, 0, 0);

            Console.SetCursorPosition(position.X+5, position.Y+3);
        }
    }
}
