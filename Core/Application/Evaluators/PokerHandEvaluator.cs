using Core.Application.Interfaces;
using Core.Domain.Enumerations;
using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Extensions;

namespace Core.Evaluators
{
    public class PokerHandEvaluator : IHandEvaluator
    {
        public HandValue EvaluateHand(List<Card> cards)
        {
            var cardRanksGrouped = cards
                .Select(c => c.Rank)
                .GroupBy(c => c);

            var largestMatchingRankGroup = cardRanksGrouped.LargestMatchingRankGroupSize();

            switch (largestMatchingRankGroup)
            {
                case 4: return HandValue.FOUR_OF_A_KIND;
                case 3: return GetThreeOrFullHouse(cardRanksGrouped);
                case 2: return GetPairOrJackOrOther(cardRanksGrouped);
                case 1: return GetSomeFlushOrStraigth(cards);
                default: return HandValue.ALL_OTHER;
            }
        }

        private HandValue GetThreeOrFullHouse(IEnumerable<IGrouping<CardRank, CardRank>> cardRanks)
        {
            if (cardRanks.ContainsRankGroupSize(2))
                return HandValue.FULL_HOUSE;

            return HandValue.THREE_OF_A_KIND;
        }

        private HandValue GetPairOrJackOrOther(IEnumerable<IGrouping<CardRank, CardRank>> cardRanks)
        {
            if (cardRanks.CountOfRankGroupSize(2) == 2)
                return HandValue.TWO_PAIR;

            if (cardRanks.ContainsJacksOrBetter())
                return HandValue.JACKS_OR_BETTER;

            return HandValue.ALL_OTHER; 
        }

        private HandValue GetSomeFlushOrStraigth(IEnumerable<Card> cards)
        {
            if (cards.AllRanksConsecutive())
            {
                if (cards.AllSuitsMatch())
                    return GetStraightOrRoyalFlush(cards);

                return HandValue.STRAIGHT;
            }

            if (cards.AllSuitsMatch())
                return HandValue.FLUSH;

            return HandValue.ALL_OTHER;
        }

        private HandValue GetStraightOrRoyalFlush(IEnumerable<Card> cards)
        {
            if (cards.ContainsAce())
                return HandValue.ROYAL_FLUSH;

            return HandValue.STRAIGHT_FLUSH;
        }
    }
}
