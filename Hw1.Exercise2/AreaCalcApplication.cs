using System;
using System.Globalization;

namespace Hw1.Exercise2
{
    /// <summary>
    /// Area calc application core.
    /// </summary>
    public class AreaCalcApplication
    {
        /// <summary>
        /// Runs area calc application.
        /// Prints area of selected shape (from <paramref name="args"/>) to the output.
        /// </summary>
        /// <param name="args">
        /// Arguments - shape with dimensions.
        /// args[0] - shape [Circle, Square, Rect, Triangle].
        /// args[0..2] - shape dimensions.
        /// </param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid <paramref name="args"/>;
        /// <c>-2</c> in case of invalid dimensions.
        /// </returns>
        public int Run(string[] args)
        {
            if (args == null || args.Length is 0 or 1)
            {
                return -1;
            }

            var figure = args[0].ToLower(CultureInfo.CurrentCulture);
            double result;
            var sizes = new double[3];
            string temp;

            for (var i = 1; i < args.Length; i++)
            {
                temp = args[i].Replace(',', '.');
                if (double.TryParse(temp, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                {
                    if (value <= 0)
                    {
                        return -2;
                    }
                    sizes[i - 1] = value;
                }
                else
                {
                    return -1;
                }
            }

            switch (figure)
            {
                case "circle":
                    result = (double)Math.Pow(sizes[0], 2.0);
                    result *= Math.PI;
                    break;
                case "square":
                    result = Math.Pow(sizes[0], 2);
                    break;
                case "rect":
                    if (sizes[1] == 0)
                    {
                        return -1;
                    }
                    result = sizes[0] * sizes[1];
                    break;
                case "triangle":
                    if (sizes[2] == 0)
                    {
                        result = 0.5d * sizes[0] * sizes[1];
                    }
                    else if (sizes[0] < sizes[1] + sizes[2]
                        && sizes[1] < sizes[0] + sizes[2]
                        && sizes[2] < sizes[1] + sizes[0])
                    {
                        var p = (sizes[0] + sizes[1] + sizes[2]) / 2;
                        result = Math.Sqrt(p * (p - sizes[0]) * (p - sizes[1]) * (p - sizes[2]));
                    }
                    else
                    {
                        return -2;
                    }
                    break;
                default:
                    return -1;
            }
            result = Math.Round(result, 1, MidpointRounding.ToEven);
            Console.Write(Convert.ToString(result, CultureInfo.InvariantCulture));

            return 0;
        }
    }
}
