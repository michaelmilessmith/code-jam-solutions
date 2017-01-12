using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace CodeJam._2009.Round1C.AllYourBase.src
{
    public class Solver
    {
        public string Solve(Case newCase)
        {
            var number = newCase.Number;
            var numberBase = this.GetBase(number.ToCharArray());
            var map = this.GetMap(number, numberBase);

            var total = BigInteger.Zero;
            var bigBase = new BigInteger(numberBase);
            for (int i = 0; i < number.Length; i++)
            {
                total += BigInteger.Pow(bigBase, i) * map[number[number.Length - 1 - i]];
            }

            return total.ToString();
        }

        public Dictionary<char, int> GetMap(string number, int numberBase)
        {
            var map = new Dictionary<char, int>();
            map[number[0]] = 1;
            var zero = number.FirstOrDefault(c => c != number[0]);
            map[zero] = 0;
            var start = number.IndexOf(zero) + 1;
            var value = 2;
            for (int i = start; i < number.Length; i++)
            {
                if (!map.Keys.Contains(number[i]))
                {
                    map[number[i]] = value;
                    value++;
                }
            }
            return map;
        }

        public int GetBase(char[] number)
        {
            var numberBase = number.Distinct().Count();
            return numberBase > 1 ? numberBase : 2;
        }
    }
}