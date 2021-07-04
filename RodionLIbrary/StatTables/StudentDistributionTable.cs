using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.StatTables
{
    public abstract class StudentDistributionTable
    {
        private static Dictionary<Tuple<double, int>, double> normalDistributionTable = new Dictionary<Tuple<double, int>, double>
        {
            [new Tuple<double, int>(0.99, 5)] = 3.36,
            [new Tuple<double, int>(0.98, 5)] = 2.76,
            [new Tuple<double, int>(0.975, 5)] = 2.57,
            [new Tuple<double, int>(0.95, 5)] = 2.02,
            [new Tuple<double, int>(0.9, 5)] = 1.48,

            [new Tuple<double, int>(0.99, 6)] = 3.14,
            [new Tuple<double, int>(0.98, 6)] = 2.61,
            [new Tuple<double, int>(0.975, 6)] = 2.45,
            [new Tuple<double, int>(0.95, 6)] = 1.94,
            [new Tuple<double, int>(0.9, 6)] = 1.44,

            [new Tuple<double, int>(0.99, 7)] = 3.00,
            [new Tuple<double, int>(0.98, 7)] = 2.52,
            [new Tuple<double, int>(0.975, 7)] = 2.36,
            [new Tuple<double, int>(0.95, 7)] = 1.89,
            [new Tuple<double, int>(0.9, 7)] = 1.41,

            [new Tuple<double, int>(0.99, 8)] = 2.90,
            [new Tuple<double, int>(0.98, 8)] = 2.45,
            [new Tuple<double, int>(0.975, 8)] = 2.31,
            [new Tuple<double, int>(0.95, 8)] = 1.86,
            [new Tuple<double, int>(0.9, 8)] = 1.40,
        };
        public static double GetT(double confidenceLevel, int degree) => normalDistributionTable[new Tuple<double, int>((confidenceLevel + 1) / 2, degree)];

        public static double GetX(double confidenceLevel, int degree) => normalDistributionTable[new Tuple<double, int>(confidenceLevel, degree)];
    }
}
