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

        [Test]
        public void MoveNext_WhenListIsEmpty_ThrowsInvalidOperationException()
        {
            CircularList<int> list = new();

            TestDelegate act = () => list.MoveNext();

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndOneMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();

            Assert.AreEqual(1, list.Current);
            Assert.AreEqual(0, list.Previous);
            Assert.AreEqual(2, list.Next);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveNext();

            Assert.AreEqual(2, list.Current);
            Assert.AreEqual(1, list.Previous);
            Assert.AreEqual(0, list.Next);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndThreeMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveNext();
            list.MoveNext();

            Assert.AreEqual(0, list.Current);
            Assert.AreEqual(2, list.Previous);
            Assert.AreEqual(1, list.Next);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNextAndAddItem_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveNext();
            list.Add(3);

            Assert.AreEqual(2, list.Current);
            Assert.AreEqual(1, list.Previous);
            Assert.AreEqual(3, list.Next);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNextAndAddItemAndOneMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveNext();
            list.Add(3);
            list.MoveNext();

            Assert.AreEqual(3, list.Current);
            Assert.AreEqual(2, list.Previous);
            Assert.AreEqual(0, list.Next);
        }

        [Test]
        public void MoveBack_WhenListIsEmpty_ThrowsInvalidOperationException()
        {
            CircularList<int> list = new();

            TestDelegate act = () => list.MoveBack();

            Assert.Throws<InvalidOperationException>(act);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndOneMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveBack();

            Assert.AreEqual(2, list.Current);
            Assert.AreEqual(1, list.Previous);
            Assert.AreEqual(0, list.Next);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndTwoMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveBack();
            list.MoveBack();

            Assert.AreEqual(1, list.Current);
            Assert.AreEqual(0, list.Previous);
            Assert.AreEqual(2, list.Next);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndThreeMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveBack();
            list.MoveBack();
            list.MoveBack();

            Assert.AreEqual(0, list.Current);
            Assert.AreEqual(2, list.Previous);
            Assert.AreEqual(1, list.Next);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndOneMoveBackAndAddItem_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveBack();
            list.Add(3);

            Assert.AreEqual(2, list.Current);
            Assert.AreEqual(1, list.Previous);
            Assert.AreEqual(3, list.Next);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndOneMoveBackOneMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveBack();
            list.MoveNext();

            Assert.AreEqual(0, list.Current);
            Assert.AreEqual(2, list.Previous);
            Assert.AreEqual(1, list.Next);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndOneMoveNextOneMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveBack();

            Assert.AreEqual(0, list.Current);
            Assert.AreEqual(2, list.Previous);
            Assert.AreEqual(1, list.Next);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndThreeMoveNextOneMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.MoveNext();
            list.MoveNext();
            list.MoveNext();
            list.MoveBack();

            Assert.AreEqual(2, list.Current);
            Assert.AreEqual(1, list.Previous);
            Assert.AreEqual(0, list.Next);
        }
    }
}
