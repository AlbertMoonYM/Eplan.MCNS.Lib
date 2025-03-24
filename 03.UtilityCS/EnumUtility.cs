using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    [Flags]
    public enum TypeFlag
    {
        intFlag = 0,
        fltFlag = 1,
        strFlag = 2,
    }
    public enum Ecolor
    {
        Disable,
        Active,
        InActTextBox,
        InActComboBox,
        Logo,
        TextBlack,
        TextGray,
        HmxGreen,
        HmxYellow,
        HmxBlue,
    }
}
