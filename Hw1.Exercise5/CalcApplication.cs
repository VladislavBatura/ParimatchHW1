using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Hw1.Exercise5
{
    /// <summary>
    /// Calc application core.
    /// </summary>
    public class CalcApplication
    {
        /// <summary>
        /// Runs calc application.
        /// Prints calculation result.
        /// </summary>
        /// <param name="args"> Math expression.</param>
        /// <returns>Returns : 
        /// <c>0</c> in case of success; 
        /// <c>-1</c> in case of invalid format of <paramref name="args"/>;
        /// <c>-2</c> in case of invalid math expression <paramref name="args"/>.
        /// </returns>
        public int Run(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                return -1;
            }

            var firstNumber = -0d;
            var secondNumber = -0d;
            var resultLong = (long)1;
            var operation = "";
            var isEcho = false;


            var expression = string.Concat(args);
            expression = Regex.Replace(expression, @"\s+", "");
            expression = expression.Replace(',', '.');
            var regex = new Regex(@"^(-?\d+[.]?\d?\d?)([!*xX/\\^+-][\\]?)?(-?\d+[.]?\d?\d?)?$");

            if (!regex.IsMatch(expression))
                return -1;

            var echo = Regex.Split(expression, @"^(-?\d+[.]?\d?\d?)");
            var array = regex.Split(expression);

            foreach (var arg in array)
            {
                if (Regex.IsMatch(arg, @"([!*xX/\\^+-][\\]?)") && !Regex.IsMatch(arg, @"([-]\d)"))
                {
                    isEcho = false;
                    operation = arg;
                    break;
                }
                else
                {
                    isEcho = true;
                }
            }

            if (isEcho)
            {
                Console.Write(echo[1]);
                return 0;
            }

            foreach (var arg in array)
            {
                if (double.TryParse(arg, NumberStyles.Any, CultureInfo.InvariantCulture, out var value))
                {
                    if (firstNumber == -0d)
                    {
                        firstNumber = value;
                        continue;
                    }
                    secondNumber = value;
                }
            }

            double result;
            switch (operation)
            {
                case "!":
                    if (firstNumber is < 0 or > 18)
                    {
                        return -2;
                    }
                    if (firstNumber != Math.Floor(firstNumber))
                    {
                        return -2;
                    }
                    for (var i = 1; i <= firstNumber; i++)
                    {
                        resultLong *= i;
                    }
                    Console.Write(resultLong);
                    return 0;
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "\\":
                case "/":
                    if (secondNumber == 0)
                    {
                        return -2;
                    }
                    result = firstNumber / secondNumber;
                    break;
                case "*":
                case "x":
                case "X":
                    result = firstNumber * secondNumber;
                    break;
                case "^":
                    if (firstNumber < 0 & (secondNumber > 0 || secondNumber < 1))
                    {
                        return -2;
                    }
                    result = Math.Pow(firstNumber, secondNumber);
                    break;
                default:
                    return -1;
            }

            Console.WriteLine(result);

            return 0;
        }
    }
}
