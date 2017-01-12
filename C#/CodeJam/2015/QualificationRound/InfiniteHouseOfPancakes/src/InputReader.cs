using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CodeJam._2015.QualificationRound.InfiniteHouseOfPancakes.src
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
                newCase.D = this.ReadLineOne(lines[i]);
                newCase.PancakeDistribution = this.ReadLineTwo(lines[i + 1]);
                cases.Add(newCase);
            }
            return cases;
        }

        public int ReadLineOne(string line)
        {
            return int.Parse(line);
        }

        public int[] ReadLineTwo(string line)
        {
            var sections = line.Split(' ');
            var diners = new int[sections.Length];
            for (int i = 0; i < sections.Length; i++)
            {
                diners[i] = int.Parse(sections[i]);
            }
            var pancakeDistribution = new int[diners.Max() + 1];
            for (int i = 0; i < diners.Length; i++)
            {
                pancakeDistribution[diners[i]]++;
            }
            return pancakeDistribution;
        }
    }
}