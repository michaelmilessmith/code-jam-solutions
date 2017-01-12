using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeJam._2009.QualificationRound.AlienLanguage.src
{
    public class Solver
    {
        public List<string> ValidWords { get; set; }

        public char[][] ValidCharacters { get; set; }

        public void PopulateValidCharacters(List<string> validWords)
        {
            this.ValidCharacters = new char[validWords.Count][];
            for (int i = 0; i < ValidCharacters.Length; i++)
            {
                ValidCharacters[i] = ValidWords[i].ToArray();
            }
        }

        public int RegexSolve(string message)
        {
            Regex reg = new Regex(message.Replace('(', '[').Replace(')', ']'));
            return ValidWords.Where(w => reg.IsMatch(w)).Count();
        }

        public int Solve(string message)
        {
            var newMessage = this.ParseMessage(message);
            var total = 0;
            for (int i = 0; i < ValidWords.Count; i++)
            {
                var word = ValidWords[i];
                var valids = new bool[newMessage.Count];
                for (int j = 0; j < newMessage.Count; j++)
                {
                    if (!newMessage[j].Contains(word[j]))
                    {
                        valids[j] = false;
                    }
                    else
                    {
                        valids[j] = true;
                    }
                }
                if (valids.All(b => b))
                    total++;
            }
            var regTotal = RegexSolve(message);
            if (total == regTotal)
            {
                return total;
            }
            return regTotal;
        }

        public List<char[]> ParseMessage(string message)
        {
            var newMessage = new List<char[]>();
            for (var i = 0; i < message.Length; i++)
            {
                if (message[i] != '(')
                {
                    newMessage.Add(new char[1] { message[i] });
                }
                else
                {
                    var end = message.IndexOf(')', i);
                    i++;
                    var length = end - i;
                    var newToken = new char[length];
                    for (var j = 0; j < length; j++)
                    {
                        newToken[j] = message[i];
                        i++;
                    }
                    newMessage.Add(newToken);
                }
            }
            return newMessage;
        }

        public List<string> GetAllCombinations(List<char[]> message)
        {
            var totalNumberOfCombonations = 1;
            var length = message.Count;
            var arraySizes = new int[length];
            for (var i = 0; i < message.Count; i++)
            {
                arraySizes[i] = message[i].Length;
                totalNumberOfCombonations *= arraySizes[i];
            }
            var map = new char[totalNumberOfCombonations, length];

            for (int i = 0; i < length; i++)
            {
                var numberOfCombonations = arraySizes.Take(i + 1).Aggregate(1, (a, b) => a * b);
                var split = numberOfCombonations / arraySizes[i];
                var repeats = totalNumberOfCombonations / numberOfCombonations;
                for (int j = 0; j < repeats; j++)
                {
                    for (int k = 0; k < arraySizes[i]; k++)
                    {
                        for (int h = 0; h < split; h++)
                        {
                            var position = (j * split * arraySizes[i]) + (k * split) + h;
                            map[position, i] = message[i][k];
                        }
                    }
                }
            }

            var list = new List<string>();
            for (int i = 0; i < totalNumberOfCombonations; i++)
            {
                var builder = new StringBuilder();
                for (int j = 0; j < length; j++)
                {
                    builder.Append(map[i, j]);
                }
                list.Add(builder.ToString());
            }
            return list;
        }
    }
}