using System.Collections.Generic;
using System.IO;

namespace CodeJam._2009.QualificationRound.AlienLanguage.src
{
    public class AlienLanguage
    {
        private readonly static string _path = "2009/QualificationRound/AlienLanguage";

        public static void Solve(string filename)
        {
            var cases = new InputReader().ReadInput(Path.Combine(_path, filename));
            var solver = new Solver();
            solver.ValidWords = cases.ValidWords;
            var lines = new List<string>();
            for (int i = 0; i < cases.Messages.Count; i++)
            {
                var result = solver.Solve(cases.Messages[i]);
                lines.Add("Case #" + (i + 1) + ": " + result);
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}