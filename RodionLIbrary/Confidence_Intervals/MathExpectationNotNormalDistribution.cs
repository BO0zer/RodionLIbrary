using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class MathExpectationNotNormalDistribution : MathExpectation
    {
        private double _calculatedSd;

        public MathExpectationNotNormalDistribution(int confidenceLevel, IEnumerable<double> data) : base(confidenceLevel, data) 
        {
            _calculatedSd = Statistics.Statistics.Sd(data);
        }

        public override DoubleSidedAnswer GetDoubleSided()
        {
            double stat = NormalDistributionTable.GetT(ConfidenceLevel);
            double left = Mean - stat * (_calculatedSd / Math.Sqrt(Number));
            double right = Mean + stat * (_calculatedSd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"M[X] - t[N] * (Sx / √n) <= {main} <= M[X] + t[N] * (Sx / √n)";
            string calculation = $"{Mean} - {stat} * ({_calculatedSd} / √{Number}) <= {main} <= {Mean} + {stat} * ({_calculatedSd} / √{Number})";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public override LeftSidedAnswer GetLeftSided()
        {
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = Mean - stat * (_calculatedSd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"{main} >= M[X] - x[N] * (Sx / √n)";
            string calculation = $"{main} >= {Mean} - {stat} * ({_calculatedSd} / √{Number})";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public override RightSidedAnswer GetRightSided()
        {
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = Mean + stat * (_calculatedSd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"{main} <= M[X] + x[N] * (Sx / √n)";
            string calculation = $"{main} <= {Mean} + {stat} * ({_calculatedSd} / √{Number})";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
