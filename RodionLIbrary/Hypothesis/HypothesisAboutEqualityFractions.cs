using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Hypothesis
{
    /// <summary>
    /// Гипотеза о равенстве вероятностей (долей) двух биномиальных совокупностей
    /// </summary>
    class HypothesisAboutEqualityFractions :Answer
    {
        /// <summary>
        /// Конструктор для создания экземпляра класса HypothesisAboutEqualityFractions (каждый экземпляр представляет собой задачу, связанную с данной гипотезой)
        /// </summary>
        /// <param name="m1">Число  элементов,  обладающих свойством  А в 1 выборке</param>
        /// <param name="m2">Число  элементов,  обладающих свойством  А в 2 выборке</param>
        /// <param name="n1">Объем 1 выборки</param>
        /// <param name="n2">Объем 2 выборки</param>
        public HypothesisAboutEqualityFractions(double m1, double n1, double m2, double n2)
        {
            var u = Round((m1 / n1 - m2 / n2) / Math.Sqrt((m1 + m2) / (n1 + n2) * (1 - (m1 + m2) / (n1 + n2)) * (1 / n1 + 1 / n2)));
            SolutionText = "U(выч) = (m1 / n1 - m2 / n2) / кв.корень((m1 + m2) / (n1 + n2) * (1 - (m1 + m2) / (n1 + n2)) * (1 / n1 + 1 / n2))";
            AddText($"U(выч) = ({m1} / {n1} - {m2} / {n2}) / кв.корень(({m1} + {m2}) / ({n1} + {n2}) * (1 - ({m1} + {m2}) / ({n1} + {n2})) * (1 / {n1} + 1 / {n2}))");
            AddText($"U(выч) = {u}");
        }
    }
}
