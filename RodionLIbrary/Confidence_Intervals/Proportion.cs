using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class Proportion : IConfidenceInterval
    {
        private int _confidenceLevel;

        private int _number;

        private int _n;

        private int _m;

        public Proportion(int confidenceLevel, int n, int m, int N)
        {
            ConfidenceLevel = confidenceLevel;
            Number = N;
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

                if (value < m) throw new Exception("'n' must be not less than 'm'.");

                if (value > Number) throw new Exception("'n' must be not greater than 'N'.");

                _n = value;
            }
        }

        public int m
        {
            get => _m;

            set
            {
                if (value < 0) throw new Exception("'m' value must not less than 0.");

                if (value > n) throw new Exception("'m' must be not greater than 'n'.");

                _m = value;
            }
        }

        public int Number
        {
            get => _number;

            set
            {
                if (value < 1) throw new Exception("Number must be above 0.");

                if (value < n) throw new Exception("'N' must be not less than 'n'.");

                _number = value;
            }
        }

        public IAnswer GetDoubleSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetT(ConfidenceLevel);
            double left = w - stat * Math.Sqrt(w * (1 - w) * (Number - n) / (n * (Number - 1)));
            double right = w + stat * Math.Sqrt(w * (1 - w) * (Number - n) / (n * (Number - 1)));

            string main = "D/N";
            string formula = $"w - t[N] * √(w * (1-w) * (N-n) / (n * (N-1))) <= {main} <= w + t[N] * √(w * (1-w) * (N-n) / (n * (N-1))); w=m/n";
            string calculation = $"{w} - {stat} * √({w} * (1-{w}) * ({Number}-{n}) / ({n} * ({Number}-1))) <= {main} <= {w} + {stat} * √({w} * (1-{w}) * ({Number}-{n}) / ({n} * ({Number}-1)))";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public IAnswer GetLeftSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetT(ConfidenceLevel); // почему в формуле t, а не x???
            double value = w - stat * Math.Sqrt(w * (1 - w) * (Number - n) / (n * (Number - 1)));

            string main = "D/N";
            string formula = $"{main} >= w - t[N] * √(w * (1-w) * (N-n) / (n * (N-1))); w=m/n";
            string calculation = $"{main} >= {w} - {stat} * √({w} * (1-{w}) * ({Number}-{n}) / ({n} * ({Number}-1)))";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public IAnswer GetRightSided()
        {
            double w = (double)m / n;
            double stat = NormalDistributionTable.GetT(ConfidenceLevel); // почему в формуле t, а не x???
            double value = w + stat * Math.Sqrt(w * (1 - w) * (Number - n) / (n * (Number - 1)));

            string main = "D/N";
            string formula = $"{main} <= w + t[N] * √(w * (1-w) * (N-n) / (n * (N-1))); w=m/n";
            string calculation = $"{main} <= {w} + {stat} * √({w} * (1-{w}) * ({Number}-{n}) / ({n} * ({Number}-1)))";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
