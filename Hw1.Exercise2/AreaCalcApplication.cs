using System;

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
            throw new NotImplementedException("Should be implemented by executor");
        }
    }
}
