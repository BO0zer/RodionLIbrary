using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Statistics
{
    public abstract class Statistics
    {
        public static double Mean(IEnumerable<double> data) => data.Average();


    }
}
