using NUnit.Framework;
using System;

namespace CircularList.Tests
{
    public static class CircularListTestsHelper
    {
        public static CircularList<int> CreateListAndAddThreeItems()
        {
            CircularList<int> list = new();
            list.Add(0);
            list.Add(1);
            list.Add(2);
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
