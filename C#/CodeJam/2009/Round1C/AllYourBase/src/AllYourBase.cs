﻿using System.Collections.Generic;
using System.IO;

namespace CodeJam._2009.Round1C.AllYourBase.src
{
    public static class AllYourBase
    {
        private readonly static string _path = "2009/Round1C/AllYourBase";

        public static void Solve(string filename)
        {
            var cases = new InputReader().ReadInput(Path.Combine(_path, filename));
            var solver = new Solver();
            var lines = new List<string>();
            for (int i = 0; i < cases.Count; i++)
            {
                var result = solver.Solve(cases[i]);
                lines.Add("Case #" + (i + 1) + ": " + result);
            }
            new OutputWriter().WriteOutput(Path.Combine(_path, filename), lines.ToArray());
        }
    }
}