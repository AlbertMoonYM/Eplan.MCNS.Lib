using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eplan.MCNS.Lib
{
    public class CS_XtraTabControl
    {
        /// <summary>
        /// 기능명 상세 보여주기
        /// </summary>
        /// <param name="xtraTabControl"></param>
        public void AddPanelToTabPage(XtraTabControl xtc, string[,] arrStrNameSet)
        {
            // 모든 탭 페이지의 텍스트를 배열의 첫 번째 열과 비교하여 일치하는 탭 페이지만 확인
            foreach (XtraTabPage tabPage in xtc.TabPages)
            {
                // 현재 탭 페이지의 텍스트와 배열의 첫 번째 열을 비교
                bool matchFound = false;
                for (int i = 0; i < arrStrNameSet.GetLength(0); i++)
                {
                    if (tabPage.Text == arrStrNameSet[i, 0])
                    {
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    // 패널과 레이블을 생성하여 탭 페이지에 추가
                    Panel pnlBar = new Panel();
                    Label lblBar = new Label();

                    pnlBar.Size = new Size(5, tabPage.Height); // 패널 크기 조정
                    pnlBar.BackColor = Color.Silver;
                    pnlBar.Cursor = Cursors.Hand;
                    pnlBar.Dock = DockStyle.Left;

                    lblBar.Text = "▶";
                    lblBar.ForeColor = Color.Gray;
                    lblBar.Cursor = Cursors.Hand;
                    lblBar.Dock = DockStyle.Fill;
                    lblBar.TextAlign = ContentAlignment.MiddleCenter;

                    pnlBar.Controls.Add(lblBar);
                    tabPage.Controls.Add(pnlBar);

                    // 클릭 이벤트 핸들러 등록
                    pnlBar.Click += (o, e) => ToggleTabPageTexts(lblBar);
                    lblBar.Click += (o, e) => ToggleTabPageTexts(lblBar);
                }
            }

            // 토글 함수 생성
            void ToggleTabPageTexts(Label lbl)
            {
                if (lbl.Text == "▶")
                {
                    lbl.Text = "◀";
                    foreach (XtraTabPage tabPage in xtc.TabPages)
                    {
                        for (int i = 0; i < arrStrNameSet.GetLength(0); i++)
                        {
                            if (tabPage.Text == arrStrNameSet[i, 0])
                            {
                                tabPage.Text = arrStrNameSet[i, 1]; // 텍스트를 변경
                                break;
                            }
                        }
                    }
                }
                else
                {
                    lbl.Text = "▶";
                    foreach (XtraTabPage tabPage in xtc.TabPages)
                    {
                        for (int i = 0; i < arrStrNameSet.GetLength(0); i++)
                        {
                            if (tabPage.Text == arrStrNameSet[i, 1])
                            {
                                tabPage.Text = arrStrNameSet[i, 0]; // 원래 텍스트로 복원
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
