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
        public double GetAnswer();

        /// <summary>
        /// Получить ход решения
        /// </summary>
        /// <returns>Ход решения, записанный построчно</returns>
        public string[] GetSolution();
    }
}
