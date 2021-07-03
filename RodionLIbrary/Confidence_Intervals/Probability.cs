using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class Probability : IConfidenceInterval
    {
        private int _confidenceLevel;

        private int _n;

        private int _m;

        public Probability(int confidenceLevel, int n, int m)
        {
            ConfidenceLevel = confidenceLevel;
            this.n = n;
            this.m = m;
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

        public int n
        {
            get => _n;

            set
            {
                if (value < 1) throw new Exception("'n' value must be above 0.");

                if (value < _m) throw new Exception("'n' must be not less than 'm'.");

                _n = value;
            }
        }

        public int m
        {
            get => _m;

            set
            {
                if (value < 0) throw new Exception("'m' value must not less than 0.");

                if (value > _n) throw new Exception("'m' must be not greater than 'n'.");

                _m = value;
            }
        }

        public IAnswer GetDoubleSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetT(ConfidenceLevel);
            double left = w - stat * Math.Sqrt(w * (1 - w) / n);
            double right = w + stat * Math.Sqrt(w * (1 - w) / n);

            string main = "p";
            string formula = $"w - t[N] * √(w * (1-w) / n) <= {main} <= w + t[N] * √(w * (1-w) / n); w=m/n";
            string calculation = $"{w} - {stat} * √({w} * (1-{w}) / {n}) <= {main} <= {w} + {stat} * √({w} * (1-{w}) / {n})";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public IAnswer GetLeftSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = w - stat * Math.Sqrt(w * (1 - w) / n);

            string main = "p";
            string formula = $"{main} >= w - t[N] * √(w * (1-w) / n); w=m/n";
            string calculation = $"{main} >= {w} - {stat} * √({w} * (1-{w}) / {n})";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public IAnswer GetRightSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = w + stat * Math.Sqrt(w * (1 - w) / n);

            string main = "a";
            string formula = $"{main} <= w + t[N] * √(w * (1-w) / n); w=m/n";
            string calculation = $"{main} <= {w} + {stat} * √({w} * (1-{w}) / {n})";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
