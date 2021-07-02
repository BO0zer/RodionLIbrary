using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class DoubleSidedAnswer : IAnswer
    {
        public DoubleSidedAnswer(double leftBorder, double rightBorder)
        {
            IAnswer answer = this;

            RightBorder = rightBorder;
            LeftBorder = leftBorder;
            Difference = RightBorder - LeftBorder;

            double left = answer.Round(LeftBorder), right = answer.Round(RightBorder);

            SolutionText = $"Двусторонний доверительный интервал: {left} <= a <= {right}";
            SolutionText += $"\nЛевая граница: {left}";
            SolutionText += $"\nПравая граница: {right}";
            SolutionText += $"\nРазница: {answer.Round(Difference)}";
        }

        public string SolutionText { get; private set; }

        public double LeftBorder { get; private set; }

        public double RightBorder { get; private set; }

        public double Difference { get; private set; }
    }
}
