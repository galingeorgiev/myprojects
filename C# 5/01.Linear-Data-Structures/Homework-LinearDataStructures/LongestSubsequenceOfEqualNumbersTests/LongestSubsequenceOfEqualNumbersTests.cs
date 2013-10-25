namespace LongestSubsequenceOfEqualNumbersTests
{
    using LongestSubsequence;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;

    [TestClass]
    public class LongestSubsequenceOfEqualNumbersTests
    {
        [TestMethod]
        public void LongestSubsequence_StartWithLongSequence()
        {
            List<int> input = new List<int>() { 1, 1, 1, 1, 2, 2, 2, 3, 4, 5 };
            List<int> actualResult = LongestSubsequenceOfEqualNumbers.LongestSubsequence(input);
            List<int> excectedResult = new List<int>() { 1, 1, 1, 1 };

            CollectionAssert.AreEqual(excectedResult, actualResult);
        }

        [TestMethod]
        public void LongestSubsequence_EndWithLongSequence()
        {
            List<int> input = new List<int>() { 1, 2, 2, 2, 3, 4, 5, 5, 5, 5 };
            List<int> actualResult = LongestSubsequenceOfEqualNumbers.LongestSubsequence(input);
            List<int> excectedResult = new List<int>() { 5, 5, 5, 5 };

            CollectionAssert.AreEqual(excectedResult, actualResult);
        }

        [TestMethod]
        public void LongestSubsequence_LongSequenceInMiddle()
        {
            List<int> input = new List<int>() { 1, 2, 2, 2, 3, 4, 5, 5, 5, 5, 1, 1, 2, 3 };
            List<int> actualResult = LongestSubsequenceOfEqualNumbers.LongestSubsequence(input);
            List<int> excectedResult = new List<int>() { 5, 5, 5, 5 };

            CollectionAssert.AreEqual(excectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LongestSubsequence_EmptyInputList()
        {
            List<int> input = new List<int>();
            LongestSubsequenceOfEqualNumbers.LongestSubsequence(input);
        }
    }
}
