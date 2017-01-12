using CodeJam._2010.Round1C.RopeIntranet.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests._2010.Round1C
{
    [TestClass]
    public class RopeIntranetTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve(new Case()
            {
                WireHeights = new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,10),
                    new Tuple<int, int>(5,5),
                    new Tuple<int, int>(7,7)
                }
            });
            Assert.AreEqual(2, result);

            result = solver.Solve(new Case()
            {
                WireHeights = new List<Tuple<int, int>>()
                {
                    new Tuple<int, int>(1,1),
                    new Tuple<int, int>(2,2)
                }
            });
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void InputReader()
        {
            var reader = new InputReader();
            var result = reader.ReadLines(new List<string>()
            {
                "2",
                "3",
                "1 10",
                "5 5",
                "7 7",
                "2",
                "1 1",
                "2 2"
            });
            var expected = new List<Case>()
            {
                new Case()
                {
                    WireHeights = new List<Tuple<int, int>>()
                    {
                    new Tuple<int, int>(1,10),
                    new Tuple<int, int>(5,5),
                    new Tuple<int, int>(7,7)
                    }
                },
                new Case()
                {
                    WireHeights = new List<Tuple<int, int>>()
                    {
                    new Tuple<int, int>(1,1),
                    new Tuple<int, int>(2,2)
                    }
                }
            };
            CollectionAssert.AreEqual(expected[0].WireHeights, result[0].WireHeights);
            CollectionAssert.AreEqual(expected[1].WireHeights, result[1].WireHeights);
        }
    }
}