using NUnit.Framework;
using System;

namespace CircularList.Tests
{
    public class ICircularListPartTests
    {
        [Test]
        public void Current_WhenListIsEmpty_ThrowsInvalidOperationException()
        {
            CircularList<int> list = new();

            TestDelegate act = () => { var item = list.Current; };

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void Current_WhenJustAddFewItems_ReturnsFirstItem()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            var actualValue = list.Current;

            Assert.AreEqual(0, actualValue);
        }

        [Test]
        public void Previous_WhenListIsEmpty_ThrowsInvalidOperationException()
        {
            CircularList<int> list = new();

            TestDelegate act = () => { var item = list.Previous; };

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void Previous_WhenJustAddFewItems_ReturnsLastItem()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            var actualValue = list.Previous;

            Assert.AreEqual(2, actualValue);
        }

        [Test]
        public void Previous_WhenAddOnlyOneItem_ReturnsThisItem()
        {
            CircularList<int> list = new();
            list.Add(0);

            var actualValue = list.Previous;

            Assert.AreEqual(0, actualValue);
        }

        [Test]
        public void Next_WhenListIsEmpty_ThrowsInvalidOperationException()
        {
            CircularList<int> list = new();

            TestDelegate act = () => { var item = list.Next; };

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void Next_WhenJustAddFewItems_ReturnsSecondItem()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            var actualValue = list.Next;

            Assert.AreEqual(1, actualValue);
        }

        [Test]
        public void Next_WhenAddOnlyOneItem_ReturnsThisItem()
        {
            CircularList<int> list = new();
            list.Add(0);

            var actualValue = list.Next;

            Assert.AreEqual(0, actualValue);
        }
    }
}
