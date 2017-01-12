using System.Collections.Generic;
using System.IO;

namespace CodeJam._2015.QualificationRound.Dijkstra.src
{
    public class InputReader : InputReader<Case>
    {
        public List<Case> ReadInput(string file)
        {
            var lines = File.ReadAllLines(file);
            var cases = new List<Case>();
            var total = int.Parse(lines[0]);
            for (int i = 1; i < (total * 2) + 1; i += 2)
            {
                var newCase = new Case();
                newCase.Repeats = this.GetNumberOfRepeats(lines[i]);
                newCase.Repeatable = lines[i + 1];
                cases.Add(newCase);
            }
            return cases;
        }

        public long GetNumberOfRepeats(string line)
        {
            var parts = line.Split(' ');
            return long.Parse(parts[1]);
        }

        public string GetLine(string repeatable, long repeats)
        {
            var array = new string[repeats];
            for (int i = 0; i < repeats; i++)
                array[i] = repeatable;
            return string.Join(string.Empty, array);
        }
    }
}