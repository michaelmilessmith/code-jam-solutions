using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.OminousOmino.src
{
    public class InputReader : InputReader<Case>
    {
        public List<Case> ReadInput(string file)
        {
            var lines = File.ReadAllLines(file);
            var cases = new List<Case>();
            var total = int.Parse(lines[0]);
            for (int i = 1; i < total + 1; i++)
            {
                var newCase = new Case();
                var values = lines[i].Split(' ');
                newCase.X = int.Parse(values[0]);
                newCase.R = int.Parse(values[1]);
                newCase.C = int.Parse(values[2]);
                cases.Add(newCase);
            }
            return cases;
        }
    }
}