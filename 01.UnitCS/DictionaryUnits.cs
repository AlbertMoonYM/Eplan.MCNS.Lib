using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib
{
    public static class DictionaryUnits
    {
        public static Dictionary<string, Control[]> dicCtrlSrmAll { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, Control[]> dicCtrlMod { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, Control[]> dicCtrlFunc { get; set; } = new Dictionary<string, Control[]> { };
        public static Dictionary<string, GroupControl[]> dicGrpSrmFunc { get; set; } = new Dictionary<string, GroupControl[]> { };
        public static Dictionary<string, List<string>> dicfuncSensor { get; set; }

    }
}
