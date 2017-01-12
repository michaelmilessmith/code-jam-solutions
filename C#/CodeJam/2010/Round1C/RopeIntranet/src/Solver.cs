namespace CodeJam._2010.Round1C.RopeIntranet.src
{
    public class Solver
    {
        public int Solve(Case newCase)
        {
            var intersects = 0;
            for (int i = 0; i < newCase.WireHeights.Count; i++)
            {
                var A = newCase.WireHeights[i];
                for (int j = i + 1; j < newCase.WireHeights.Count; j++)
                {
                    var B = newCase.WireHeights[j];

                    if ((A.Item1 > B.Item1 && A.Item2 < B.Item2) ||
                        (A.Item1 < B.Item1 && A.Item2 > B.Item2))
                    {
                        intersects++;
                    }
                }
            }
            return intersects;
        }
    }
}