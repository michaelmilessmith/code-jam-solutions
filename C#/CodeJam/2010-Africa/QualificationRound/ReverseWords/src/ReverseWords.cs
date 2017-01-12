using System.Collections.Generic;
using System.IO;

namespace CodeJam._2010___Africa.QualificationRound.ReverseWords.src
{
    public class ReverseWords
    {
        private readonly static string _path = "2010-Africa/QualificationRound/ReverseWords";

        public static void Solve(string filename)
        {
            var cases = File.ReadAllLines(Path.Combine(_path, filename));
            var solver = new Solver();
            var lines = new List<string>();
            for (int i = 1; i < cases.Length; i++)
            {
                var result = solver.Solve(cases[i]);
                lines.Add("Case #" + (i) + ": " + result);
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}