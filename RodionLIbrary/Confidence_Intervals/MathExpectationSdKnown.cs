using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class MathExpectationSdKnown : MathExpectation
    {
        public MathExpectationSdKnown(int confidenceLevel, double sd, int n, double mean) : base(confidenceLevel, n, mean) 
        {
            Sd = sd;
        }

        public MathExpectationSdKnown(int confidenceLevel, double sd, IEnumerable<double> data) : base(confidenceLevel, data) 
        {
            Sd = sd;
        }

        public double Sd { get; set; }

        public override IAnswer GetDoubleSided()
        {
            double left = Mean - NormalDistributionTable.GetT(ConfidenceLevel) * (Sd / Math.Sqrt(Number));
            double right = Mean + NormalDistributionTable.GetT(ConfidenceLevel) * (Sd / Math.Sqrt(Number));

            return new DoubleSidedAnswer(left, right);
        }

        public override IAnswer GetLeftSided()
        {
            double value = Mean - NormalDistributionTable.GetX(ConfidenceLevel) * (Sd / Math.Sqrt(Number));

            return new LeftSidedAnswer(value);
        }

        public override IAnswer GetRightSided()
        {
            double value = Mean + NormalDistributionTable.GetX(ConfidenceLevel) * (Sd / Math.Sqrt(Number));

            return new RightSidedAnswer(value);
        }
    }
}
