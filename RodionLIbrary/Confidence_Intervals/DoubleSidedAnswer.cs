using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class DoubleSidedAnswer : Answer
    {
        public DoubleSidedAnswer(double leftBorder, double rightBorder, string main, string formula, string calculation)
        {
            RightBorder = rightBorder;
            LeftBorder = leftBorder;
            Difference = RightBorder - LeftBorder;

            double left = Round(LeftBorder), right = Round(RightBorder);

            SolutionText = "Двусторонний доверительный интервал:";
            AddText(formula); // formula
            AddText(calculation); // calculation
            AddText($"{left} <= {main} <= {right}"); // result
            AddText($"Левая граница: {left}");
            AddText($"Правая граница: {right}");
            AddText($"Разница: {Round(Difference)}");
        }

        public double LeftBorder { get; private set; }

        public double RightBorder { get; private set; }

        public double Difference { get; private set; }
    }
}
