using CustomLinkedList;
using NUnit.Framework;
using System;

namespace CustomLinkedListTests
{
    [TestFixture]
    public class CustomListTests
    {
        private const int InitialCount = 0;

        [Test]
        public void CtorShouldSetCountToZero()
        {
            DynamicList<int> list = new DynamicList<int>();

            Assert.AreEqual(list.Count, InitialCount);
        }

        [Test]
        public void IndexOperatorShouldReturnValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(13);

            int element = list[0];

            Assert.AreEqual(13, element);
        }

        [Test]
        public void IndexOperatorShouldSetrValue()
        {
            DynamicList<int> list = new DynamicList<int>();

            list.Add(13);

            list[0] = 42;

            Assert.That(list[0], Is.EqualTo(42));
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldthrowExceptionWhenGetingInvalidIndex(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            int returnValue = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = list[index]);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(int.MaxValue)]
        [TestCase(100)]
        public void IndexOperatorShouldThrowExceptionWhenSetInvalidIndex(int index)
        {
            DynamicList<int> list = new DynamicList<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69);
        }
    }
}