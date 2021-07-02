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
