using System;

namespace CodeJam._2015.QualificationRound.StandingOvation.src
{
    public class Solver
    {
        public int SolvePlants(Case oldCase)
        {
            int standing = 0;
            int highestContributingShyness = 0;
            for (int i = 0; i < oldCase.SMax; i++)
            {
                highestContributingShyness = oldCase.Audience[i] > 0 ? i : highestContributingShyness;
                standing += oldCase.Audience[i];
                if (standing >= oldCase.SMax)
                {
                    if (i != 0)
                    {
                        var newCase = new Case();
                        newCase.SMax = i;
                        newCase.Audience = new int[newCase.SMax + 1];
                        Array.Copy(oldCase.Audience, 0, newCase.Audience, 0, newCase.SMax + 1);
                        return this.SolvePlants(newCase);
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            var plantsToAdd = oldCase.SMax - standing;
            if (plantsToAdd != 0)
            {
                var plantCase = new Case();
                plantCase.SMax = highestContributingShyness;
                plantCase.Audience = new int[plantCase.SMax + 1];
                Array.Copy(oldCase.Audience, 0, plantCase.Audience, 0, plantCase.SMax + 1);
                plantCase.Audience[0] += plantsToAdd;
                return this.SolvePlants(plantCase) + plantsToAdd;
            }
            return 0;
        }
    }
}