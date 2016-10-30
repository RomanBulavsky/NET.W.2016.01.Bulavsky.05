using System;
using NUnit.Framework;
using static Task2.JaggedArraySorter;

namespace Task2.Tests
{
    [TestFixture]
    public class JaggedArraySorterTests
    {
  
        [TestCase(new int[] { 4, 5 }, SortingType.SumUp, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new int[] { 4, 5 }, SortingType.MaxUp, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 3, 4 }, SortingType.MinUp, new int[] { 1, 4, 3 }, new int[] { 2, 8 }, new int[] { 4, 1 }, new int[] { 1, 3, 4 })]
        public static void ChangeAndSortTest_JaggedArrayAndUp_RightArrayInTheFirstIndexOfJaggedArray(int[] result,  SortingType sortingType,  params int[][] jArray )//Extended method
        {
            int[][] Array = jArray;
            ChangeAndSort(Array, sortingType);

            Assert.AreEqual(Array[0], result);

        }

        [TestCase(new int[] { 4, 5 }, SortingType.SumDown, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 5, 4 })]
        [TestCase(new int[] { 4, 5 }, SortingType.MaxDown, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new int[] { 1, 2, 3 }, SortingType.MinDown, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(new int[] { -1, 4 }, SortingType.MinDown, new int[] { 1, 4, 3 }, new int[] { 2, 8 }, new int[] { 4, -1 })]
        public static void ChangeAndSortTest_JaggedArrayAndUp_СorrectArrayInTheLastIndexOfJaggedArray(int[] result, SortingType sortingType, params int[][] jArray)
        {
            int[][] Array = jArray;
            ChangeAndSort(Array, sortingType);
            
            Assert.AreEqual(Array[Array.Length - 1], result);

        }

        [TestCase(null, new int[] { 1, 2, 3 }, new int[] { 1, 2 }, new int[] { 4, 5 })]
        [TestCase(SortingType.MinDown, new int[] { 1, 4, 3 }, new int[] { 2, 8 }, null)]
        public static void ChangeAndSortTest_BadParams_Exception(SortingType sortingType, int[] a, int[] b, int[] c)
        {
            int[][] Array = new int[][] {a,b,c};
            Assert.That(() => ChangeAndSort(Array, sortingType), Throws.TypeOf<ArgumentException>());
        }

        [TestCase(SortingType.MinDown, null)]
        public static void ChangeAndSortTest_NullArray_Exception(SortingType sortingType, int[][] jArray)
        {
            Assert.That(() => ChangeAndSort(jArray, sortingType), Throws.TypeOf<ArgumentException>());
        }

    }
}
