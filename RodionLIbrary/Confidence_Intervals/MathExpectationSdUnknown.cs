using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class MathExpectationSdUnknown : MathExpectation
    {
        public MathExpectationSdUnknown(int confidenceLevel, double sd, int n, double mean) : base(confidenceLevel, n, mean)
        {
            CalculatedSd = sd;
        }

        public MathExpectationSdUnknown(int confidenceLevel, IEnumerable<double> data) : base(confidenceLevel, data)
        {
            CalculatedSd = Statistics.Statistics.Sd(data);
        }

        public double CalculatedSd { get; set; }

        public override IAnswer GetDoubleSided()
        {
            double stat = StudentDistributionTable.GetT(ConfidenceLevel, Number - 1);
            double left = Mean - stat * (CalculatedSd / Math.Sqrt(Number - 1));
            double right = Mean + stat * (CalculatedSd / Math.Sqrt(Number - 1));

            string main = "a";
            string formula = $"M[X] - t[St(n-1)] * (Sx / √(n-1)) <= {main} <= M[X] + t[St(n-1)] * (Sx / √(n-1))";
            string calculation = $"{Mean} - {stat} * ({CalculatedSd} / √({Number}-1)) <= {main} <= {Mean} + {stat} * ({CalculatedSd} / √({Number}-1))";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public override IAnswer GetLeftSided()
        {
            double stat = StudentDistributionTable.GetX(ConfidenceLevel, Number - 1);
            double value = Mean - stat * (CalculatedSd / Math.Sqrt(Number - 1));

            string main = "a";
            string formula = $"{main} >= M[X] - x[St(n-1)] * (Sx / √(n-1))";
            string calculation = $"{main} >= {Mean} - {stat} * ({CalculatedSd} / √({Number}-1))";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public override IAnswer GetRightSided()
        {
            double stat = StudentDistributionTable.GetX(ConfidenceLevel, Number - 1);
            double value = Mean + stat * (CalculatedSd / Math.Sqrt(Number - 1));

            string main = "a";
            string formula = $"{main} <= M[X] + x[St(n-1)] * (Sx / √(n-1))";
            string calculation = $"{main} <= {Mean} + {stat} * ({CalculatedSd} / √({Number}-1))";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
