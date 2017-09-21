using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NovelTheory.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void BasicUse()
        {
            int countIt = 0;
            int expected = 9;

            var counter = new Every(33, t => ++countIt);

            for(int i =0; i <300; ++i)
                counter.Next();

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void PrefixIncrementer_Test()
        {
            int countIt = 0;
            int expected = 9;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                ++counter;

            Assert.AreEqual(expected, countIt);

        }


        [TestMethod]
        public void PostfixIncrementer_Test()
        {
            int countIt = 0;
            int expected = 9;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter++;

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void CallNow_Test()
        {
            int countIt = 0;
            int expected = 10;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter.Next();

            counter.CallNow();

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void CallEveryTime()
        {
            int countIt = 0;
            int expected = 300;

            var counter = new Every(1, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter.Next();

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void NeverCalled()
        {
            int countIt = 0;
            int expected = 0;

            var counter = new Every(301, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter.Next();

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void EdgeCall()
        {
            int countIt = 0;
            int expected = 1;

            var counter = new Every(300, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter.Next();

            Assert.AreEqual(expected, countIt);

        }

        [TestMethod]
        public void SplitUse()
        {
            int countIt = 0;

            int expected1st = 6;
            int expected2nd = 9;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 200; ++i)
                counter.Next();
            Assert.AreEqual(expected1st, countIt);

            for (int i = 0; i < 100; ++i)
                counter.Next();
            Assert.AreEqual(expected2nd, countIt);

        }

        [TestMethod]
        public void Total_Test()
        {
            int countIt = 0;
            int expected = 300;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 300; ++i)
                counter.Next();

            Assert.AreEqual(expected, counter.Total);

        }

        [TestMethod]
        public void Total_SplitTest()
        {
            int countIt = 0;
            int expected1st = 200;
            int expected2nd = 300;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 200; ++i)
                counter.Next();
            Assert.AreEqual(expected1st, counter.Total);

            for (int i = 0; i < 100; ++i)
                counter.Next();

            Assert.AreEqual(expected2nd, counter.Total);

        }

        [TestMethod]
        public void Reset_Test()
        {
            int countIt = 0;

            int expected1st = 200;
            int expected2nd = 100;

            var counter = new Every(33, t => ++countIt);

            for (int i = 0; i < 200; ++i)
                counter.Next();
            Assert.AreEqual(expected1st, counter.Total);

            counter.Reset();

            for (int i = 0; i < 100; ++i)
                counter.Next();

            Assert.AreEqual(expected2nd, counter.Total);

        }

    }
}
