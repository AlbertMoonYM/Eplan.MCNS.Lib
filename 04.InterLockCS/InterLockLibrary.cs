using DevExpress.XtraEditors;
using DevExpress.XtraTab;
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
    public class InterLockLibrary
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
                List<string> textParts = new List<string>(); // 개별 텍스트를 저장할 리스트

                // ctrls[0], ctrls[1], ctrls[2]의 BackColor가 모두 흰색이 아닌 경우 baseCtrl을 숨김
                if (ctrls[0].BackColor != ColorUtility.colors[Ecolor.Active] ||
                    ctrls[1].BackColor != ColorUtility.colors[Ecolor.Active] ||
                    ctrls[2].BackColor != ColorUtility.colors[Ecolor.Active])
                {
                    baseCtrl.Hide();
                    return;
                }
                else
                {
                    baseCtrl.BackColor = ColorUtility.colors[Ecolor.Active];
                    baseCtrl.Show();
                }

                for (int i = 0; i < ctrls.Length; i++)
                {
                    // BackColor가 흰색이고, Visible이 true인 경우에만 Text를 추가
                    if (ctrls[i].ForeColor == Color.Black && ctrls[i].Visible)
                    {
                        string text = ctrls[i].Text;

                        if (!string.IsNullOrEmpty(text))
                        {
                            // i가 2 또는 4일 때 앞에 "-"를 추가 (리스트에 저장할 때)
                            if (i == 2 || i == 4)
                            {
                                textParts.Add("-" + text);
                            }
                            else
                            {
                                textParts.Add(text);
                            }
                        }
                    }
                    // i가 3이고, ctrls[i]가 CheckBox인 경우
                    else if (i == 3 && ctrls[i] is CheckEdit cb && cb.Checked)
                    {
                        textParts.Add(cb.Text);
                    }
                }

                // 리스트의 첫 번째 요소가 "-"로 시작하는 경우 제거 (불필요한 "-" 방지)
                fullText = string.Join("", textParts).TrimStart('-');

                // 결과를 baseCtrl에 설정
                baseCtrl.Text = fullText;
                StringUnits.strModFullName = fullText;
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

        public void FilterComboBox(ComboBoxEdit currentCb, ComboBoxEdit nextCb, List<string> items, params ComboBoxEdit[] previousCbs)
        {
            // White 배경일 때만 필터링을 적용하고 다음 ComboBox를 보여줍니다.
            if (currentCb.BackColor == ColorUtility.colors[Ecolor.Active])
            {
                // 모든 이전 ComboBox와 현재 ComboBox에서 선택된 최대 인덱스를 가져옵니다.
                int maxIndex = previousCbs
                    .Append(currentCb)
                    .Select(cb => items.IndexOf(cb.Text))
                    .Where(index => index >= 0)
                    .DefaultIfEmpty(-1)
                    .Max();

                // 필터링된 리스트 설정
                nextCb.Show();
                nextCb.Properties.Items.Clear();
                nextCb.Properties.Items.AddRange(items
                    .Where((_, i) => i > maxIndex)
                    .ToArray());
            }
        }

        public void UpdateComboBoxVisibility(ComboBoxEdit[] cbMODoptions)
        {
            for (int i = 0; i < cbMODoptions.Length - 1; i++)
            {
                // EditValue가 빈 문자열("")인 경우
                if (string.IsNullOrEmpty(cbMODoptions[i].EditValue?.ToString()))
                {
                    // i 이후의 콤보박스를 모두 숨기고 선택된 인덱스를 초기화
                    for (int j = i + 1; j < cbMODoptions.Length; j++)
                    {
                        cbMODoptions[j].Hide();
                        cbMODoptions[j].SelectedIndex = -1;
                    }
                    break; // 이후 콤보박스를 더 이상 확인하지 않도록 루프 종료
                }
                else
                {
                    // EditValue가 빈 문자열이 아니면 그 다음 콤보박스를 보이게 설정
                    if (i + 1 < cbMODoptions.Length)
                    {
                        cbMODoptions[i + 1].Show();
                    }
                }
            }
        }

        public void SetFlagValue(Control[] controls, Action<bool> setFlag, string strMatch = "")
        {
            void UpdateFlag()
            {
                bool isCheckBoxChecked = controls
                    .OfType<CheckEdit>()
                    .Any(ckb => ckb.Checked);

                bool anyComboBoxMatch = controls
                    .OfType<ComboBoxEdit>()
                    .Any(cb => (cb.EditValue?.ToString() ?? "") == strMatch);

                // 체크박스가 체크되었거나, 콤보박스 중 하나라도 일치하는 항목이 있을 때 true
                setFlag(isCheckBoxChecked || anyComboBoxMatch);
            }

            foreach (var ctrl in controls)
            {
                if (ctrl is CheckEdit ckb)
                {
                    ckb.CheckStateChanged += (o, e) => UpdateFlag();
                }
                else if (ctrl is ComboBoxEdit cb)
                {
                    cb.TextChanged += (o, e) => UpdateFlag();
                }
            }

            // 초기 상태 업데이트
            UpdateFlag();
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
