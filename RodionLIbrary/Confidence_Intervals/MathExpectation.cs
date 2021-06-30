using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class MathExpectation : IConfidenceInterval
    {
        private double _confidenceLevel;

        public MathExpectation(double confidenceLevel, bool isNormalDistribution, bool isSdKnown, double mean, double sd)
        {
            ConfidenceLevel = confidenceLevel;
        }

        public MathExpectation(double confidenceLevel, bool isNormalDistribution, bool isSdKnown, IEnumerable<double> data)
        {
            ConfidenceLevel = confidenceLevel;
        }

        public double ConfidenceLevel 
        {
            get => _confidenceLevel;

            set
            {
                if (value < 1 || value > 100) throw new Exception("Confidence level is out of range (1-100%)");

                _confidenceLevel = value;
            } 
        }

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
