using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class LeftSidedAnswer : Answer
    {
        public LeftSidedAnswer(double value, string main, string formula, string calculation)
        {
            Value = value;

            SolutionText = "Левосторонний доверительный интервал:";
            AddText(formula); // formula
            AddText(calculation); // calculation
            AddText($"{main} >= {Round(Value)}"); // result
        }

        public double Value { get; private set; }
    }
}
