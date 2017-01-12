using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.OminousOmino.src
{
    public class OminousOmino
    {
        private readonly static string _path = "2015/QualificationRound/OminousOmino";

        public static void Solve(string filename)
        {
            var cases = new InputReader().ReadInput(Path.Combine(_path, filename));
            var solver = new Solver();
            var lines = new List<string>();
            for (int i = 0; i < cases.Count; i++)
            {
                var result = solver.RichardWins(cases[i]) ? "RICHARD" : "GABRIEL";
                lines.Add("Case #" + (i + 1) + ": " + result);
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}