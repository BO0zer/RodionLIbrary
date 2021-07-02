﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Нормальное распределение сигма^2 известно, a=a0
    /// </summary>
    class Hypothesis1 : IHypothesis
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis1 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="mean">Среднее значение совокупности</param>
        /// <param name="count">Количество элементов в совокупности</param>
        /// <param name="averageSd">Среднее квадратичное отклонение</param>
        public Hypothesis1(double mean, double count, double averageSd, double a)
        {
            this.mean = mean;
            this.count = count;
            this.averageSd = averageSd;
            this.a = a;
            var u = (mean - a) / (averageSd / Math.Sqrt(count));
            (this as IAnswer).Round(u);
            SolutionText += $"U(выч)= (ср. значение совокупности - a) / (ср. кв. откл. / кв. корень(кол-во элементов в совокупности))\n" +
                $"U(выч)= ({mean} - {a}) / ({averageSd} / кв. корень({count}))\n" +
                $"U(выч)= {u}";
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

        public string SolutionText { get; private set; }
    }
}
