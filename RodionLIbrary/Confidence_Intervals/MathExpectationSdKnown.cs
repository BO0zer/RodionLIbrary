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

        public override DoubleSidedAnswer GetDoubleSided()
        {
            double stat = NormalDistributionTable.GetT(ConfidenceLevel);
            double left = Mean - stat * (Sd / Math.Sqrt(Number));
            double right = Mean + stat * (Sd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"M[X] - t[N] * (σ / √n) <= {main} <= M[X] + t[N] * (σ / √n)";
            string calculation = $"{Mean} - {stat} * ({Sd} / √{Number}) <= {main} <= {Mean} + {stat} * ({Sd} / √{Number})";

            return new DoubleSidedAnswer(left, right, main, formula, calculation);
        }

        public override LeftSidedAnswer GetLeftSided()
        {
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = Mean - stat * (Sd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"{main} >= M[X] - x[N] * (σ / √n)";
            string calculation = $"{main} >= {Mean} - {stat} * ({Sd} / √{Number})";

            return new LeftSidedAnswer(value, main, formula, calculation);
        }

        public override RightSidedAnswer GetRightSided()
        {
            double stat = NormalDistributionTable.GetX(ConfidenceLevel);
            double value = Mean + stat * (Sd / Math.Sqrt(Number));

            string main = "a";
            string formula = $"{main} <= M[X] + x[N] * (σ / √n)";
            string calculation = $"{main} <= {Mean} + {stat} * ({Sd} / √{Number})";

            return new RightSidedAnswer(value, main, formula, calculation);
        }
    }
}
