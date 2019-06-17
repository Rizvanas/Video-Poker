using System.Collections.Generic;
using Core.Domain.Models;

namespace Core.Application.Interfaces
{
    public interface IDeckBuilder
    {
        List<Card> BuildDeck();
    }
}
