using CodeJam._2015.QualificationRound.Dijkstra.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests._2015.QualificationRound
{
    [TestClass]
    public class DijkstraTest
    {
        [TestMethod]
        public void ProduceLineTest()
        {
            var reader = new InputReader();
            var result = reader.GetLine("ijk", 5);
            Assert.AreEqual("ijkijkijkijkijk", result);
        }

        [TestMethod]
        public void GetNumberOfRepeatsTest()
        {
            var reader = new InputReader();
            var result = reader.GetNumberOfRepeats("2 6");
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void MultiplyQuaternionsTest()
        {
            var solver = new Solver();
            var result = solver.MultiplyQuaternions("1", "1");
            Assert.AreEqual("1", result);

            //1
            result = solver.MultiplyQuaternions("i", "1");
            Assert.AreEqual("i", result);
            result = solver.MultiplyQuaternions("j", "1");
            Assert.AreEqual("j", result);
            result = solver.MultiplyQuaternions("k", "1");
            Assert.AreEqual("k", result);

            //i
            result = solver.MultiplyQuaternions("i", "i");
            Assert.AreEqual("-1", result);
            result = solver.MultiplyQuaternions("i", "j");
            Assert.AreEqual("k", result);
            result = solver.MultiplyQuaternions("i", "k");
            Assert.AreEqual("-j", result);

            //j
            result = solver.MultiplyQuaternions("j", "i");
            Assert.AreEqual("-k", result);
            result = solver.MultiplyQuaternions("j", "j");
            Assert.AreEqual("-1", result);
            result = solver.MultiplyQuaternions("j", "k");
            Assert.AreEqual("i", result);

            //k
            result = solver.MultiplyQuaternions("k", "i");
            Assert.AreEqual("j", result);
            result = solver.MultiplyQuaternions("k", "j");
            Assert.AreEqual("-i", result);
            result = solver.MultiplyQuaternions("k", "k");
            Assert.AreEqual("-1", result);

            //+-i
            result = solver.MultiplyQuaternions("-i", "i");
            Assert.AreEqual("1", result);
            result = solver.MultiplyQuaternions("-i", "j");
            Assert.AreEqual("-k", result);
            result = solver.MultiplyQuaternions("-i", "k");
            Assert.AreEqual("j", result);

            //--i
            result = solver.MultiplyQuaternions("-i", "-i");
            Assert.AreEqual("-1", result);
            result = solver.MultiplyQuaternions("-i", "-j");
            Assert.AreEqual("k", result);
            result = solver.MultiplyQuaternions("-i", "-k");
            Assert.AreEqual("-j", result);
        }

        [TestMethod]
        public void SimplifyTest()
        {
            var solver = new Solver();
            var result = solver.Simplify("jij");
            Assert.AreEqual("i", result);
        }

        [TestMethod]
        public void SolveTest()
        {
            var solver = new Solver();
            var result = solver.Solve("ik", 1);
            Assert.AreEqual(false, result);

            result = solver.Solve("ijk", 1);
            Assert.AreEqual(true, result);

            result = solver.Solve("kji", 1);
            Assert.AreEqual(false, result);

            result = solver.Solve("ji", 6);
            Assert.AreEqual(true, result);
        }
    }
}