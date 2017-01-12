using System;

namespace CodeJam
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var caller = new ProblemCaller();
            if (args.Length != 0)
            {
                caller.SolveProblem(args[0]);
            }
            else
            {
                Console.WriteLine("require name of problem");
            }
        }
    }
}