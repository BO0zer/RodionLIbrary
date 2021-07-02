using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class LeftSidedAnswer : IAnswer
    {
        public LeftSidedAnswer(double value)
        {
            IAnswer answer = this;

            SolutionText = $"Левосторонний довирительный интервал: a >= {answer.Round(value)}";
        }

        public string SolutionText { get; private set; }

        public double Value { get; private set; }
    }
}
