using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2009.Round1C.AllYourBase.src
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
                newCase.Number = lines[i];
                cases.Add(newCase);
            }

            return cases;
        }
    }
}