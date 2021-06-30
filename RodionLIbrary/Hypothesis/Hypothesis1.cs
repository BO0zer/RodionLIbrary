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
    class Hypothesis1 : IHypothesis
    {
        /// <summary>
        /// Среднее значение 
        /// </summary>
        public double mean;
        public double GetAnswer { get; set; }
        public string GetSolution { get; set; }
    }
}
