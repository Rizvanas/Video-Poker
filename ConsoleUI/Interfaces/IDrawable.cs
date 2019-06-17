using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Interfaces
{
    public interface IDrawable
    {
        int Width { get; set; }
        int Height { get; set; }
        void Draw(Position position);
    }
}
