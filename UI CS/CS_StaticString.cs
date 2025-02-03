using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    public static class CS_StaticString
    {
        //DataTable의 Colums 셋팅
        public static string[,] dArrDtColums = new string[,]
        {
            { "Num", "순번" },
            { "PageName", "페이지" },
            { "Function", "기능" },
            { "Group", "그룹"},
            { "Item", "항목"},
            { "Data", "입력값"},
            { "ObjetType", "객체형식" },
        };
        public static string[,] dArrStrFunc = new string[,]
        {
            { "ELEQ", "ELEQ(공통사양)"},
            { "LIFT", "LIFT(승강)"},
            { "TRAV", "TRAV(주행)"},
            { "TRAV2", "TRAV2(주행2)"},
            { "FORK", "FORK(포크)"},
            { "FORK2", "FORK2(포크2)"},
            { "CARR", "CARR(화물)"},
            { "MCAG", "MCAG(메인터넌스)"},
            { "OP", "OP(지상반)"},
        };
        public static string[,] dArrDtLoutColums = new string[,]
        {
            { "Items", "항목" },
            { "Width", "가로" },
            { "Depth", "세로" },
            { "Height", "높이"},
        };
        public static string[,] dArrTravSensorItems = new string[,]
        {
            { "TDF", "TRAVELING DECELERATION FORWARD"},
            { "TDR", "TRAVELING DECELERATION REVERSE"},
            { "THP", "TRAVELING HOME POSITION"},
            { "TSTH", "TRAVEL EMERGENCY STOP HOME"},
            { "TSTE", "TRAVEL EMERGENCY STOP END"},
        };
        public static string[,] dArrLiftSensorItems = new string[,]
        {
            { "RTF", "ROPE TENTION FRONT"},
            { "RTR", "ROPE TENTION REAR"},
            { "LDU", "LIFTING DECELRATION UP"},
            { "LDD", "LIFTING DECELRATION DOWN"},
            { "LHP", "LIFTING HOME POSITION"},
            { "LSTH", "HOIST EMERGENCY STOP HOME"},
            { "LSTE", "HOIST EMERGENCY STOP END"},
        };

    }
}
