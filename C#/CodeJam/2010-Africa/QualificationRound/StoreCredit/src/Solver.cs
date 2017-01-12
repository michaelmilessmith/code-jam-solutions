namespace CodeJam._2010___Africa.QualificationRound.StoreCredit.src
{
    public class Solver
    {
        public int[] Solve(Case newCase)
        {
            var result = new int[2];

            for (int i = 0; i < newCase.Count; i++)
            {
                var value = newCase.Items[i];
                if (value < newCase.Credit)
                {
                    var valueToFind = newCase.Credit - value;
                    for (int j = i + 1; j < newCase.Count; j++)
                    {
                        if (valueToFind == newCase.Items[j])
                        {
                            return new int[2] { i + 1, j + 1 };
                        }
                    }
                }
            }
            return null;
        }
    }
}