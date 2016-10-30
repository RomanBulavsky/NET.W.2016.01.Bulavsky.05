using System;
using NUnit.Framework;
using static Task1.ClassicGCD;
using static Task1.GeneralSupport;

namespace Task1.Tests
{
    [TestFixture]
    public static class ClassicGCDTests
    {
        [TestCase(1, 2,4,6,8,13)]
        [TestCase(3, 9,81,60,87,6)]
        [TestCase(5, 200,100,25,80,40)]
        [TestCase(1, 2,4,6,8,13,15,23,51,55,213)]
        [TestCase(7, 42,84,168,7)]
        public static void FindGCD_GoodNumbers_CorrectGCD(int GCD, params int[] inputValues)
        {
            Assert.AreEqual(GCD, FindForManyArgs(FindEuclideanGCD, inputValues));
        }

        [TestCase(1, 2, 4, 6, 8, -13)]
        [TestCase(3, 9, 81, -60, 87, 6)]
        [TestCase(-5, 200, 100, 25, 80, 40)]
        [TestCase(42)]
        public static void FindGCD_BadNumbers_ArgumentException(params int[] inputValues)
        {
            Assert.That(() => FindForManyArgs(FindEuclideanGCD, inputValues), Throws.TypeOf<ArgumentException>());
            
        }



        [TestCase(null)]
        public static void FindGCD_Null_ArgumentException(int[] inputValues)
        {
            Assert.That(() => FindForManyArgs(FindEuclideanGCD, inputValues), Throws.TypeOf<ArgumentNullException>());

        }






        /*
          [TestCase(2, 3000)]
          public static void TestTime(int number, long resultTime)
          {
              Assert.IsTrue(resultTime > GeneralSupport.TimeTest(number, FindEuclideanGCD));

          }

          [TestCase(10, 10)]
          [TestCase(50, 25)]
          [TestCase(100, 1000)]
          [TestCase(150, 1500)]
          [TestCase(200, 2000)]
          //[TestCase(1000, 5000)]
          public static void TestTime2(int number, long resultTime)
          {

              //Assert.AreEqual(resultTime,GeneralSupport.Test(number, FindEuclideanGCD));
              Assert.IsTrue(resultTime > GeneralSupport.Test(number, FindEuclideanGCD));

          }*/


    }
}