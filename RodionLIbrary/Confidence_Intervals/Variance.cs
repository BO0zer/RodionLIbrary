using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class Variance : IConfidenceInterval
    {
        public int ConfidenceLevel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public IAnswer GetDoubleSided()
        {
            throw new NotImplementedException();
        }

        public IAnswer GetLeftSided()
        {
            throw new NotImplementedException();
        }

        public IAnswer GetRightSided()
        {
            throw new NotImplementedException();
        }
    }
}
