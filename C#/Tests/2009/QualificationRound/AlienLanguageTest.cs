using CodeJam._2009.QualificationRound.AlienLanguage.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests._2009.QualificationRound
{
    [TestClass]
    public class AlienLanguageTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            solver.ValidWords = (new List<string>()
            {
                "abc",
                "bca",
                "dac",
                "dbc",
                "cba"
            });
            var result = solver.Solve("(ab)(bc)(ca)");
            Assert.AreEqual(2, result);

            result = solver.Solve("abc");
            Assert.AreEqual(1, result);

            result = solver.Solve("(abc)(abc)(abc)");
            Assert.AreEqual(3, result);

            result = solver.Solve("(zyx)bc");
            Assert.AreEqual(0, result);
        }
    }
}