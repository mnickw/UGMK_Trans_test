using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static CircularList.Tests.CircularListTestsHelper;

namespace CircularList.Tests
{
    public class GetEnumeratorTests
    {
        [Test]
        public void GetEnumerator_WhenEmptyList_ReturnsEmptyEnumerator()
        {
            Assert.IsEmpty(new CircularList<int>());
        }

        IEnumerable<T> GetFirstElements<T>(CircularList<T> list, int count)
        {
            int i = 0;
            foreach (var item in list)
            {
                if (i < count) { yield return item; i++; }
                else break;
            }
        }

        [Test]
        [TestCase(1, 5)]
        [TestCase(2, 5)]
        [TestCase(3, 5)]
        public void GetEnumerator_WhenListIsNotEmpty_ReturnsItemsInfinitely(int countOfAddedItemsInList, int countOfHowManyTimesToCheckCycle)
        {
            CircularList<int> list = new();
            for (int i = 0; i < countOfAddedItemsInList; i++)
                list.Add(i);

            //Don't use Take Linq! It works like a finite list!
            var actualFirstElements = GetFirstElements(list, countOfHowManyTimesToCheckCycle * countOfAddedItemsInList);

            List<int> expectedElements = new List<int>();
            for (int i = 0; i < countOfHowManyTimesToCheckCycle; i++)
                for (int j = 0; j < countOfAddedItemsInList; j++)
                    expectedElements.Add(j);
            CollectionAssert.AreEqual(expectedElements, actualFirstElements);
        }
    }
}
