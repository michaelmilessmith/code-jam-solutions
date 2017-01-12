using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.StandingOvation.src
{
    public class StandingOvation
    {
        private readonly static string _path = "2015/QualificationRound/StandingOvation";

        public static void Solve(string filename)
        {
            var cases = new InputReader().ReadInput(Path.Combine(_path, filename));
            var solver = new Solver();
            var lines = new List<string>();
            for (int i = 0; i < cases.Count; i++)
            {
                lines.Add("Case #" + (i + 1) + ": " + solver.SolvePlants(cases[i]));
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}