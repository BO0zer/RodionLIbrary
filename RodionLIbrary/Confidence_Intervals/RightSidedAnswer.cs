using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class RightSidedAnswer : IAnswer
    {
        public RightSidedAnswer(double value)
        {
            IAnswer answer = this;

            Value = value;

            SolutionText = $"Правосторонний доверительный интервал: a <= {answer.Round(Value)}";
        }

        public string SolutionText { get; private set; }

        public double Value { get; private set; }
    }
}
