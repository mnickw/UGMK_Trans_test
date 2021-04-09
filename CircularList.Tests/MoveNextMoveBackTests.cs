using NUnit.Framework;
using System;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    public class MoveNextMoveBackTests
    {
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
            var list = CreateListAndAddThreeItems();

            list.MoveNext();

            AssertCurrentPreviousNext(list, 1, 0, 2);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveNext();

            AssertCurrentPreviousNext(list, 2, 1, 0);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndThreeMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveNext();
            list.MoveNext();

            AssertCurrentPreviousNext(list, 0, 2, 1);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNextAndAddItem_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveNext();
            list.Add(3);

            AssertCurrentPreviousNext(list, 2, 1, 3);
        }

        [Test]
        public void MoveNext_WhenAddThreeItemsAndTwoMoveNextAndAddItemAndOneMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveNext();
            list.Add(3);
            list.MoveNext();

            AssertCurrentPreviousNext(list, 3, 2, 0);
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
            var list = CreateListAndAddThreeItems();

            list.MoveBack();

            AssertCurrentPreviousNext(list, 2, 1, 0);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndTwoMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveBack();
            list.MoveBack();

            AssertCurrentPreviousNext(list, 1, 0, 2);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndThreeMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveBack();
            list.MoveBack();
            list.MoveBack();

            AssertCurrentPreviousNext(list, 0, 2, 1);
        }

        [Test]
        public void MoveBack_WhenAddThreeItemsAndOneMoveBackAndAddItem_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveBack();
            list.Add(3);

            AssertCurrentPreviousNext(list, 2, 1, 3);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndOneMoveBackOneMoveNext_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveBack();
            list.MoveNext();

            AssertCurrentPreviousNext(list, 0, 2, 1);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndOneMoveNextOneMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveBack();

            AssertCurrentPreviousNext(list, 0, 2, 1);
        }

        [Test]
        public void MoveNextAndMoveBack_WhenAddThreeItemsAndThreeMoveNextOneMoveBack_CurrentAndPreviousAndNextWorksGood()
        {
            var list = CreateListAndAddThreeItems();

            list.MoveNext();
            list.MoveNext();
            list.MoveNext();
            list.MoveBack();

            AssertCurrentPreviousNext(list, 2, 1, 0);
        }
    }
}
