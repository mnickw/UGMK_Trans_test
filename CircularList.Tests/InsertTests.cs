using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    public class InsertTests
    {
        [Test]
        public void Insert_WhenListIsNotEmptyAndIndexIsGreaterThanPointerAndLessThanCount_InsertsItemAndDoesNotChangePointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.Insert(5, 9);
            //    v
            //0123495678

            Assert.AreEqual(10, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 9, 5, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 4, 3, 9);
        }

        [Test]
        public void Insert_WhenListIsNotEmptyAndIndexEqualsPointer_InsertsItemAndMovesRightPointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.Insert(4, 9);
            //     v
            //0123x45678

            Assert.AreEqual(10, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 9, 4, 5, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 4, 9, 5);
        }

        [Test]
        public void Insert_WhenListIsNotEmptyAndIndexLessThanPointer_InsertsItemAndMovesRightPointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.Insert(3, 9);
            //     v
            //012x345678

            Assert.AreEqual(10, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 9, 3, 4, 5, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 4, 3, 5);
        }

        [Test]
        public void Insert_WhenListIsEmptyAndIndexEqualsToZero_InsertsItemAndAddsPointer()
        {
            var list = new CircularList<int>();
            //empty

            list.Insert(0, 9);
            //v
            //0

            Assert.AreEqual(1, list.Count);
            CollectionAssert.AreEqual(new[] { 9 }, list);
            AssertCurrentPreviousNext(list, 9, 9, 9);
        }
    }
}
