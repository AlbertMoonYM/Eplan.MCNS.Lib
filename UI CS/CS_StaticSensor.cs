using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib.UI_CS
{
    public static class CS_StaticSensor
    {
        

        public static string listLiftSensor { get; set; }
        public static string listTrav1Sensor { get; set; }
        public static string listTrav2Sensor { get; set; }
        public static string listFork1Sensor { get; set; }
        public static string listFork2Sensor { get; set; }
        public static string listCarrSensor { get; set; }
        public static string listMcagSensor { get; set; } 

        public static DataTable sensorIoDt { get; set; }
        public static DataTable sensorCopyIoDt { get; set; }
        public static DataTable uniqueIoDt { get; set; }
        public static DataTable logicIoDt { get; set; }
        public static Dictionary<string, List<string>> funcSensorDict { get; set; }
        // 이벤트 정의
        
    }
}
