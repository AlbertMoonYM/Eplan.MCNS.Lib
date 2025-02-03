using DevExpress.DocumentView;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout.Customization;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboBox = System.Windows.Forms.ComboBox;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;
using Label = System.Windows.Forms.Label;

namespace Eplan.MCNS.Lib
{
    public class CS_DataTable
    {
        
        public void GetDataTable(DataTable dt, string[,] dArrStrColumsSet )
        {
            dt.Columns.Clear();
            dt.Rows.Clear();

            for(int i = 0;  i < dArrStrColumsSet.GetLength(0); i++) 
            {
                string columnName = dArrStrColumsSet[i, 0];
                string columnCaption = dArrStrColumsSet[i, 1];

                dt.Columns.Add(columnName);
                dt.Columns[columnName].Caption = columnCaption;
            }
        }
        
    }
}
