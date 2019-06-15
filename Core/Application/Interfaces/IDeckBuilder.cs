using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Core.Interfaces
{
    public interface IDeckBuilder
    {
        List<Card> BuildDeck();
    }
}
