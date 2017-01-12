using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2010.Round1B.FileFix_it.src
{
    public class InputReader : InputReader<Case>
    {
        public List<Case> ReadInput(string file)
        {
            var lines = File.ReadAllLines(file).ToList();
            var cases = new List<Case>();
            var total = int.Parse(lines[0]);
            for (int i = 1; i < lines.Count; i++)
            {
                var newCase = new Case();
                var values = lines[i].Split(' ').Select(l => int.Parse(l)).ToArray();

                newCase.Exists = new List<string>();
                for (int j = 0; j < values[0]; j++)
                {
                    newCase.Exists.Add(lines[i + j + 1]);
                }

                newCase.ToCreate = new List<string>();
                for (int j = 0; j < values[1]; j++)
                {
                    newCase.ToCreate.Add(lines[i + values[0] + j + 1]);
                }

                cases.Add(newCase);
                i += values[1] + values[0];
            }

            return cases;
        }
    }
}