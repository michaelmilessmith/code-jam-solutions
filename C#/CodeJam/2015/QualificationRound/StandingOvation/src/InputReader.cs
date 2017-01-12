using System;
using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.StandingOvation.src
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
                cases.Add(this.ReadLine(lines[i]));
            }
            return cases;
        }

        public Case ReadLine(string line)
        {
            var sections = line.Split(' ');
            var newCase = new Case();
            newCase.SMax = int.Parse(sections[0]);
            newCase.Audience = new int[newCase.SMax + 1];
            for (int i = 0; i < sections[1].Length; i++)
            {
                newCase.Audience[i] = (int)Char.GetNumericValue(sections[1][i]);
            }
            return newCase;
        }
    }
}