using CodeJam._2009.Round1C.AllYourBase.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests._2009.Round1C
{
    [TestClass]
    public class AllYourBaseTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve(new Case()
            {
                Number = "11001001"
            });
            Assert.AreEqual("201", result);

            result = solver.Solve(new Case()
            {
                Number = "cats"
            });
            Assert.AreEqual("75", result);

            result = solver.Solve(new Case()
            {
                Number = "zig"
            });
            Assert.AreEqual("11", result);
        }

        [TestMethod]
        public void GetBase()
        {
            var solver = new Solver();
            var result = solver.GetBase("11001001".ToCharArray());
            Assert.AreEqual(2, result);

            result = solver.GetBase("cats".ToCharArray());
            Assert.AreEqual(4, result);

            result = solver.GetBase("zig".ToCharArray());
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void GetMap()
        {
            var solver = new Solver();
            var result = solver.GetMap("11001001", 2);
            CollectionAssert.AreEqual(
                new Dictionary<char, int>()
                {
                    { '1', 1 },
                    { '0', 0 }
                },
                result);

            result = solver.GetMap("cats", 4);

            CollectionAssert.AreEqual(
                new Dictionary<char, int>()
                {
                    { 'c', 1 },
                    { 'a', 0 },
                    { 't', 2 },
                    { 's', 3 }
                },
                result);

            result = solver.GetMap("zig", 3);
            CollectionAssert.AreEqual(
                new Dictionary<char, int>()
                {
                    { 'z', 1 },
                    { 'i', 0 },
                    { 'g', 2 }
                },
                result);

            result = solver.GetMap("11111111", 2);
            CollectionAssert.AreEqual(
                new Dictionary<char, int>()
                {
                    { '1', 1 },
                    { '\0', 0 }
                },
                result);
        }

        [TestMethod]
        public void InputReader()
        {
            var reader = new InputReader();
            var result = reader.ReadLines(new List<string>()
            {
                "3",
                "11001001",
                "cats",
                "zig"
            });

            var expected = new List<Case>()
            {
                new Case()
                {
                    Number = "11001001"
                },
                new Case()
                {
                    Number = "cats"
                },
                new Case()
                {
                    Number = "zig"
                }
            };
            for (int i = 0; i < result.Count; i++)
            {
                Assert.AreEqual(expected[i].Number, result[i].Number);
            }
        }
    }
}