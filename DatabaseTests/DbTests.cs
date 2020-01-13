namespace DatabaseTests
{
    using DatabaseP01;
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Reflection;

    [TestFixture]
    public class DbTests
    {
        private const int ArraySize = 16;
        private const int InitialArrayIndex = -1;

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PublicConstructorShouldInitData()
        {
            Database db = new Database();

            Type type = typeof(Database);

            var field = (int[])type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "data")
                .GetValue(db);

            var lenght = field.Length;

            Assert.That(lenght, Is.EqualTo(ArraySize));
        }

        [Test]
        public void PublicConstructorShouldInitIndexToMinusOne()
        {
            Database db = new Database();

            Type type = typeof(Database);

            var indexValue = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);


            Assert.That(indexValue, Is.EqualTo(InitialArrayIndex));
        }

        [Test]
        public void CtorShouldThrowInvalidOperationExceptionWithLargerArray()
        {
            int[] arr = new int[17];

            Assert.Throws<InvalidOperationException>(() => new Database(arr));
        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, })]
        [TestCase(new int[] { 1, 2, 3 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void CtorShouldSetIndexCorectly(int[] values)
        {

            Database db = new Database(values);

            Type type = typeof(Database);

            int expectedIndex = values.Length - 1;

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            Assert.AreEqual(expectedIndex, index);

        }

        [Test]
        [TestCase(new int[] { })]
        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15})]
        public void AddShouldIncreaseIndexCorectly(int[] values)
        {
            Database db = new Database(values);

            Type type = typeof(Database);

            db.Add(16);

            var index = (int)type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            int expectedIndex = values.Length;

            Assert.AreEqual(expectedIndex, index);        
        }

        [Test]
        public void AddWhenDBIsFullShouldThrowInvalidOperationException()
        {
            int[] arr = new int[16];

            Database db = new Database(arr);

            Assert.Throws<InvalidOperationException>(() => db.Add(1));
        
        }

        [Test]
        public void RemoveShouldDecreaseIndex()
        {
            int[] arr = new int[10];

            Database db = new Database(arr);

            Type type = typeof(Database);

            db.Remove();

            var index = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .First(f => f.Name == "index")
                .GetValue(db);

            int expectedInedx = arr.Length - 2;

            Assert.AreEqual(expectedInedx, index);
        }

        [Test]
        public void RemoveWhenDBIsEmptyShouldThrowInvalidOperationException()
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }
    }
}