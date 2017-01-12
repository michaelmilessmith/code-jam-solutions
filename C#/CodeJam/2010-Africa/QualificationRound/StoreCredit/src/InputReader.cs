using System.Collections.Generic;
using System.IO;

namespace CodeJam._2010___Africa.QualificationRound.StoreCredit.src
{
    public class InputReader : InputReader<Case>
    {
        public List<Case> ReadInput(string file)
        {
            var lines = File.ReadAllLines(file);
            var cases = new List<Case>();
            var total = int.Parse(lines[0]);
            for (int i = 1; i < (total * 3) + 1; i += 3)
            {
                var newCase = new Case();
                newCase.Credit = this.ReadCredit(lines[i]);
                newCase.Count = this.ReadCredit(lines[i + 1]);
                newCase.Items = this.ReadItems(lines[i + 2]);
                cases.Add(newCase);
            }
            return cases;
        }

        public int ReadCredit(string line)
        {
            return int.Parse(line);
        }

        public int ReadCount(string line)
        {
            return int.Parse(line);
        }

        public List<int> ReadItems(string line)
        {
            var values = line.Split(' ');
            var items = new List<int>();
            for (int i = 0; i < values.Length; i++)
            {
                items.Add(int.Parse(values[i]));
            }
            return items;
        }
    }
}