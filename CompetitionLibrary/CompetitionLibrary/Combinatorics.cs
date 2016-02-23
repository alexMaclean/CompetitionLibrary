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
    
    /// <summary>
    /// Swaps lhs with rhs.
    /// </summary>
    static void Swap<T>(ref T lhs, ref T rhs)
	{
	    T temp;
	    temp = lhs;
	    lhs = rhs;
	    rhs = temp;
	}
	
	/// <summary>
    /// Swaps the value of list and index1 with the value at index2.
    /// </summary>
	static void Swap<T>(List<T> list, int index1, int index2) {
		T temp = list[index1];
		list[index1] = list[index2];
		list[index2] = temp;
	}
    
    /// <summary>
    /// Returns all permutations of the list.
    /// </summary>
	public static List<List<T>>Permutations<T>(List<T> list) {
		var result = new List<List<T>>();
        int n = list.Count;

        List<int> indices = new List<int>(Enumerable.Range(0, n));
        

        while(true) {
        	result.Add(indices.Select(i => list[i]).ToList());
        	
        	int k = n - 2;
        	for (;  k >= 0; --k) {
				if (indices[k] < indices[k + 1]) {
					break;
				}
			}
			
			if (k < 0) {
				break;
			}
			
			int l = n - 1;
			for (; l > k; --l) {
				if (indices[k] < indices[l]) {
					break;
				}
			}
			
			Swap<int>(indices, k, l);
			
			indices.Reverse(k + 1, n - k - 1);
        }

		return result;
	}
}
