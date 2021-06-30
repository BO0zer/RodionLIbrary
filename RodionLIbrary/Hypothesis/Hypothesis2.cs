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
    class Hypothesis2 : IHypothesis
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis1 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="averageSd">Среднее квадратичное отклонение</param>
        /// <param name="a">Хз как назвать это</param>
        public Hypothesis2(double mean, double count, double averageSd, double a)
        {
            this.mean = mean;
            this.count = count;
            this.averageSd = averageSd;
            this.a = a;
        }

        /// <summary>
        /// Среднее значение 
        /// </summary>
        public double mean;

        /// <summary>
        /// Количество элментов в совокупности
        /// </summary>
        public double count;

        /// <summary>
        /// Среднее квадратичное отклонение
        /// </summary>
        public double averageSd;

        public double a;
        public double GetAnswer()
        {
            return (mean - a) / (averageSd / Math.Sqrt(count - 1));
        }

        public string[] GetSolution()
        {
            string[] solution = new string[2];
            solution[0] = $"U(выч)= (ср. значение совокупности - a) / (ср. кв. откл. / кв. корень(кол-во элементов в совокупности - 1))";
            solution[1] = $"U(выч)= ({mean} - {a}) / ({averageSd} / кв. корень({count} - 1))";
            return solution;
        }
    }
}
