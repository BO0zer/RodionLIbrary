using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Гипотеза для вероятности (w = m / n)
    /// </summary>
    class HypothesisAboutP:Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса Hypothesis4 (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="count">Количество объектов</param>
        /// <param name="m">Количество объектов, способствующие успеху прямопропорционально </param>
        /// <param name="p">Предложенная вероятность успеха</param>
        /// <param name="q">Предложенная вероятность неудачи (1-p)</param>
        public HypothesisAboutP(double count, double m, double p, double q)
        {
            var w = m / count;
            var u = Round((w - p) / Math.Sqrt(p * q / count));
            SolutionText = "w =  m / count";
            AddText($"w = {m} / {count}");
            AddText("U(выч) = (w - p) / кв. корень(p * q / count)");
            AddText($"U(выч) = ({w} - {p}) / кв. корень({p} * {q} / {count})");
            AddText($"U(выч) = {u}");
        }
    }
}
