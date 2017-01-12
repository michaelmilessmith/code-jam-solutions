using System;
using System.Linq;

namespace CodeJam._2015.QualificationRound.InfiniteHouseOfPancakes.src
{
    public class Solver
    {
        public int Solve(int[] diners)
        {
            var maxPancakes = diners.Length - 1;
            var best = maxPancakes;

            for (int i = maxPancakes - 1; i >= 1; i--)
            {
                var moves = 0;
                for (int j = maxPancakes; j > i; j--)
                {
                    moves += diners[j] * ((j - 1) / i);
                }

                if (i + moves < best)
                    best = i + moves;
            }
            return best;
        }

        public Sm GetMaxSm(int[] distribution)
        {
            var sm = new Sm();
            sm.Max = distribution.Length - 1;

            var operationGain = new int[sm.Max];
            sm.Distribution = new int[2];

            for (int i = 1; i < sm.Max; i++)
            {
                operationGain[i] = operationGain[i - 1] + this.SmGain(distribution);
                distribution = this.RedistibutePancakes(distribution);
                if (operationGain[i] > sm.Gain)
                {
                    sm.Distribution = distribution;
                    sm.Gain = operationGain[i];
                }
            }
            return sm;
        }

        public int SmGain(int[] distribution)
        {
            var pMax = distribution.Length - 1;
            var smToReduce = distribution.Last();
            var secondHighest = this.SecondHighest(distribution);
            var difference = pMax - secondHighest;
            return difference - smToReduce;
        }

        public int SecondHighest(int[] diners)
        {
            var highestHalf = this.GetHighestHalf(diners.Length - 1);
            for (int i = diners.Length - 2; i > highestHalf; i--)
            {
                if (diners[i] > 0)
                {
                    return i;
                }
            }
            return highestHalf;
        }

        public int GetHighestHalf(int number)
        {
            return (int)Math.Round((double)number / 2, MidpointRounding.AwayFromZero);
        }

        public int[] RedistibutePancakes(int[] diners)
        {
            var number = diners.Last();
            var nextHeighest = this.SecondHighest(diners);
            var newDistribution = new int[nextHeighest + 1];
            Array.Copy(diners, 0, newDistribution, 0, newDistribution.Length);
            if (diners.Length <= newDistribution.Length)
            {
                newDistribution[diners.Length - 1] = 0;
            }
            if ((diners.Length - 1) % 2 != 0)
            {
                var high = this.GetHighestHalf(diners.Length - 1);
                newDistribution[high] += number;
                newDistribution[high - 1] += number;
            }
            else
            {
                newDistribution[(diners.Length - 1) / 2] += number * 2;
            }
            return newDistribution;
        }

        public int[] RedistributePancake(int[] diners)
        {
            var number = 1;
            var nextHeighest = 0;
            if (diners.Last() > 1)
            {
                nextHeighest = diners.Length - 1;
            }
            else
            {
                nextHeighest = this.SecondHighest(diners);
            }
            var newDistribution = new int[nextHeighest + 1];
            Array.Copy(diners, 0, newDistribution, 0, newDistribution.Length);
            if (diners.Length <= newDistribution.Length)
            {
                newDistribution[diners.Length - 1] = 0;
            }
            if ((diners.Length - 1) % 2 != 0)
            {
                var high = this.GetHighestHalf(diners.Length - 1);
                newDistribution[high] += number;
                newDistribution[high - 1] += number;
            }
            else
            {
                newDistribution[(diners.Length - 1) / 2] += number * 2;
            }
            return newDistribution;
        }

        public int[] DinersEat(int[] diners)
        {
            var newDistribution = new int[diners.Length - 1];
            Array.Copy(diners, 1, newDistribution, 0, newDistribution.Length);
            return newDistribution;
        }
    }
}