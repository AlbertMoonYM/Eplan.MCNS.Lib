using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eplan.MCNS.Lib
{
    public static class DataTableUnits
    {
        public static DataTable dtSensorIo { get; set; }
        public static DataTable dtEplanSensorIo { get; set; }
        public static DataTable dtSensorCopyIo { get; set; }
        public static DataTable dtUniqueIo { get; set; }
        public static DataTable dtLogicIo { get; set; }
        public static DataTable[] arrDtSrmFunc { get; set; } = new DataTable[] { };
        public static DataTable dtLout { get; set; } = new DataTable { };
        public static DataTable dtExcelIo { get; set; } = new DataTable { };
        public static DataTable dtExcelMccb { get; set; } = new DataTable { };
        public static DataTable dtExcelCable { get; set; } = new DataTable { };
        public static DataTable dtProducts {  get; set; } = new DataTable { };
        public static DataTable dtBrakeOption { get; set; } = new DataTable { };
        

    }
}
