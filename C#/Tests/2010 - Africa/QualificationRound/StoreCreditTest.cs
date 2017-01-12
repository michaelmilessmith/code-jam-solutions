using CodeJam._2010___Africa.QualificationRound.StoreCredit.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests._2010___Africa.QualificationRound
{
    [TestClass]
    public class StoreCreditTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve(new Case() { Credit = 100, Count = 3, Items = new List<int>() { 5, 75, 25 } });
            CollectionAssert.AreEqual(new int[2] { 2, 3 }, result);

            result = solver.Solve(new Case() { Credit = 200, Count = 7, Items = new List<int>() { 150, 24, 79, 50, 88, 345, 3 } });
            CollectionAssert.AreEqual(new int[2] { 1, 4 }, result);

            result = solver.Solve(new Case() { Credit = 8, Count = 8, Items = new List<int>() { 2, 1, 9, 4, 4, 56, 90, 3 } });
            CollectionAssert.AreEqual(new int[2] { 4, 5 }, result);
        }
    }
}