using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Models
{
    public class Hand
    {
        public List<Card> Cards { get; set; }
        public int Size { get; set; }
        public int Value { get; set; }
    }
}
