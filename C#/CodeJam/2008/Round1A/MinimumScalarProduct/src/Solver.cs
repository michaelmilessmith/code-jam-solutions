using System.Linq;

namespace CodeJam._2008.Round1A.MinimumScalarProduct.src
{
    public class Solver
    {
        public long Solve(Case newCase)
        {
            var sortX = newCase.Xs.OrderBy(x => x).ToArray();
            var sortY = newCase.Ys.OrderByDescending(y => y).ToArray();
            return this.CalculateScalarProduct(sortX, sortY);
        }

        public long CalculateScalarProduct(long[] xs, long[] ys)
        {
            var total = 0L;
            for (int i = 0; i < xs.Length; i++)
            {
                total += xs[i] * ys[i];
            }
            return total;
        }
    }
}