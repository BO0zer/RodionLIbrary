using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Statistics
{
    public abstract class Statistics
    {
        public static double Mean(IEnumerable<double> data) => data.Average();

        public static double Var(IEnumerable<double> data)
        {
            double sqrMean = 0;
            foreach (var item in data) sqrMean += Math.Pow(item, 2);
            sqrMean /= data.Count();

            return sqrMean - Math.Pow(Mean(data), 2);
        }

        public static double Sd(IEnumerable<double> data) => Math.Sqrt(Var(data));
    }
}
