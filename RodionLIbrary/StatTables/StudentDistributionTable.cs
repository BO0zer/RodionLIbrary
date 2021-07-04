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

            [new Tuple<double, int>(0.99, 9)] = 2.82,
            [new Tuple<double, int>(0.98, 9)] = 2.40,
            [new Tuple<double, int>(0.975, 9)] = 2.26,
            [new Tuple<double, int>(0.95, 9)] = 1.83,
            [new Tuple<double, int>(0.9, 9)] = 1.38,

            [new Tuple<double, int>(0.99, 10)] = 2.76,
            [new Tuple<double, int>(0.98, 10)] = 2.36,
            [new Tuple<double, int>(0.975, 10)] = 2.23,
            [new Tuple<double, int>(0.95, 10)] = 1.81,
            [new Tuple<double, int>(0.9, 10)] = 1.37,

            [new Tuple<double, int>(0.99, 11)] = 2.72,
            [new Tuple<double, int>(0.98, 11)] = 2.33,
            [new Tuple<double, int>(0.975, 11)] = 2.20,
            [new Tuple<double, int>(0.95, 11)] = 1.80,
            [new Tuple<double, int>(0.9, 11)] = 1.36,

            [new Tuple<double, int>(0.99, 12)] = 2.68,
            [new Tuple<double, int>(0.98, 12)] = 2.30,
            [new Tuple<double, int>(0.975, 12)] = 2.18,
            [new Tuple<double, int>(0.95, 12)] = 1.78,
            [new Tuple<double, int>(0.9, 12)] = 1.36,

            [new Tuple<double, int>(0.99, 13)] = 2.65,
            [new Tuple<double, int>(0.98, 13)] = 2.28,
            [new Tuple<double, int>(0.975, 13)] = 2.16,
            [new Tuple<double, int>(0.95, 13)] = 1.77,
            [new Tuple<double, int>(0.9, 13)] = 1.35,

            [new Tuple<double, int>(0.99, 14)] = 2.62,
            [new Tuple<double, int>(0.98, 14)] = 2.26,
            [new Tuple<double, int>(0.975, 14)] = 2.14,
            [new Tuple<double, int>(0.95, 14)] = 1.76,
            [new Tuple<double, int>(0.9, 14)] = 1.35,

            [new Tuple<double, int>(0.99, 15)] = 2.60,
            [new Tuple<double, int>(0.98, 15)] = 2.25,
            [new Tuple<double, int>(0.975, 15)] = 2.13,
            [new Tuple<double, int>(0.95, 15)] = 1.75,
            [new Tuple<double, int>(0.9, 15)] = 1.34,

            [new Tuple<double, int>(0.99, 16)] = 2.58,
            [new Tuple<double, int>(0.98, 16)] = 2.24,
            [new Tuple<double, int>(0.975, 16)] = 2.12,
            [new Tuple<double, int>(0.95, 16)] = 1.75,
            [new Tuple<double, int>(0.9, 16)] = 1.34,

            [new Tuple<double, int>(0.99, 17)] = 2.57,
            [new Tuple<double, int>(0.98, 17)] = 2.22,
            [new Tuple<double, int>(0.975, 17)] = 2.11,
            [new Tuple<double, int>(0.95, 17)] = 1.74,
            [new Tuple<double, int>(0.9, 17)] = 1.33,

            [new Tuple<double, int>(0.99, 18)] = 2.55,
            [new Tuple<double, int>(0.98, 18)] = 2.21,
            [new Tuple<double, int>(0.975, 18)] = 2.10,
            [new Tuple<double, int>(0.95, 18)] = 1.73,
            [new Tuple<double, int>(0.9, 18)] = 1.33,

            [new Tuple<double, int>(0.99, 19)] = 2.54,
            [new Tuple<double, int>(0.98, 19)] = 2.20,
            [new Tuple<double, int>(0.975, 19)] = 2.09,
            [new Tuple<double, int>(0.95, 19)] = 1.73,
            [new Tuple<double, int>(0.9, 19)] = 1.33,

            [new Tuple<double, int>(0.99, 20)] = 2.53,
            [new Tuple<double, int>(0.98, 20)] = 2.20,
            [new Tuple<double, int>(0.975, 20)] = 2.09,
            [new Tuple<double, int>(0.95, 20)] = 1.72,
            [new Tuple<double, int>(0.9, 20)] = 1.33,
        };
        public static double GetT(double confidenceLevel, int degree) => normalDistributionTable[new Tuple<double, int>((confidenceLevel + 1) / 2, degree)];

        public static double GetX(double confidenceLevel, int degree) => normalDistributionTable[new Tuple<double, int>(confidenceLevel, degree)];
    }
}
