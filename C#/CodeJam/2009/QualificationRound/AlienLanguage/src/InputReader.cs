using System.IO;
using System.Linq;

namespace CodeJam._2009.QualificationRound.AlienLanguage.src
{
    public class InputReader
    {
        public Case ReadInput(string file)
        {
            var lines = File.ReadAllLines(file).ToList();
            var newCase = new Case();
            var totals = lines[0].Split(' ').Select(l => int.Parse(l)).ToArray();
            newCase.WordLength = totals[0];
            newCase.ValidWords = lines.GetRange(1, totals[1]);
            newCase.Messages = lines.GetRange(totals[1] + 1, totals[2]);

            if (newCase.ValidWords.Count == totals[1] &&
                newCase.Messages.Count == totals[2])
                return newCase;

            return null;
        }
    }
}