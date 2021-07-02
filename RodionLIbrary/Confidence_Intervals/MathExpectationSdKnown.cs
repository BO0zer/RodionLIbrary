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
