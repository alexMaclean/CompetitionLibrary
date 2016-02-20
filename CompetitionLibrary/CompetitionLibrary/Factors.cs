class Factors
{
    /// <summary>
    /// Returns the factors of n, including 1 and the number itself.
    /// </summary>
    public static int CountFactors(int n)
    {
        int factors = 0;

        for (int i = 1; i <= n; ++i) {
            factors += n % i == 0 ? 1 : 0;
        }

        return factors;
    }

    /// <summary>
    /// Returns true if n is a prime and false if not.
    /// </summary>
    public static bool IsPrime(int n)
    {
        return CountFactors(n) == 2;
    }

    /// <summary>
    /// Returns the nth prime.
    /// </summary>
    public static int NthPrime(int n)
    {
        int primesFound = 0;

        for (int i = 2; ; ++i) {
            if (IsPrime(i)) {
                ++primesFound;
                if (primesFound == n) {
                    return i;
                }
            }
        }
    }
}