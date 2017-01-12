using CodeJam._2008.Round1A.MinimumScalarProduct.src;
using CodeJam._2009.QualificationRound.AlienLanguage.src;
using CodeJam._2009.Round1C.AllYourBase.src;
using CodeJam._2010.Round1A.Rotate.src;
using CodeJam._2010.Round1B.FileFix_it.src;
using CodeJam._2010.Round1C.RopeIntranet.src;
using CodeJam._2010___Africa.QualificationRound.ReverseWords.src;
using CodeJam._2010___Africa.QualificationRound.StoreCredit.src;
using CodeJam._2015.QualificationRound.Dijkstra.src;
using CodeJam._2015.QualificationRound.InfiniteHouseOfPancakes.src;
using CodeJam._2015.QualificationRound.OminousOmino.src;
using CodeJam._2015.QualificationRound.StandingOvation.src;

namespace CodeJam
{
    internal enum InputSize
    {
        small,
        large
    }

    public class ProblemCaller
    {
        public void SolveProblem(string problemName)
        {
            switch (problemName)
            {
                case "MinimumScalarProduct":
                    MinimumScalarProduct.Solve(this.GetFileName(InputSize.small, 'A'));
                    MinimumScalarProduct.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "AlienLanguage":
                    AlienLanguage.Solve(this.GetFileName(InputSize.small, 'A'));
                    AlienLanguage.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "AllYourBase":
                    AllYourBase.Solve(this.GetFileName(InputSize.small, 'A'));
                    AllYourBase.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "Rotate":
                    Rotate.Solve(this.GetFileName(InputSize.small, 'A'));
                    Rotate.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "FileFix-it":
                    FileFix_it.Solve(this.GetFileName(InputSize.small, 'A'));
                    FileFix_it.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "RopeIntranet":
                    RopeIntranet.Solve(this.GetFileName(InputSize.small, 'A'));
                    RopeIntranet.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "ReverseWords":
                    ReverseWords.Solve(this.GetFileName(InputSize.small, 'B'));
                    ReverseWords.Solve(this.GetFileName(InputSize.large, 'B'));
                    break;

                case "StoreCredit":
                    StoreCredit.Solve(this.GetFileName(InputSize.small, 'A'));
                    StoreCredit.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "StandingOvation":
                    StandingOvation.Solve(this.GetFileName(InputSize.small, 'A'));
                    StandingOvation.Solve(this.GetFileName(InputSize.large, 'A'));
                    break;

                case "InfiniteHouseOfPancakes":
                    InfiniteHouseOfPancakes.Solve(this.GetFileName(InputSize.small, 'B'));
                    InfiniteHouseOfPancakes.Solve(this.GetFileName(InputSize.large, 'B'));
                    break;

                case "Dijkstra":
                    Dijkstra.Solve(this.GetFileName(InputSize.small, 'C'));
                    Dijkstra.Solve(this.GetFileName(InputSize.large, 'C'));
                    break;

                case "OminousOmino":
                    OminousOmino.Solve(this.GetFileName(InputSize.small, 'D'));
                    OminousOmino.Solve(this.GetFileName(InputSize.large, 'D'));
                    break;
            }
        }

        private string GetFileName(InputSize size, char letter)
        {
            return $"{char.ToUpper(letter)}-{size.ToString()}-practice.in";
        }
    }
}