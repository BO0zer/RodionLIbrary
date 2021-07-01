using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodionLIbrary.Confidence_Intervals
{
    public interface IConfidenceInterval
    {
        int ConfidenceLevel { get; set; }

        IAnswer GetLeftSided();

        IAnswer GetRightSided();

        IAnswer GetDoubleSided();
    }
}
