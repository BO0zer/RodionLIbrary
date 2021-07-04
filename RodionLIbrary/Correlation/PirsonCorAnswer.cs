using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public class PirsonCorAnswer : Answer
    {
        public PirsonCorAnswer(double cor, string formula, string calculation)
        {
            Cor = cor;

            SolutionText = "Выборочный коэффициент корреляции:";
            AddText(formula);
            AddText(calculation);
            AddText($"Выборочный коэффициент корреляции = {Round(Cor)}");
        }

        public double Cor { get; private set; }
    }
}
