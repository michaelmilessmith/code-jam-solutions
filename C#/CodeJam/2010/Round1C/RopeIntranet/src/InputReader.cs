using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2010.Round1C.RopeIntranet.src
{
    public class InputReader
    {
        public List<Case> ReadInput(string fileName)
        {
            var lines = File.ReadAllLines(fileName).ToList();
            return ReadLines(lines);
        }

        public List<Case> ReadLines(List<string> lines)
        {
            var cases = new List<Case>();
            var total = int.Parse(lines[0]);
            for (int i = 1; i < lines.Count; i++)
            {
                var newCase = new Case();
                var values = int.Parse(lines[i]);

                newCase.WireHeights = new List<Tuple<int, int>>();
                for (int j = 0; j < values; j++)
                {
                    var line = lines[i + j + 1].Split(' ').Select(x => int.Parse(x)).ToArray();
                    newCase.WireHeights.Add(new Tuple<int, int>(line[0], line[1]));
                }

                cases.Add(newCase);
                i += values;
            }

            return cases;
        }
    }
}