using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2010.Round1A.Rotate.src
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
                newCase.K = values[1];
                newCase.GridSize = values[0];
                newCase.Grid = new char[newCase.GridSize, newCase.GridSize];
                for (int j = 0; j < newCase.GridSize; j++)
                {
                    for (int l = 0; l < newCase.GridSize; l++)
                    {
                        var line = i + newCase.GridSize - j;
                        newCase.Grid[j, l] = lines[line][l];
                    }
                }

                cases.Add(newCase);
                i += newCase.GridSize;
            }

            return cases;
        }
    }
}