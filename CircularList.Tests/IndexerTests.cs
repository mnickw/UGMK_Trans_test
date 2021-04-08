using NUnit.Framework;
using System;

namespace CircularList.Tests
{
    public class IndexerTests
    {
        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(3, 0)]
        [TestCase(4, 1)]
        [TestCase(5, 2)]
        [TestCase(6, 0)]
        [TestCase(7, 1)]
        [TestCase(8, 2)]
        public void Indexer_WhenIndexesAreGreaterThanListCount_ReturnsCircularValue(int indexToCheck, int expectedValue)
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            var actualValue = list[indexToCheck];

            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(1)]
        public void Indexer_WhenListIsEmpty_ThrowsInvalidOperationException(int indexToCheck)
        {
            CircularList<int> list = new();

            TestDelegate act = () => { var item = list[indexToCheck]; };

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void Indexer_WhenIndexIsNegativeAndListIsNotEmpty_ThrowsArgumentOutOfRangeException()
        {
            CircularList<int> list = new();
            list.Add(0);

            TestDelegate act = () => { var item = list[-1]; };

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }
    }
}
