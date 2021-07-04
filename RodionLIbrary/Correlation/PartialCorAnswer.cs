using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public class PartialCorAnswer : Answer
    {
        public PartialCorAnswer(double cor, string formula, string calculation)
        {
            Cor = cor;

            SolutionText = "Частный коэффициент корреляции:";
            AddText(formula);
            AddText(calculation);
            AddText($"Частный коэффициент корреляции = {Round(Cor)}");
        }

        public double Cor { get; private set; }
    }
}
