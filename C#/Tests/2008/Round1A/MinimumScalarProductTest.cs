using CodeJam._2008.Round1A.MinimumScalarProduct.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests._2008.Round1A
{
    [TestClass]
    public class MinimumScalarProductTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve(new Case() { Length = 3, Xs = new long[3] { 1, 3, -5 }, Ys = new long[3] { -2, 4, 1 } });
            Assert.AreEqual(-25, result);

            result = solver.Solve(new Case() { Length = 5, Xs = new long[5] { 1, 2, 3, 4, 5 }, Ys = new long[5] { 1, 0, 1, 0, 1 } });
            Assert.AreEqual(6, result);
        }
    }
}