using Core.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Enumerations;

namespace Core.Application.Extensions
{
    public static class EvaluatorExtensions
    {
        public static bool AllRanksConsecutive(this IEnumerable<Card> cards)
        {
            var rankValues = cards.Select(c => (int)c.Rank);
            var rankValuesCount = rankValues.ToList().Count();
            var diff = rankValues.Max() - rankValues.Min();

            return diff == rankValuesCount -1 
                && rankValues.Distinct().ToList().Count == rankValues.ToList().Count;
        }

        public static bool AllSuitsMatch(this IEnumerable<Card> cards)
        {
            var cardSuits = cards.Select(c => c.Suit);
            return !cardSuits.Distinct().Skip(1).Any();
        }

        public static bool ContainsRankGroupSize(this IEnumerable<IGrouping<CardRank, CardRank>> cardRanks, int n) 
            => cardRanks.FirstOrDefault(cr => cr.ToList().Count == n) != null;

        public static int CountOfRankGroupSize(this IEnumerable<IGrouping<CardRank, CardRank>> cardRanks, int n)
        {
            return cardRanks.Count(cr => cr.ToList().Count == n);
        }

        public static int LargestMatchingRankGroupSize(this IEnumerable<IGrouping<CardRank, CardRank>> cardRanks)
        {
            return cardRanks.Max(c => c.ToList().Count);
        }

        public static bool ContainsJacksOrBetter(this IEnumerable<IGrouping<CardRank, CardRank>> cardRanks)
        {
            return cardRanks
                    .FirstOrDefault(cr => cr.Key > CardRank.TEN && cr.ToList().Count == 2)
                    != null;
        }

        public static bool ContainsAce(this IEnumerable<Card> cards)
        {
            var cardRanks = cards.Select(c => c.Rank);
            return cardRanks.Contains(CardRank.ACE);
        }
    }
}
