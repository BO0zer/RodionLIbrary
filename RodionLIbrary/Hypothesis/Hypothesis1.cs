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
    class Hypothesis1 : Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis1 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="averageSd">Среднее квадратичное отклонение</param>
        /// <param name="a">Математическое ожидание</param>
        public Hypothesis1(double mean, double count, double averageSd, double a)
        {
            var u = Round((mean - a) / (averageSd / Math.Sqrt(count)));
            SolutionText = "U(выч)= (ср. значение совокупности - a) / (ср. кв. откл. / кв. корень(кол-во элементов в совокупности))";
            AddText($"U(выч)= ({mean} - {a}) / ({averageSd} / кв. корень({count}))");
            AddText($"U(выч)= {u}");
        }
    }
}
