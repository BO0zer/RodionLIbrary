using System;
using System.Collections.Generic;
namespace RodionLIbrary.Hypothesis
{
    interface IHypothesis
    {

        /// <summary>
        /// Вычисленное значение статистики критерия для проверки гипотезы
        /// </summary>
        /// <returns>U(вычисленное)</returns>
        public double GetAnswer { get; set; }

        /// <summary>
        /// Ход решения
        /// </summary>
        public string GetSolution { get; set; }
    }
}
