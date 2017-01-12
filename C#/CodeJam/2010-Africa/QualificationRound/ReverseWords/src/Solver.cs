using System.Collections.Generic;

namespace CodeJam._2010___Africa.QualificationRound.ReverseWords.src
{
    public class Solver
    {
        public string Solve(string newCase)
        {
            var words = newCase.Split(' ');
            var newLine = new List<string>();
            for (int i = words.Length - 1; i > -1; i--)
            {
                newLine.Add(words[i]);
            }
            return string.Join(" ", newLine);
        }
    }
}