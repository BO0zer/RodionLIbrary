using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Нормальное распределение сигма^2 неизвестно, a=a0
    /// </summary>
    class HypothesisSUnknown : Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis2 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="s">Стандартное отклонение</param>
        /// <param name="a">Математическое ожидание</param>
        public HypothesisSUnknown(double mean, double count, double s, double a)
        {
            var u = Round((mean - a) / (s / Math.Sqrt(count)));
            SolutionText = "U(выч)= (X(ср) - a) / (S / кв. корень(n - 1))";
            AddText($"U(выч)= ({mean} - {a}) / ({s} / кв. корень({count - 1}))");
            AddText($"U(выч)= {u}");
        }
    }
}
