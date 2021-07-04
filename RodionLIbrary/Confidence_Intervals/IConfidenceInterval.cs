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

        LeftSidedAnswer GetLeftSided();

        RightSidedAnswer GetRightSided();

        DoubleSidedAnswer GetDoubleSided();
    }
}
