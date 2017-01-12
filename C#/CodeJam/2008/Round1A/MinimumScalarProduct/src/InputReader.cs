using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2008.Round1A.MinimumScalarProduct.src
{
    public class InputReader
    {
        public List<Case> ReadInput(string file)
        {
            var lines = File.ReadAllLines(file).ToList();
            var cases = new List<Case>();
            var total = lines[0];

            for (int i = 1; i < lines.Count; i += 3)
            {
                var newCase = new Case();
                newCase.Length = int.Parse(lines[i]);
                newCase.Xs = lines[i + 1].Split(' ').Select(l => long.Parse(l)).ToArray();
                newCase.Ys = lines[i + 2].Split(' ').Select(l => long.Parse(l)).ToArray();

                cases.Add(newCase);
            }

            return cases;
        }
    }
}