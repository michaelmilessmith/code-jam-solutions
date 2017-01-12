using System.Linq;
using System.Text;

namespace CodeJam._2010.Round1B.FileFix_it.src
{
    public class Solver
    {
        public int Solve(Case newCase)
        {
            var mkdirCount = 0;
            for (int i = 0; i < newCase.ToCreate.Count; i++)
            {
                var section = newCase.ToCreate[i].Split('/');

                for (int j = 0; j < section.Length; j++)
                {
                    var folder = this.ConcatDirectory(section.Skip(1).Take(j + 1).ToArray());
                    if (!newCase.Exists.Contains(folder))
                    {
                        newCase.Exists.Add(folder);
                        mkdirCount++;
                    }
                }
            }
            return mkdirCount;
        }

        public string ConcatDirectory(string[] folders)
        {
            var builder = new StringBuilder();
            for (int i = 0; i < folders.Length; i++)
            {
                builder.Append("/");
                builder.Append(folders[i]);
            }
            return builder.ToString();
        }
    }
}