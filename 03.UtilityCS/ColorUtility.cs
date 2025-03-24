using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.CodeParser.Diagnostics;

namespace Eplan.MCNS.Lib
{
    public static class ColorUtility
    {
        public static Dictionary<Ecolor, Color> colors = new Dictionary<Ecolor, Color>
        {
            { Ecolor.Disable, Color.LightCoral },
            { Ecolor.Active, Color.White },
            { Ecolor.InActTextBox, Color.LightGray },
            { Ecolor.InActComboBox, Color.LightSteelBlue },
            { Ecolor.Logo, ColorTranslator.FromHtml("#0A3820") },
            { Ecolor.TextBlack, Color.Black },
            { Ecolor.TextGray, Color.Gray },
            { Ecolor.HmxGreen, ColorTranslator.FromHtml("#00A451") },
            { Ecolor.HmxYellow, ColorTranslator.FromHtml("#FDBA0E") },
            { Ecolor.HmxBlue, ColorTranslator.FromHtml("#00529B") },
        };
    }
}
