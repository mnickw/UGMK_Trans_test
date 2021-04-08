using NUnit.Framework;

namespace CircularList.Tests
{
    public class Tests
    {
        // посмотреть какие еще методы и свойства есть у дефолтного листа
        
        // можно добавить и нулевой элемент будет присут
        // два эл будут
        // три, цикличные индексы работают (несколько тестов)
        // пустой лист - искл при индексе
        // правильный Count (0,1,2)
        // overflow

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}