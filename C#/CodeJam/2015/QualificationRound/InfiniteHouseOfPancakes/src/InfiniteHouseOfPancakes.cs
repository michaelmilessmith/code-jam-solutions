using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.InfiniteHouseOfPancakes.src
{
    public class InfiniteHouseOfPancakes
    {
        private readonly static string _path = "2015/QualificationRound/InfiniteHouseOfPancakes";

        public static void Solve(string filename)
        {
            var cases = new InputReader().ReadInput(Path.Combine(_path, filename));
            var solver = new Solver();
            var lines = new List<string>();
            for (int i = 0; i < cases.Count; i++)
            {
                var minutes = solver.Solve(cases[i].PancakeDistribution);
                lines.Add("Case #" + (i + 1) + ": " + minutes);
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}