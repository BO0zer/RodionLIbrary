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
    class Hypothesis2 : Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis2 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="sd">Среднее квадратичное отклонение</param>
        /// <param name="a">Математическое ожидание</param>
        public Hypothesis2(double mean, double count, double sd, double a)
        {
            var u = Round((mean - a) / (sd / Math.Sqrt(count)));
            SolutionText = "U(выч)= (ср. значение совокупности - a) / (ср. кв. откл. / кв. корень(кол-во элементов в совокупности - 1))";
            AddText($"U(выч)= ({mean} - {a}) / ({sd} / кв. корень({count - 1}))");
            AddText($"U(выч)= {u}");
        }
    }
}
