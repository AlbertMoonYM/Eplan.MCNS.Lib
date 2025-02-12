using DevExpress.XtraEditors;
using DevExpress.XtraEditors.TextEditController.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization; // 숫자 변환을 위해 필요

namespace Eplan.MCNS.Lib
{
    public class CS_ComboBox
    {

        public void SettingComboBox(ComboBoxEdit cb, string unit, bool displayUnit)
        {
            // 기본 스타일 설정
            cb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cb.Font = new Font("맑은 고딕", 10);

            cb.Properties.CustomDisplayText += (o, e) =>
            {
                string inputValue = e.Value?.ToString();

                if (!cb.Enabled)
                {
                    cb.BackColor = Color.LightCoral;
                    e.DisplayText = "";
                }
                else if (string.IsNullOrEmpty(inputValue))
                {
                    e.DisplayText = unit; // 값이 없으면 단위만 표시
                    cb.BackColor = Color.LightGray;
                    cb.ForeColor = Color.Gray;
                }
                else if (double.TryParse(inputValue, NumberStyles.Any, CultureInfo.InvariantCulture, out _) && displayUnit == true)
                {
                    e.DisplayText = inputValue + " " + unit; // UI에서 숫자 + 단위 형식으로 표시
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                }
                else
                {
                    e.DisplayText = inputValue; // 숫자가 아니면 그대로 출력
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                }
            };
            cb.KeyPress += (sender, e) =>
            {
                // 백스페이스와 딜리트는 허용, 나머지 키는 차단
                if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Tab)
                {
                    e.Handled = true; // 키 입력 무시
                }
            };
            cb.Enter += (sender, e) =>
            {
                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
            };
        }

        public void ChangeToTextBox(ComboBoxEdit cb, string unit, bool displayUnit,TypeFlag typeFlag)
        {
            // 콤보박스를 텍스트 박스처럼 보이게 설정
            cb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cb.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            cb.Font = new Font("맑은 고딕", 10);

            cb.Properties.CustomDisplayText += (o, e) =>
            {
                string inputValue = e.Value?.ToString();

                if (!cb.Enabled)
                {
                    cb.BackColor = Color.LightCoral;
                    e.DisplayText = "";
                }
                else if (string.IsNullOrEmpty(inputValue))
                {
                    e.DisplayText = unit; // 값이 없으면 단위만 표시
                    cb.BackColor = Color.LightGray;
                    cb.ForeColor = Color.Gray;
                }
                else if (decimal.TryParse(inputValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result) && displayUnit)
                {
                    // 소수점 이하 0을 제거한 값을 표시
                    string formattedValue = result.ToString("0.##"); // "0.##" 형식은 소수점 아래 불필요한 0을 제거
                    e.DisplayText = formattedValue + " " + unit; // UI에서 숫자 + 단위 형식으로 표시
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                }
                else
                {
                    e.DisplayText = inputValue; // 숫자가 아니면 그대로 출력
                    cb.BackColor = Color.White;
                    cb.ForeColor = Color.Black;
                }
            };

            cb.Enter += (sender, e) =>
            {
                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
            };

            cb.KeyPress += (sender, e) =>
            {
                if (typeFlag == TypeFlag.fltFlag)
                {
                    // 숫자와 점만 허용
                    if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true; // 다른 키 입력 차단
                    }

                    // 점이 여러 번 입력되지 않도록 제한
                    if (e.KeyChar == '.' && cb.Text.Contains("."))
                    {
                        e.Handled = true; // 점이 이미 있으면 차단
                    }
                }
                else if (typeFlag == TypeFlag.intFlag) 
                {
                    // 숫자와 점만 허용
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                    {
                        e.Handled = true; // 다른 키 입력 차단
                    }
                }
            };
            
        }


    }

    }
