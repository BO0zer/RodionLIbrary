using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public class SpearmanCorAnswer : Answer
    {
        public SpearmanCorAnswer(double cor, string formula, string calculation)
        {
            Cor = cor;

            SolutionText = "Коэффициент ранговой корреляции Спирмена:";
            AddText(formula);
            AddText(calculation);
            AddText($"Коэффициент ранговой корреляции Спирмена = {Round(Cor)}");
        }

        public double Cor { get; private set; }
    }
}
