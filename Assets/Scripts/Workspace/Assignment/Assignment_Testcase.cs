using NUnit.Framework;

namespace Assignment
{
    public class Assignment_Testcase
    {
        private StudentSolution assignment;

        [SetUp]
        public void Setup()
        {
            // Use StudentSolution as the test subject
            assignment = new StudentSolution();
        }

        #region Lecture

        [Category("Lecture")]
        [TestCase(5, 120, TestName = "LCT01_RecursiveFactorial_5", Description = "Factorial of 5")]
        [TestCase(0, 1, TestName = "LCT01_RecursiveFactorial_0", Description = "Factorial of 0")]
        [TestCase(1, 1, TestName = "LCT01_RecursiveFactorial_1", Description = "Factorial of 1")]
        [TestCase(3, 6, TestName = "LCT01_RecursiveFactorial_3", Description = "Factorial of 3")]
        [TestCase(4, 24, TestName = "LCT01_RecursiveFactorial_4", Description = "Factorial of 4")]
        [TestCase(6, 720, TestName = "LCT01_RecursiveFactorial_6", Description = "Factorial of 6")]
        public void Test_LCT01_RecursiveFactorial(int n, int expected)
        {
            var actual = assignment.LCT01_RecursiveFactorial(n);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Lecture")]
        [TestCase(6, 8, TestName = "LCT02_RecursiveFibonacci_6", Description = "Fibonacci of 6")]
        [TestCase(0, 0, TestName = "LCT02_RecursiveFibonacci_0", Description = "Fibonacci of 0")]
        [TestCase(1, 1, TestName = "LCT02_RecursiveFibonacci_1", Description = "Fibonacci of 1")]
        [TestCase(2, 1, TestName = "LCT02_RecursiveFibonacci_2", Description = "Fibonacci of 2")]
        [TestCase(3, 2, TestName = "LCT02_RecursiveFibonacci_3", Description = "Fibonacci of 3")]
        [TestCase(4, 3, TestName = "LCT02_RecursiveFibonacci_4", Description = "Fibonacci of 4")]
        [TestCase(5, 5, TestName = "LCT02_RecursiveFibonacci_5", Description = "Fibonacci of 5")]
        public void Test_LCT02_RecursiveFibonacci(int n, int expected)
        {
            var actual = assignment.LCT02_RecursiveFibonacci(n);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Lecture")]
        [TestCase(5, 15, TestName = "LCT03_RecursiveSumOfOneToN_5", Description = "Sum from 1 to 5")]
        [TestCase(0, 0, TestName = "LCT03_RecursiveSumOfOneToN_0", Description = "Sum from 1 to 0")]
        [TestCase(1, 1, TestName = "LCT03_RecursiveSumOfOneToN_1", Description = "Sum from 1 to 1")]
        [TestCase(3, 6, TestName = "LCT03_RecursiveSumOfOneToN_3", Description = "Sum from 1 to 3")]
        [TestCase(10, 55, TestName = "LCT03_RecursiveSumOfOneToN_10", Description = "Sum from 1 to 10")]
        [TestCase(2, 3, TestName = "LCT03_RecursiveSumOfOneToN_2", Description = "Sum from 1 to 2")]
        public void Test_LCT03_RecursiveSumOfOneToN(int n, int expected)
        {
            var actual = assignment.LCT03_RecursiveSumOfOneToN(n);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Lecture")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 15, TestName = "LCT04_RecursiveSumOfNumbers_Basic", Description = "Sum of array")]
        [TestCase(new int[] { }, 0, TestName = "LCT04_RecursiveSumOfNumbers_Empty", Description = "Sum of empty array")]
        [TestCase(new int[] { 10 }, 10, TestName = "LCT04_RecursiveSumOfNumbers_Single", Description = "Sum of single element")]
        [TestCase(new int[] { 1, 2, 3 }, 6, TestName = "LCT04_RecursiveSumOfNumbers_Small", Description = "Sum of small array")]
        [TestCase(new int[] { 0, 0, 0 }, 0, TestName = "LCT04_RecursiveSumOfNumbers_Zeros", Description = "Sum of zeros")]
        [TestCase(new int[] { -1, 1 }, 0, TestName = "LCT04_RecursiveSumOfNumbers_Negative", Description = "Sum with negative")]
        public void Test_LCT04_RecursiveSumOfNumbers(int[] numbers, int expected)
        {
            var actual = assignment.LCT04_RecursiveSumOfNumbers(numbers);
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion

        #region Assignment

        [Category("Assignment")]
        [TestCase(2, 3, 8, TestName = "ASN01_RecursivePower_2_3", Description = "2^3")]
        [TestCase(5, 0, 1, TestName = "ASN01_RecursivePower_5_0", Description = "5^0")]
        [TestCase(3, 2, 9, TestName = "ASN01_RecursivePower_3_2", Description = "3^2")]
        [TestCase(4, 2, 16, TestName = "ASN01_RecursivePower_4_2", Description = "4^2")]
        [TestCase(1, 5, 1, TestName = "ASN01_RecursivePower_1_5", Description = "1^5")]
        [TestCase(10, 1, 10, TestName = "ASN01_RecursivePower_10_1", Description = "10^1")]
        public void Test_ASN01_RecursivePower(int baseNum, int exponent, int expected)
        {
            var actual = assignment.ASN01_RecursivePower(baseNum, exponent);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Assignment")]
        [TestCase("radar", true, TestName = "ASN02_IsPalindrome_Radar", Description = "Radar is palindrome")]
        [TestCase("hello", false, TestName = "ASN02_IsPalindrome_Hello", Description = "Hello is not palindrome")]
        [TestCase("a", true, TestName = "ASN02_IsPalindrome_Single", Description = "Single char is palindrome")]
        [TestCase("", true, TestName = "ASN02_IsPalindrome_Empty", Description = "Empty string is palindrome")]
        [TestCase("aba", true, TestName = "ASN02_IsPalindrome_Aba", Description = "Aba is palindrome")]
        [TestCase("abcba", true, TestName = "ASN02_IsPalindrome_Abcba", Description = "Abcba is palindrome")]
        [TestCase("ab", false, TestName = "ASN02_IsPalindrome_Ab", Description = "Ab is not palindrome")]
        [TestCase("aa", true, TestName = "ASN02_IsPalindrome_Aa", Description = "Aa is palindrome")]
        public void Test_ASN02_IsPalindrome(string str, bool expected)
        {
            var actual = assignment.ASN02_IsPalindrome(str);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Assignment")]
        [TestCase(48, 18, 6, TestName = "ASN03_RecursiveGCD_48_18", Description = "GCD of 48 and 18")]
        [TestCase(100, 75, 25, TestName = "ASN03_RecursiveGCD_100_75", Description = "GCD of 100 and 75")]
        [TestCase(7, 3, 1, TestName = "ASN03_RecursiveGCD_7_3", Description = "GCD of 7 and 3")]
        [TestCase(54, 24, 6, TestName = "ASN03_RecursiveGCD_54_24", Description = "GCD of 54 and 24")]
        [TestCase(17, 13, 1, TestName = "ASN03_RecursiveGCD_17_13", Description = "GCD of 17 and 13")]
        [TestCase(25, 15, 5, TestName = "ASN03_RecursiveGCD_25_15", Description = "GCD of 25 and 15")]
        public void Test_ASN03_RecursiveGCD(int a, int b, int expected)
        {
            var actual = assignment.ASN03_RecursiveGCD(a, b);
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Category("Assignment")]
        [TestCase(new int[] { 1, 3, 5, 7, 9 }, 5, 2, TestName = "ASN04_RecursiveBinarySearch_Found", Description = "Target found")]
        [TestCase(new int[] { 1, 2, 3, 4, 5 }, 6, -1, TestName = "ASN04_RecursiveBinarySearch_NotFound", Description = "Target not found")]
        [TestCase(new int[] { 10 }, 10, 0, TestName = "ASN04_RecursiveBinarySearch_Single", Description = "Single element found")]
        [TestCase(new int[] { 1, 2, 3 }, 0, -1, TestName = "ASN04_RecursiveBinarySearch_NotFoundLow", Description = "Target less than all")]
        [TestCase(new int[] { 2, 4, 6, 8, 10 }, 4, 1, TestName = "ASN04_RecursiveBinarySearch_Even", Description = "Target in even position")]
        [TestCase(new int[] { 1, 3, 5 }, 1, 0, TestName = "ASN04_RecursiveBinarySearch_First", Description = "Target is first")]
        [TestCase(new int[] { 1, 2, 3, 4 }, 5, -1, TestName = "ASN04_RecursiveBinarySearch_NotFoundHigh", Description = "Target greater than all")]
        [TestCase(new int[] { 5 }, 6, -1, TestName = "ASN04_RecursiveBinarySearch_SingleNotFound", Description = "Single element not found")]
        public void Test_ASN04_RecursiveBinarySearch(int[] arr, int target, int expected)
        {
            var actual = assignment.ASN04_RecursiveBinarySearch(arr, target);
            Assert.That(actual, Is.EqualTo(expected));
        }

        #endregion

    }
}