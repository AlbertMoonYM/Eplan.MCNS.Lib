using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    public static class CS_StaticEtc
    {
        //마우스 제어 변수
        public static bool On;
        public static Point Pos;

        
        public static Color[] colors = new Color[]
        {
            ColorTranslator.FromHtml("#000000"),    //검정색 0
            ColorTranslator.FromHtml("#00A451"),    //초록색 1
            ColorTranslator.FromHtml("#FDBA0E"),    //노란색 2
            ColorTranslator.FromHtml("#00529B"),    //파란색 3
            ColorTranslator.FromHtml("#0A3820"),    //로고 색상 4
        };
    }
}
