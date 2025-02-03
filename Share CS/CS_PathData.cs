using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace Eplan.MCNS.Lib.Share_CS
{
    public class CS_PathData
    {
        // 폴더 경로
        public static string PrjFolderPath { get; set; }
        public static string BasicTempletFilePath { get; set; }
        //public static string BasicPageMacroFolderPath { get; set; }
        public static string MacroFolderPath { get; set; }
        
         
        // 파일 경로
        public static string ConfigFilePath { get; set; }
        public static string ItemListFilePath {  get; set; }
        public static string IoListFilePath { get; set; }
        

        // 엔지니어링 데이터 Xml 파일 저장 위치
        public static string XmlFolderPath { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string XmlFilePath { get; set; } = "";


    }
}
