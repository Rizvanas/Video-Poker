using Core.Domain.Enumerations;
using Core.Domain.Models;
using System.Collections.Generic;

namespace Core.Application.Interfaces
{
    public interface IHandEvaluator
    {
        HandValue EvaluateHand(List<Card> hand);
    }
}
