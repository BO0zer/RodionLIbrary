using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.StatTables
{
    public abstract class NormalDistributionTable
    {
        private static Dictionary<double, double> normalDistributionTable = new Dictionary<double, double>
        {
            [99] = 2.33,
            [98] = 2.05,
            [97.5] = 1.96,
            [95] = 1.64,
            [90] = 1.28
        };
        public static double GetT(double confidenceLevel) => normalDistributionTable[(1 + confidenceLevel) / 2];

        public static double GetX(double confidenceLevel) => normalDistributionTable[confidenceLevel];
    }
}
