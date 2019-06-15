using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> src, Random rng)
        {
            T[] elements = src.ToArray();
            for (var i = elements.Length - 1; i >= 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elements[swapIndex];
                elements[swapIndex] = elements[i];
            }
        }
    }
}
