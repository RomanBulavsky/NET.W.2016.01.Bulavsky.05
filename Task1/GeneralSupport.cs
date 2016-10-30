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
        /// Delegate that take method for finding GCD
        /// </summary>
        /// <param name="inputValues"> params for choosed method of finding GCD</param>
        /// <returns></returns>
        public delegate int DelegatHelper(params int[] inputValues);

        /// <summary>
        /// Method for testing time loosing for find GCD
        /// </summary>
        /// <param name="numberOfValues"> number of elements for GCD</param>
        /// <param name="GCDMethod"> Delegate that take method for finding GCD</param>
        /// <returns> Return lost time for operations</returns>
        public static long TimeTest(int numberOfValues, DelegatHelper GCDMethod)
        {
            var inputValues = new int[numberOfValues];
            var random = new Random(75);
            for (int i = 1; i < numberOfValues + 1; i++)
            {
                inputValues[i - 1] = 6 * Math.Abs(random.Next(120));
            }
            inputValues[numberOfValues - 1] = 2;

            Stopwatch s = new Stopwatch();
            s.Reset();
            s.Start();
            //GCDBin(23,46).Dump();
            GCDMethod(inputValues);
            s.Stop();
            return s.ElapsedTicks;//.Dump(numberOfValues.ToString() + " " + nod);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="argumentsArray"></param>
        /// <returns></returns>
        public static bool IsBadArray(int[] argumentsArray)
        {
            
            if (ReferenceEquals(argumentsArray, null) || argumentsArray.Length < 2) return true;
            foreach (var arg in argumentsArray)
            {
                if (arg <= 0) return true;
            }
            return false;
        }
    }
}
