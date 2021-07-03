using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Нормальное распределение сигма^2 известно, a=a0
    /// </summary>
    class HypothesisSKnown : Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis1 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="sd">Стандартное отклонение</param>
        /// <param name="a">Математическое ожидание</param>
        public HypothesisSKnown(double mean, double count, double sd, double a)
        {
            var u = Round((mean - a) / (sd / Math.Sqrt(count)));
            SolutionText = "U(выч)= (X(ср) - a) / (sd / кв. корень(n))";
            AddText($"U(выч)= ({mean} - {a}) / ({sd} / кв. корень({count}))");
            AddText($"U(выч)= {u}");
        }
    }
}
