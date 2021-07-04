using System;
using System.Collections.Generic;
using System.Linq;

namespace RodionLIbrary.Confidence_Intervals
{
    public abstract class MathExpectation : IConfidenceInterval
    {
        private int _confidenceLevel;

        private int _number;

        public MathExpectation(int confidenceLevel, int n, double mean)
        {
            ConfidenceLevel = confidenceLevel;
            Number = n;
            Mean = mean;
        }

        public MathExpectation(int confidenceLevel, IEnumerable<double> data)
        {
            ConfidenceLevel = confidenceLevel;
            Number = data.Count();
            Mean = Statistics.Statistics.Mean(data);
        }

        public int ConfidenceLevel
        {
            get => _confidenceLevel;

            set
            {
                if (value < 1 || value > 100) throw new Exception("Confidence level is out of range (1-100%).");

                _confidenceLevel = value;
            } 
        }

        public int Number
        {
            get => _number;

            set
            {
                if (value < 1) throw new Exception("Number must be above 0.");

                _number = value;
            }
        }

        public double Mean { get; set; }

        public abstract DoubleSidedAnswer GetDoubleSided();

        public abstract LeftSidedAnswer GetLeftSided();

        public abstract RightSidedAnswer GetRightSided();
    }
}
