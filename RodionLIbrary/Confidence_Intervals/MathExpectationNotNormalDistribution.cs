using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class MathExpectationNotNormalDistribution : MathExpectation
    {
        public MathExpectationNotNormalDistribution(int confidenceLevel, int n, double mean) : base(confidenceLevel, n, mean) { }

        public MathExpectationNotNormalDistribution(int confidenceLevel, IEnumerable<double> data) : base(confidenceLevel, data) { }

        public override IAnswer GetDoubleSided()
        {
            throw new NotImplementedException();
        }

        public override IAnswer GetLeftSided()
        {
            throw new NotImplementedException();
        }

        public override IAnswer GetRightSided()
        {
            throw new NotImplementedException();
        }
    }
}
