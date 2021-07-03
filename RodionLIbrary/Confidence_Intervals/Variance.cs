using RodionLIbrary.StatTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public class Variance : IConfidenceInterval
    {
        private int _confidenceLevel;

        private int _number;

        public Variance(int confidenceLevel, int n, double calculatedVariance)
        {
            ConfidenceLevel = confidenceLevel;
            Number = n;
            CalculatedVariance = calculatedVariance;
        }

        public Variance(int confidenceLevel, IEnumerable<double> data)
        {
            ConfidenceLevel = confidenceLevel;
            Number = data.Count();
            CalculatedVariance = Statistics.Statistics.Var(data);
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

        public double CalculatedVariance { get; set; }

        public IAnswer GetDoubleSided()
        {
            double statLeft = ChiDistributionTable.GetX((100 + ConfidenceLevel) / 2, Number - 1);
            double statRight = ChiDistributionTable.GetX((100 - ConfidenceLevel) / 2, Number - 1);
            double left = Number * CalculatedVariance / statLeft;
            double right = Number * CalculatedVariance / statRight;

            string main = "σ^2";
            string formula = $"n * Sx^2 / x{{(1+γ)/2}}[χ^2(n-1)] < {main} < n * Sx^2 / x{{(1-γ)/2}}[χ^2(n-1)]";
            string calculation = $"{Number} * {CalculatedVariance} / {statLeft} < {main} < {Number} * {CalculatedVariance} / {statRight}";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public IAnswer GetLeftSided()
        {
            double stat = ChiDistributionTable.GetX(ConfidenceLevel, Number - 1);
            double value = Number * CalculatedVariance / stat;

            string main = "σ^2";
            string formula = $"{main} > n * Sx^2 / x[χ^2(n-1)]";
            string calculation = $"{main} > {Number} * {CalculatedVariance} / {stat}";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public IAnswer GetRightSided()
        {
            double stat = ChiDistributionTable.GetX(100 - ConfidenceLevel, Number - 1);
            double value = Number * CalculatedVariance / stat;

            string main = "σ^2";
            string formula = $"{main} < n * Sx^2 / x{{1-γ}}[χ^2(n-1)]";
            string calculation = $"{main} < {Number} * {CalculatedVariance} / {stat}";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
