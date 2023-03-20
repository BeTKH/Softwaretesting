using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametrizedTest
{
    public class MatH
    {
        public int Add(int a, int b) 
        {
            return a + b;
        }

        public int Sub(int a, int b) 
        {
            return a - b;
        }

        public int Mul(int a, int b) 
        {
            return a * b;
        }

        public double Div(double a, double b) 
        {
            return a / b;
        }

        public int Max(int a, int b) 
        {
            return (a > b) ? a : b;
        }

        public IEnumerable<IEquatable<int>> GetOddNumbers(int limit) 
        {
            for (var i = 0; i <= limit; i++)
                if (i%2 != 0)
                    yield return i;
        }
    }
}
