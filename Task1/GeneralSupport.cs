using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class GeneralSupport
    {
        /// <summary>
        /// Delegate that takes method for finding GCD.
        /// </summary>
        public delegate int DelegatHelper(params int[] inputValues);

        /// <summary>
        /// Determines the time spent to the searching GCD. 
        /// </summary>
        /// <param name="numberOfValues">The number of elements to be generated for finding the gcd.</param>
        /// <param name="GCDMethod"> Delegate that takes method for finding GCD.</param>
        /// <returns> Number of Elapsed ticks.</returns>
        public static long TimeTest(int numberOfValues, DelegatHelper GCDMethod)
        {
            var inputValues = new int[numberOfValues];
            var random = new Random();
            for (int i = 1; i < numberOfValues + 1; i++)
            {
                inputValues[i - 1] = sizeof(byte) - 2 * Math.Abs(random.Next());
            }
            inputValues[numberOfValues - 1] = 2;

            Stopwatch s = new Stopwatch();
            s.Reset();
            s.Start();
            
            GCDMethod(inputValues);
            s.Stop();
            return s.ElapsedTicks;//.Dump(numberOfValues.ToString() + " " + nod);

        }
        /// <summary>
        /// Checks the input parameters to meet the conditions of the method caller.
        /// </summary>
        /// <param name="argumentsArray">Input parameters for validation. </param>
        /// <returns> Bool value. </returns>
        public static bool IsBadArray(int[] argumentsArray)
        {
            
            if (ReferenceEquals(argumentsArray, null) || argumentsArray.Length < 2) return true;
            return argumentsArray.Any(arg => arg <= 0); // Tnx Resharper
        }
    }
}
