using System;

namespace Task1
{
    public static class BinaryGCD
    {
        /// <summary>
        /// Takes two parameters and returns the GCD.
        /// </summary>
        /// <param name="firstNumber">The first number to compute.</param>
        /// <param name="secondNumber">The second number to compute.</param>
        /// <returns> int which contains the GCD of two numbers.</returns>
        public static int FindGCD(int firstNumber, int secondNumber)
        {
            if ((firstNumber == 0) && (secondNumber == 0)) throw new ArgumentException();
       
            if (firstNumber == secondNumber) return firstNumber;
            if ((firstNumber == 0) && (secondNumber != 0)) return secondNumber;
            if ((firstNumber != 0) && (secondNumber == 0)) return firstNumber;
            if ((firstNumber == 1) && (secondNumber == 1)) return 1;


            var cofficient = 1;
            while ((firstNumber != 0) && (secondNumber != 0))
            {
                while ((firstNumber%2 == 0) && (secondNumber%2 == 0))
                {
                    firstNumber /= 2;
                    secondNumber /= 2;
                    cofficient *= 2;
                }
                while (firstNumber%2 == 0) firstNumber /= 2;
                while (secondNumber%2 == 0) secondNumber /= 2;
                if (firstNumber >= secondNumber) firstNumber -= secondNumber;
                else secondNumber -= firstNumber;
            }
            return secondNumber*cofficient;
        }

        /// <summary>
        /// Takes array of parameters and returns the GCD.
        /// </summary>
        /// <param name="argumentsArray">The array of numbers to compute.</param>
        /// <returns> int which contains the GCD of two numbers.</returns>
        public static int FindGCD(params int[] argumentsArray)
        {
            if (GeneralSupport.IsBadArray(argumentsArray))
                throw new ArgumentException();

            if (argumentsArray.Length == 2) return FindGCD(argumentsArray[0], argumentsArray[1]);

            for (int i = 0; i < argumentsArray.Length - 1; i++)
            {
                if (argumentsArray[i] == argumentsArray[i + 1])
                    continue;
                else
                    argumentsArray[0] = FindGCD(argumentsArray[0], argumentsArray[i + 1]);
            }

            return argumentsArray[0];
        }
    }
}