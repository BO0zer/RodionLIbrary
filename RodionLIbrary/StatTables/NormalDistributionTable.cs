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
            [0.99] = 2.33,
            [0.98] = 2.05,
            [0.975] = 1.96,
            [0.95] = 1.64,
            [0.90] = 1.28
        };

        /// <summary>
        /// Получение t-значения статистической таблицы нормального распределения
        /// </summary>
        /// <param name="confidenceLevel">Уровень значимости в процентах</param>
        /// <returns>t-значение</returns>
        public static double GetT(double confidenceLevel) => normalDistributionTable[(1 + confidenceLevel / 100) / 2];

        /// <summary>
        /// Получение x-значения статистической таблицы нормального распределения
        /// </summary>
        /// <param name="confidenceLevel">Уровень значимости в процентах</param>
        /// <returns>x-значение</returns>
        public static double GetX(double confidenceLevel) => normalDistributionTable[confidenceLevel / 100];
    }
}
