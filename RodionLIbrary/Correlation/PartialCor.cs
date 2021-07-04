using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Correlation
{
    public abstract class PartialCor
    {
        public static PartialCorAnswer GetCor(double rX1Y, double rX2Y, double rX1X2)
        {
            double cor = (rX1Y - rX2Y * rX1X2) / Math.Sqrt((1 - Math.Pow(rX1Y, 2)) * (1 - Math.Pow(rX1X2, 2)));

            string formula = "r(Y, X1|X2) = (r(X1,Y) - r(X2,Y)*r(X1,X2)) / √((1 - (r(X1,Y))^2) * (1 - (r(X1,X2))^2))";
            string calculation = $"r(Y, X1|X2) = ({rX1Y} - {rX2Y}*{rX1X2}) / √((1 - ({rX1Y})^2) * (1 - ({rX1X2})^2))";

            return new PartialCorAnswer(cor, formula, calculation);
        }
    }
}
