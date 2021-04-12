using NUnit.Framework;
using System;

namespace CircularList.Tests
{
    public static class CircularListTestsHelper
    {
        public static CircularList<int> CreateListAndAddNineItems()
        {
            CircularList<int> list = new();
            for (int i = 0; i < 9; i++)
                list.Add(i);
            return list;
        }

        public static CircularList<int> CreateListAndAddNineItemsAndMoveNextFourTimes()
        {
            CircularList<int> list = CreateListAndAddNineItems();
            for (int i = 0; i < 4; i++)
                list.MoveNext();
            return list;
        }

        public static void AssertCurrentPreviousNext(CircularList<int> list, int current, int previous, int next)
        {
            Assert.AreEqual(current, list.Current);
            Assert.AreEqual(previous, list.Previous);
            Assert.AreEqual(next, list.Next);
        }
    }
}
