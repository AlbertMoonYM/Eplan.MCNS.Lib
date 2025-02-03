using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using Eplan.MCNS.Lib.UI_CS;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib
{
    public class CS_InterLock
    {

        public void ActivatePageByText(Control[] baseCtrls, string[] triggerStrs, XtraTabControl xtraCtrl, int indexNum)
        {
            XtraTabPage xtraPage = xtraCtrl.TabPages[indexNum];

            // 초기 상태에서 탭 페이지를 숨김
            xtraPage.PageVisible = false;

            void ResetPageControls(Control parent)
            {
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl is ComboBoxEdit comboBox)
                    {
                        comboBox.SelectedIndex = -1; // 선택 초기화
                        comboBox.Text = string.Empty; // 텍스트 초기화
                        comboBox.Select();
                    }
                    else if (ctrl is CheckEdit checkBox)
                    {
                        checkBox.Checked = false; // 체크 초기화
                    }
                    // 재귀적으로 하위 컨트롤 탐색
                    if (ctrl.HasChildren)
                    {
                        ResetPageControls(ctrl);
                    }
                }
            }

            void UpdatePageVisibility()
            {
                // ComboBox 또는 CheckBox의 조건을 평가하여 페이지 표시 여부 결정
                bool shouldShowPage = baseCtrls.OfType<ComboBoxEdit>()
                        .Any(ctrl => triggerStrs.Any(trigger => ctrl.Text.Contains(trigger)))
                    || baseCtrls.OfType<CheckEdit>()
                        .Any(ctrl => ctrl.Checked);

                // 탭 페이지 표시 또는 숨김
                if (!shouldShowPage && xtraPage.PageVisible)
                {
                    ResetPageControls(xtraPage); // 페이지를 숨길 때 컨트롤 초기화
                }

                xtraPage.PageVisible = shouldShowPage;
            }

            foreach (Control baseCtrl in baseCtrls)
            {
                // ComboBox인 경우
                if (baseCtrl is ComboBoxEdit comboBox)
                {
                    comboBox.TextChanged += (o, e) => UpdatePageVisibility();
                }
                // CheckBox인 경우
                else if (baseCtrl is CheckEdit checkBox)
                {
                    checkBox.CheckedChanged += (o, e) => UpdatePageVisibility();
                }
            }

            // 초기 표시 상태 업데이트
            UpdatePageVisibility();
        }

        public void ActivateControlSwitch(CheckEdit ckb1, ComboBoxEdit[] targetCbs)
        {
            ckb1.CheckedChanged += (o, e) =>
            {
                if (ckb1.Checked) 
                {
                    foreach(ComboBoxEdit ctrl in targetCbs)
                    {
                        ctrl.Enabled = false;
                    }
                }
                else
                {
                    foreach (ComboBoxEdit ctrl in targetCbs)
                    {
                        ctrl.Enabled = true;
                    }
                }
            };

        }

        public void CheckSwitchByText(Control[] baseCtrl, string[] triggerStrs, CheckEdit ckbTrue)
        {
            foreach (var ctrl in baseCtrl)
            {
                // 각 Control에 대해 TextChanged 이벤트 핸들러 등록
                ctrl.TextChanged += (o, e) =>
                {
                    // 모든 Control의 상태를 검사할 플래그
                    bool anyMatch = false;

                    foreach (var control in baseCtrl)
                    {
                        string currentText = control.Text;

                        if (triggerStrs.Contains(currentText))
                        {
                            anyMatch = true;
                            break;
                        }
                    }

                    // 조건에 맞는 경우 CheckBox 상태 업데이트
                    if (anyMatch)
                    {
                        ckbTrue.Checked = true;
                    }
                    else
                    {
                        ckbTrue.Checked = false;
                    }
                };
            }
        }

        public void SplitTextByDelimiter(Control baseCtrl, string triggerStr, ComboBoxEdit[] targetCtrls, char delimiter)
        {
            // 초기화 함수 정의
            void InitializeControls()
            {
                if (baseCtrl.Text != triggerStr)
                {
                    string[] paneValues = baseCtrl.Text.Split(delimiter);
                    if (paneValues.Length == targetCtrls.Length)
                    {
                        for (int i = 0; i < targetCtrls.Length; i++)
                        {
                            targetCtrls[i].Text = paneValues[i].Trim();
                            targetCtrls[i].Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                            targetCtrls[i].Select();
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < targetCtrls.Length; i++)
                    {
                        targetCtrls[i].Text = ""; // 초기화
                        targetCtrls[i].Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                        targetCtrls[i].Select();
                    }

                }
            }

            // 초기값 설정
            InitializeControls();

            // TextChanged 이벤트 핸들러 추가
            baseCtrl.TextChanged += (o, e) =>
            {
                InitializeControls();
            };
        }

        public void UpdateFullText(Control baseCtrl, Control[] ctrls)
        {
            baseCtrl.Hide();
            baseCtrl.ForeColor = Color.Blue;
            baseCtrl.BackColor = Color.Gray;

            // 기존 핸들러 제거 (중복 호출 방지)
            foreach (Control ctrl in ctrls)
            {
                if(ctrl is ComboBoxEdit cb)
                {
                    cb.TextChanged -= OnControlTextChanged;
                }
                else if(ctrl is CheckEdit ckb)
                {
                    ckb.CheckedChanged -= OnControlTextChanged;
                }
            }

            // 새로운 핸들러 추가
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is ComboBoxEdit cb)
                {
                    cb.TextChanged += OnControlTextChanged;
                }
                else if (ctrl is CheckEdit ckb)
                {
                    ckb.CheckedChanged += OnControlTextChanged;
                }
            }

            void OnControlTextChanged(object sender, EventArgs e)
            {
                
                string fullText = "";

                // ctrls[0], ctrls[1], ctrls[2]의 BackColor가 모두 흰색이 아닌 경우 baseCtrl을 숨김
                if (ctrls[0].BackColor != Color.White ||
                    ctrls[1].BackColor != Color.White ||
                    ctrls[2].BackColor != Color.White )
                {
                    baseCtrl.Hide(); // baseCtrl을 숨김
                    return; // 이후 코드를 실행하지 않음
                }
                else
                {
                    baseCtrl.BackColor = Color.White;
                    baseCtrl.Show(); // 조건을 만족하면 baseCtrl을 표시
                }

                for (int i = 0; i < ctrls.Length; i++)
                {
                    // BackColor가 흰색이고, Visible이 true인 경우에만 Text를 추가
                    if (ctrls[i].ForeColor == Color.Black && ctrls[i].Visible)
                    {
                        if (i == 2)
                        {
                            fullText += "-" + ctrls[i].Text;
                        }
                        else if (i == 4)
                        {
                            fullText += "-" + ctrls[i].Text;
                        }
                        else
                        {
                            fullText += ctrls[i].Text;
                        }
                    }
                    // i가 3이고, ctrls[i]가 CheckBox인 경우
                    else if (i == 3)
                    {
                        if (ctrls[3] is CheckEdit cb && cb.Checked)
                        {
                            fullText += cb.Text;  // CheckBox가 체크된 경우 텍스트 추가
                        }
                    }
                }
                
                // 결과를 baseCtrl에 설정
                baseCtrl.Text = fullText;
                CS_StaticUnit.strModFullName = fullText;
            }
        }

        public void AlramToFunctionByText(Control baseCtrl, Control[] targetCtrls)
        {
            string SetLogText()
            {
                string logText = "";

                foreach (Control ctrl in targetCtrls)
                {
                    string labelText = ctrl.Parent?.Controls.OfType<LabelControl>().FirstOrDefault()?.Text ?? "Unknown";
                    labelText = labelText.Replace("\r", "").Replace("\n", "");
                    if(ctrl is ComboBoxEdit cb)
                    {
                        string valueText = cb.Text;
                        if (valueText != "" && cb.BackColor != Color.LightGray)
                        {
                            logText += string.Concat(labelText, ":", valueText, ">");
                        }
                    }
                    else if(ctrl is CheckEdit ckb)
                    {
                        string valueText = ckb.Text;
                        if (ckb.Checked)
                        {
                            logText += string.Concat(labelText, ":", valueText, ">");
                        }
                    }

                }
                return logText;
            }
            
            baseCtrl.Text = SetLogText();

            foreach (Control ctrl in targetCtrls)
            {
                if(ctrl is ComboBoxEdit cb)
                {
                    cb.TextChanged += (o, e) =>
                    {
                        baseCtrl.Text = SetLogText();
                    };
                }
                else if(ctrl is CheckEdit ckb)
                {
                    ckb.CheckedChanged += (o, e) =>
                    {
                        baseCtrl.Text = SetLogText();
                    };
                }
                
            }
        }


        public void BlockCtrlsByInverter(ComboBoxEdit cbInverterMaker, ComboBoxEdit cbInverterSpec,string txtInverterMaker, string txtInverterSpec, Control[] ctrls)
        {
            void BlockControls()
            {
                if(cbInverterMaker.Text == txtInverterMaker && cbInverterSpec.Text == txtInverterSpec)
                {
                    foreach (Control ctrl in ctrls) 
                    {
                        ctrl.Text = "";
                        ctrl.BackColor = Color.LightCoral;
                        ctrl.Enabled = false;
                    }
                }
                else 
                {
                    foreach (Control ctrl in ctrls)
                    {
                        ctrl.Text = "";
                        ctrl.BackColor = Color.LightGray;
                        ctrl.Enabled = true;
                    }
                }
            }

            BlockControls();
            cbInverterMaker.TextChanged += (o, e) => 
            {
                BlockControls();
            };
            cbInverterSpec.TextChanged += (o, e) =>
            {
                BlockControls();
            };
        }


        /*
        void UpdateTargetText(string triggerStr, bool add)
        {
            string stateStr = $"{labelText}:{triggerStr}>";

            foreach (var ctrl in targetCtrls)
            {
                if (add)
                {
                    // stateStr이 없으면 추가
                    if (!ctrl.Text.Contains(stateStr))
                        ctrl.Text += stateStr;
                }
                else
                {
                    // stateStr이 있으면 제거
                    ctrl.Text = ctrl.Text.Replace(stateStr, "");
                }
            }
        }

        // ComboBox 처리
        if (baseCtrl is ComboBoxEdit cb)
        {
            cb.TextChanged += (o, e) =>
            {
                foreach (string triggerStr in triggerStrs)
                {
                    UpdateTargetText(triggerStr, cb.Text == triggerStr);
                }
            };

            // 초기값 설정
            foreach (string triggerStr in triggerStrs)
            {
                UpdateTargetText(triggerStr, cb.Text == triggerStr);
            }
        }
        // CheckBox 처리
        else if (baseCtrl is CheckEdit ckb)
        {
            ckb.CheckedChanged += (o, e) =>
            {
                foreach (string triggerStr in triggerStrs)
                {
                    UpdateTargetText(triggerStr, ckb.Text == triggerStr && ckb.Checked);
                }
            };

            // 초기값 설정
            foreach (string triggerStr in triggerStrs)
            {
                UpdateTargetText(triggerStr, ckb.Text == triggerStr && ckb.Checked);
            }
        }
        */





    }

}
