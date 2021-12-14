using System;
using System.Globalization;

namespace Hw1.Exercise3
{
    /// <summary>
    /// 'Rock-Paper-Scissors' game application core.
    /// </summary>
    public class GameApplication
    {
        /// <summary>
        /// Runs game application.
        /// Prints game results.
        /// </summary>
        /// <param name="args">
        /// Arguments - player's shape.
        /// args[0] - shape [Rock, Paper, Scissors].
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

            var figures = new string[3] { "Rock", "Scissors", "Paper" };
            var results = new string[3] { "Win", "Lose", "Draw" };

            if (!IsEven(args[0], figures[0]) && !IsEven(args[0], figures[1]) && !IsEven(args[0], figures[2]))
            {
                return -1;
            }

            var playerFigure = args[0].ToLower(CultureInfo.InvariantCulture);
            var rand = new Random();
            var computerFigure = figures[rand.Next(0, 3)];
            var resultHuman = results[2];
            var resultComputer = results[2];

            switch (computerFigure)
            {
                case "Rock":
                    if (IsEven(playerFigure, figures[1]))
                    {
                        resultHuman = results[1];
                        resultComputer = results[0];
                        playerFigure = figures[1];
                    }
                    else if (IsEven(playerFigure, figures[2]))
                    {
                        resultHuman = results[0];
                        resultComputer = results[1];
                        playerFigure = figures[2];
                    }
                    else
                    {
                        playerFigure = figures[0];
                    }
                    break;
                case "Scissors":
                    if (IsEven(playerFigure, figures[2]))
                    {
                        resultHuman = results[1];
                        resultComputer = results[0];
                        playerFigure = figures[2];
                    }
                    else if (IsEven(playerFigure, figures[0]))
                    {
                        resultHuman = results[0];
                        resultComputer = results[1];
                        playerFigure = figures[0];
                    }
                    else
                    {
                        playerFigure = figures[1];
                    }
                    break;
                case "Paper":
                    if (IsEven(playerFigure, figures[0]))
                    {
                        resultHuman = results[1];
                        resultComputer = results[0];
                        playerFigure = figures[0];
                    }
                    else if (IsEven(playerFigure, figures[1]))
                    {
                        resultHuman = results[0];
                        resultComputer = results[1];
                        playerFigure = figures[1];
                    }
                    else
                    {
                        playerFigure = figures[2];
                    }
                    break;
                default:
                    return -1;
            }

            Console.WriteLine($"Player={playerFigure}:{resultHuman}");
            Console.WriteLine($"Computer={computerFigure}:{resultComputer}");

            return 0;
        }

        private bool IsEven(string figure, string figure2)
        {
            return string.Equals(figure.ToLower(CultureInfo.InvariantCulture),
                figure2.ToLower(CultureInfo.InvariantCulture), StringComparison.Ordinal);
        }
    }
}
