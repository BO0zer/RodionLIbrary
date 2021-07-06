using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    class HypothesisAboutRs:Answer
    {
        public HypothesisAboutRs(double rs, int n)
        {
            var u = Round(rs * Math.Sqrt(n - 1));
            SolutionText = "U(выч)= r * Корень кв.(n - 1)";
            AddText($"U(выч)= {rs} * корень кв.({n - 1})");
            AddText($"U(выч)= {u}");
        }
    }
}
