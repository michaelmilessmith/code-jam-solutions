using CodeJam._2015.QualificationRound.OminousOmino.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests._2015.QualificationRound
{
    [TestClass]
    public class OminousOminoTest
    {
        [TestMethod]
        public void SolveTest()
        {
            var solver = new Solver();
            var result = solver.RichardWins(new Case() { X = 2, R = 2, C = 2 });
            Assert.AreEqual(false, result);
            result = solver.RichardWins(new Case() { X = 2, R = 1, C = 3 });
            Assert.AreEqual(true, result);
            result = solver.RichardWins(new Case() { X = 4, R = 4, C = 1 });
            Assert.AreEqual(true, result);
            result = solver.RichardWins(new Case() { X = 3, R = 2, C = 3 });
            Assert.AreEqual(false, result);
        }
    }
}