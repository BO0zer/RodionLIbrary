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

        public override IAnswer GetDoubleSided()
        {
            double left = Mean - NormalDistributionTable.GetT(ConfidenceLevel) * (_calculatedSd / Math.Sqrt(Number));
            double right = Mean + NormalDistributionTable.GetT(ConfidenceLevel) * (_calculatedSd / Math.Sqrt(Number));

            return new DoubleSidedAnswer(left, right);
        }

        public override IAnswer GetLeftSided()
        {
            double value = Mean - NormalDistributionTable.GetX(ConfidenceLevel) * (_calculatedSd / Math.Sqrt(Number));

            return new LeftSidedAnswer(value);
        }

        public override IAnswer GetRightSided()
        {
            double value = Mean + NormalDistributionTable.GetX(ConfidenceLevel) * (_calculatedSd / Math.Sqrt(Number));

            return new RightSidedAnswer(value);
        }
    }
}
