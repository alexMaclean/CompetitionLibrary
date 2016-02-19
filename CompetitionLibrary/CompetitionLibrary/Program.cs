using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetitionLibrary
{
    class Program
    {
        //returns the number of factors in a number including 1 and the number
        public static int countFactors(int number)
        {
            int factors = 0;
            for (int i = 1; i <= number; ++i)
                factors += number % i == 0 ? 1 : 0;
            return factors;
        }

        static void Main(string[] args)
        {
        }
    }
}
