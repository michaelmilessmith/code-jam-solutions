using CodeJam._2010.Round1B.FileFix_it.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests._2010.Round1B
{
    [TestClass]
    public class FileFix_itTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve(new Case() { Exists = new List<string>(), ToCreate = new List<string>() { "/home/gcj/finals", "/home/gcj/quals" } });
            Assert.AreEqual(4, result);

            result = solver.Solve(new Case() { Exists = new List<string>() { "/chicken", "/chicken/egg" }, ToCreate = new List<string>() { "/chicken" } });
            Assert.AreEqual(0, result);

            result = solver.Solve(new Case() { Exists = new List<string>() { "/a" }, ToCreate = new List<string>() { "/a/b", "/a/c", "/b/b" } });
            Assert.AreEqual(4, result);
        }
    }
}