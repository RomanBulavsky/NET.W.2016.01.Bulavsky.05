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
        public delegate int MethodForFindingGDCForMultipleArgs(params int[] inputValues);
        public delegate int MethodForFindingGDC(int a, int b);

        /// <summary>
        /// Determines the time spent to the searching GCD. 
        /// </summary>
        /// <param name="numberOfValues">The number of elements to be generated for finding the gcd.</param>
        /// <param name="GCDMethod"> Delegate that takes method for finding GCD.</param>
        /// <returns> Number of Elapsed ticks.</returns>
        public static long TimeTest(int numberOfValues, MethodForFindingGDCForMultipleArgs GCDMethod)
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

        /// <summary>
        /// Takes array of parameters and returns the GCD.
        /// </summary>
        /// <param name="argumentsArray">The array of numbers to compute.</param>
        /// <returns> int which contains the GCD of two numbers.</returns>
        public static int FindForManyArgs(MethodForFindingGDC methodForFindGCD, params int[] argumentsArray)//Bad practise, very similar to the BinaryGCD.FindGCD.
        {
            if (methodForFindGCD == null) throw new ArgumentNullException(nameof(methodForFindGCD));
            if (argumentsArray == null) throw new ArgumentNullException(nameof(argumentsArray));

            if (GeneralSupport.IsBadArray(argumentsArray))
                throw new ArgumentException();

            if (argumentsArray.Length == 2) return methodForFindGCD(argumentsArray[0], argumentsArray[1]);

            for (int i = 0; i < argumentsArray.Length - 1; i++)
            {
                if (argumentsArray[i] == argumentsArray[i + 1])
                    continue;
                else
                    argumentsArray[0] = methodForFindGCD(argumentsArray[0], argumentsArray[i + 1]);
            }

            return argumentsArray[0];

        }
    }
}
