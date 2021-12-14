using System;
using System.Globalization;
using System.Collections.Generic;

namespace Hw1.Exercise1
{
    /// <summary>
    /// Prime numbers application core.
    /// </summary>
    public class PrimeNumbersApplication
    {
        /// <summary>
        /// Runs prime numbers application.
        /// Prints prime numbers in the given range (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - valid integer range [from, to] 
        /// between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>
        /// to find prime numbers.
        /// </param>
        /// <returns>Return <c>0</c> in case of success and <c>-1</c> in case of failure.</returns>
        public int Run(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return -1;
            }

            var border = new List<int>();
            var max = 0;

            for (var i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], out var j))
                {
                    border.Add(j);
                    if (j > max)
                    {
                        max = j;
                    }
                }
            }
            if (border.Count < 2 || max < 3)
            {
                return -1;
            }

            var from = border[0];
            var to = border[1];
            var result = from > to ? PrimeNumbers(to, from) : PrimeNumbers(from, to);

            Console.Write(result);

            return 0;
        }

        public string PrimeNumbers(int from, int to)
        {
            var resultArray = new List<string>();

            for (var i = from; i <= to; i++)
            {
                var b = true;
                if (i is 0 or 1 or < 0)
                {
                    continue;
                }
                for (var j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    resultArray.Add(Convert.ToString(i, CultureInfo.CurrentCulture));
                }
            }
            return string.Join(';', resultArray) + ";";
        }
    }
}
