using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;

namespace Eplan.MCNS.Lib
{
    public static class CS_StaticUnit
    {
        public static Dictionary<string, Control[]> dicCtrlSrmAll { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, Control[]> dicCtrlMod { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, Control[]> dicCtrlFunc { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, GroupControl[]> dicGrpSrmFunc { get; set; } = new Dictionary<string, GroupControl[]> { };
        public static string strModFullName { get; set; }

        public static DataTable[] arrDtSrmFunc { get; set; } = new DataTable[] { };

        public static DataTable dtLout { get; set; } = new DataTable { };

        public static Control[][] arrCtrlGrpSrmFunc { get; set; } = new Control[][] { };

        public static CheckBox[] arrCkbSrmAll { get; set; } = new CheckBox[] { };
    }
}

