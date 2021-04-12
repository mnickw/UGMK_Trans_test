using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    public class RemoveAtTests
    {
        [Test]
        public void RemoveAt_WhenListIsNotEmptyAndIndexIsGreaterThanPointerAndLessThanCount_RemovesItemAndDoesNotChangePointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.RemoveAt(5);
            //    v
            //01234678

            Assert.AreEqual(8, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 4, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 4, 3, 6);
        }

        [Test]
        public void RemoveAt_WhenListIsNotEmptyAndIndexEqualsPointer_RemovesItemAndMovesLeftPointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.RemoveAt(4);
            //   v
            //01235678

            Assert.AreEqual(8, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 3, 5, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 3, 2, 5);
        }

        [Test]
        public void RemoveAt_WhenListIsNotEmptyAndIndexLessThanPointer_RemovesItemAndMovesLeftPointer()
        {
            var list = CreateListAndAddNineItemsAndMoveNextFourTimes();
            //    v
            //012345678

            list.RemoveAt(3);
            //   v
            //01245678

            Assert.AreEqual(8, list.Count);
            CollectionAssert.AreEqual(new[] { 0, 1, 2, 4, 5, 6, 7, 8 }, list);
            AssertCurrentPreviousNext(list, 4, 2, 5);
        }

        [Test]
        public void RemoveAt_WhenListHasOneItemAndIndexEqualsPointerEqualsZero_RemovesItemAndRemovesPointer()
        {
            var list = new CircularList<int>();
            list.Add(0);
            //v
            //0

            list.RemoveAt(0);
            //empty

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[0], list);
            Assert.Throws<InvalidOperationException>(() => { var item = list.Current; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Previous; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Next; });
        }
    }
}
