using CodeJam._2010___Africa.QualificationRound.ReverseWords.src;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests._2010___Africa.QualificationRound
{
    [TestClass]
    public class ReverseWordsTest
    {
        [TestMethod]
        public void Solver()
        {
            var solver = new Solver();
            var result = solver.Solve("this is a test");
            Assert.AreEqual("test a is this", result);

            result = solver.Solve("foobar");
            Assert.AreEqual("foobar", result);

            result = solver.Solve("all your base");
            Assert.AreEqual("base your all", result);
        }
    }
}