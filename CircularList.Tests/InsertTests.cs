using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    //нужно сильно отрефакторить
    public class InsertTests
    {
        [Test]
        public void Insert_WhenListIsEmptyAndIndexEqualsZero_AddsItem()
        {
            CircularList<int> list = new();

            list.Insert(0, 0);

            //отрефакторить это
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(0, list[1]);
            Assert.AreEqual(0, list[10]);
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void Insert_WhenListIsEmptyAndIndexDoesNotEqualZero_ThrowsInvalidOperationException(int index)
        {
            CircularList<int> list = new();

            TestDelegate act = () => list.Insert(index, 0);

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void Insert_WhenListIsNotEmptyAndIndexIsNegative_ThrowsArgumentOutOfRangeException()
        {
            CircularList<int> list = new();
            list.Add(0);

            TestDelegate act = () => list.Insert(-1, 0);

            Assert.Throws<ArgumentOutOfRangeException>(act);
        }

        [Test]
        [TestCase(0)]
        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void Insert_WhenListIsNotEmptyAndIndexIsZeroOrCycleZero_InsertsItemCorrectly(int index)
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.Insert(index, 9);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(9, list[0]);
            Assert.AreEqual(0, list[1]);
            Assert.AreEqual(1, list[2]);
            Assert.AreEqual(2, list[3]);
            Assert.AreEqual(9, list[4]);
        }

        [Test]
        [TestCase(1)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(10)]
        public void Insert_WhenListIsNotEmptyAndIndexIsOneOrCycleOne_InsertsItemCorrectly(int index)
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.Insert(index, 9);

            Assert.AreEqual(4, list.Count);
            Assert.AreEqual(0, list[0]);
            Assert.AreEqual(9, list[1]);
            Assert.AreEqual(1, list[2]);
            Assert.AreEqual(2, list[3]);
            Assert.AreEqual(0, list[4]);
            Assert.AreEqual(9, list[5]);
        }
    }
}
