using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Нормальное распределение a неизвестно, сигма^2=сигма^2
    /// </summary>
    class Hypothesis3: Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis3 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="s">Выборочная дисперсия</param>
        /// <param name="s0">Математическое ожидание</param>
        public Hypothesis3(double count, double s, double s0)
        {
            var u = Round(count * s / s0);
            SolutionText = "U(выч)= Кол-во элементов в совокупности  * Дисперсия / Мат. ожидание";
            AddText($"U(выч)= {count} * {s} / {s0}");
            AddText($"U(выч)= {u}");
        }
    }
}
