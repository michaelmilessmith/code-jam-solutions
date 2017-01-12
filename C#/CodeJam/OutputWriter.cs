using System.IO;

namespace CodeJam
{
    public class OutputWriter
    {
        public void WriteOutput(string inputFilename, string[] lines)
        {
            File.WriteAllLines(Path.Combine(Path.GetDirectoryName(inputFilename), Path.GetFileNameWithoutExtension(inputFilename) + ".out"), lines);
        }
    }
}