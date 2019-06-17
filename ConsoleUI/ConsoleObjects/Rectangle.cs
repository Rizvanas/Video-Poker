using ConsoleUI.Enumerations;
using ConsoleUI.Interfaces;
using System;

namespace ConsoleUI.ConsoleObjects
{
    public class Rectangle : IDrawable
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ConsoleColor Color { get; set; }

        public void Draw(Position position)
        {
            DrawTopAndBottom(position);

            DrawSides(position);

            Console.SetCursorPosition(0, position.Y + Height + 2);
            Console.ResetColor();
        }

        protected void WriteAt(string s, Position init, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(init.X + x, init.Y + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        
        private void DrawTopAndBottom(Position position)
        {
            for (int i = 0; i < Width; i++)
            {
                if (i == 0)
                {
                    WriteAt(DrawingSymbols.TOP_LEFT_CORNER, position, i, 0);
                    WriteAt(DrawingSymbols.BOTTOM_LEFT_CORNER, position, i, Height);
                }
                else if (i == Width - 1)
                {
                    WriteAt(DrawingSymbols.TOP_RIGHT_CORNER, position, i, 0);
                    WriteAt(DrawingSymbols.BOTTOM_RIGHT_CORNER, position, i, Height);
                }
                else
                {
                    WriteAt(DrawingSymbols.HORIZONTAL_LINE, position, i, 0);
                    WriteAt(DrawingSymbols.HORIZONTAL_LINE, position, i, Height);
                }
            }
        }

        private void DrawSides(Position position)
        {
            for (int i = 1; i < Height; i++)
            {
                WriteAt(DrawingSymbols.VERTICAL_LINE, position, 0, i);
                WriteAt(DrawingSymbols.VERTICAL_LINE, position, Width - 1, i);
            }
        }

    }
}
