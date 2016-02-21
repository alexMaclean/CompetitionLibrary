using System.Collections.Generic;
using System.Linq;
using System.Numerics;

class Combinatorics
{
    /// <summary>
    /// Returns factorial of n.
    /// </summary>
    public static BigInteger Factorial(BigInteger n)
    {
        return n == 0 ? 1 : Factorial(n - 1) * n;
    }

    /// <summary>
    /// Returns Binomial Coefficient of n and k (nCk).
    /// </summary>
    public static BigInteger BinomialCoefficient(BigInteger n, BigInteger k)
    {
        return Factorial(n) / (Factorial(n - k) * Factorial(k));
    }

    /// <summary>
    /// Returns all subsets of k, disregarding order.
    /// </summary>
    public static List<List<T>> Combinations<T>(List<T> list)
    {
        var result = new List<List<T>>();

        for (BigInteger bitMask = 0; bitMask < (BigInteger.One << list.Count); ++bitMask) {
            var subset = new List<T>();
            for (int i = 0; i < list.Count; ++i) {
                if ((bitMask >> i & 1) == 1) {
                    subset.Add(list[i]);
                }
            }
            result.Add(subset);
        }

        return result;
    }

    /// <summary>
    /// Returns all subsets with length k of the list, disregarding order.
    /// </summary>
    public static List<List<T>> KCombinations<T>(List<T> list, int k)
    {
        var result = new List<List<T>>();
        int n = list.Count;

        List<int> indices = new List<int>(Enumerable.Range(0, k));

        while (true) {
            nextSubset: result.Add(indices.Select(i => list[i]).ToList());

            for (int i = k - 1; i >= 0; --i) {
                if (indices[i] != n - k + i) {
                    ++indices[i];

                    for (int j = i + 1; j < k; ++j) {
                        indices[j] = indices[j - 1] + 1;
                    }

                    goto nextSubset;
                }
            }

            break;
        }

        return result;
    }
}
