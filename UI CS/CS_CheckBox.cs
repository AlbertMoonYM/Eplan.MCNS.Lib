using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CheckBox = System.Windows.Forms.CheckBox;

namespace Eplan.MCNS.Lib
{
    public class CS_CheckBox
    {
        public void ChangeToRadioButton(CheckEdit ckb1, CheckEdit ckb2)
        {
            ckb1.Checked = true;
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
        /*
        public void ChangeToComboBox(CheckBox ckb1, ComboBox cb)
        {
            ckb1.CheckedChanged += (o, e) =>
            {
                if (ckb1.Checked)
                {
                    // 다른 체크박스의 체크를 해제
                    cb.Text = ckb1.Text;
                }
                else { cb.Text = ""; }
            };
            
        }*/


    }
}
