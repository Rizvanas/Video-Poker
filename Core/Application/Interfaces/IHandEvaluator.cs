using Core.Domain.Enumerations;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interfaces
{
    public interface IHandEvaluator
    {
        HandValue EvaluateHand(List<Card> hand);
    }
}
