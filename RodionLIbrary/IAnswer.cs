using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary
{
    public interface IAnswer
    {
        private const int _defaultDecimals = 3;

        string SolutionText { get; }

        protected double Round(double value, int decimals = _defaultDecimals) => Math.Round(value, decimals);
    }
}
