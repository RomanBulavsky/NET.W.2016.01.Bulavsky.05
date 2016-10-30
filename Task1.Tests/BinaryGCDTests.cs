using System;
using NUnit.Framework;
using static Task1.BinaryGCD;
using static Task1.GeneralSupport;

namespace Task1.Tests
{
    [TestFixture]
    class BinaryGCDTests
    {

        [TestCase(1, 2, 4, 6, 8, 13)]
        [TestCase(3, 9, 81, 60, 87, 6)]
        [TestCase(5, 200, 100, 25, 80, 40)]
        [TestCase(1, 2, 4, 6, 8, 13, 15, 23, 51, 55, 213)]
        [TestCase(7, 42, 84, 168, 7)]
        public static void FindEuclideanGCD_GoodNumbers_RightGCD(int GCD, params int[] inputValues)
        {
            Assert.AreEqual(GCD, FindForManyArgs(FindGCD,inputValues));
        }

        [TestCase(1, 2, 4, 6, 8, -13)]
        [TestCase(3, 9, 81, -60, 87, 6)]
        [TestCase(-5, 200, 100, 25, 80, 40)]
        [TestCase(42)]
        public static void FindEuclideanGCD_BadNumbers_ArgumentException(params int[] inputValues)
        {
            Assert.That(() => FindForManyArgs(FindGCD, inputValues), Throws.TypeOf<ArgumentException>());

        }



        [TestCase(null)]
        public static void FindEuclideanGCD_Null_ArgumentException(int[] inputValues)
        {
            Assert.That(() => FindForManyArgs(FindGCD, inputValues), Throws.TypeOf<ArgumentNullException>());

        }

        /*
        [TestCase(2, 2)]
        public static void Test(int number, int GCD)
        {
            TestContext.Write(GeneralSupport.TimeTest(number, new GeneralSupport.MethodForFindingGDCForMultipleArgs(new GeneralSupport.MethodForFindingGDCForMultipleArgs(FindGCD))));

            Assert.AreEqual(GCD, FindGCD(2, 4, 12, 2, 26));
        }*/
    }
}
