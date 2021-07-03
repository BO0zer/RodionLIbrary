using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class RightSidedAnswer : Answer
    {
        public RightSidedAnswer(double value, string main, string formula, string calculation)
        {
            Value = value;

            SolutionText = "Правосторонний доверительный интервал:";
            AddText(formula); // formula
            AddText(calculation); // calculation
            AddText($"{main} <= {Round(Value)}"); // result
        }

        public double Value { get; private set; }
    }
}
