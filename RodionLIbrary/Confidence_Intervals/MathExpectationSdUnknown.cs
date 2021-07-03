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
            double left = Mean - StudentDistributionTable.GetT(ConfidenceLevel, Number - 1) * (CalculatedSd / Math.Sqrt(Number - 1));
            double right = Mean + StudentDistributionTable.GetT(ConfidenceLevel, Number - 1) * (CalculatedSd / Math.Sqrt(Number - 1));

            return new DoubleSidedAnswer(left, right);
        }

        public override IAnswer GetLeftSided()
        {
            double value = Mean - StudentDistributionTable.GetX(ConfidenceLevel, Number - 1) * (CalculatedSd / Math.Sqrt(Number - 1));

            return new LeftSidedAnswer(value);
        }

        public override IAnswer GetRightSided()
        {
            double value = Mean + StudentDistributionTable.GetX(ConfidenceLevel, Number - 1) * (CalculatedSd / Math.Sqrt(Number - 1));

            return new RightSidedAnswer(value);
        }
    }
}
