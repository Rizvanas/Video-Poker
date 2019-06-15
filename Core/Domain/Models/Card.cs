using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Enumerations;

namespace Core.Domain.Models
{
    public class Card
    {
        public CardSuit Suit { get; set; }
        public CardRank Rank { get; set; }
    }
}
