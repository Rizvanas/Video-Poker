using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Enumerations
{
    public enum HandValue
    {
        ROYAL_FLUSH = 800,
        STRAIGHT_FLUSH = 50,
        FOUR_OF_A_KIND = 25,
        FULL_HOUSE = 9,
        FLUSH = 6,
        STRAIGHT = 4,
        THREE_OF_A_KIND = 3,
        TWO_PAIR = 2,
        JACKS_OR_BETTER = 1,
        ALL_OTHER = 0
    }
}
