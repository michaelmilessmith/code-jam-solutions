using System;

namespace CodeJam._2015.QualificationRound.OminousOmino.src
{
    public enum Transform
    {
        RotateClockwise,
        RotateAnticlockwise,
        ReflectY,
        ReflectX
    }

    public class Solver
    {
        public bool RichardWins(Case newCase)
        {
            var X = newCase.X;
            var min = Math.Min(newCase.C, newCase.R);
            var max = Math.Max(newCase.C, newCase.R);
            if ((min * max) % X != 0) return true;

            if (X == 3 && min == 1) return true;
            if (X == 4 && min <= 2) return true;
            if (X == 5 && (min <= 2 || (min == 3 && max == 5))) return true;
            if (X == 6 && min <= 3) return true;
            if (X >= 7) return true;
            return false;
        }
    }
}