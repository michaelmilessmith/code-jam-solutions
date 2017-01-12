using CodeJam._2015.QualificationRound.InfiniteHouseOfPancakes.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests._2015.QualificationRound
{
    [TestClass]
    public class InfiniteHouseOfPancakesTest
    {
        [TestMethod]
        public void DinersEatTest()
        {
            var solver = new Solver();
            var array = new int[6] { 0, 4, 3, 1, 2, 4 };
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[5] { 4, 3, 1, 2, 4 }, array);
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[4] { 3, 1, 2, 4 }, array);
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[3] { 1, 2, 4 }, array);
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[2] { 2, 4 }, array);
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[1] { 4 }, array);
            array = solver.DinersEat(array);
            CollectionAssert.AreEqual(new int[0], array);
        }

        [TestMethod]
        public void RedistibutePancakesTest()
        {
            var solver = new Solver();
            var array = new int[6] { 0, 4, 3, 1, 2, 4 };
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[5] { 0, 4, 7, 5, 2 }, array);
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[4] { 0, 4, 11, 5 }, array);
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[3] { 0, 9, 16 }, array);
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[2] { 0, 41 }, array);
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[2] { 41, 41 }, array);

            array = new int[9] { 0, 0, 0, 1, 1, 0, 0, 1, 2 };
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[8] { 0, 0, 0, 1, 5, 0, 0, 1 }, array);
            array = solver.RedistibutePancakes(array);
            CollectionAssert.AreEqual(new int[5] { 0, 0, 0, 2, 6 }, array);
        }

        [TestMethod]
        public void ReadLineTwoTest()
        {
            var reader = new InputReader();
            var array = reader.ReadLineTwo("4 8 7 8 3");
            CollectionAssert.AreEqual(new int[9] { 0, 0, 0, 1, 1, 0, 0, 1, 2 }, array);
        }

        [TestMethod]
        public void SolveTest()
        {
            var solver = new Solver();
            var reader = new InputReader();

            var array = reader.ReadLineTwo("3");
            var minutes = solver.Solve(array);
            Assert.AreEqual(3, minutes);

            array = reader.ReadLineTwo("1 2 1 2");
            minutes = solver.Solve(array);
            Assert.AreEqual(2, minutes);

            array = reader.ReadLineTwo("4");
            minutes = solver.Solve(array);
            Assert.AreEqual(3, minutes);

            array = reader.ReadLineTwo("2 1");
            minutes = solver.Solve(array);
            Assert.AreEqual(2, minutes);

            array = reader.ReadLineTwo("4 8 7 8 3");
            minutes = solver.Solve(array);
            Assert.AreEqual(7, minutes);

            array = reader.ReadLineTwo("3 1 5 5 1");
            minutes = solver.Solve(array);
            Assert.AreEqual(5, minutes);

            array = reader.ReadLineTwo("6 5 4 3 2 1");
            minutes = solver.Solve(array);
            Assert.AreEqual(6, minutes);

            array = reader.ReadLineTwo("8 8 8");
            minutes = solver.Solve(array);
            Assert.AreEqual(7, minutes);

            array = reader.ReadLineTwo("9");
            minutes = solver.Solve(array);
            Assert.AreEqual(5, minutes);
        }
    }
}