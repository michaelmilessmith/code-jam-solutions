using CodeJam._2010.Round1A.Rotate.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests._2010.Round1A
{
    [TestClass]
    public class RotateTest
    {
        [TestMethod]
        public void GravityRight()
        {
            var solver = new Solver();
            var map = new char[7, 7];

            map[0, 1] = 'R';
            map[0, 2] = 'B';
            map[0, 3] = 'B';
            map[0, 4] = 'R';
            map[1, 2] = 'B';
            map[1, 3] = 'R';
            map[1, 4] = 'B';
            map[2, 3] = 'R';
            map[2, 4] = 'B';
            map[3, 3] = 'R';

            var result = solver.GravityRight(map);

            var expected = new char[7, 7];

            expected[0, 3] = 'R';
            expected[0, 4] = 'B';
            expected[0, 5] = 'B';
            expected[0, 6] = 'R';
            expected[1, 4] = 'B';
            expected[1, 5] = 'R';
            expected[1, 6] = 'B';
            expected[2, 5] = 'R';
            expected[2, 6] = 'B';
            expected[3, 6] = 'R';

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GravityRightCorner()
        {
            var solver = new Solver();
            var map = new char[7, 7];

            map[0, 1] = 'R';
            map[0, 2] = 'B';
            map[0, 3] = 'B';
            map[0, 4] = 'R';
            map[1, 2] = 'B';
            map[1, 3] = 'R';
            map[1, 4] = 'B';
            map[2, 3] = 'R';
            map[2, 4] = 'B';
            map[3, 3] = 'R';

            var result = solver.GravityRightCorner(map);

            var expected = new List<string>
            {
                "RBBR",
                "BRB",
                "BR",
                "R"
            };

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CheckWin()
        {
            var solver = new Solver();
            var map = new List<string>
            {
                "RBBR",
                "BRB",
                "BR",
                "R"
            };

            var result = solver.CheckWin(map, 'B', 3);
            Assert.AreEqual(false, result);

            result = solver.CheckWin(map, 'R', 3);
            Assert.AreEqual(false, result);

            map = new List<string>
            {
                "RBBB",
                "BRB",
                "BR",
                "R"
            };

            result = solver.CheckWin(map, 'B', 3);
            Assert.AreEqual(true, result);

            result = solver.CheckWin(map, 'R', 3);
            Assert.AreEqual(false, result);

            map = new List<string>
            {
                "RRBB",
                "BRB",
                "BR",
                "R"
            };

            result = solver.CheckWin(map, 'B', 3);
            Assert.AreEqual(false, result);

            result = solver.CheckWin(map, 'R', 3);
            Assert.AreEqual(true, result);

            map = new List<string>
            {
                "RRBB",
                "BRB",
                "BB",
                "R"
            };

            result = solver.CheckWin(map, 'B', 3);
            Assert.AreEqual(true, result);

            result = solver.CheckWin(map, 'R', 3);
            Assert.AreEqual(false, result);
            map = new List<string>
            {
                "RRBB",
                "BRR",
                "BBR",
                "R"
            };

            result = solver.CheckWin(map, 'B', 3);
            Assert.AreEqual(false, result);

            result = solver.CheckWin(map, 'R', 3);
            Assert.AreEqual(true, result);
        }
    }
}