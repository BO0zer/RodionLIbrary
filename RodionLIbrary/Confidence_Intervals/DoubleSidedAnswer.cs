using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class DoubleSidedAnswer : IAnswer
    {
        private const int _defaultDecimals = 3;

        public DoubleSidedAnswer(double leftBorder, double rightBorder)
        {
            RightBorder = rightBorder;
            LeftBorder = leftBorder;
            Difference = RightBorder - LeftBorder;

            double left = Round(LeftBorder), right = Round(RightBorder);

            SolutionText = $"Двусторонний довирительный интервал: {left} <= a <= {right}";
            SolutionText += $"\nЛевая граница: {left}";
            SolutionText += $"\nПравая граница: {right}";
            SolutionText += $"\nРазница: {Round(Difference)}";
        }

        public string SolutionText { get; private set; }

        public double LeftBorder { get; private set; }

        public double RightBorder { get; private set; }

        public double Difference { get; private set; }

        private static double Round(double value, int decimals = _defaultDecimals) => Math.Round(value, decimals);
    }
}
