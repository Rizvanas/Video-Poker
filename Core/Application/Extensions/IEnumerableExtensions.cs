using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Application.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> src, Random rng)
        {
            T[] elems = src.ToArray();
            for (var i = elems.Length - 1; i >= 0; i--)
            {
                int swapIndex = rng.Next(i + 1);
                yield return elems[swapIndex];
                elems[swapIndex] = elems[i];
            }
        }
    }
}
