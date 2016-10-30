using System;
using System.Diagnostics;

namespace Task1
{
    public class ClassicGCD
    {
        
        /// <summary>
        /// Takes two parameters and returns the GCD.
        /// </summary>
        /// <param name="firstNumber">The first number to compute.</param>
        /// <param name="secondNumber">The second number to compute.</param>
        /// <returns> int which contains the GCD of two numbers.</returns>
        public static int FindEuclideanGCD(int firstNumber, int secondNumber = 1)
        {
            if ((firstNumber == 0) && (secondNumber == 0)) throw new ArgumentException();

            if (firstNumber == secondNumber) return firstNumber;
            if ((firstNumber == 0) && (secondNumber != 0)) return secondNumber;
            if ((firstNumber != 0) && (secondNumber == 0)) return firstNumber;
            if ((firstNumber == 1) && (secondNumber == 1)) return 1;

            if (firstNumber == secondNumber) return firstNumber;
            if ((firstNumber == 0) && (secondNumber != 0)) return secondNumber;
            if ((firstNumber != 0) && (secondNumber == 0)) return firstNumber;
            if ((firstNumber == 1) && (secondNumber == 1)) return 1;

            while (firstNumber != secondNumber)
                if (firstNumber > secondNumber)
                    firstNumber = firstNumber - secondNumber;
                else
                    secondNumber = secondNumber - firstNumber;

            return firstNumber;
        }
        /*
        /// <summary>
        /// Takes array of parameters and returns the GCD.
        /// </summary>
        /// <param name="argumentsArray">The array of numbers to compute.</param>
        /// <returns> int which contains the GCD of two numbers.</returns>
        public static int FindEuclideanGCD(params int[] argumentsArray)//Bad practise, very similar to the BinaryGCD.FindGCD.
        {
            if (GeneralSupport.IsBadArray(argumentsArray))
                throw new ArgumentException();

            if (argumentsArray.Length == 2) return FindEuclideanGCD(argumentsArray[0], argumentsArray[1]);

            for (int i = 0; i < argumentsArray.Length - 1; i++)
            {
                if (argumentsArray[i] == argumentsArray[i + 1])
                    continue;
                else
                    argumentsArray[0] = FindEuclideanGCD(argumentsArray[0], argumentsArray[i + 1]);
            }

            return argumentsArray[0];

        }*/
 
    }
}