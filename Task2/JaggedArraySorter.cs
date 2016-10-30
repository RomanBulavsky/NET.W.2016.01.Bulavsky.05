using System;
using System.Linq;

namespace Task2
{
    /// <summary>
    ///     Class for deferent sor operation on jagged array*************
    /// </summary>
    public static class JaggedArraySorter
    {
        /// <summary>
        /// Enum for choosing the type of algorithm logic. 
        /// </summary>
        public enum SortingType
        {
            SumUp = 1,// It's need for security. Without it SumUp == null, and that will break logic.
            SumDown,
            MaxUp,
            MaxDown,
            MinUp,
            MinDown
        }

        /// <summary>
        ///     Method that choosing type of logic for sorting.
        /// </summary>
        /// <param name="jArray">input Jagged Array. </param>
        /// <param name="mode"> Chooses mode from  SortingType ENUM for sorting.</param>
        public static void ChangeAndSort(int[][] jArray, SortingType mode)
        {
            if (jArray == null || jArray.Any(inner => inner == null) || mode == 0)//tnx ReSharper
                    throw new ArgumentException();
            

            switch (mode)
            {
                case SortingType.SumUp:
                    SumMode(jArray, true);
                    break;
                case SortingType.SumDown:
                    SumMode(jArray, false);
                    break;
                case SortingType.MaxUp:
                    MaxMode(jArray, true);
                    break;
                case SortingType.MaxDown:
                    MaxMode(jArray, false);
                    break;
                case SortingType.MinUp:
                    MinMode(jArray, true);
                    break;
                case SortingType.MinDown:
                    MinMode(jArray, false);
                    break;
            }
            //return jArray;
        }

        /// <summary>
        ///     A method that swaps the fields of the jagged array based on fields of the support matrix.
        /// </summary>
        /// <param name="up"> chooses direction of algorithm (up/down).</param>
        /// <param name="supportiveArray"> 1-d array that helps to sort fields in 2-d jArray.</param>
        /// <param name="jArray"> 2-d Array that need to be changed.</param>
        /// <param name="index"> The index for swap.</param>
        public static void SortInnerMatrix(bool up, int[] supportiveArray, int[][] jArray, int index)
        {
            if (up)
            {
                if (supportiveArray[index] < supportiveArray[index + 1])
                {
                    var sumTmp = supportiveArray[index];
                    supportiveArray[index] = supportiveArray[index + 1];
                    supportiveArray[index + 1] = sumTmp;

                    var tmp = jArray[index];
                    jArray[index] = jArray[index + 1];
                    jArray[index + 1] = tmp;
                }
            }
            else
            {
                if (supportiveArray[index] > supportiveArray[index + 1])
                {
                    var sumTmp = supportiveArray[index];
                    supportiveArray[index] = supportiveArray[index + 1];
                    supportiveArray[index + 1] = sumTmp;

                    var tmp = jArray[index];
                    jArray[index] = jArray[index + 1];
                    jArray[index + 1] = tmp;
                }
            }
        }

        /// <summary>
        ///     Sorts the array.
        /// </summary>
        public static void InnerBubbleSort(int[] array)
        {
            for (var i = 0; i < array.Length - 1; i++)
            {
                var swapped = false;
                for (var j = 0; j < array.Length - i - 1; j++)
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        var tmp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = tmp;
                        swapped = true;
                    }

                if (!swapped)
                    break;
            }
        }

        /// <summary>
        ///     Sorts the jagged array fields based on the sum of the elements (inner arrays) of these fields.
        /// </summary>
        /// <param name="jArray"> Source jagged array</param>
        /// <param name="up">Selects the direction in which the fields of jagged array will be sorted.</param>
        public static void SumMode(int[][] jArray, bool up)
        {
            var sumArray = new int[jArray.Length];

            foreach (var x in jArray)
                InnerBubbleSort(x);


            var i = 0;
            foreach (var x in jArray) /////////////////////////
            {
                foreach (var z in x)
                    sumArray[i] += z;
                i++;
            } ////////////////////////////////////

            for (var j = 0; j < sumArray.Length; j++)
                for (var k = 0; k < sumArray.Length - 1; k++)
                    SortInnerMatrix(up, sumArray, jArray, k); /*
			if (!up)////////////////////////////
			{
				if (sumArray[index] < sumArray[index + 1])
				{
					int sumTmp = sumArray[index];
					sumArray[index] = sumArray[index + 1];
					sumArray[index + 1] = sumTmp;

					int[] tmp = jArray[index];
					jArray[index] = jArray[index + 1];
					jArray[index + 1] = tmp;
				}
			}
			else
			{
				if (sumArray[index] > sumArray[index + 1])
				{
					int sumTmp = sumArray[index];
					sumArray[index] = sumArray[index + 1];
					sumArray[index + 1] = sumTmp;

					int[] tmp = jArray[index];
					jArray[index] = jArray[index + 1];
					jArray[index + 1] = tmp;
				}
			}/////////////////////////////////////*/

            //return jArray;
        }

        /// <summary>
        ///      Sorts the jagged array fields based on the Max element in inner arrays of these fields.
        /// </summary>
        /// <param name="jArray"> Source jagged array</param>
        /// <param name="up">Selects the direction in which the fields of jagged array will be sorted.</param>
        public static void MaxMode(int[][] jArray, bool up)
        {
            var maxArray = new int[jArray.Length];
            for (var g = 0; g < maxArray.Length; g++)
                maxArray[g] = 0;

            foreach (var x in jArray)
                InnerBubbleSort(x);


            var i = 0;
            foreach (var x in jArray) /////////////////////////
            {
                foreach (var z in x)
                    if (maxArray[i] < z)
                        maxArray[i] = z;
                i++;
            } ////////////////////////////////////

            for (var j = 0; j < maxArray.Length; j++)
                for (var k = 0; k < maxArray.Length - 1; k++)
                    SortInnerMatrix(up, maxArray, jArray, k);

            //return jArray;
        }

        /// <summary>
        ///      Sorts the jagged array fields based on the Min element in inner arrays of these fields.
        /// </summary>
        /// <param name="jArray"> Source jagged array</param>
        /// <param name="up">Selects the direction in which the fields of jagged array will be sorted.</param>
        public static void MinMode(int[][] jArray, bool up)
        {
            var maxArray = new int[jArray.Length];
            for (var g = 0; g < maxArray.Length; g++)
                maxArray[g] = int.MaxValue;

            foreach (var x in jArray)
                InnerBubbleSort(x);


            var i = 0;
            foreach (var x in jArray) /////////////////////////
            {
                foreach (var z in x)
                    if (maxArray[i] > z)
                        maxArray[i] = z;
                i++;
            } ////////////////////////////////////

            for (var j = 0; j < maxArray.Length; j++)
                for (var k = 0; k < maxArray.Length - 1; k++)
                    SortInnerMatrix(!up, maxArray, jArray, k);


            //return jArray;
        }


        /*
      /// <summary>
      ///     Creates a test 2-d jagged array.
      /// </summary>
      /// <returns> 2-d jArray.</returns>
      public static int[][] CreateJaggedArray()
      {
          var jaggedArray = new int[5][];
          jaggedArray[0] = new int[1];
          jaggedArray[1] = new int[2];
          jaggedArray[2] = new int[3];
          jaggedArray[3] = new int[4];
          jaggedArray[4] = new int[5];

          var r = new Random(3);
          for (var i = 0; i < jaggedArray.Length; i++)
              for (var j = 0; j < jaggedArray[i].Length; j++)
                  jaggedArray[i][j] = r.Next(7);

          return jaggedArray;
      }
      */
    }
}