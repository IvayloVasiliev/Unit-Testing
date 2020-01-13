using CustomLinkedList;
using NUnit.Framework;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class Tests
    {
        private const int InitialCount = 0;

        [Test]
        public void CtorShouldSetCountToZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.AreEqual(list.Count, InitialCount);

        }
    }
}