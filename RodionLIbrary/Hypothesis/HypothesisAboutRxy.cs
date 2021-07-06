using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    class HypothesisAboutRxy:Answer
    {
        public HypothesisAboutRxy(double rxy, int n)
        {
            var u = Round(rxy * Math.Sqrt(n - 2) / Math.Sqrt(1 - Math.Pow(rxy, 2)));
            SolutionText = "U(выч)= r * Корень кв.(n - 2) / Корень кв.(1 - r^2)";
            AddText($"U(выч)= {rxy} * Корень кв.({n - 2}) / Корень кв.({1 - rxy}^2)");
            AddText($"U(выч)= {u}");
        }
    }
}
