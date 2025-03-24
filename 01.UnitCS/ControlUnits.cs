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

namespace Eplan.MCNS.Lib
{
    public static class ControlUnits
    {

        public static GridControl[] arrGcFunc { get; set; } = new GridControl[] { };
        public static GridView[] arrGvFunc { get; set; } = new GridView[] { };
        public static BindingSource[] bindingSource { get; set; } = new BindingSource[] { };
        public static GroupControl[] arrGrpAll { get; set; } = new GroupControl[] { };
        public static Control[][] arrCtrlGrpSrmFunc { get; set; } = new Control[][] { };

    }
}

