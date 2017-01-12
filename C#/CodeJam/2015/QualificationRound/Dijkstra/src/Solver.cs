using System.Collections.Generic;
using System.Text;

namespace CodeJam._2015.QualificationRound.Dijkstra.src
{
    public class Solver
    {
        public int number { get; set; }

        public static Dictionary<string, string> QuaternionMultiplication = new Dictionary<string, string>
        {
            { "11" , "1" },
            { "1i" , "i" },
            { "1j" , "j" },
            { "1k" , "k" },
            { "i1" , "i" },
            { "ii" , "-1" },
            { "ij" , "k" },
            { "ik" , "-j" },
            { "j1" , "j" },
            { "ji" , "-k" },
            { "jj" , "-1" },
            { "jk" , "i" },
            { "k1" , "k" },
            { "ki" , "j" },
            { "kj" , "-i" },
            { "kk" , "-1" }
        };

        public bool Solve(string line, long repeats)
        {
            number++;
            var fullLine = string.Empty;
            var test = string.Empty;

            var ori = line;
            var simpleLine = this.Simplify(line);
            if ("-1" != SolveMultiple(simpleLine, repeats))
            {
                return false;
            }

            if (repeats > 1)
            {
                if (repeats > 11)
                {
                    line = new StringBuilder().Insert(0, ori, 12).ToString();
                }
                else
                {
                    var count = (int)repeats % 12;
                    line = new StringBuilder().Insert(0, ori, count).ToString();
                }
            }

            var firstQuaternion = "1";
            for (int i = 0; i < line.Length; i++)
            {
                firstQuaternion = this.MultiplyQuaternions(firstQuaternion, line[i].ToString());
                if ("k" == firstQuaternion)
                {
                    var secondQuaternion = "1";
                    var substring = line.Substring(0, i);
                    for (int j = 0; j < substring.Length; j++)
                    {
                        secondQuaternion = this.MultiplyQuaternions(secondQuaternion, substring[j].ToString());
                        if ("i" == secondQuaternion)
                        {
                            if (line.Length < 10000 & line.Length * repeats < 1000000)
                            {
                                var icase = this.Simplify(substring.Substring(0, j + 1));
                                var jcase = this.Simplify(line.Substring(j + 1, i - j));
                                var kTest = this.Simplify(line.Substring(0, i + 1));
                                fullLine = GetLine(ori, repeats);
                                var kcase = this.Simplify(fullLine.Substring(i + 1));
                                test = this.Simplify(fullLine);
                                if (test != "-1")
                                {
                                    SolveMultiple(simpleLine, repeats);
                                    this.Simplify(line);
                                }
                            }
                            else
                            {
                                return true;
                            }
                            return true;
                        }
                    }
                }
            }
            fullLine = GetLine(ori, repeats);
            test = this.Simplify(fullLine);

            return false;
        }

        public string SolveMultiple(string quaternion, long repeats)
        {
            var isEven = repeats % 2 == 0;
            var minRepeats = repeats % 4;
            var sol = new string[4];
            switch (quaternion)
            {
                case "1": return "1";
                case "-1": return isEven ? "1" : "-1";
                case "i":
                    sol = new string[] { "1", "i", "-1", "-i" };
                    return sol[minRepeats];

                case "-i":
                    sol = new string[] { "1", "-i", "-1", "i" };
                    return sol[minRepeats];

                case "j":
                    sol = new string[] { "1", "j", "-1", "-j" };
                    return sol[minRepeats];

                case "-j":
                    sol = new string[] { "1", "-j", "-1", "j" };
                    return sol[minRepeats];

                case "k":
                    sol = new string[] { "1", "k", "-1", "-k" };
                    return sol[minRepeats];

                case "-k":
                    sol = new string[] { "1", "-k", "-1", "k" };
                    return sol[minRepeats];
            }
            return "1";
        }

        public string GetLine(string repeatable, long repeats)
        {
            var array = new string[repeats];
            for (int i = 0; i < repeats; i++)
                array[i] = repeatable;
            return string.Join(string.Empty, array);
        }

        public string Simplify(string remainingQ)
        {
            var firstQ = "1";
            for (int i = 0; i < remainingQ.Length; i++)
            {
                firstQ = this.MultiplyQuaternions(firstQ, remainingQ[i].ToString());
            }
            return firstQ;
        }

        public string MultiplyQuaternions(string q1, string q2)
        {
            var sign = 1;
            if (q1.Length > 1 && this.IsNegative(q1))
            {
                sign *= -1;
                q1 = q1[q1.Length - 1].ToString();
            }
            if (q2.Length > 1 && this.IsNegative(q2))
            {
                sign *= -1;
                q2 = q2[q2.Length - 1].ToString();
            }

            var result = QuaternionMultiplication[q1 + q2];

            if (result.Length > 1 && this.IsNegative(result))
            {
                sign *= -1;
                result = result[result.Length - 1].ToString();
            }

            var signCharacter = sign < 0 ? "-" : "";
            return signCharacter + result;
        }

        public bool IsNegative(string q)
        {
            return q.StartsWith("-");
        }
    }
}