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

namespace Eplan.MCNS.Lib
{
    public class CS_ComboBox
    {

        public void SettingComboBox(ComboBoxEdit cb, string defaultTxt)
        {
            // 기본 스타일 설정
            cb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cb.Font = new Font("맑은 고딕", 10);
            cb.ForeColor = Color.Gray;
            cb.BackColor = Color.LightGray;
            cb.Text = defaultTxt;

            // 공통 스타일 업데이트 메서드
            void UpdateStyle()
            {
                if (string.IsNullOrEmpty(cb.Text) || cb.Text == defaultTxt)
                {
                    cb.ForeColor = Color.Gray;
                    cb.Text = defaultTxt;
                    cb.BackColor = Color.LightGray;
                }
                else
                {
                    cb.ForeColor = Color.Black;
                    cb.BackColor = Color.White;
                }
            }

            // KeyPress 이벤트를 사용해 타이핑 제한
            cb.KeyPress += (sender, e) =>
            {
                // 백스페이스와 딜리트는 허용, 나머지 키는 차단
                if (!char.IsControl(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Tab)
                {
                    e.Handled = true; // 키 입력 무시
                }
            };

            // Enter 이벤트
            cb.Enter += (sender, e) =>
            {
                if (cb.Text == defaultTxt)
                    cb.Text = "";

                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
            };

            // Leave 이벤트
            cb.Leave += (sender, e) => UpdateStyle();

            // TextChanged 이벤트
            cb.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(cb.Text))
                {
                    cb.ForeColor = Color.Gray;
                }
            };

            // VisibleChanged 이벤트
            cb.VisibleChanged += (sender, e) => UpdateStyle();
        }

        public void ChangeToTextBox(ComboBoxEdit cb, TypeFlag typeFlag, int maxLength, string defaultTxt, string unit)
        {
            // 콤보박스를 텍스트 박스처럼 보이게 설정
            cb.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            cb.Font = new Font("맑은 고딕", 10);
            cb.ForeColor = Color.Gray;
            cb.BackColor = Color.LightGray;
            cb.Text = defaultTxt;

            // 드롭다운 비활성화
            cb.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;

            // Ctrl + A 전체 텍스트 선택
            cb.KeyDown += (sender, e) =>
            {
                if (e.Control && e.KeyCode == Keys.A)
                {
                    cb.SelectAll();
                    e.SuppressKeyPress = true;
                }
            };

            // 텍스트 박스 활성화
            cb.Enter += (sender, e) =>
            {
                if (cb.Text == defaultTxt)
                {
                    cb.Text = "";
                }
                cb.BackColor = Color.White;
                cb.ForeColor = Color.Black;
            };

            // 텍스트 박스 비활성화
            cb.Leave += (sender, e) =>
            {
                cb.BackColor = Color.LightGray;

                if (string.IsNullOrEmpty(cb.Text) || cb.Text == defaultTxt||cb.Text=="0" || cb.Text == "0.000")
                {
                    cb.ForeColor = Color.Gray;
                    cb.Text = defaultTxt;
                }
                else
                {
                    cb.ForeColor = Color.Black;
                    cb.BackColor = Color.White;
                }
            };

            // 텍스트 박스 자료형
            if (typeFlag == TypeFlag.intFlag || typeFlag == TypeFlag.fltFlag)
            {
                cb.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
                cb.Properties.Mask.EditMask = typeFlag == TypeFlag.intFlag ? "d" : "f3";

                // 소수점 제한 추가
                cb.Properties.Mask.UseMaskAsDisplayFormat = true;
                cb.Properties.CustomDisplayText += (sender, e) =>
                {
                    if (decimal.TryParse(e.Value?.ToString(), out decimal value))
                    {
                        if (value == Math.Floor(value)) // 소수점 이하가 0인 경우
                        {
                            e.DisplayText = string.Concat((int)value, " ", unit); // 정수로 표시 + 단위
                        }
                        else
                        {
                            e.DisplayText = string.Concat(value.ToString("F3"), " ", unit); // 소수점 3자리 + 단위
                        }
                    }
                    else
                    {
                        e.DisplayText = "0 " + unit; // 잘못된 값일 경우 기본값 설정
                    }
                };
            }

            // 텍스트 박스 글자 제한
            cb.Properties.MaxLength = maxLength;
        }


    }

}
