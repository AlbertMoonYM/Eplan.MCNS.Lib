using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib
{
    public class CheckboxManager
    {
        public void ChangeToRadioButton(CheckEdit ckb1, CheckEdit ckb2)
        {
            ckb1.CheckedChanged += (o, e) =>
            {
                if (ckb1.Checked)
                {
                    ckb2.Checked = false;
                }
                
            };

            ckb2.CheckedChanged += (o, e) =>
            {
                if (ckb2.Checked)
                {
                    ckb1.Checked = false;
                }

            };
        }
    }
}
