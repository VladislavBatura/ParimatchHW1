using System;
using System.Globalization;

namespace Hw1.Exercise4
{
    /// <summary>
    /// Array statistics application core.
    /// </summary>
    public class ArrayStatApplication
    {
        /// <summary>
        /// Runs array statistics application.
        /// Prints statistics.
        /// </summary>
        /// <param name="args">
        /// Arguments - integer array.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return -1;
            }

            var array = new int[args.Length];

            var sum = 0;
            var average = 0d;

            for (var i = 0; i < args.Length; i++)
            {
                if (int.TryParse(args[i], NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                {
                    array[i] = value;
                    sum += value;
                    average += value;
                }
                else
                {
                    return -1;
                }
            }

            average /= array.Length;
            Array.Sort(array);

            var min = array[0];
            var max = array[^1];

            Console.WriteLine($"Min={min}");
            Console.WriteLine($"Max={max}");
            Console.WriteLine($"Sum={sum}");
            Console.WriteLine($"Average={average}");
            Console.WriteLine($"Count={array.Length}");
            Console.Write("Sorted=");
            foreach (var i in array)
            {
                Console.Write($"{i};");
            }

            return 0;
        }
    }
}
