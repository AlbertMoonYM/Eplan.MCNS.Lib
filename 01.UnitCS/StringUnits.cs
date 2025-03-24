using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    public static class StringUnits
    {
        // 폴더 경로
        public static string strPrjFolderPath { get; set; }
        public static string strBasicTempletFilePath { get; set; }
        public static string strMacroFolderPath { get; set; }


        // 파일 경로
        public static string strConfigFilePath { get; set; }
        public static string strItemListFilePath { get; set; }
        public static string strIoListFilePath { get; set; }
        public static string strMccbFilePath { get; set; }


        // 엔지니어링 데이터 Xml 파일 저장 위치
        public static string strXmlFolderPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string strXmlFilePath { get; set; } = "";


        public static string strLiftSensor { get; set; }
        public static string strTrav1Sensor { get; set; }
        public static string strTrav2Sensor { get; set; }
        public static string strFork1Sensor { get; set; }
        public static string strFork2Sensor { get; set; }
        public static string strCarrSensor { get; set; }
        public static string strMcagSensor { get; set; }
        public static string strModFullName { get; set; }

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

    }
}
