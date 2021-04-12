using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    public class ClearTests
    {
        [Test]
        public void Clear_WhenListIsNotEmpty_RemovesItemsAndRemovesPointer()
        {
            var list = new CircularList<int>() { 0, 1, 2 };

            list.Clear();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[0], list);
            Assert.Throws<InvalidOperationException>(() => { var item = list.Current; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Previous; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Next; });
        }

        [Test]
        public void Clear_WhenListIsEmpty_DoNothing()
        {
            var list = new CircularList<int>();

            list.Clear();

            Assert.AreEqual(0, list.Count);
            CollectionAssert.AreEqual(new int[0], list);
            Assert.Throws<InvalidOperationException>(() => { var item = list.Current; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Previous; });
            Assert.Throws<InvalidOperationException>(() => { var item = list.Next; });
        }
    }
}
