using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.StatTables
{
    public class ChiDistributionTable
    {
        private static Dictionary<Tuple<double, int>, double> chiDistributionTable = new Dictionary<Tuple<double, int>, double>
        {
            [new Tuple<double, int>(0.01, 5)] = 0.55,
            [new Tuple<double, int>(0.05, 5)] = 1.15,
            [new Tuple<double, int>(0.10, 5)] = 1.61,
            [new Tuple<double, int>(0.90, 5)] = 9.24,
            [new Tuple<double, int>(0.95, 5)] = 11.07,
            [new Tuple<double, int>(0.99, 5)] = 15.09,

            [new Tuple<double, int>(0.01, 6)] = 0.87,
            [new Tuple<double, int>(0.05, 6)] = 1.64,
            [new Tuple<double, int>(0.10, 6)] = 2.20,
            [new Tuple<double, int>(0.90, 6)] = 10.64,
            [new Tuple<double, int>(0.95, 6)] = 12.59,
            [new Tuple<double, int>(0.99, 6)] = 16.81,

            [new Tuple<double, int>(0.01, 7)] = 1.24,
            [new Tuple<double, int>(0.05, 7)] = 2.17,
            [new Tuple<double, int>(0.10, 7)] = 2.83,
            [new Tuple<double, int>(0.90, 7)] = 12.02,
            [new Tuple<double, int>(0.95, 7)] = 14.07,
            [new Tuple<double, int>(0.99, 7)] = 18.48,

            [new Tuple<double, int>(0.01, 8)] = 1.65,
            [new Tuple<double, int>(0.05, 8)] = 2.73,
            [new Tuple<double, int>(0.10, 8)] = 3.49,
            [new Tuple<double, int>(0.90, 8)] = 13.36,
            [new Tuple<double, int>(0.95, 8)] = 15.51,
            [new Tuple<double, int>(0.99, 8)] = 20.09,

            [new Tuple<double, int>(0.01, 9)] = 2.09,
            [new Tuple<double, int>(0.05, 9)] = 3.33,
            [new Tuple<double, int>(0.10, 9)] = 4.17,
            [new Tuple<double, int>(0.90, 9)] = 14.68,
            [new Tuple<double, int>(0.95, 9)] = 16.92,
            [new Tuple<double, int>(0.99, 9)] = 21.67,

            [new Tuple<double, int>(0.01, 10)] = 2.56,
            [new Tuple<double, int>(0.05, 10)] = 3.94,
            [new Tuple<double, int>(0.10, 10)] = 4.87,
            [new Tuple<double, int>(0.90, 10)] = 15.99,
            [new Tuple<double, int>(0.95, 10)] = 18.31,
            [new Tuple<double, int>(0.99, 10)] = 23.21,

            [new Tuple<double, int>(0.01, 11)] = 3.05,
            [new Tuple<double, int>(0.05, 11)] = 4.57,
            [new Tuple<double, int>(0.10, 11)] = 5.58,
            [new Tuple<double, int>(0.90, 11)] = 17.28,
            [new Tuple<double, int>(0.95, 11)] = 19.68,
            [new Tuple<double, int>(0.99, 11)] = 24.73,

            [new Tuple<double, int>(0.01, 12)] = 3.57,
            [new Tuple<double, int>(0.05, 12)] = 5.23,
            [new Tuple<double, int>(0.10, 12)] = 6.30,
            [new Tuple<double, int>(0.90, 12)] = 18.55,
            [new Tuple<double, int>(0.95, 12)] = 21.03,
            [new Tuple<double, int>(0.99, 12)] = 26.22,

            [new Tuple<double, int>(0.01, 13)] = 4.11,
            [new Tuple<double, int>(0.05, 13)] = 5.89,
            [new Tuple<double, int>(0.10, 13)] = 7.04,
            [new Tuple<double, int>(0.90, 13)] = 19.81,
            [new Tuple<double, int>(0.95, 13)] = 22.36,
            [new Tuple<double, int>(0.99, 13)] = 27.69,

            [new Tuple<double, int>(0.01, 14)] = 4.66,
            [new Tuple<double, int>(0.05, 14)] = 6.57,
            [new Tuple<double, int>(0.10, 14)] = 7.79,
            [new Tuple<double, int>(0.90, 14)] = 21.06,
            [new Tuple<double, int>(0.95, 14)] = 23.68,
            [new Tuple<double, int>(0.99, 14)] = 29.14,

            [new Tuple<double, int>(0.01, 15)] = 5.23,
            [new Tuple<double, int>(0.05, 15)] = 7.26,
            [new Tuple<double, int>(0.10, 15)] = 8.55,
            [new Tuple<double, int>(0.90, 15)] = 22.31,
            [new Tuple<double, int>(0.95, 15)] = 25.00,
            [new Tuple<double, int>(0.99, 15)] = 30.58,
        };

        /// <summary>
        /// Получение x-значения статистической таблицы распределения xu-квадрата с v степенями свободы
        /// </summary>
        /// <param name="confidenceLevel">Уровень значимости в процентах</param>
        /// <param name="degree">Степень свободы</param>
        /// <returns>x-значение</returns>
        public static double GetX(double confidenceLevel, int degree) => chiDistributionTable[new Tuple<double, int>(confidenceLevel / 100, degree)];
    }
}
